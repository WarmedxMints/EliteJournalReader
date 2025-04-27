using System.Collections.Generic;

namespace EliteJournalReader
{
    public class SuitModule
    {
        public string SlotName { get; set; }
        public string ModuleName { get; set; }
        public long SuitModuleID { get; set; }
        public string Class { get; set; }
        public IReadOnlyList<string> WeaponMods { get; set; }
    }
}