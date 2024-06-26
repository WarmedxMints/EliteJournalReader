namespace EliteJournalReader.Events
{
    //When written: when the player requests docking at a station
    //Parameters:
    //�	StationName: name of station
    public class DockingRequestedEvent : JournalEvent<DockingRequestedEvent.DockingRequestedEventArgs>
    {
        public DockingRequestedEvent() : base("DockingRequested") { }

        public class DockingRequestedEventArgs : JournalEventArgs
        {
            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }
            public LandingPads LandingPads { get; set; }
        }
    }
}
