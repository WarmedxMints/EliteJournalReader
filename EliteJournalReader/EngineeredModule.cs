namespace EliteJournalReader
{
    public class EngineeredModule
    {
        public string Engineer { get; set; }
        public ulong EngineerID { get; set; }
        public ulong BlueprintID { get; set; }
        public string BlueprintName { get; set; }
        public int Level { get; set; }
        public double Quality { get; set; }
        public string ExperimentalEffect { get; set; }
        public EngineeringModifiers[] Modifiers { get; set; }

        public EngineeredModule Clone() => (EngineeredModule)MemberwiseClone();
    }
}
