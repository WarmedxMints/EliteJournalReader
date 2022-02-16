namespace EliteJournalReader.Events
{
    public class SquadronCreatedEvent : JournalEvent<SquadronCreatedEvent.SquadronCreatedEventArgs>
    {
        public SquadronCreatedEvent() : base("SquadronCreated") { }

        public class SquadronCreatedEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
