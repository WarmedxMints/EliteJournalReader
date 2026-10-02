namespace EliteJournalReader.Events
{
    public sealed class CompleteConstructionEvent : JournalEvent<CompleteConstructionEvent.CompleteConstructionEventEventArgs>
    {
        public CompleteConstructionEvent() : base("CompleteConstruction") { }

        public sealed class CompleteConstructionEventEventArgs : JournalEventArgs
        {
        }
    }
}
