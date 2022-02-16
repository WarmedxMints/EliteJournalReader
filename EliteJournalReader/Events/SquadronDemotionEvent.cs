namespace EliteJournalReader.Events
{
    public class SquadronDemotionEvent : JournalEvent<SquadronDemotionEvent.SquadronDemotionEventArgs>
    {
        public SquadronDemotionEvent() : base("SquadronDemotion") { }

        public class SquadronDemotionEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
            public int OldRank { get; set; }
            public int NewRank { get; set; }
        }
    }
}
