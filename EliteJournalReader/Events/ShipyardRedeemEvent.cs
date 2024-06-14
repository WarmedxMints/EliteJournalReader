namespace EliteJournalReader.Events
{
    public sealed class ShipyardRedeemEvent : JournalEvent<ShipyardRedeemEvent.ShipyardRedeemEventArgs>
    {
        public ShipyardRedeemEvent() : base("ShipyardRedeem") { }

        public sealed class ShipyardRedeemEventArgs : JournalEventArgs
        {
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public long BundleID { get; set; }
            public long MarketID { get; set; }
        }
    }
}
