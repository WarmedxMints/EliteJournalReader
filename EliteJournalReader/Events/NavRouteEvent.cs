using Newtonsoft.Json;

namespace EliteJournalReader.Events
{
    public class NavRouteEvent : JournalEvent<NavRouteEvent.NavRouteEventArgs>
    {
        public NavRouteEvent() : base("NavRoute") { }

        public class NavRouteEventArgs : JournalEventArgs
        {
            public string StarSystem { get; set; }

            public long SystemAddress { get; set; }

            [JsonConverter(typeof(SystemPositionConverter))]
            public SystemPosition StarPos { get; set; }

            public string StarClass { get; set; }
        }
    }
}