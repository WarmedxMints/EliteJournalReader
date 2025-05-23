using System.Collections.Generic;
using System.Text;

namespace EliteJournalReader.Events
{
    //When Written: when a mission is completed
    //Parameters:
    //�	Name: mission type
    //�	Faction: faction name
    //�	MissionID
    //Optional parameters (depending on mission type)
    //�	Commodity
    //�	Count
    //�	Target
    //�	TargetType
    //�	TargetFaction
    //�	Reward: value of reward
    //�	Donation: donation offered (for altruism missions)
    //�	PermitsAwarded:[] (names of any permits awarded, as a JSON array)
    //�	MaterialsReward:[] (name, category and count)
    //�	FactionEffects: array of records
    //    o   Faction
    //    o   Effects: array of Effect and Trend value pairs
    //    o   Influence: array of SystemAddress and Trend value pairs
    //    o   Reputation: Trend value

    public class MissionCompletedEvent : JournalEvent<MissionCompletedEvent.MissionCompletedEventArgs>
    {
        public MissionCompletedEvent() : base("MissionCompleted") { }

        public class MissionCompletedEventArgs : JournalEventArgs
        {
            public struct CommodityRewardItem
            {
                public string Name;
                public string Name_Localised;
                public int Count;
            }

            public struct MaterialRewardItem
            {
                public string Name;
                public string Name_Localised;
                public string Category;
                public string Category_Localised;
                public int Count;
            }

            public struct FactionEffectsDesc
            {
                public string Faction;
                public FactionEffect[] Effects;
                public FactionInfluenceEffect[] Influence;
                public string Reputation;
            }

            public struct FactionEffect
            {
                public string Effect;
                public string Effect_Localised;
                public string Trend;
            }

            public struct FactionInfluenceEffect
            {
                public long SystemAddress;
                public string Trend;
                public string Influence;
            }

            public string Faction { get; set; }
            public string Name { get; set; }
            public string LocalisedName { get; set; }
            public ulong MissionID { get; set; }
            public string Commodity { get; set; }
            public string Commodity_Localised { get; set; }
            public int Count { get; set; }
            public string Target { get; set; }
            public string TargetType { get; set; }
            public string TargetFaction { get; set; }
            public int Reward { get; set; }
            public string Donation { get; set; }
            public int Donated { get; set; }
            public IReadOnlyList<string> PermitsAwarded { get; set; }
            public IReadOnlyList<CommodityRewardItem> CommodityReward { get; set; }
            public IReadOnlyList<MaterialRewardItem> MaterialsReward { get; set; }
            public IReadOnlyList<FactionEffectsDesc> FactionEffects { get; set; }
            public string DestinationSystem { get; set; }
            public string DestinationStation { get; set; }
            public string DestinationSettlement { get; set; }
            public string NewDestinationStation { get; set; }
            public string NewDestinationSystem { get; set; }
            public int? KillCount { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();

                sb.AppendLine($"Time   :{Timestamp}");
                sb.AppendLine($"Giver   :{Faction}");
                sb.AppendLine($"Target :{TargetFaction}");

                return sb.ToString();
            }
        }
    }
}
