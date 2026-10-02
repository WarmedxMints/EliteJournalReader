namespace EliteJournalReader.Events
{
    public sealed class SquadronPromotionEvent : JournalEvent<SquadronPromotionEvent.SquadronPromotionEventArgs>
    {
        public SquadronPromotionEvent() : base("SquadronPromotion") { }

        public sealed class SquadronPromotionEventArgs : JournalEventArgs
        {
            public int SquadronID { get; set; }
            public string SquadronName { get; set; }
            public int OldRank { get; set; }
            public string OldRankName { get; set; }
            public int NewRank { get; set; }
            public string NewRankName { get; set; }
        }
    }
}
