using System;
using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: when accessing the commodity market in a station
    //A separate file market.json is written to the same folder as the journal, containing full market price info
    //Parameters:
    //�	MarketID
    //�	StationName
    //�	StarSystem

    //The separate file also contains:
    //�	Items: array of objects
    //o   id
    //o   Name
    //o   BuyPrice
    //o   SellPrice
    //o   MeanPrice
    //o   StockBracket
    //o   DemandBracket
    //o   Stock
    //o   Demand
    //o   Consumer: bool
    //o   Producer: bool
    //o   Rare: bool
    public class MarketEvent : JournalEvent<MarketEvent.MarketEventArgs>
    {
        public MarketEvent() : base("Market") { }

        public class MarketEventArgs : JournalEventArgs
        {
            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }
            public string CarrierDockingAccess { get; set; }
            public string StarSystem { get; set; }           
        }
    }

    public class MarketInfo
    {
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
        public IReadOnlyList<MarketItem> Items { get; set; }
    }

    public class MarketItem
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Category { get; set; }
        public string Category_Localised { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int MeanPrice { get; set; }
        public int StockBracket { get; set; }
        public int DemandBracket { get; set; }
        public int Stock { get; set; }
        public int Demand { get; set; }
        public bool Consumer { get; set; }
        public bool Producer { get; set; }
        public bool Rare { get; set; }
    }
}
