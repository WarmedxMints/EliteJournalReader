using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public sealed class RequestPowerMicroResourcesEvent : JournalEvent<RequestPowerMicroResourcesEvent.RequestPowerMicroResourcesEventArgs>
    {
        public RequestPowerMicroResourcesEvent() : base("RequestPowerMicroResources") { }

        public class RequestPowerMicroResourcesEventArgs : JournalEventArgs
        {
            public int TotalCount { get; set; }
            public IReadOnlyCollection<MicroResource> MicroResources { get; set; }
            public long MarketID { get; set; }
        }
    }
}
