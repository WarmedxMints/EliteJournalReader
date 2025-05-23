using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public class SwitchSuitLoadoutEvent : JournalEvent<SwitchSuitLoadoutEvent.SwitchSuitLoadoutEventArgs>
    {
        public SwitchSuitLoadoutEvent() : base("SwitchSuitLoadout") { }

        public class SwitchSuitLoadoutEventArgs : JournalEventArgs
        {
            public long SuitID { get; set; }
            public string SuitName { get; set; }
            public IReadOnlyList<string> SuitMods { get; set; }
            public long LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public IReadOnlyList<SuitModule> Modules { get; set; }
        }
    }
}