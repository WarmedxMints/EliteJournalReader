namespace EliteJournalReader.Events
{
    //When written: when taking off from planet surface
    //Parameters:
    //�	Latitude
    //�	Longitude
    //�	PlayerControlled: (bool) false if ship dismissed when player is in SRV, true if player is taking off
    public class LiftoffEvent : JournalEvent<LiftoffEvent.LiftoffEventArgs>
    {
        public LiftoffEvent() : base("Liftoff") { }

        public class LiftoffEventArgs : JournalEventArgs
        {
            public bool PlayerControlled { get; set; }
            public bool Taxi { get; set; }
            public bool Multicrew { get; set; }
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }
            public int BodyID { get; set; }
            public bool OnStation { get; set; }
            public bool OnPlanet { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string NearestDestination { get; set; }
            public string NearestDestination_Localised { get; set; }
        }
    }
}
