using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public class FCMaterialsEvent : JournalEvent<FCMaterialsEvent.FCMaterialsEventEventArgs>
    {
        public FCMaterialsEvent() : base("FCMaterials") { }

        public class FCMaterialsEventEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string CarrierName { get; set; }
            public string CarrierID { get; set; }
            public List<FCMaterialItem> Items { get; set; }
        }
    }
}
