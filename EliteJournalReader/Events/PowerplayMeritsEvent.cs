namespace EliteJournalReader.Events
{
    public sealed class PowerplayMeritsEvent  : JournalEvent<PowerplayMeritsEvent.PowerplayMeritsEventArgs>
    {
        public PowerplayMeritsEvent() : base("PowerplayMerits") { }

        public class PowerplayMeritsEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
            public int MeritsGained { get; set; }
            public ulong TotalMerits { get; set; }
        }
    }
}
