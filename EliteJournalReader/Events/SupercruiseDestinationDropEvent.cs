namespace EliteJournalReader.Events
{
    public sealed class SupercruiseDestinationDropEvent : JournalEvent<SupercruiseDestinationDropEvent.SupercruiseDestinationDropEventArgs>
    {
        public SupercruiseDestinationDropEvent() : base("SupercruiseDestinationDrop") { }

        public class SupercruiseDestinationDropEventArgs : JournalEventArgs
        {
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public long MarketID { get; set; }
            public int Threat { get; set; }
        }
    }
}
