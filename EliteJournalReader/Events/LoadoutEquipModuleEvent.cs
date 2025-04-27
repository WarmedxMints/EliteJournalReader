using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public class LoadoutEquipModuleEvent : JournalEvent<LoadoutEquipModuleEvent.LoadoutEquipModuleEventArgs>
    {
        public LoadoutEquipModuleEvent() : base("LoadoutEquipModule") { }

        public class LoadoutEquipModuleEventArgs : JournalEventArgs
        {
            public long SuitID { get; set; }
            public string SuitName { get; set; }
            public long LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public string SlotName { get; set; }
            public string ModuleName { get; set; }
            public long SuitModuleID { get; set; }
            public string Class { get; set; }
            public IReadOnlyList<string> WeaponMods { get; set; }
        }
    }
}