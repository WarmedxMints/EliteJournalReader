using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When Written: when selling exploration data in Cartographics
    //Parameters:
    //�	Systems: JSON array of system names
    //�	Discovered: JSON array of discovered bodies
    //�	BaseValue: value of systems
    //�	Bonus: bonus for first discoveries
    //�	TotalEarnings: total credits received(including for example the 200% bonus if rank 5 with Li Yong Rui)
    public class SellExplorationDataEvent : JournalEvent<SellExplorationDataEvent.SellExplorationDataEventArgs>
    {
        public SellExplorationDataEvent() : base("SellExplorationData") { }

        public class SellExplorationDataEventArgs : JournalEventArgs
        {
            public IReadOnlyList<string> Systems { get; set; }
            public IReadOnlyList<string> Discovered { get; set; }
            public long BaseValue { get; set; }
            public long Bonus { get; set; }
            public long TotalEarnings { get; set; }
        }
    }
}
