using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: at startup
    //Parameters:
    //•	Active: (array of objects)
    //•	Failed: (array of objects)
    //•	Complete: (array of objects)

    //Each object contains:
    //•	MissionID
    //•	Name
    //•	PassengerMission: bool
    //•	Expires: time left in seconds
    public class MissionsEvent : JournalEvent<MissionsEvent.MissionsEventArgs>
    {
        public MissionsEvent() : base("Missions") { }

        public class MissionsEventArgs : JournalEventArgs
        {
            public IReadOnlyList<Mission> Active { get; set; }
            public IReadOnlyList<Mission> Failed { get; set; }
            public IReadOnlyList<Mission> Complete { get; set; }

        }
    }
}
