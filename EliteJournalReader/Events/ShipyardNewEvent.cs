namespace EliteJournalReader.Events
{
    //When written: after a new ship has been purchased
    //Parameters:
    //�	ShipType
    //�	ShipID
    public class ShipyardNewEvent : JournalEvent<ShipyardNewEvent.ShipyardNewEventArgs>
    {
        public ShipyardNewEvent() : base("ShipyardNew") { }

        public class ShipyardNewEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public long NewShipID { get; set; }
        }
    }
}
