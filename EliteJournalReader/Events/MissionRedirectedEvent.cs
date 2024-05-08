using System.Text;

namespace EliteJournalReader.Events
{
    //When written: when a mission is updated with a new destination
    //Parameters
    //�	MissionID
    //�	MissionName
    //�	NewDestinationStation
    //�	OldDestinationStation
    //�	NewDestinationSystem
    //�	OldDestinationSystem

    public class MissionRedirectedEvent : JournalEvent<MissionRedirectedEvent.MissionRedirectedEventArgs>
    {
        public MissionRedirectedEvent() : base("MissionRedirected") { }

        public class MissionRedirectedEventArgs : JournalEventArgs
        {
            public long MissionID { get; set; }
            public string Name { get; set; }
            public string LocalisedName { get; set; }
            public string MissionName { get; set; }
            public string NewDestinationStation { get; set; }
            public string OldDestinationStation { get; set; }
            public string NewDestinationSystem { get; set; }
            public string OldDestinationSystem { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Time   :{Timestamp}");
                sb.AppendLine($"Name  :{Name}");

                return sb.ToString();
            }
        }
    }
}
