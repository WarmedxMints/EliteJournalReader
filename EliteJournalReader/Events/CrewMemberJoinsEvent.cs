namespace EliteJournalReader.Events
{
    //When written: When another player joins your ship's crew
    //Parameters:
    //�	Crew: player's commander name
    public class CrewMemberJoinsEvent : JournalEvent<CrewMemberJoinsEvent.CrewMemberJoinsEventArgs>
    {
        public CrewMemberJoinsEvent() : base("CrewMemberJoins") { }

        public class CrewMemberJoinsEventArgs : JournalEventArgs
        {
            public string Crew { get; set; }
            public long CrewID { get; set; }
        }
    }
}
