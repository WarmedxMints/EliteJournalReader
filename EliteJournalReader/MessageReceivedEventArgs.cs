using Newtonsoft.Json.Linq;
using System;
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
            JObject = args.OriginalEvent?.DeepClone() as JObject;
            EventType = Enum.Parse<JournalTypeEnum>(eventType);
            Timestamp = args.Timestamp;
            EventArgs = args;
            Filename = Path.GetFileName(filename); 
            Offset = offset;
        }
    }
}