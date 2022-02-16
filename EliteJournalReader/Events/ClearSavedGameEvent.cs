namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class ClearSavedGameEvent : JournalEvent<ClearSavedGameEvent.ClearSavedGameEventArgs>
    {
        public ClearSavedGameEvent() : base("ClearSavedGame") { }

        public class ClearSavedGameEventArgs : JournalEventArgs
        {
            public string FID { get; set; }
            public string Name { get; set; }
        }
    }
}
