namespace EliteJournalReader.Events
{
    public class BackPackOldEvent : JournalEvent<BackPackOldEvent.BackPackOldEventArgs>
    {
        public BackPackOldEvent() : base("BackPack") { }

        public class BackPackOldEventArgs : JournalEventArgs
        {
        }
    }
}
