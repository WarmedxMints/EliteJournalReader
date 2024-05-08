namespace EliteJournalReader.Events
{
    public class NavRouteClearEvent : JournalEvent<NavRouteClearEvent.NavRoutClearEventArgs>
    {
        public NavRouteClearEvent() : base("NavRouteClear") { }

        public class NavRoutClearEventArgs : JournalEventArgs
        {
        }
    }
}
