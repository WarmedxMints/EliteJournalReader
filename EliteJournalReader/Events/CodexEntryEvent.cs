using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: when a new discovery is added to the Codex
    //Parameters:
    //•	EntryID: an ID number
    //•	Name: string (+localisation)
    //•	SubCategory: string (+localisation)
    //•	Category: string (+localisation)
    //•	Region: string
    //•	System: string
    //•	SystemAddress
    //•	NearestDestination: name
    //•	IsNewEntry: bool
    //•	NewTraitsDiscovered: bool
    //•	Traits: [array of strings]
    //
    //The IsNewEntry and NewTraitsDiscovered fields are optional depending on the results of the scan, 
    //and the Traits field is only available for entries that have unlocked traits.
    public class CodexEntryEvent : JournalEvent<CodexEntryEvent.CodexEntryEventArgs>
    {
        public CodexEntryEvent() : base("CodexEntry") { }

        public class CodexEntryEventArgs : JournalEventArgs
        {
            public long EntryID { get; set; }
            public long BodyID { get; set; }
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string SubCategory { get; set; }
            public string SubCategory_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            [JsonConverter(typeof(GalaxyRegionTypeConvertor))]
            public GalacticRegions Region { get; set; }
            public string Region_Localised { get; set; }
            public string System { get; set; }
            public long SystemAddress { get; set; }
            public string NearestDestination { get; set; }
            public string NearestDestination_Localised { get; set; }
            public bool IsNewEntry { get; set; } = false;
            public int? VoucherAmount { get; set; }
            public bool NewTraitsDiscovered { get; set; } = false;
            public IReadOnlyList<string> Traits { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        private class GalaxyRegionTypeConvertor : StringEnumConverter
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (string.IsNullOrEmpty(reader.Value?.ToString()))
                    return GalacticRegions.Unknown;

                if (reader.Value is string s)
                {
                    return Enum.Parse<GalacticRegions>(s.Replace("$", "").Replace(";", ""));
                }
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
        }
    }
}
