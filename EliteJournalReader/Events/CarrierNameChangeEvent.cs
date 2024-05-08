namespace EliteJournalReader.Events
{
    public class CarrierNameChangeEvent : JournalEvent<CarrierNameChangeEvent.CarrierNameChangeEventArgs>
    {
        public CarrierNameChangeEvent() : base("CarrierNameChange") { }

        public class CarrierNameChangeEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string Name { get; set; }
            public string Callsign { get; set; }
        }
    }
}
