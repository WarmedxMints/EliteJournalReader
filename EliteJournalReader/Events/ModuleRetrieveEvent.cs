namespace EliteJournalReader.Events
{
    //When Written: when fetching a previously stored module
    //Parameters:
    //�	Slot
    //�	Ship
    //�	ShipID
    //�	RetrievedItem
    //�	EngineerModifications: name of modification blueprint, if any
    //�	SwapOutItem (if slot was not empty)
    //�	Cost
    public class ModuleRetrieveEvent : JournalEvent<ModuleRetrieveEvent.ModuleRetrieveEventArgs>
    {
        public ModuleRetrieveEvent() : base("ModuleRetrieve") { }

        public class ModuleRetrieveEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string Slot { get; set; }
            public string Ship { get; set; }
            public long ShipID { get; set; }
            public string RetrievedItem { get; set; }
            public string RetrievedItem_Localised { get; set; }
            public string EngineerModifications { get; set; }
            public int Level { get; set; }
            public double Quality { get; set; }
            public bool Hot { get; set; }
            public string SwapOutItem { get; set; }
            public string SwapOutItem_Localised { get; set; }
            public int Cost { get; set; }
        }
    }
}
