using System.Collections.Generic;
using System.Text;

namespace EliteJournalReader.Events
{
    //    When written: player is awarded a bounty for a kill
    //Parameters: 
    //�	Rewards: an array of Faction names and the Reward values, as the target can have multiple bounties payable by different factions
    //�	VictimFaction: the victim�s faction
    //�	TotalReward
    //�	SharedWithOthers: if credit for the kill is shared with other players, this has the number of other players involved
    public class BountyEvent : JournalEvent<BountyEvent.BountyEventArgs>
    {
        public BountyEvent() : base("Bounty") { }

        public class BountyEventArgs : JournalEventArgs
        {
            public class FactionReward
            {
                public string Faction { get; set; }
                public int Reward { get; set; }
            }
            public string Target { get; set; }
            public string Target_Localised { get; set; }
            public string PilotName { get; set; }
            public string Faction { get; set; }

            public List<FactionReward> Rewards { get; set; }
            public string VictimFaction { get; set; }
            public string VictimFaction_Localised { get; set; }
            public int Reward { get; set; }
            public int TotalReward { get; set; }
            public int SharedWithOthers { get; set; } = 0;

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Time   :{Timestamp}");
                sb.AppendLine($"Target :{Target}");
                sb.AppendLine($"Victim :{VictimFaction}");
                sb.AppendLine($"Reward :{TotalReward}");

                return sb.ToString();
            }
        }
    }
}
