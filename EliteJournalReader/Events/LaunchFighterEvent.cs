using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when launching a fighter
    //Parameters:
    //�	Loadout
    //�	PlayerControlled: whether player is controlling the fighter from launch
    public class LaunchFighterEvent : JournalEvent<LaunchFighterEvent.LaunchFighterEventArgs>
    {
        public LaunchFighterEvent() : base("LaunchFighter") { }

        public class LaunchFighterEventArgs : JournalEventArgs
        {
            public string Loadout { get; set; }
            public string Name { get; set; }
            public string _Localised { get; set; }
            public bool PlayerControlled { get; set; }
            public long ID { get; set; }

            public override void PostProcess(JObject evt)
            {
                var name = evt[""].Value<string>();

                if (string.IsNullOrEmpty(name))
                    return;

                Name = name;
            }
        }
    }
}
