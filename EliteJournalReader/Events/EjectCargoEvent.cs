namespace EliteJournalReader.Events
{
    //When Written:
    //Parameters:
    //�	Type: cargo type
    //�	Count: number of units
    //�	Abandoned: whether �abandoned�
    public class EjectCargoEvent : JournalEvent<EjectCargoEvent.EjectCargoEventArgs>
    {
        public EjectCargoEvent() : base("EjectCargo") { }

        public class EjectCargoEventArgs : JournalEventArgs
        {
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public int Count { get; set; }
            public bool Abandoned { get; set; }
            public string PowerplayOrigin { get; set; }
            public ulong MissionID { get; set; }
        }
    }
}
