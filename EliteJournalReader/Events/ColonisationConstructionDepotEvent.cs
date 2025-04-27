using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public sealed class ColonisationConstructionDepotEvent : JournalEvent<ColonisationConstructionDepotEvent.ColonisationConstructionDepotEventArgs>
    {
        public ColonisationConstructionDepotEvent() : base("ColonisationConstructionDepot") { }

        public class ColonisationConstructionDepotEventArgs : JournalEventArgs 
        { 
            public long MarketID { get; set; }
            public double ConstructionProgress { get; set; }
            public bool ConstructionComplete { get; set; }
            public bool ConstructionFailed { get; set; }
            public IReadOnlyCollection<ColonisationResource> ResourcesRequired { get; set; }
        }
    }

    public record ColonisationResource(string Name, string Name_Localised, int RequiredAmount, int ProvidedAmount, int Payment);
}
