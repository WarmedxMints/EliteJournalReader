using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public class ProspectedAsteroidEvent : JournalEvent<ProspectedAsteroidEvent.ProspectedAsteroidEventArgs>
    {
        public ProspectedAsteroidEvent() : base("ProspectedAsteroid") { }

        public class ProspectedAsteroidEventArgs : JournalEventArgs
        {
            public IReadOnlyList<ScanItemComponent> Materials { get; set; }
            public string Content { get; set; }
            public string MotherlodeMaterial { get; set; }
            public double Percentage { get; set; }
            public double Remaining { get; set; }
        }
    }
}
