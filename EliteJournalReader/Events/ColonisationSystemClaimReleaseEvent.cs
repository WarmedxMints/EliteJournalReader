namespace EliteJournalReader.Events
{
    public sealed class ColonisationSystemClaimReleaseEvent : JournalEvent<ColonisationSystemClaimReleaseEvent.ColonisationSystemClaimReleaseEventArgs>
    {
        public ColonisationSystemClaimReleaseEvent() : base("ColonisationSystemClaimRelease") { }

        public class ColonisationSystemClaimReleaseEventArgs : JournalEventArgs
        {
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
        }
    }
}
