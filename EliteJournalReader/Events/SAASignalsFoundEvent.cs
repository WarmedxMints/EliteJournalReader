using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: when using SAA scanner on a planet or rings
    //Parameters:
    //�	SystemAddress
    //�	BodyName
    //�	BodyID
    //�	Signals: (array)
    //  o   Type
    //  o   Count
    public partial class SAASignalsFoundEvent : JournalEvent<SAASignalsFoundEvent.SAASignalsFoundEventArgs>
    {
        public SAASignalsFoundEvent() : base("SAASignalsFound") { }

        public class SAASignalsFoundEventArgs : JournalEventArgs
        {
            public long SystemAddress { get; set; }
            public string BodyName { get; set; }
            public long BodyID { get; set; }
            public IReadOnlyList<SAASignal> Signals { get; set; }
            public IReadOnlyList<SAAGenus> Genuses { get; set; }
        }
    }
}
