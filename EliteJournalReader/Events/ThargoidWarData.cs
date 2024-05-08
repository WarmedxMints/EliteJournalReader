namespace EliteJournalReader.Events
{
    public sealed class ThargoidWarData
    {
        public string CurrentState { get; set; }
        public string NextStateSuccess { get; set; }
        public string NextStateFailure { get; set; }
        public bool SucSuccessStateReached { get; set; }
        public int WarProgress { get; set; }
        public int RemainingPorts { get; set; }
        public string EstimatedRemainingTime { get; set; }
    }
}
