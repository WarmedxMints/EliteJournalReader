namespace EliteJournalReader.Events
{
    //When written: when collecting powerplay commodities for delivery
    //Parameters:
    //•	Power: name of power
    //•	Type: type of commodity
    //•	Count: number of units
    public class PowerplayCollectEvent : JournalEvent<PowerplayCollectEvent.PowerplayCollectEventArgs>
    {
        public PowerplayCollectEvent() : base("PowerplayCollect") { }

        public class PowerplayCollectEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public int Count { get; set; }

            public string GetTypeCollected()
            {
                if(string.IsNullOrEmpty(Type_Localised))
                {
                    return Type;
                }
                return Type_Localised;
            }
        }
    }
}
