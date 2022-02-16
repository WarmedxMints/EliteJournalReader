namespace EliteJournalReader.Events
{
    //This is written when a crew member's combat rank increases
    //Parameters:
    //�	NpcCrewId
    //�	RankCombat
    public class NpcCrewRankEvent : JournalEvent<NpcCrewRankEvent.NpcCrewRankEventArgs>
    {
        public NpcCrewRankEvent() : base("NpcCrewRank") { }

        public class NpcCrewRankEventArgs : JournalEventArgs
        {
            public string NpcCrewName { get; set; }
            public long NpcCrewId { get; set; }
            public CombatRank RankCombat { get; set; }
        }
    }
}
