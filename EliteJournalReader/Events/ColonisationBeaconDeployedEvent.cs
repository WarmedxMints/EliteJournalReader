namespace EliteJournalReader.Events
{
    public sealed class ColonisationBeaconDeployedEvent : JournalEvent<ColonisationBeaconDeployedEvent.ColonisationBeaconDeployedEventArgs>
    {
        public ColonisationBeaconDeployedEvent() : base("ColonisationBeaconDeployed") { }

        public class ColonisationBeaconDeployedEventArgs : JournalEventArgs { }
    }
}
