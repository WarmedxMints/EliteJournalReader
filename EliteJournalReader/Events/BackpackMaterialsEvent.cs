using System.Collections.Generic;

namespace EliteJournalReader.Events
{
    public class BackPackMaterialsEvent : JournalEvent<BackPackMaterialsEvent.BackpackMaterialsEventArgs>
    {
        public BackPackMaterialsEvent() : base("BackPackMaterials") { }

        public class BackpackMaterialsEventArgs : JournalEventArgs
        {
            public List<Material> Items { get; set; }

            public List<Material> Components { get; set; }

            public List<Material> Consumables { get; set; }

            public List<Material> Data { get; set; }
        }
    }
}