namespace EliteJournalReader.Events
{
    //When Written: when buying a module in outfitting
    //Parameters:
    //�	Slot: the outfitting slot
    //�	BuyItem: the module being purchased
    //�	BuyPrice: price paid
    //�	Ship: the players ship
    //If replacing an existing module:
    //�	SellItem: item being sold
    //�	SellPrice: sale price
    public class ModuleBuyEvent : JournalEvent<ModuleBuyEvent.ModuleBuyEventArgs>
    {
        public ModuleBuyEvent() : base("ModuleBuy") { }

        public class ModuleBuyEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string Slot { get; set; }
            public string BuyItem { get; set; }
            public string BuyItem_Localised { get; set; }
            public int BuyPrice { get; set; }
            public string Ship { get; set; }
            public long ShipID { get; set; }
            public string SellItem { get; set; }
            public string SellItem_Localised { get; set; }
            public string StoredItem { get; set; }
            public string StoredItem_Localised { get; set; }
            public int? SellPrice { get; set; }
        }
    }
}
