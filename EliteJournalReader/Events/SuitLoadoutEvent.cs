using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public class SuitLoadoutEvent : JournalEvent<SuitLoadoutEvent.SuitLoadoutEventArgs>
    {
        public SuitLoadoutEvent() : base("SuitLoadout") { }

        public class SuitLoadoutEventArgs : JournalEventArgs
        {
            public long SuitID { get; set; }
            public string SuitName { get; set; }
            public string SuitName_Localised { get; set; }
            public List<string> SuitMods { get; set; }
            public long LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public List<SuitModule> Modules { get; set; }
        }
    }
}

