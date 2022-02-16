using Newtonsoft.Json;

namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class StartJumpEvent : JournalEvent<StartJumpEvent.StartJumpEventArgs>
    {
        public StartJumpEvent() : base("StartJump") { }

        public class StartJumpEventArgs : JournalEventArgs
        {
            [JsonConverter(typeof(ExtendedStringEnumConverter<JumpType>))]
            public JumpType JumpType { get; set; }
            public string StarClass { get; set; }
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
        }
    }
}
