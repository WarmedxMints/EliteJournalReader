namespace EliteJournalReader.Events
{
    //When written: when launching a fighter
    //Parameters:
    //�	Loadout
    //�	PlayerControlled: whether player is controlling the fighter from launch
    public class LaunchFighterEvent : JournalEvent<LaunchFighterEvent.LaunchFighterEventArgs>
    {
        public LaunchFighterEvent() : base("LaunchFighter") { }

        public class LaunchFighterEventArgs : JournalEventArgs
        {
            public string Loadout { get; set; }
            public bool PlayerControlled { get; set; }
            public long ID { get; set; }
        }
    }
}
