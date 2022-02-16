namespace EliteJournalReader.Events
{
    public class ModuleBuyAndStoreEvent : JournalEvent<ModuleBuyAndStoreEvent.ModuleBuyAndStoreEventArgs>
    {
        public ModuleBuyAndStoreEvent() : base("ModuleBuyAndStore") { }

        public class ModuleBuyAndStoreEventArgs : JournalEventArgs
        {
            public string BuyItem { get; set; }
            public string BuyItem_Localised { get; set; }
            public long MarketID { get; set; }
            public long BuyPrice { get; set; }
            public string Ship { get; set; }
            public int ShipID { get; set; }
        }
    }
}
