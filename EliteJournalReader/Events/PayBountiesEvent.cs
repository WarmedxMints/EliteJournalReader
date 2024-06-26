namespace EliteJournalReader.Events
{
    //When written: when paying off bounties
    //Parameters:
    //�	Amount: (total amount paid, including any broker fee)
    //�	BrokerPercentage(present if paid via a Broker)
    //�	AllFines: bool
    //�	Faction
    //�	ShipID
    public class PayBountiesEvent : JournalEvent<PayBountiesEvent.PayBountiesEventArgs>
    {
        public PayBountiesEvent() : base("PayBounties") { }

        public class PayBountiesEventArgs : JournalEventArgs
        {
            public int Amount { get; set; }
            public double? BrokerPercentage { get; set; }
            public string Faction { get; set; }
            public string Faction_Localised { get; set; }
            public long ShipID { get; set; }
            public bool AllFines { get; set; }
        }
    }
}
