namespace EliteJournalReader
{
    public class Mission
    {
        public ulong MissionID { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public int Expires { get; set; }
    }
}