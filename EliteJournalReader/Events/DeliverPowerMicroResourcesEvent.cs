using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public struct MicroResource
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
    }

    public sealed class DeliverPowerMicroResourcesEvent : JournalEvent<DeliverPowerMicroResourcesEvent.DeliverPowerMicroResourcesEventArgs>
    {
        public DeliverPowerMicroResourcesEvent() : base("DeliverPowerMicroResources") { }

        public class DeliverPowerMicroResourcesEventArgs : JournalEventArgs
        {
            public int TotalCount { get; set; }
            public IReadOnlyCollection<MicroResource> MicroResources { get; set; }
            public long MarketID { get; set; }

        }
    }
}
