using System.Collections.Generic;
using System.Linq;

namespace EliteJournalReader
{
    public class Faction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
        public string Government { get; set; }
        public string Government_Localised { get; set; }
        public double Influence { get; set; }
        public string Allegiance { get; set; }
        public float MyReputation { get; set; }
        public bool SquadronFaction { get; set; } = false;
        public bool HappiestSystem { get; set; } = false;
        public bool HomeSystem { get; set; } = false;

        public IReadOnlyList<FactionStateChange> PendingStates { get; set; } = [];
        public IReadOnlyList<FactionStateChange> RecoveringStates { get; set; } = [];
        public IReadOnlyList<FactionStateChange> ActiveStates { get; set; } = [];

        public override bool Equals(object obj) => Equals(obj as Faction);

        public static implicit operator Faction(string s)
        {
            return new Faction() { Name = s };
        }
        public bool Equals(Faction that) => that != null
            && that.Name?.Equals(Name) == true
            && that.FactionState?.Equals(FactionState) == true
            && that.Government?.Equals(Government) == true
            && that.Influence == Influence
            && that.Allegiance?.Equals(Allegiance) == true
            && that.MyReputation.Equals(MyReputation) == true
            && that.SquadronFaction == SquadronFaction
            && that.HappiestSystem == HappiestSystem
            && that.HomeSystem == HomeSystem
            && that.PendingStates.SequenceEqual(PendingStates) == true
            && that.RecoveringStates.SequenceEqual(RecoveringStates) == true
            && that.ActiveStates.SequenceEqual(ActiveStates) == true;

        public bool BGSDataUpdated(Faction that) => that != null
            && that.Name?.Equals(Name) == true
            && that.FactionState?.Equals(FactionState) == true
            && that.Influence == Influence
            && that.MyReputation.Equals(MyReputation) == true
            && that.PendingStates.SequenceEqual(PendingStates) == true
            && that.RecoveringStates.SequenceEqual(RecoveringStates) == true
            && that.ActiveStates.SequenceEqual(ActiveStates) == true;

        public override int GetHashCode()
        {
            //https://stackoverflow.com/a/892640/3131828
            unchecked
            {
                int h = 23;
                h *= 31 + (Name?.GetHashCode() ?? 0);
                h *= 31 + (FactionState?.GetHashCode() ?? 0);
                h *= 31 + (Government?.GetHashCode() ?? 0);
                h *= 31 + Influence.GetHashCode();
                h *= 31 + (Allegiance?.GetHashCode() ?? 0);
                h *= 31 + (MyReputation.GetHashCode());
                h *= 31 + SquadronFaction.GetHashCode();
                h *= 31 + HappiestSystem.GetHashCode();
                h *= 31 + HomeSystem.GetHashCode();
                h *= 31 + (PendingStates?.GetHashCode() ?? 0);
                h *= 31 + (RecoveringStates?.GetHashCode() ?? 0);
                h *= 31 + (ActiveStates?.GetHashCode() ?? 0);

                return h;
            }
        }

        public Faction Clone() => (Faction)MemberwiseClone();
    }

    public record FactionStateChange(string State, int Trend);
}
