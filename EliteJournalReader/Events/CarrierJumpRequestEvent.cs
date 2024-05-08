using System;

namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //�	Name: commander name
    public class CarrierJumpRequestEvent : JournalEvent<CarrierJumpRequestEvent.CarrierJumpRequestEventArgs>
    {
        public CarrierJumpRequestEvent() : base("CarrierJumpRequest") { }

        public class CarrierJumpRequestEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string SystemName { get; set; }
            public long SystemID { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }
            public long BodyID { get; set; }
            public DateTime DepartureTime { get; set; }
        }
    }
}
