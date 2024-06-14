namespace EliteJournalReader.Events
{
    public sealed class ShipRedeemEvent : JournalEvent<ShipRedeemEvent.ShipRedeemEventArgs>
    {
        public ShipRedeemEvent() : base("ShipRedeemed") { }

        public sealed class ShipRedeemEventArgs : JournalEventArgs
        {
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public long NewShipID { get; set; }
        }
    }
}
