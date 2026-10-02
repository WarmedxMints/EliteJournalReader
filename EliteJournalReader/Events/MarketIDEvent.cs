namespace EliteJournalReader.Events
{
    public sealed class MarketIDEvent : JournalEvent<MarketIDEvent.MarketIDEventEventArgs>
    {
        public MarketIDEvent() : base("MarketID") { }

        public sealed class MarketIDEventEventArgs : JournalEventArgs
        {
        }
    }
}
