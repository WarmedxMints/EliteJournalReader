namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class CarrierFinanceEvent : JournalEvent<CarrierFinanceEvent.CarrierFinanceEventArgs>
    {
        public CarrierFinanceEvent() : base("CarrierFinance") { }

        public class CarrierFinanceEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public long CarrierBalance { get; set; }
            public long ReserveBalance { get; set; }
            public long AvailableBalance { get; set; }
            public double ReservePercent { get; set; }
            public double TaxRate_pioneersupplies { get; set; }
            public double TaxRate_shipyard { get; set; }
            public double TaxRate_rearm { get; set; }
            public double TaxRate_outfitting { get; set; }
            public double TaxRate_refuel { get; set; }
            public double TaxRate_repair { get; set; }
        }
    }
}
