namespace EliteJournalReader.Events
{
    //When Written: when a mission has failed
    //Parameters:
    //•	Name: name of mission
    public class MissionFailedEvent : JournalEvent<MissionFailedEvent.MissionFailedEventArgs>
    {
        public MissionFailedEvent() : base("MissionFailed") { }

        public class MissionFailedEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string LocalisedName { get; set; }
            public ulong MissionID { get; set; }
            public int Fine { get; set; }
        }
    }
}
