using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: liftoff from a landing pad in a station, outpost or settlement
    //Parameters:
    //�	StationName: name of station
    public class UndockedEvent : JournalEvent<UndockedEvent.UndockedEventArgs>
    {
        public UndockedEvent() : base("Undocked") { }

        public class UndockedEventArgs : JournalEventArgs
        {
            public override void Initialize(JObject evt)
            {
                base.Initialize(evt);
                StationName = evt.Value<string>("StationName");
            }

            public string StationName { get; set; }
        }
    }
}
