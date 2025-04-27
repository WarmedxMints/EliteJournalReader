namespace EliteJournalReader.Events
{
    //When written: when delivering powerplay commodities
    //Parameters:
    //•	Power
    //•	Type
    //•	Count
    public class PowerplayDeliverEvent : JournalEvent<PowerplayDeliverEvent.PowerplayDeliverEventArgs>
    {
        public PowerplayDeliverEvent() : base("PowerplayDeliver") { }

        public class PowerplayDeliverEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public int Count { get; set; }

            public string GetTypeCollected()
            {
                if (string.IsNullOrEmpty(Type_Localised))
                {
                    return Type;
                }
                return Type_Localised;
            }
        }
    }
}
