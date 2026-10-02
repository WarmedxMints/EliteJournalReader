using EliteJournalReader.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EliteJournalReader
{

    /// <summary>
    /// File watcher and parser for the new journal feed to be introduced in Elite:Dangerous 2.2.
    /// It reads the file as it comes in and parses it on a line by line basis.
    /// All events are fired as .NET events to be consumed by other classes.
    /// </summary>
    public class JournalWatcher : FileSystemWatcher
    {
        public const int UPDATE_INTERVAL_MILLISECONDS = 500;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        ///     The default filter
        /// </summary>
        private const string DefaultFilter = @"Journal*.*.log";

        /// <summary>
        ///     The latest log file
        /// </summary>
        public string LatestJournalFile { get; private set; }

        /// <summary>
        /// Monitor the journal in a separate thread
        /// </summary>
        private Thread journalThread = null;
        private volatile int journalThreadId = 0;

        /// <summary>
        /// Token to signal that we are no longer watching
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Token that triggers the end of the current journal watcher
        /// </summary>
        private CancellationTokenSource journalCancellationTokenSource;

        /// <summary>
        /// Because the journal is kept open, we might not get notified through the FileWatcher
        /// So, in cases where we expect a new file might come, poll the directory to see if it does.
        /// </summary>
        private bool isPollingForNewFile = false;

        private bool IsPollingForNewFile
        {
            get => isPollingForNewFile;
            set
            {
                isPollingForNewFile = value;
#if DEBUG
                Trace.WriteLine($"Polling for new file : {value}");
#endif
            }
        }

        /// <summary>
        /// Keep a map of event names to event objects
        /// </summary>
        private static readonly Dictionary<string, JournalEvent> journalEventsByName = [];

        /// <summary>
        /// Also map the event objects by their type
        /// </summary>
        private static readonly Dictionary<Type, JournalEvent> journalEvents = [];

        /// <summary>
        /// Fire one single event
        /// </summary>
        private readonly bool fireSingleEvent = false;

        public event EventHandler<bool> LiveStatusChange;

        private bool isLive;
        public bool IsLive
        {
            get
            {
                if (ReadingHistory)
                {
                    return false;
                }
                return isLive;
            }
            protected set
            {
                isLive = value;
                LiveStatusChange?.Invoke(this, isLive);
            }
        }

        /// <summary>
        /// Use reflection to generate a list of event handlers. This allows for a dynamic list of handler classes, one for each type
        /// of event.
        /// </summary>
        static JournalWatcher()
        {
            try
            {

                var allHandlerTypes = AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => typeof(JournalEvent).IsAssignableFrom(type));

                var handlers = from type in allHandlerTypes
                               where !(type.IsAbstract || type.IsGenericTypeDefinition || type.IsInterface)
                               select (JournalEvent)Activator.CreateInstance(type);

                foreach (var handler in handlers)
                {
#pragma warning disable CA1031 // Do not catch general exception types
                    try
                    {
                        journalEvents[handler.GetType()] = handler;
                        foreach (string eventName in handler.EventNames)
                        {
                            journalEventsByName[eventName] = handler;
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Trace.TraceError("Error initializing JournalWatcher: " + handler.GetType().FullName);
                        var exception = e;
                        while (exception != null)
                        {
                            System.Diagnostics.Trace.TraceError(exception.ToString());
                            System.Diagnostics.Trace.TraceError(exception.StackTrace);
                            exception = exception.InnerException;
                        }

                    }
                }
            }
            catch (System.Reflection.ReflectionTypeLoadException ex)
            {
                var sb = new StringBuilder();
                foreach (var exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.ToString());
                    if (exSub is FileNotFoundException exFileNotFound)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }

                string errorMessage = sb.ToString();
                System.Diagnostics.Trace.TraceError("Error initializing JournalWatcher, loading " + ex.Message + " - " + ex.Source);
                System.Diagnostics.Trace.TraceError(ex.ToString());
                System.Diagnostics.Trace.TraceError(errorMessage);
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.TraceError("Error initializing JournalWatcher");
                var exception = e;
                while (exception != null)
                {
                    System.Diagnostics.Trace.TraceError(exception.ToString());
                    System.Diagnostics.Trace.TraceError(exception.StackTrace);
                    exception = exception.InnerException;
                }
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public JournalWatcher(string path, bool fireSingleEvent = false)
        {
            this.fireSingleEvent = fireSingleEvent;
            Filter = DefaultFilter;
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Size;
#pragma warning disable CA1031 // Do not catch general exception types
            try
            {
                Path = System.IO.Path.GetFullPath(path);
            }
            catch (Exception ex)
            {
#if DEBUG
                Trace.TraceError("Exception in setting path: " + ex.Message);
#endif
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        protected JournalWatcher()
        {
            // to be used for unit tests when we're not actually checking file systems
        }

        private readonly Regex journalFileRegex = new(@"^(?<path>.*)\\Journal(Beta)?\.(?<timestamp>\d+)\.(?<part>\d+)\.log$", RegexOptions.Compiled);

        /// <summary>
        /// This will look into the journal folder and check the latest journal.
        /// It will then fire events from all previous events in the current play session to facilitate
        /// rebuilding a status object before going "live".
        /// </summary>
        /// <returns></returns>
        private long ProcessPreviousJournals()
        {
            long offset = -1;
            try
            {
                var journals = Directory.GetFiles(Path, DefaultFilter).OrderByDescending(GetFileCreationDate);
                if (!journals.Any())
                {
                    return 0; // there's nothing
                }

                // return the list until we find one with a part number 01.
                int partNr = 1;
                var match = journalFileRegex.Match(journals.First());
                if (match.Success && match.Groups["Commander"] != null)
                {
                    int.TryParse(match.Groups["part"].Value, out partNr);
                }

                var previousFiles = journals.Take(partNr).Reverse();

                // now process each journal
                foreach (string filename in previousFiles)
                {
                    string journalFile = System.IO.Path.Combine(Path, filename);

                    using var reader = new StreamReader(new FileStream(journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

                    LatestJournalFile = filename;
#if DEBUG
                    Trace.TraceInformation($"Journal: now reading previous entries from {LatestJournalFile}.");
#endif
                    offset = ParseData(reader, 0, filename);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceError($"Error while parsing previous data from {LatestJournalFile}: " + e.Message);
#endif
                return -1;
            }

            return offset;
        }

        public bool ReadingHistory { get; private set; }
        public void ParseHistory(IProgress<string> progress)
        {
            if (progress is null)
            {
                throw new ArgumentNullException(nameof(progress));
            }

            ReadingHistory = true;
            try
            {
                var journals = Directory.GetFiles(Path, DefaultFilter).OrderBy(x => GetFileCreationDate(x));
                if (!journals.Any())
                {
                    return; // there's nothing
                }

                // now process each journal
                foreach (string filename in journals)
                {
                    string journalFile = System.IO.Path.Combine(Path, filename);

                    using var reader = new StreamReader(new FileStream(journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

                    string[] fName = filename.Split('\\');
#if DEBUG
                    Trace.TraceInformation($"Journal: now reading previous entries from {filename}.");
#endif
                    progress.Report($"{fName[^1]}");

                    _ = ParseData(reader, 0, filename);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceError($"Error while parsing previous data from {LatestJournalFile}: " + e.Message);
#endif
                return;
            }

            ReadingHistory = false;
        }

        public void ParseHistory()
        {
            ReadingHistory = true;
            try
            {
                var journals = Directory.GetFiles(Path, DefaultFilter).OrderBy(x => GetFileCreationDate(x));
                if (!journals.Any())
                {
                    return; // there's nothing
                }

                // now process each journal
                foreach (string filename in journals)
                {
#if DEBUG
                    Trace.TraceInformation($"Journal: now reading previous entries from {filename}.");
#endif
                    string journalFile = System.IO.Path.Combine(Path, filename);

                    using var reader = new StreamReader(new FileStream(journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

                    string[] fName = filename.Split('\\');
#if DEBUG
                    Trace.TraceInformation($"Journal: now reading previous entries from {filename}.");
#endif
                    _ = ParseData(reader, 0, filename);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceError($"Error while parsing previous data from {LatestJournalFile}: " + e.Message);
#endif
                return;
            }

            ReadingHistory = false;
        }

        private static DateTime GetFileCreationDate(string path)
        {
            try
            {
                var creationTime = File.GetCreationTimeUtc(path);
                var lastWriteTime = File.GetLastWriteTimeUtc(path);
                return creationTime < lastWriteTime ? creationTime : lastWriteTime;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        ///     Starts the watching.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Throws an exception if the <see cref="Path" /> does not contain netLogs
        ///     files.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        ///     The directory specified in <see cref="P:System.IO.FileSystemWatcher.Path" />
        ///     could not be found.
        /// </exception>
        public virtual async Task StartWatching()
        {
            if (EnableRaisingEvents)
            {
                // Already watching
                return;
            }

            if (!Directory.Exists(Path))
            {
#if DEBUG
                Trace.TraceError($"Cannot watch non-existing folder {Path}.");
#endif
                return;
            }

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel(false); // should not happen, but let's be safe, okay?
            }

            cancellationTokenSource = new CancellationTokenSource();

            long offset = 0;

            // before we start watching, rerun all events up until now (including any previous parts of this game session)

            await Task.Run(() => {
                offset = ProcessPreviousJournals();

                // because we might just have read an old log file, make sure we don't miss the new one when it arrives
                StartPollingForNewJournal();
                Created += async (sender, args) => await UpdateLatestJournalFile().ConfigureAwait(false);
                Changed += JournalWatcher_Changed;

                if (offset >= 0)
                {
                    // finally send an event that we've gone live
                    IsLive = true;
                    FireEvent("MagicMau.IsLiveEvent", new JObject(new JProperty("timestamp", DateTime.UtcNow)));

                    if (!string.IsNullOrEmpty(LatestJournalFile))
                    {
                        CheckForJournalUpdateAsync(LatestJournalFile, offset);
                    }
                }

                EnableRaisingEvents = true;
            }).ConfigureAwait(true);
        }

        public virtual async Task StartWatching(HashSet<string> ignoredFilenames)
        {
            if (EnableRaisingEvents)
            {
                // Already watching
                return;
            }

            if (!Directory.Exists(Path))
            {
#if DEBUG
                Trace.TraceError($"Cannot watch non-existing folder {Path}.");
#endif
                return;
            }

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel(false); // should not happen, but let's be safe, okay?
            }

            cancellationTokenSource = new CancellationTokenSource();

            long offset = 0;
            // before we start watching, rerun all events up until now (including any previous parts of this game session)
            await Task.Run(() => {
                offset = ProcessPreviousJournals(ignoredFilenames, offset);

                // because we might just have read an old log file, make sure we don't miss the new one when it arrives
                StartPollingForNewJournal();
                Created += async (sender, args) => await UpdateLatestJournalFile().ConfigureAwait(false);
                Changed += JournalWatcher_Changed;

                if (offset >= 0)
                {
                    // finally send an event that we've gone live
                    IsLive = true;
                    //FireEvent("MagicMau.IsLiveEvent", new JObject(new JProperty("timestamp", DateTime.UtcNow)));

                    if (!string.IsNullOrEmpty(LatestJournalFile))
                    {
                        CheckForJournalUpdateAsync(LatestJournalFile, offset);
                    }
                }

                EnableRaisingEvents = true;
            }).ConfigureAwait(true);
        }

        private long ProcessPreviousJournals(HashSet<string> ignoredFilenames, long fileOffset)
        {
            long offset = -1;
            try
            {
                var journals = Directory.GetFiles(Path, DefaultFilter)
                                        .Where(x => ignoredFilenames.Contains(System.IO.Path.GetFileName(x)) == false)
                                        .OrderBy(GetFileCreationDate)
                                        .ToList();
                if (journals.Count == 0)
                {
                    return 0; // there's nothing
                }

                // now process each journal
                for (int i = 0; i < journals.Count; i++)
                {
                    string filename = journals[i];
                    if (i > 0)
                    {
                        fileOffset = 0;
                    }
                    string journalFile = System.IO.Path.Combine(Path, filename);

                    using var reader = new StreamReader(new FileStream(journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    LatestJournalFile = filename;
#if DEBUG
                    Trace.TraceInformation($"Journal: now reading previous entries from {LatestJournalFile}.");
#endif
                    offset = ParseData(reader, fileOffset, filename);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceError($"Error while parsing previous data from {LatestJournalFile}: " + e.Message);
#endif
                return -1;
            }

            return offset;
        }

        public virtual async Task StartWatchingFromFileOffset(string filename, long offset, DateTime? maxJournalAge = null)
        {
            if (EnableRaisingEvents)
            {
                // Already watching
                return;
            }

            if (!Directory.Exists(Path))
            {
#if DEBUG
                Trace.TraceError($"Cannot watch non-existing folder {Path}.");
#endif
                return;
            }

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel(false); // should not happen, but let's be safe, okay?
            }

            cancellationTokenSource = new CancellationTokenSource();

            // before we start watching, rerun all events up until now (including any previous parts of this game session)
            await Task.Run(() => {
                offset = ProcessPreviousJournals(filename, offset, maxJournalAge);

                // because we might just have read an old log file, make sure we don't miss the new one when it arrives
                StartPollingForNewJournal();
                Created += async (sender, args) => await UpdateLatestJournalFile().ConfigureAwait(false);
                Changed += JournalWatcher_Changed;

                if (offset >= 0)
                {
                    // finally send an event that we've gone live
                    IsLive = true;
                    //FireEvent("MagicMau.IsLiveEvent", new JObject(new JProperty("timestamp", DateTime.UtcNow)));

                    if (!string.IsNullOrEmpty(LatestJournalFile))
                    {
                        CheckForJournalUpdateAsync(LatestJournalFile, offset);
                    }
                }

                EnableRaisingEvents = true;
            });
        }

        private long ProcessPreviousJournals(string lastFilename, long fileOffset, DateTime? maxJournalAge = null)
        {
            long offset = -1;
            try
            {
                var journals = Directory.GetFiles(Path, DefaultFilter).OrderBy(f => GetFileCreationDate(f)).ToList();
                if (!journals.Any())
                {
                    return 0; // there's nothing
                }

                if (maxJournalAge.HasValue)
                {
                    string youngestJournal = journals.LastOrDefault(x => GetFileCreationDate(x) < maxJournalAge);

                    int index = journals.IndexOf(youngestJournal);

                    if (index > 0)
                    {
                        journals.RemoveRange(0, index);
                    }
                }

                if (string.IsNullOrEmpty(lastFilename) == false)
                {
                    string position = journals.FirstOrDefault(x => x.Contains(lastFilename));

                    int index = journals.IndexOf(position);

                    if (index > 0)
                    {
                        journals.RemoveRange(0, index);
                    }
                }

                // now process each journal
                for (int i = 0; i < journals.Count; i++)
                {
                    string filename = journals[i];
                    if (i > 0)
                    {
                        fileOffset = 0;
                    }
                    string journalFile = System.IO.Path.Combine(Path, filename);

                    using var reader = new StreamReader(new FileStream(journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    LatestJournalFile = filename;
#if DEBUG
                    Trace.TraceInformation($"Journal: now reading previous entries from {LatestJournalFile}.");
#endif
                    offset = ParseData(reader, fileOffset, filename);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceError($"Error while parsing previous data from {LatestJournalFile}: " + e.Message);
#endif
                return -1;
            }

            return offset;
        }

        public CargoEvent.CargoEventArgs ReadCargoJson()
        {
            try
            {
                string cargoPath = System.IO.Path.Combine(Path, "Cargo.json");

                if (!File.Exists(cargoPath))
                {
                    return null;
                }

                string json = File.ReadAllText(cargoPath, Encoding.UTF8);

                CargoEvent.CargoEventArgs cargo = JsonConvert.DeserializeObject<CargoEvent.CargoEventArgs>(json);

                return cargo;
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceWarning($"Error reading cargo.json journal file: {e.Message}");
                Trace.TraceInformation(e.ToString());
#endif
            }

            return null;
        }

        public NavRouteEvent.NavRouteEventArgs ReadNavRouteJson()
        {
            try
            {
                string navPath = System.IO.Path.Combine(Path, "NavRoute.json");

                if (!File.Exists(navPath))
                {
                    return null;
                }

                string json = File.ReadAllText(navPath, Encoding.UTF8);

                var route = JsonConvert.DeserializeObject<NavRouteEvent.NavRouteEventArgs>(json);

                return route;
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceWarning($"Error reading navroute.json journal file: {e.Message}");
                Trace.TraceInformation(e.ToString());
#endif
            }

            return null;
        }

        public MarketInfo ReadMarketInfo(string filename = "Market.json")
        {
            string filePath = System.IO.Path.Combine(Path, filename);
#pragma warning disable CA1031 // Do not catch general exception types
            try
            {
                var result = JToken.ReadFrom(new JsonTextReader(new StreamReader(filePath))).ToObject<MarketInfo>();
                return result;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.TraceError($"Error reading from {filePath}: {e.Message}");
                return null;
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        private async void JournalWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            // if we're not watching anything, let's see if there is a log available
            if (LatestJournalFile == null || e.Name != LatestJournalFile)
            {
                await UpdateLatestJournalFile().ConfigureAwait(false);
            }
        }

        internal void StartPollingForNewJournal()
        {
            if (IsPollingForNewFile || cancellationTokenSource == null || cancellationTokenSource.IsCancellationRequested)
            {
                return; // we're already polling or no longer needed
            }

            IsPollingForNewFile = true;
            Task.Run(async () => {
                while (IsPollingForNewFile)
                {
                    try
                    {
                        await Task.Delay(5000, cancellationTokenSource.Token); // check every five seconds
                        if (cancellationTokenSource.IsCancellationRequested)
                        {
                            IsPollingForNewFile = false;
                            return;
                        }

                        await UpdateLatestJournalFile().ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        IsPollingForNewFile = false;
                    }
                    catch (OperationCanceledException)
                    {
                        IsPollingForNewFile = false;
                    }
                    catch (Exception e)
                    {
#if DEBUG
                        Trace.TraceError($"Error while polling for new journal: {e.Message}.");
#endif
                    }
                }
            });
        }

        public virtual void StopWatching()
        {
            try
            {
                EnableRaisingEvents = false;
                IsLive = false;
                isPollingForNewFile = false;
                Created -= async (sender, args) => await UpdateLatestJournalFile().ConfigureAwait(false);
                Changed -= JournalWatcher_Changed;
                journalCancellationTokenSource?.Cancel(false);
                cancellationTokenSource?.Cancel(false);
               
                journalThread?.Join();
                //cancellationTokenSource = null;
            }
            catch (OperationCanceledException e)
            {
#if DEBUG
                Trace.TraceError($"Error while stopping Journal watcher: {e.Message}");
                Trace.TraceInformation(e.StackTrace);
#endif
            }
            catch { }
        }

        public long CurrentOffset { get; private set; }        

        private void CheckForJournalUpdateAsync(string filename, long startOffset)
        {
            journalThreadId++;

            if (journalCancellationTokenSource != null)
            {
                journalCancellationTokenSource.Cancel();
            }

            if (journalThread != null && journalThread.IsAlive)
            {
                try
                {
                    if (!journalThread.Join(30000))
                    {
#if DEBUG
                        Trace.TraceError($"Something went wrong shutting down the previous journal reader thread");
#endif
                    }
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.TraceError($"Something went wrong shutting down the previous journal reader thread: {e.Message}");
#endif
                }
                finally
                {
                    journalThread = null;
                }
            }

            journalCancellationTokenSource = new CancellationTokenSource();
            journalThread = new Thread(state => {
                // keep a current ID for this thread. If the ID changes, we are watching a different file, and this thread can exit.
                var tuple = (Tuple<int, long, string, CancellationToken>)state;
                int id = tuple.Item1;
                long offset = tuple.Item2;
                string journalFile = System.IO.Path.Combine(Path, tuple.Item3);
                var cancellationToken = tuple.Item4;

#if DEBUG
                Trace.TraceInformation($"Journal: now starting journal thread {id} for {journalFile} from offset {offset}.");
#endif

                try
                {

                    using var reader = new StreamReader(new FileStream(journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    while (id == journalThreadId && !cancellationToken.IsCancellationRequested)
                    {                       
                        // check for updates every 0.5 seconds
                        // if we are no longer watching (this thread), stop.
                        if (!Pause() || id != journalThreadId)
                        {
                            return;
                        }

                        // if the file size has not changed, idle
                        if (reader.BaseStream.Length <= offset)
                        {
                            continue;
                        }
                        
                        // we found new data, so this is definitely not a stale file
                        IsPollingForNewFile = false;

                        // parse the data we just read
                        offset = ParseData(reader, offset, tuple.Item3);
#if DEBUG
                        Trace.TraceInformation($"Journal: now reading from offset {offset}.");
#endif
                    }

                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.TraceError($"Something went wrong in the journal reader thread {id}: {e.Message}");
                    Trace.TraceInformation(e.StackTrace);
#endif
                    // Something went wrong, let's check log files again
                    LatestJournalFile = null;
                }
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (id == journalThreadId)
                    {
                        // We're here, so something must've gone wrong
                        // Let's try again in a few seconds
                        Pause();
                        UpdateLatestJournalFile().Wait(cancellationTokenSource.Token);
                    }
                }
                catch (OperationCanceledException ex)
                {
#if DEBUG
                    Trace.TraceInformation("Journal: Watcher Stopped");
                    Trace.TraceInformation(ex.StackTrace);
#endif
                }

#if DEBUG
                Trace.TraceInformation($"Journal: end of journal thread for {journalFile}.");
#endif

            })
            {
                Name = "Journal Watcher",
                IsBackground = true
            };

            journalThread.Start(Tuple.Create(journalThreadId, startOffset, filename, journalCancellationTokenSource.Token));

        }

        private long ParseData(StreamReader reader, long offset, string filename)
        {
            try
            {
                // seek to the last max offset
                reader.BaseStream.Seek(offset, SeekOrigin.Begin);

                // read new data
                string newData = reader.ReadToEnd();

                ParseText(newData, filename, offset);
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceError($"Exception while parsing journal data: {e.Message}");
#endif
            }
            finally
            {
                try
                {
                    // update the last max offset
                    offset = reader.BaseStream.Position;
                    CurrentOffset = offset;
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.TraceError($"Exception while updating position in journal file: {e.Message}");
#endif
                    // might be something wrong with the file - let's start polling for a new one
                    StartPollingForNewJournal();
                }
            }
            return offset;
        }

        // Parses multiple lines of journal data
        public void ParseText(string text, string filename, long offset)
        {
            // split the new data into lines
            string[] lines = text.Split('\r', '\n');
            long lineDifference = offset;
            // parse each line
            foreach (string line in lines)
            {
                Parse(line, filename, lineDifference);
                lineDifference += line.Length + 1;
            }
        }

        private bool Pause()
        {
            try
            {
                Task.Delay(UPDATE_INTERVAL_MILLISECONDS, cancellationTokenSource.Token).Wait(cancellationTokenSource.Token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Updates the <see cref="LatestJournalFile" /> property.
        /// </summary>
        private async Task<string> UpdateLatestJournalFile()
        {
            // filenames have format: Journal.160922194205.01.log
            string[] journals = Directory.GetFiles(Path, DefaultFilter);

            // keep waiting until there is a journal, or we're being cancelled.
            while (journals.Length == 0)
            {
                try
                {
                    await Task.Delay(UPDATE_INTERVAL_MILLISECONDS, cancellationTokenSource.Token).ConfigureAwait(false);
                    journals = Directory.GetFiles(Path, DefaultFilter);
                }
                catch (TaskCanceledException)
                {
                    return null;
                }
            }

            // because the timestamp is in the filename, we can just sort by filename descending.
            string latestJournal = Directory.GetFiles(Path, DefaultFilter).OrderByDescending(GetFileCreationDate).FirstOrDefault();

            bool isChanged = latestJournal != null && LatestJournalFile != latestJournal;
            if (isChanged)
            {
                LatestJournalFile = latestJournal;
                IsPollingForNewFile = false;
#if DEBUG
                Trace.TraceInformation($"Journal: now reading from {LatestJournalFile}.");
#endif
                CheckForJournalUpdateAsync(latestJournal, 0);
            }


            return latestJournal;
        }

        /// <summary>
        /// Parses a line of JSON from the journal and fire a .NET event handler.
        /// </summary>
        /// <param name="line"></param>
        protected void Parse(string line, string filename, long offset)
        {
            if (string.IsNullOrEmpty(line))
            {
                return;
            }

            try
            {
                var evt = JObject.Parse(line);
                string eventType = evt.Value<string>("event");
                if (string.IsNullOrEmpty(eventType))
                {
                    return; // no event, nothing to do
                }

#if DEBUG
                if (IsLive)
                {
                    Trace.TraceInformation($"Journal - firing event {eventType} @ {evt["timestamp"]?.Value<string>()}\r\n\t{line}");
                }
#endif
                var journalEventArgs = FireEvent(eventType, evt, fireSingleEvent);

                if (journalEventArgs is null)
                {
#if DEBUG
                    Trace.WriteLine($"arg null | Event : {eventType}");
#endif
                    return;
                }
                if (fireSingleEvent)
                {
                    MessageReceived?.Invoke(this, new MessageReceivedEventArgs(journalEventArgs, eventType, filename, offset));
                    return;
                }
            }
            catch (JsonReaderException jsonEx)
            {
#if DEBUG
                Trace.TraceError($"Exception handling journal event:\r\n\t{line}\r\n\t{jsonEx.GetType().FullName}: {jsonEx.Message}");
#endif
                OnError(new ErrorEventArgs(jsonEx));
            }
            catch (IOException ex)
            {
#if DEBUG
                Trace.TraceError($"Exception handling journal event:\r\n\t{line}\r\n\t{ex.GetType().FullName}: {ex.Message}");
#endif
                OnError(new ErrorEventArgs(ex));
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.TraceError($"Exception handling journal event:\r\n\t{line}\r\n\t{e.GetType().FullName}: {e.Message}");
#endif
                OnError(new ErrorEventArgs(e));
            }
        }

        /// <summary>
        /// Find the event handler for the given type. If found, invoke it.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="evt"></param>
        private JournalEventArgs FireEvent(string eventType, JObject evt, bool singleEvent = false)
        {
            if (journalEventsByName.TryGetValue(eventType, out var handler))
            {
                return handler.FireEvent(this, evt, !singleEvent);
            }
#if DEBUG
            else
            {
                Trace.TraceWarning("No event handler registered for journal event of type: " + eventType);
                Console.WriteLine("No event handler registered for journal event of type: " + eventType);
                OnErrorMessage?.Invoke(this, "No event handler registered for journal event of type: " + eventType);
            }
#endif
            return null;
        }

#if DEBUG
        public EventHandler<string> OnErrorMessage;

        public void SendErrorMessage(string message) => OnErrorMessage?.Invoke(this, message);
#endif
        public static JournalEventArgs GetEventData(string eventdata)
        {
            var evnt = JObject.Parse(new string(eventdata));

            string eventType = evnt["event"].ToString();

            if (string.IsNullOrEmpty(eventType))
            {
                return null;
            }
            if (journalEventsByName.TryGetValue(eventType, out var handler))
            {
                return handler.JsonToEvent(null, evnt);
            }

            return null;
        }

        public static TJournalEvent GetEvent<TJournalEvent>() where TJournalEvent : JournalEvent
        {
            var type = typeof(TJournalEvent);
            return journalEvents.TryGetValue(type, out JournalEvent value) ? value as TJournalEvent : null;
        }

        public TJournalEvent GetEventLocal<TJournalEvent>() where TJournalEvent : JournalEvent
        {
            var type = typeof(TJournalEvent);
            return journalEvents.TryGetValue(type, out JournalEvent value) ? value as TJournalEvent : null;
        }

        public bool HasFiles()
        {
            if (string.IsNullOrEmpty(Path) || Directory.Exists(Path) == false) 
                return false;

            try
            {
                var journals = Directory.GetFiles(Path, DefaultFilter).OrderBy(f => GetFileCreationDate(f)).ToList();
                return journals.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
