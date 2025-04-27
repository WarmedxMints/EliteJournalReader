using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class MaterialsEvent : JournalEvent<MaterialsEvent.MaterialsEventArgs>
    {
        public MaterialsEvent() : base("Materials") { }

        public class MaterialsEventArgs : JournalEventArgs
        {
            public IReadOnlyList<Material> Raw { get; set; }
            public IReadOnlyList<Material> Manufactured { get; set; }
            public IReadOnlyList<Material> Encoded { get; set; }
        }
    }
}
