namespace EliteJournalReader.Events
{
    public sealed class ClearImpoundEvent : JournalEvent<ClearImpoundEvent.ClearImpoundEventArgs>
    {
        public ClearImpoundEvent() : base("ClearImpound") { }

        public class ClearImpoundEventArgs : JournalEventArgs
        {
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public string System { get; set; }
            public int ShipID { get; set; }
            public ulong ShipMarketID { get; set; }
            public ulong MarketID { get; set; }
        }
    }
}
