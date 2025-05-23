using Newtonsoft.Json;

namespace EliteJournalReader.Events
{
    //When written: when selecting a star system to jump to
    //Note, when following a multi-jump route, this will typically appear for the next star, 
    //during a jump, ie after �StartJump� but before the �FSDJump�
    //Parameters:
    //�	Starsystem
    //�	Name

    public class FSDTargetEvent : JournalEvent<FSDTargetEvent.FSDTargetEventArgs>
    {
        public FSDTargetEvent() : base("FSDTarget") { }

        public class FSDTargetEventArgs : JournalEventArgs
        {
            public long SystemAddress { get; set; }
            public string Name { get; set; }
            public int RemainingJumpsInRoute { get; set; }
            [JsonConverter(typeof(ExtendedStringEnumConverter<StarType>))]
            public StarType StarClass { get; set; }
        }
    }
}
