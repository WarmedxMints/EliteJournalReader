namespace EliteJournalReader.Events
{
    public sealed class HoloscreenHackedEvent : JournalEvent<HoloscreenHackedEvent.HoloscreenHackedEventArgs>
    {
        public HoloscreenHackedEvent() : base("HoloscreenHacked") { }

        public class HoloscreenHackedEventArgs : JournalEventArgs
        {
            public string PowerBefore { get; set; }
            public string PowerAfter { get; set; }
        }
    }
}
