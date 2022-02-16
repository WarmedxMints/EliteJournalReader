namespace EliteJournalReader.Events
{
    public class WingInviteEvent : JournalEvent<WingInviteEvent.WingInviteEventArgs>
    {
        public WingInviteEvent() : base("WingInvite") { }

        public class WingInviteEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
        }
    }
}
