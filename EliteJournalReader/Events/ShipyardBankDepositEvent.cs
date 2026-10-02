namespace EliteJournalReader.Events
{
    public sealed class ShipyardBankDepositEvent : JournalEvent<ShipyardBankDepositEvent.ShipyardBankDepositEventEventArgs>
    {
        public ShipyardBankDepositEvent() : base("ShipyardBankDeposit") { }

        public sealed class ShipyardBankDepositEventEventArgs : JournalEventArgs
        {
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public ulong MarketID { get; set; }
        }
    }
}
