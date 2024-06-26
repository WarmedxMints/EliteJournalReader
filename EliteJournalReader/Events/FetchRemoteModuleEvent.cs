namespace EliteJournalReader.Events
{
    //When written: when requesting a module is transferred from storage at another station
    //Parameters:
    //�	StorageSlot
    //�	StoredItem
    //�	ServerId
    //�	TransferCost
    //�	Ship
    //�	ShipId
    //�	TransferTime: (in seconds)
    public class FetchRemoteModuleEvent : JournalEvent<FetchRemoteModuleEvent.FetchRemoteModuleEventArgs>
    {
        public FetchRemoteModuleEvent() : base("FetchRemoteModule") { }

        public class FetchRemoteModuleEventArgs : JournalEventArgs
        {
            public string StorageSlot { get; set; }
            public string Ship { get; set; }
            public long ShipID { get; set; }
            public string StoredItem { get; set; }
            public string StoredItem_Localised { get; set; }
            public string ServerId { get; set; }
            public long TransferCost { get; set; }
            public long TransferTime { get; set; }
        }
    }
}
