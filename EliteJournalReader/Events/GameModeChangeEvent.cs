namespace EliteJournalReader.Events
{
    public sealed class GameModeChangeEvent : JournalEvent<GameModeChangeEvent.GameModeChangeEventArgs>
    {
        public GameModeChangeEvent() : base("GameModeChange") { }

        public class GameModeChangeEventArgs : JournalEventArgs
        {
            public string GameMode { get; set; }
        }
    }
}
