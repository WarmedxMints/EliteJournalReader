namespace EliteJournalReader.Events
{
    public class FSSBodySignalsEvent : JournalEvent<FSSBodySignalsEvent.FSSBodySignalsEventArgs>
    {
        public FSSBodySignalsEvent() : base("FSSBodySignals") { }

        public class FSSBodySignalsEventArgs : JournalEventArgs
        {
            public string BodyName { get; set; }

            public int BodyID { get; set; }

            public long SystemAddress { get; set; }

            public FSSSignal[] Signals { get; set; }
        }
    }
}
