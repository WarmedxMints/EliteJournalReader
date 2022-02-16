namespace EliteJournalReader.Events
{
    public class DropShipDeployEvent : JournalEvent<DropShipDeployEvent.DropShipDeployEventArgs>
    {
        public DropShipDeployEvent() : base("DropshipDeploy") { }

        public class DropShipDeployEventArgs : JournalEventArgs
        {
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }
            public long BodyID { get; set; }
            public bool OnStation { get; set; }
            public bool OnPlanet { get; set; }
        }
    }
}