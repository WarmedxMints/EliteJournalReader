namespace EliteJournalReader.Events
{
    //When written: when scooping fuel from a star
    //Parameters:
    //�	Scooped: tons fuel scooped
    //�	Total: total fuel level after scooping
    public class ReservoirReplenishedEvent : JournalEvent<ReservoirReplenishedEvent.ReservoirReplenishedEventArgs>
    {
        public ReservoirReplenishedEvent() : base("ReservoirReplenished") { }

        public class ReservoirReplenishedEventArgs : JournalEventArgs
        {
            public double FuelMain { get; set; }
            public double FuelReservoir { get; set; }
        }
    }
}
