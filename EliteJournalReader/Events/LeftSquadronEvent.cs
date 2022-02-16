namespace EliteJournalReader.Events
{
    public class LeftSquadronEvent : JournalEvent<LeftSquadronEvent.LeftSquadronEventArgs>
    {
        public LeftSquadronEvent() : base("LeftSquadron") { }

        public class LeftSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
