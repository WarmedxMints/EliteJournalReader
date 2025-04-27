namespace EliteJournalReader.Events
{
    public sealed class CarrierLocationEvent : JournalEvent<CarrierLocationEvent.CarrierLocationEventArgs>
    {
        public CarrierLocationEvent() : base("CarrierLocation") { }

        /*
         *   "CarrierID": 3704934656,
         *   "StarSystem": "Ross 584",
         *   "SystemAddress": 3382387380938,
         *   "BodyID": 11
         */

        public class CarrierLocationEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
            public int BodyID { get; set; }
        }
    }
}
