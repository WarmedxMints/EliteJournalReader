using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteJournalReader.Events
{
    //When written: at startup, or when being resurrected at a station
    //Parameters:
    //	StarSystem: name of destination starsystem
    //	StarPos: star position, as a Json array [x, y, z], in light years
    //	Body: stars body name
    //	BodyType
    //	Docked: true (if docked)
    //	Latitude (if landed)
    //	Longitude (if landed)
    //	StationName: station name, (if docked)
    //	StationType: (if docked)
    //	Faction: star system controlling faction
    //	FactionState
    //	SystemAllegiance
    //	SystemEconomy
    //	SystemGovernment
    //	SystemSecurity
    //	Factions: an array with info on local minor factions (similar to FSDJump)
    //If the player is pledged to a Power in Powerplay, and the star system is involved in powerplay,
    //	Powers: a json array with the names of any powers contesting the system, or the name of the controlling power
    //	PowerplayState: the system state  one of("InPrepareRadius", "Prepared", "Exploited", "Contested", "Controlled", "Turmoil", "HomeSystem")
    public class LocationEvent : JournalEvent<LocationEvent.LocationEventArgs>
    {
        public LocationEvent() : base("Location") { }

        public class LocationEventArgs : JournalEventArgs
        {

            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }

            [JsonConverter(typeof(SystemPositionConverter))]
            public SystemPosition StarPos { get; set; }

            public string Body { get; set; }
            public long BodyID { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public BodyType BodyType { get; set; }

            public bool Docked { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }
            public string SystemFaction { get; set; }
            public string FactionState { get; set; }
            public string SystemAllegiance { get; set; }
            public string SystemEconomy { get; set; }
            public string SystemEconomy_Localised { get; set; }
            public string SystemGovernment { get; set; }
            public string SystemGovernment_Localised { get; set; }
            public string SystemSecurity { get; set; }
            public string SystemSecurity_Localised { get; set; }
            public long? Population { get; set; }
            public string[] Powers { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public PowerplayState PowerplayState { get; set; }

            public List<Faction> Factions { get; set; }
        }
    }
}
