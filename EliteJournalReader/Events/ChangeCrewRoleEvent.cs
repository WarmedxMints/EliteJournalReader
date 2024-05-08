namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class ChangeCrewRoleEvent : JournalEvent<ChangeCrewRoleEvent.ChangeCrewRoleEventArgs>
    {
        public ChangeCrewRoleEvent() : base("ChangeCrewRole") { }

        public class ChangeCrewRoleEventArgs : JournalEventArgs
        {
            public RoleType Role { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
