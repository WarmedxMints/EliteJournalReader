using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the �reboot repair� function is used
    //Parameters:
    //�	Modules: JSON array of names of modules repaired
    public class RebootRepairEvent : JournalEvent<RebootRepairEvent.RebootRepairEventArgs>
    {
        public RebootRepairEvent() : base("RebootRepair") { }

        public class RebootRepairEventArgs : JournalEventArgs
        {
            public override void Initialize(JObject evt)
            {
                base.Initialize(evt);
                Modules = evt.Value<JArray>("Modules").Values<string>().ToArray();
            }

            public string[] Modules { get; set; }
        }
    }
}
