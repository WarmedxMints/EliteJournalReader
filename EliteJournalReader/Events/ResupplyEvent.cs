namespace EliteJournalReader.Events
{
    public class ResupplyEvent : JournalEvent<ResupplyEvent.ResupplyEventArgs>
    {
        public ResupplyEvent() : base("Resupply") { }

        public class ResupplyEventArgs : JournalEventArgs
        {

        }
    }
}
