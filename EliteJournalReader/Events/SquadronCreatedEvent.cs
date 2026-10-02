namespace EliteJournalReader.Events
{
    public class SquadronCreatedEvent : JournalEvent<SquadronCreatedEvent.SquadronCreatedEventArgs>
    {
        public SquadronCreatedEvent() : base("SquadronCreated") { }

        public class SquadronCreatedEventArgs : JournalEventArgs
        {
            public int SquadronID { get; set; }
            public string SquadronName { get; set; }
        }
    }
}
