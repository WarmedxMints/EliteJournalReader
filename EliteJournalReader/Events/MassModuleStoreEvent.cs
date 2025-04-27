using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: when putting multiple modules into storage
    //Parameters:
    //�	MarketID
    //�	Ship
    //�	ShipId
    //�	Items: Array of records
    //o   Slot
    //o   Name
    //o   EngineerModifications(only present if modified)
    public class MassModuleStoreEvent : JournalEvent<MassModuleStoreEvent.MassModuleStoreEventArgs>
    {
        public MassModuleStoreEvent() : base("MassModuleStore") { }

        public class MassModuleStoreEventArgs : JournalEventArgs
        {
            public struct ModuleItems
            {
                public string Slot;
                public string Name;
                public string EngineerModifications;
                public int Level { get; set; }
                public double Quality { get; set; }
                public bool Hot { get; set; }
            }

            public string Ship { get; set; }
            public long ShipID { get; set; }
            public long MarketID { get; set; }
            public IReadOnlyList<ModuleItems> Items { get; set; }
        }
    }
}
