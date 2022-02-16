namespace EliteJournalReader.Events
{
    public class JoinedSquadronEvent : JournalEvent<JoinedSquadronEvent.JoinedSquadronEventArgs>
    {
        public JoinedSquadronEvent() : base("JoinedSquadron") { }

        public class JoinedSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
