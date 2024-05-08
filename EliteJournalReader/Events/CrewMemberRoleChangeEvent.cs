namespace EliteJournalReader.Events
{
    //When written: When another player joins your ship's crew
    //Parameters:
    //�	Crew: player's commander name
    //�	Role: selected role
    public class CrewMemberRoleChangeEvent : JournalEvent<CrewMemberRoleChangeEvent.CrewMemberRoleChangeEventArgs>
    {
        public CrewMemberRoleChangeEvent() : base("CrewMemberRoleChange") { }

        public class CrewMemberRoleChangeEventArgs : JournalEventArgs
        {
            public string Crew { get; set; }
            public long CrewID { get; set; }
            public string Role { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
