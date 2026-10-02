namespace EliteJournalReader.Events
{
    //When written: when contributing materials to a "research" community goal
    //Parameters:
    //•	Name: material name
    //•	Category
    //•	Count
    public class SearchAndRescueEvent : JournalEvent<SearchAndRescueEvent.SearchAndRescueEventArgs>
    {
        public SearchAndRescueEvent() : base("SearchAndRescue") { }

        public class SearchAndRescueEventArgs : JournalEventArgs
        {
            public ulong MarketID { get; set; }
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
            public int Reward { get; set; }
        }
    }
}
