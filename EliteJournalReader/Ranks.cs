using System.ComponentModel;

namespace EliteJournalReader
{
    public enum CombatRank
    {
        Harmless = 0,
        [Description("Mostly Harmless")] MostlyHarmless,
        Novice,
        Competent,
        Expert,
        Master,
        Dangerous,
        Deadly,
        Elite,
        [Description("Elite I")]
        EliteI,
        [Description("Elite II")]
        EliteII,
        [Description("Elite III")]
        EliteIII,
        [Description("Elite IV")]
        EliteIV,
        [Description("Elite V")]
        EliteV
    }

    public enum TradeRank
    {
        Penniless = 0,
        [Description("Mostly Penniless")] MostlyPenniless,
        Peddler,
        Dealer,
        Merchant,
        Broker,
        Entrepreneur,
        Tycoon,
        Elite,
        [Description("Elite I")]
        EliteI,
        [Description("Elite II")]
        EliteII,
        [Description("Elite III")]
        EliteIII,
        [Description("Elite IV")]
        EliteIV,
        [Description("Elite V")]
        EliteV
    }

    public enum ExplorationRank
    {
        Aimless = 0,
        [Description("Mostly Aimless")] MostlyAimless,
        Scout,
        Surveyor,
        Explorer,
        Pathfinder,
        Ranger,
        Pioneer,
        Elite,
        [Description("Elite I")]
        EliteI,
        [Description("Elite II")]
        EliteII,
        [Description("Elite III")]
        EliteIII,
        [Description("Elite IV")]
        EliteIV,
        [Description("Elite V")]
        EliteV
    }

    public enum MercenaryRank
    {
        Defenceless = 0,
        [Description("Mostly Defenceless")] MostlyDefenceless,
        Rookie,
        Soldier,
        Gunslinger,
        Warrior,
        Gladiator,
        Deadeye,
        Elite,
        [Description("Elite I")]
        EliteI,
        [Description("Elite II")]
        EliteII,
        [Description("Elite III")]
        EliteIII,
        [Description("Elite IV")]
        EliteIV,
        [Description("Elite V")]
        EliteV
    }

    public enum ExobiologistRank
    {
        Directionless = 0,
        [Description("Mostly Directionless")] MostlyDirectionless,
        Compiler,
        Collector,
        Cataloguer,
        Taxonomist,
        Ecologist,
        Geneticist,
        Elite,
        [Description("Elite I")]
        EliteI,
        [Description("Elite II")]
        EliteII,
        [Description("Elite III")]
        EliteIII,
        [Description("Elite IV")]
        EliteIV,
        [Description("Elite V")]
        EliteV
    }
    public enum FederationRank
    {
        None = 0,
        Recruit,
        Cadet,
        Midshipman,
        PettyOfficer,
        ChiefPettyOfficer,
        WarrantOfficer,
        Ensign,
        Lieutenant,
        LtCommander,
        PostCommander,
        PostCaptain,
        RearAdmiral,
        ViceAdmiral,
        Admiral
    }

    public enum EmpireRank
    {
        None = 0,
        Outsider,
        Serf,
        Master,
        Squire,
        Knight,
        Lord,
        Baron,
        Viscount,
        Count,
        Earl,
        Marquis,
        Duke,
        Prince,
        King
    }

    public enum CQCRank
    {
        Helpless = 0,
        MostlyHelpless,
        Amateur,
        SemiProfessional,
        Professional,
        Champion,
        Hero,
        Legend,
        Elite,
        EliteI,
        EliteII,
        EliteIII,
        EliteIV,
        EliteV
    }
}
