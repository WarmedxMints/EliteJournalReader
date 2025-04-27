namespace EliteJournalReader
{
    public class BackPackChangeItem
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public long OwnerID { get; set; } = 0;
        public ulong MissionID { get; set; } = 0;
        public int Count { get; set; }
        public string Type { get; set; }
    }
}
