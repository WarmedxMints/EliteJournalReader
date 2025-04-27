using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;

namespace EliteJournalReader
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public JObject JObject { get; private set; }
        public JournalTypeEnum EventType { get; private set; }
        public string Filename { get; private set; }
        public long Offset { get; private set; }
        public DateTime Timestamp { get; private set; }
        public JournalEventArgs EventArgs { get; private set; }

        public MessageReceivedEventArgs(JournalEventArgs args, string eventType, string filename, long offset)
        {
            if (args is null)
            {
#if DEBUG
                Trace.WriteLine($"arg null | Event : {eventType}");
#endif
                return;
            }
            JObject = args.OriginalEvent?.DeepClone() as JObject;
            EventType = JournalTypeEnum.Unknown;
            if (Enum.TryParse(eventType, out JournalTypeEnum type))
            {
                EventType = type;
            }
            Timestamp = args.Timestamp;
            EventArgs = args;
            Filename = Path.GetFileName(filename);
            Offset = offset;
        }
    }
}