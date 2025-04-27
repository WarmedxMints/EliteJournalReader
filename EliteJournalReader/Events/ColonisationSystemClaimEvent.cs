namespace EliteJournalReader.Events
{
    public sealed class ColonisationSystemClaimEvent : JournalEvent<ColonisationSystemClaimEvent.ColonisationSystemClaimEventArgs>
    {
        public ColonisationSystemClaimEvent() : base("ColonisationSystemClaim") { }

        public class ColonisationSystemClaimEventArgs : JournalEventArgs
        {
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
        }
    }
}
