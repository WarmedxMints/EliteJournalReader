namespace EliteJournalReader.Events
{
    public sealed class PowerplayRankEvent : JournalEvent<PowerplayRankEvent.PowerplayRankEventArgs>
    {
        public PowerplayRankEvent() : base("PowerplayRank") { }

        public class PowerplayRankEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
            public int Rank { get; set; }
        }
    }
}
