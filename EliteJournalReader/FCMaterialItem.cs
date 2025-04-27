namespace EliteJournalReader
{
    public sealed class FCMaterialItem
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int Demand { get; set; }
    }
}
