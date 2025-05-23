using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: player was killed
    //Parameters: 
    //�	KillerName
    //�	KillerShip
    //�	KillerRank
    //When written: player was killed by a wing
    //Parameters:
    //�	Killers: a JSON array of objects containing player name, ship, and rank
    public class DiedEvent : JournalEvent<DiedEvent.DiedEventArgs>
    {
        public DiedEvent() : base("Died") { }

        public class DiedEventArgs : JournalEventArgs
        {
            public string KillerName { get; set; }
            public string KillerShip { get; set; }
            public string KillerRank { get; set; }
            public struct Killer
            {
                public string Name;
                public string Ship;
                public string Rank;
            }

            public override void PostProcess(JObject evt)
            {
                if (evt == null) return;
                string killerName = evt.Value<string>("KillerName");
                if (!string.IsNullOrEmpty(killerName))
                {
                    // it was an individual
                    Killers = new Killer[1]
                    {
                        new() {
                            Name = killerName,
                            Ship = evt.Value<string>("KillerShip"),
                            Rank = evt.Value<string>("KillerRank")
                        }
                    };
                }
            }

            public IReadOnlyList<Killer> Killers { get; set; }
        }
    }
}
