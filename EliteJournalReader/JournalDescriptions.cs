using System.ComponentModel;

namespace EliteJournalReader
{

    public enum ScanType
    {
        Unknown,
        Basic,
        Detailed,
        AutoScan,
        NavBeacon,
        NavBeaconDetail
    }

    public enum StarType
    {
        Unknown,

        // main sequence
        [Description("O Class")]
        O,
        [Description("B Class")]
        B,
        [Description("A Class")]
        A,
        [Description("F Class")]
        F,
        [Description("G Class")]
        G,
        [Description("K Class")]
        K,
        [Description("M Class")]
        M,
        [Description("L Class")]
        L,
        [Description("T Class")]
        T,
        [Description("Y Class")]
        Y,

        // proto stars
        [Description("TTS Proto Star")]
        TTS,
        [Description("AEBE Proto Star")]
        AeBe,

        // wolf-rayet
        [Description("W Wolf-Raylet")]
        W,
        [Description("WN Wolf-Raylet")]
        WN,
        [Description("WNC Wolf-Raylet")]
        WNC,
        [Description("WC Wolf-Raylet")]
        WC,
        [Description("WO Wolf-Raylet")]
        WO,

        // carbon stars
        [Description("CS Carbon Star")]
        CS,
        [Description("C Carbon Star")]
        C,
        [Description("CN Carbon Star")]
        CN,
        [Description("CJ  Carbon Star")]
        CJ,
        [Description("CH CLASS Carbon Star")]
        CH,
        [Description("CHD CLASS Carbon Star")]
        CHd,
        [Description("MS CLASS Carbon Star")]
        MS,
        [Description("S CLASS Carbon Star")]
        S,

        // white dwarfs
        [Description("D Class White Dwarf")]
        D,
        [Description("DA Class White Dwarf")]
        DA,
        [Description("DAB Class White Dwarf")]
        DAB,
        [Description("DAO Class White Dwarf")]
        DAO,
        [Description("DAZ Class White Dwarf")]
        DAZ,
        [Description("DAV Class White Dwarf")]
        DAV,
        [Description("DB Class White Dwarf")]
        DB,
        [Description("DBZ Class White Dwarf")]
        DBZ,
        [Description("DBV Class White Dwarf")]
        DBV,
        [Description("DO Class White Dwarf")]
        DO,
        [Description("DOV Class White Dwarf")]
        DOV,
        [Description("DQ Class White Dwarf")]
        DQ,
        [Description("DC Class White Dwarf")]
        DC,
        [Description("DCV Class White Dwarf")]
        DCV,
        [Description("DX Class White Dwarf")]
        DX,

        // neutron
        [Description("Neutron Star")]
        N,

        // black hole
        [Description("Black Hole")]
        H,

        // exotic
        [Description("Exotic")]
        X,

        // other
        [Description("Super Massive Black Hole")]
        SupermassiveBlackHole,
        [Description("A Class Super Giant")]
        A_BlueWhiteSuperGiant,
        [Description("F Class Super Giant")]
        F_WhiteSuperGiant,
        [Description("M Class Super Giant")]
        M_RedSuperGiant,
        [Description("M Class Giant")]
        M_RedGiant,
        [Description("K Class Giant")]
        K_OrangeGiant,
        [Description("Rogue Planet")]
        RoguePlanet,
        [Description("Nebula")]
        Nebula,
        [Description("Stella Remnant")]
        StellarRemnantNebula
    }

    public enum StarLuminosity
    {
        None,
        I,
        Ia0,
        Ia,
        Ib,
        Iab,
        II,
        IIa,
        IIab,
        IIb,
        III,
        IIIa,
        IIIab,
        IIIb,
        IV,
        IVa,
        IVab,
        IVb,
        V,
        Va,
        Vab,
        Vb,
        Vz,
        VI,
        VII
    }


    public enum PlanetClass
    {
        Unknown,

        [Description("METAL RICH BODY")]
        MetalRichBody,

        [Description("HIGH METAL CONTENT BODY")]
        HighMetalContentBody,

        [Description("ROCKY BODY")]
        RockyBody,

        [Description("ICY BODY")]
        IcyBody,

        [Description("ROCKY ICE BODY")]
        RockyIceBody,

        [Description("EARTHLIKE BODY")]
        EarthlikeBody,

        [Description("WATER WORLD")]
        WaterWorld,

        [Description("AMMONIA WORLD")]
        AmmoniaWorld,

        [Description("WATER GIANT")]
        WaterGiant,

        [Description("WATER GIANT WITH LIFE")]
        WaterGiantWithLife,

        [Description("GAS GIANT WITH WATER BASED LIFE")]
        GasGiantWithWaterBasedLife,

        [Description("GAS GIANT WITH AMMONIA BASED LIFE")]
        GasGiantWithAmmoniaBasedLife,

        [Description("SUDARSKY CLASS I GAS GIANT")]
        SudarskyClassIGasGiant,

        [Description("SUDARSKY CLASS II GAS GIANT")]
        SudarskyClassIIGasGiant,

        [Description("SUDARSKY CLASS III GAS GIANT")]
        SudarskyClassIIIGasGiant,

        [Description("SUDARSKY CLASS IV GAS GIANT")]
        SudarskyClassIVGasGiant,

        [Description("SUDARSKY CLASS V GAS GIANT")]
        SudarskyClassVGasGiant,

        [Description("HELIUM RICH GAS GIANT")]
        HeliumRichGasGiant,

        [Description("HELIUM GAS GIANT")]
        HeliumGasGiant,

        //Not used in the event, added for ODExplorer Use
        [Description("")]
        EdsmValuableBody
    }

    public enum AtmosphereClass
    {
        None,

        Unknown,

        [Description("No atmosphere")]
        NoAtmosphere,

        [Description("Suitable for water-based life")]
        SuitableForWaterBasedLife,

        [Description("Ammonia and oxygen")]
        AmmoniaAndOxygen,

        Ammonia,

        Water,

        [Description("EarthLike")]
        EarthLike,

        [Description("Carbon dioxide")]
        CarbonDioxide,

        [Description("Sulphur dioxide")]
        SulphurDioxide,

        Nitrogen,

        [Description("Water-rich")]
        WaterRich,

        [Description("Methane-rich")]
        MethaneRich,

        [Description("Ammonia-rich")]
        AmmoniaRich,

        [Description("Carbon dioxide-rich")]
        CarbonDioxideRich,

        Methane,

        Helium,

        [Description("Silicate vapour")]
        SilicateVapour,

        [Description("Metallic vapour")]
        MetallicVapour,

        [Description("Neon-rich")]
        NeonRich,

        [Description("Argon-rich")]
        ArgonRich,

        Neon,

        Argon,

        Oxygen
    }

    public enum BodyType
    {
        Unknown,
        Null,
        Star,
        Planet,
        PlanetaryRing,
        StellarRing,
        Station,
        AsteroidCluster
    }

    public enum GameMode
    {
        Unknown,
        Open,
        Solo,
        Group,
        Console
    }

    public enum PowerplayState
    {
        Unknown,
        InPrepareRadius,
        Prepared,
        Exploited,
        Contested,
        Controlled,
        Turmoil,
        HomeSystem
    }

    public enum TerraformState
    {
        Unknown,
        None,
        Terraformable,
        Terraforming,
        Terraformed
    }

    public enum ReserveLevel
    {
        [Description("?")]
        Unknown,

        [Description("DepletedResources")]
        Depleted,

        [Description("LowResources")]
        Low,

        [Description("CommonResources")]
        Common,

        [Description("MajorResources")]
        Major,

        [Description("PristineResources")]
        Pristine
    }

    public enum InfluenceLevel
    {
        Unknown,
        None,
        Low,
        Med,
        High
    }

    public enum ReputationLevel
    {
        Unknown,
        None,
        Low,
        Med,
        High
    }

    public enum JumpType
    {
        Unknown,
        Hyperspace,
        Supercruise
    }

    public enum TextChannel
    {
        Unknown,
        NPC,
        Local,
        System,
        Player,
        Wing,
        Squadron,
        Friend,
        VoiceChat
    }

    public enum DockingDeniedReason
    {
        Unknown,
        NoSpace,
        TooLarge,
        Hostile,
        Offences,
        Distance,
        ActiveFighter,
        NoReason
    }

    public enum ModuleAttribute
    {
        Size,
        Class,
        Mass,
        Integrity,
        PowerDraw,
        BootTime,
        ShieldBankSpinUp,
        ShieldBankDuration,
        ShieldBankReinforcement,
        ShieldBankHeat,
        DamageFalloffRange,
        DamagePerSecond,
        Damage,
        DistributorDraw,
        ThermalLoad,
        ArmourPenetration,
        MaximumRange,
        ShotSpeed,
        RateOfFire,
        BurstRateOfFire,
        BurstSize,
        AmmoClipSize,
        AmmoMaximum,
        RoundsPerShot,
        ReloadTime,
        BreachDamage,
        MinBreachChance,
        MaxBreachChance,
        Jitter,
        WeaponMode,
        DamageType,
        ShieldGenMinimumMass,
        ShieldGenOptimalMass,
        ShieldGenMaximumMass,
        ShieldGenMinStrength,
        ShieldGenStrength,
        ShieldGenMaxStrength,
        RegenRate,
        BrokenRegenRate,
        EnergyPerRegen,
        FSDOptimalMass,
        FSDHeatRate,
        MaxFuelPerJump,
        EngineMinimumMass,
        EngineOptimalMass,
        MaximumMass,
        EngineMinPerformance,
        EngineOptPerformance,
        EngineMaxPerformance,
        EngineHeatRate,
        PowerCapacity,
        HeatEfficiency,
        WeaponsCapacity,
        WeaponsRecharge,
        EnginesCapacity,
        EnginesRecharge,
        SystemsCapacity,
        SystemsRecharge,
        DefenceModifierHealthMultiplier,
        DefenceModifierHealthAddition,
        DefenceModifierShieldMultiplier,
        DefenceModifierShieldAddition,
        KineticResistance,
        ThermicResistance,
        ExplosiveResistance,
        CausticResistance,
        FSDInterdictorRange,
        FSDInterdictorFacingLimit,
        ScannerRange,
        DiscoveryScannerRange,
        DiscoveryScannerPassiveRange,
        MaxAngle,
        ScannerTimeToScan,
        ChaffJamDuration,
        ECMRange,
        ECMTimeToCharge,
        ECMActivePowerConsumption,
        ECMHeat,
        ECMCooldown,
        HeatSinkDuration,
        ThermalDrain,
        NumBuggySlots,
        CargoCapacity,
        MaxActiveDrones,
        DroneTargetRange,
        DroneLifeTime,
        DroneSpeed,
        DroneMultiTargetSpeed,
        DroneFuelCapacity,
        DroneRepairCapacity,
        DroneHackingTime,
        DroneMinJettisonedCargo,
        DroneMaxJettisonedCargo,
        FuelScoopRate,
        FuelCapacity,
        OxygenTimeCapacity,
        RefineryBins,
        AFMRepairCapacity,
        AFMRepairConsumption,
        AFMRepairPerAmmo,
        MaxRange,
        SensorTargetScanAngle,
        Range,
        VehicleCargoCapacity,
        VehicleHullMass,
        VehicleFuelCapacity,
        VehicleArmourHealth,
        VehicleShieldHealth,
        FighterMaxSpeed,
        FighterBoostSpeed,
        FighterPitchRate,
        FighterDPS,
        FighterYawRate,
        FighterRollRate,
        CabinCapacity,
        CabinClass,
        DisruptionBarrierRange,
        DisruptionBarrierChargeDuration,
        DisruptionBarrierActivePower,
        DisruptionBarrierCooldown,
        WingDamageReduction,
        WingMinDuration,
        WingMaxDuration,
        ShieldSacrificeAmountRemoved,
        ShieldSacrificeAmountGiven,
        FSDJumpRangeBoost,
        FSDFuelUseIncrease,
        BoostSpeedMultiplier,
        BoostAugmenterPowerUse,
        ModuleDefenceAbsorption,
        FalloffRange,
        DSS_RangeMult,
        DSS_AngleMult,
        DSS_RateMult,
        DSS_PatchRadius
    }

    public enum ReputationStatus
    {
        Hostile = -2,
        Unfriendly = -1,
        Neutral = 0,
        Cordial = 1,
        Friendly = 2,
        Allied = 3
    }

    public enum FriendStatus
    {
        Unknown,
        Requested,
        Declined,
        Added,
        Lost,
        Offline,
        Online
    }

    public enum DroneType
    {
        Unknown,
        Hatchbreaker,
        FuelTransfer,
        Collection,
        Prospector,
        Repair,
        Research,
        Decontamination
    }

    public enum JournalTypeEnum
    {
        Unknown = 0,

        AfmuRepairs = 1,
        ApproachBody = 2,
        ApproachSettlement = 3,
        AppliedToSquadron = 4,
        AsteroidCracked = 5,
        Backpack = 6,
        BackpackChange = 7,
        BookDropship = 8,
        BookTaxi = 9,
        Bounty = 10,
        BuyAmmo = 11,
        BuyDrones = 12,
        BuyExplorationData = 13,
        BuyMicroResources = 14,
        BuySuit = 15,
        BuyWeapon = 16,
        BuyTradeData = 17,
        CancelDropship = 18,
        CancelTaxi = 19,
        CapShipBond = 20,
        Cargo = 21,
        CargoDepot = 22,
        CargoTransfer = 23,
        CarrierBankTransfer = 24,
        CarrierBuy = 25,
        CarrierCancelDecommission = 26,
        CarrierCrewServices = 27,
        CarrierDecommission = 28,
        CarrierDepositFuel = 29,
        CarrierDockingPermission = 30,
        CarrierFinance = 31,
        CarrierJumpRequest = 32,
        CarrierJump = 33,
        CarrierModulePack = 34,
        CarrierShipPack = 35,
        CarrierStats = 36,
        CarrierTradeOrder = 37,
        CarrierNameChange = 38,
        CarrierJumpCancelled = 39,
        ChangeCrewRole = 40,
        ClearSavedGame = 41,
        ClearImpound = 42,
        CockpitBreached = 43,
        CodexEntry = 44,
        CollectCargo = 45,
        CollectItems = 46,
        Commander = 48,
        CommitCrime = 49,
        CommunityGoal = 50,
        CommunityGoalJoin = 51,
        CommunityGoalReward = 52,
        CommunityGoalDiscard = 53,
        Continued = 54,
        CreateSuitLoadout = 55,
        CrewAssign = 56,
        CrewFire = 57,
        CrewHire = 58,
        CrewLaunchFighter = 59,
        CrewMemberJoins = 60,
        CrewMemberQuits = 61,
        CrewMemberRoleChange = 62,
        CrimeVictim = 63,
        DataScanned = 64,
        DatalinkScan = 65,
        DatalinkVoucher = 66,
        DeleteSuitLoadout = 67,
        Died = 68,
        DiscoveryScan = 69,
        DisbandedSquadron = 70,
        Disembark = 71,
        Docked = 72,
        DockFighter = 73,
        DockingCancelled = 74,
        DockingDenied = 75,
        DockingGranted = 76,
        DockingRequested = 77,
        DockingTimeout = 78,
        DockSRV = 79,
        DropItems = 80,
        DropshipDeploy = 81,
        EjectCargo = 82,
        EndCrewSession = 83,
        EngineerApply = 84,
        EngineerContribution = 85,
        EngineerCraft = 86,
        EngineerLegacyConvert = 87,
        EngineerProgress = 88,
        Embark = 89,
        EscapeInterdiction = 90,
        FactionKillBond = 91,
        FCMaterials = 92,
        FetchRemoteModule = 93,
        FSDJump = 94,
        FSDTarget = 95,
        FSSAllBodiesFound = 96,
        FuelScoop = 97,
        Fileheader = 98,
        FighterDestroyed = 99,
        FighterRebuilt = 100,
        Friends = 101,
        FSSDiscoveryScan = 102,
        FSSSignalDiscovered = 103,
        FSSBodySignals = 104,
        HeatDamage = 105,
        HeatWarning = 106,
        HullDamage = 107,
        Interdicted = 108,
        Interdiction = 109,
        InvitedToSquadron = 110,
        JoinedSquadron = 111,
        JetConeBoost = 112,
        JetConeDamage = 113,
        JoinACrew = 114,
        KickCrewMember = 115,
        KickedFromSquadron = 116,
        LaunchDrone = 117,
        LaunchFighter = 118,
        LaunchSRV = 119,
        LeftSquadron = 120,
        LeaveBody = 121,
        Liftoff = 122,
        LoadGame = 123,
        Loadout = 124,
        LoadoutEquipModule = 125,
        LoadoutRemoveModule = 126,
        Location = 127,
        MassModuleStore = 128,
        Market = 129,
        MarketBuy = 130,
        MarketSell = 131,
        MaterialCollected = 132,
        MaterialDiscarded = 133,
        MaterialDiscovered = 134,
        MaterialTrade = 135,
        Materials = 136,
        MiningRefined = 137,
        Missions = 138,
        MissionAbandoned = 139,
        MissionAccepted = 140,
        MissionCompleted = 141,
        MissionFailed = 142,
        MissionRedirected = 143,
        ModuleInfo = 145,
        ModuleBuy = 146,
        ModuleBuyAndStore = 147,
        ModuleRetrieve = 148,
        ModuleSell = 149,
        ModuleSellRemote = 150,
        ModuleStore = 151,
        ModuleSwap = 152,
        MultiSellExplorationData = 153,
        Music = 154,
        NavBeaconScan = 155,
        NavRoute = 156,
        NavRouteClear = 157,
        NewCommander = 158,
        NpcCrewPaidWage = 159,
        NpcCrewRank = 160,
        Outfitting = 161,
        Passengers = 162,
        PayFines = 163,
        PayBounties = 164,
        PayLegacyFines = 165,
        Powerplay = 166,
        PowerplayCollect = 167,
        PowerplayDefect = 168,
        PowerplayDeliver = 169,
        PowerplayFastTrack = 170,
        PowerplayJoin = 171,
        PowerplayLeave = 172,
        PowerplaySalary = 173,
        PowerplayVote = 174,
        PowerplayVoucher = 175,
        Progress = 176,
        Promotion = 177,
        ProspectedAsteroid = 178,
        PVPKill = 179,
        QuitACrew = 180,
        Rank = 181,
        RebootRepair = 182,
        ReceiveText = 183,
        RedeemVoucher = 184,
        RefuelAll = 185,
        RefuelPartial = 186,
        RenameSuitLoadout = 187,
        Repair = 188,
        RepairAll = 189,
        RepairDrone = 190,
        Reputation = 191,
        RestockVehicle = 192,
        Resurrect = 193,
        ReservoirReplenished = 194,
        Resupply = 195,
        SAAScanComplete = 196,
        SAASignalsFound = 197,
        Scan = 198,
        ScanBaryCentre = 199,
        ScanOrganic = 200,
        Scanned = 201,
        ScientificResearch = 202,
        Screenshot = 203,
        SearchAndRescue = 204,
        SelfDestruct = 205,
        SellDrones = 206,
        SellExplorationData = 207,
        SellMicroResources = 208,
        SellOrganicData = 209,
        SellShipOnRebuy = 210,
        SellSuit = 211,
        SellWeapon = 212,
        SendText = 213,
        SetUserShipName = 214,
        SharedBookmarkToSquadron = 215,
        ShieldState = 216,
        Shipyard = 217,
        ShipyardBuy = 218,
        ShipyardNew = 219,
        ShipyardSell = 220,
        ShipyardSwap = 221,
        ShipyardTransfer = 222,
        ShipTargeted = 223,
        ShipLocker = 224,
        Shutdown = 225,
        SRVDestroyed = 226,
        StartJump = 227,
        Statistics = 228,
        StoredModules = 229,
        StoredShips = 230,
        SupercruiseEntry = 231,
        SquadronCreated = 232,
        SquadronDemotion = 233,
        SquadronPromotion = 234,
        SquadronStartup = 235,
        SupercruiseDestinationDrop = 236,
        SupercruiseExit = 237,
        SwitchSuitLoadout = 238,
        SuitLoadout = 239,
        Synthesis = 240,
        SystemsShutdown = 241,
        TechnologyBroker = 242,
        Touchdown = 245,
        TradeMicroResources = 246,
        UnderAttack = 247,
        Undocked = 248,
        UpgradeSuit = 249,
        UpgradeWeapon = 250,
        UseConsumable = 251,
        USSDrop = 252,
        VehicleSwitch = 253,
        WingAdd = 254,
        WingInvite = 255,
        WingJoin = 256,
        WingLeave = 257,
        WonATrophyForSquadron = 259,
        ShipyardRedeem = 260,
        ShipRedeemed = 261,
        // removed events
        TransferMicroResources = 10000,
        BackPack = 10001,
        ShipLockerMaterials = 10002,
        BackPackMaterials = 10003,
    }

    public enum RoleType
    {
        Unknown,
        Idle,
        FireCon,
        FighterCon,
        Helm,
        OnFoot
    }
}
