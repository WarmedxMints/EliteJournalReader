using Newtonsoft.Json;

namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class CarrierCrewServicesEvent : JournalEvent<CarrierCrewServicesEvent.CarrierCrewServicesEventArgs>
    {
        public CarrierCrewServicesEvent() : base("CarrierCrewServices") { }

        public class CarrierCrewServicesEventArgs : JournalEventArgs
        {
            public ulong CarrierID { get; set; }
            [JsonConverter(typeof(ExtendedStringEnumConverter<CarrierCrewOperation>))]
            public CarrierCrewOperation Operation { get; set; }
            [JsonConverter(typeof(ExtendedStringEnumConverter<CarrierCrewRole>))]
            public CarrierCrewRole CrewRole { get; set; }
            public string CrewName { get; set; }
            public string CarrierType { get; set; }
        }
    }
}
