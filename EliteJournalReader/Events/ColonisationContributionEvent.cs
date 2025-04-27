using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //ColonisationContribution
    public sealed class ColonisationContributionEvent : JournalEvent<ColonisationContributionEvent.ColonisationContributionEventArgs>
    {
        public ColonisationContributionEvent() : base("ColonisationContribution") { }

        public class ColonisationContributionEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public IReadOnlyList<Contribution> Contributions { get; set; }
        }
    }

    public record Contribution(string Name, string Name_Localised, int Amount);
}
