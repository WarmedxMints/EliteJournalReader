namespace EliteJournalReader.Events
{
    public class SquadronStartupEvent : JournalEvent<SquadronStartupEvent.SquadronStartupEventArgs>
    {
        public SquadronStartupEvent() : base("SquadronStartup") { }

        public class SquadronStartupEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
            public string CurrentRank { get; set; }
        }
    }
}
