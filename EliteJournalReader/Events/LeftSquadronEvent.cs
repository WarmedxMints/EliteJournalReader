namespace EliteJournalReader.Events
{
    public class LeftSquadronEvent : JournalEvent<LeftSquadronEvent.LeftSquadronEventArgs>
    {
        public LeftSquadronEvent() : base("LeftSquadron") { }

        public class LeftSquadronEventArgs : JournalEventArgs
        {
            public int SquadronID { get; set; }
            public string SquadronName { get; set; }
        }
    }
}
