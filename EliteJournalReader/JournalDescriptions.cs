using System;
using System.ComponentModel;

namespace EliteJournalReader
{

    public enum ScanType
    {
        Unknown,
        Basic,
        AutoScan,
        NavBeacon,
        NavBeaconDetail,
        Detailed,
    }

    public enum StarType
    {
        Unknown,

        // main sequence
        [Description("O Class Star")]
        O,
        [Description("B Class Star")]
        B,
        [Description("A Class Star")]
        A,
        [Description("F Class Star")]
        F,
        [Description("G Class Star")]
        G,
        [Description("K Class Star")]
        K,
        [Description("M Class Star")]
        M,
        [Description("L Class Star")]
        L,
        [Description("T Class Star")]
        T,
        [Description("Y Class Star")]
        Y,

        // proto stars
        [Description("TTS Proto Star")]
        TTS,
        [Description("AEBE Proto Star")]
        AeBe,

        // wolf-rayet
        [Description("W Wolf-Rayet")]
        W,
        [Description("WN Wolf-Rayet")]
        WN,
        [Description("WNC Wolf-Rayet")]
        WNC,
        [Description("WC Wolf-Rayet")]
        WC,
        [Description("WO Wolf-Rayet")]
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
    [Flags]
    public enum StarTypeFromScanEvents
    {
        [Description("")]
        None,
        [Description("A")]
        A,
        [Description("A_Bluewhitesupergiant")]
        A_BlueWhiteSuperGiant,
        [Description("Aebe")]
        AeBe,
        [Description("B")]
        B,
        [Description("B_Bluewhitesupergiant")]
        B_BlueWhiteSuperGiant,
        [Description("C")]
        C,
        [Description("Cj")]
        CJ,
        [Description("Cn")]
        CN,
        [Description("D")]
        D,
        [Description("Da")]
        DA,
        [Description("Dab")]
        DAB,
        [Description("Dav")]
        DAV,
        [Description("Daz")]
        DAZ,
        [Description("Db")]
        DB,
        [Description("Dbv")]
        DBV,
        [Description("Dbz")]
        DBZ,
        [Description("Dc")]
        DC,
        [Description("Dcv")]
        DCV,
        [Description("Dq")]
        DQ,
        [Description("F")]
        F,
        [Description("F_Whitesupergiant")]
        F_WhiteSuperGiant,
        [Description("G")]
        G,
        [Description("G_Whitesupergiant")]
        G_WhiteSuperGiant,
        [Description("H")]
        H,
        [Description("K")]
        K,
        [Description("K_Orangegiant")]
        K_OrangeGiant,
        [Description("L")]
        L,
        [Description("M")]
        M,
        [Description("Ms")]
        MS,
        [Description("M_Redgiant")]
        M_RedGiant,
        [Description("M_Redsupergiant")]
        M_RedSuperGiant,
        [Description("N")]
        N,
        [Description("O")]
        O,
        [Description("S")]
        S,
        [Description("Supermassiveblackhole")]
        SupermassiveBlackHole,
        [Description("T")]
        T,
        [Description("Tts")]
        TTS,
        [Description("W")]
        W,
        [Description("Wc")]
        WC,
        [Description("Wn")]
        WN,
        [Description("Wnc")]
        WNC,
        [Description("Wo")]
        WO,
        [Description("Y")]
        Y,
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

        [Description("Metal Rich Body")]
        MetalRichBody,

        [Description("High Metal Content Body")]
        HighMetalContentBody,

        [Description("Rocky Body")]
        RockyBody,

        [Description("Icy Body")]
        IcyBody,

        [Description("Rocky Ice Body")]
        RockyIceBody,

        [Description("Earthlike Body")]
        EarthlikeBody,

        [Description("Water World")]
        WaterWorld,

        [Description("Ammonia World")]
        AmmoniaWorld,

        [Description("Water Giant")]
        WaterGiant,

        [Description("Water Giant With Life")]
        WaterGiantWithLife,

        [Description("Gas Giant With Water Based Life")]
        GasGiantWithWaterBasedLife,

        [Description("Gas Giant With Ammonia Based Life")]
        GasGiantWithAmmoniaBasedLife,

        [Description("Sudarsky Class I Gas Giant")]
        SudarskyClassIGasGiant,

        [Description("Sudarsky Class II Gas Giant")]
        SudarskyClassIIGasGiant,

        [Description("Sudarsky Class III Gas Giant")]
        SudarskyClassIIIGasGiant,

        [Description("Sudarsky Class IV Gas Giant")]
        SudarskyClassIVGasGiant,

        [Description("Sudarsky Class V Gas Giant")]
        SudarskyClassVGasGiant,

        [Description("Helium Rich Gas Giant")]
        HeliumRichGasGiant,

        [Description("Helium Gas Giant")]
        HeliumGasGiant,

        //Not used in the event, added for ODExplorer Use
        [Description("")]
        EdsmValuableBody
    }

    public enum AtmosphereClass
    {
        None,
        Unknown,
        Ammonia,
        [Description("Ammonia & Oxygen")]
        AmmoniaOxygen,
        [Description("Ammonia-rich")]
        AmmoniaRich,
        Argon,
        [Description("Argon-rich")]
        ArgonRich,
        [Description("Carbon dioxide")]
        CarbonDioxide,
        [Description("Carbon dioxide-rich")]
        CarbonDioxideRich,
        [Description("Earth Like")]
        EarthLike,
        Helium,
        Methane,
        [Description("Methane-rich")]
        MethaneRich,
        [Description("Metallic vapour")]
        MetallicVapour,
        Neon,
        [Description("Neon-rich")]
        NeonRich,
        Nitrogen,
        [Description("No atmosphere")]
        NoAtmosphere,
        Oxygen,
        [Description("Silicate vapour")]
        SilicateVapour,
        [Description("Sulphur dioxide")]
        SulphurDioxide,
        [Description("Suitable for water-based life")]
        SuitableForWaterBasedLife,
        Water,
        [Description("Water-rich")]
        WaterRich,
    }

    public enum AtmosphereType
    {
        [Description("Ammonia")]
        Ammonia = 1 << 0,
        [Description("Ammoniaoxygen")]
        AmmoniaOxygen = 1 << 1,
        [Description("Ammoniarich")]
        AmmoniaRich = 1 << 2,
        [Description("Argon")]
        Argon = 1 << 3,
        [Description("Argonrich")]
        ArgonRich = 1 << 4,
        [Description("Carbondioxide")]
        CarbonDioxide = 1 << 5,
        [Description("Carbondioxiderich")]
        CarbonDioxideRich = 1 << 6,
        [Description("Earthlike")]
        EarthLike = 1 << 7,
        [Description("Helium")]
        Helium = 1 << 8,
        [Description("Metallicvapour")]
        MetallicVapour = 1 << 9,
        [Description("Methane")]
        Methane = 1 << 10,
        [Description("Methanerich")]
        MethaneRich = 1 << 11,
        [Description("Neon")]
        Neon = 1 << 12,
        [Description("Neonrich")]
        NeonRich = 1 << 13,
        [Description("Nitrogen")]
        Nitrogen = 1 << 14,
        [Description("None")]
        None = 1 << 15,
        [Description("Oxygen")]
        Oxygen = 1 << 16,
        [Description("Silicatevapour")]
        SilicateVapour = 1 << 17,
        [Description("Sulphurdioxide")]
        SulphurDioxide = 1 << 18,
        [Description("Water")]
        Water = 1 << 19,
        [Description("Waterrich")]
        WaterRich = 1 << 20,
    }
    public enum AtmosphereComp
    {
        [Description("Ammonia")]
        Ammonia = 1 << 0,
        [Description("Argon")]
        Argon = 1 << 1,
        [Description("Carbon Dioxide")]
        CarbonDioxide = 1 << 2,
        [Description("Helium")]
        Helium = 1 << 3,
        [Description("Hydrogen")]
        Hydrogen = 1 << 4,
        [Description("Iron")]
        Iron = 1 << 5,
        [Description("Methane")]
        Methane = 1 << 6,
        [Description("Neon")]
        Neon = 1 << 7,
        [Description("Nitrogen")]
        Nitrogen = 1 << 8,
        [Description("Oxygen")]
        Oxygen = 1 << 9,
        [Description("Silicates")]
        Silicates = 1 << 10,
        [Description("Sulphur Dioxide")]
        SulphurDioxide = 1 << 11,
        [Description("Water")]
        Water = 1 << 12,
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
        [Description("In Prepared Radius")]
        InPrepareRadius,
        Prepared,
        Exploited,
        Contested,
        Controlled,
        Turmoil,
        HomeSystem,
        Stronghold,
        Fortified,
        Unoccupied
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

    public enum OrganicScanStage
    {
        [Description("?")]
        MultiChoice = -1,
        [Description("...")]
        Prediction = 0,
        [Description("☺")]
        DSS,
        [Description("®")]
        Codex,
        [Description("●○○")]
        Log,
        [Description("●●○")]
        Sample,
        [Description("●●●")]
        Analyse
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
        DSS_PatchRadius,
        GuardianModuleResistance
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
        DeliverPowerMicroResources = 262,
        HoloscreenHacked = 263,
        ColonisationBeaconDeployed = 264,
        ColonisationConstructionDepot = 265,
        ColonisationContribution = 266,
        ColonisationSystemClaim = 277,
        ColonisationSystemClaimRelease = 278,
        CarrierLocation = 279,
        PowerplayMerits = 280,
        PowerplayRank = 281,
        RequestPowerMicroResources = 282,
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

    public enum GalacticRegions
    {
        [Description("All")]
        Unknown = 0,
        [Description("Acheron")]
        Codex_RegionName_23 = 23,
        [Description("Achilles's Altar")]
        Codex_RegionName_36 = 36,
        [Description("Aquila's Halo")]
        Codex_RegionName_28 = 28,
        [Description("Arcadian Stream")]
        Codex_RegionName_6 = 6,
        [Description("Dryman's Point")]
        Codex_RegionName_20 = 20,
        [Description("Empyrean Straits")]
        Codex_RegionName_2 = 2,
        [Description("Elysian Shore")]
        Codex_RegionName_33 = 33,
        [Description("Errant Marches")]
        Codex_RegionName_29 = 29,
        [Description("Formidine Rift")]
        Codex_RegionName_31 = 31,
        [Description("Formorian Frontier")]
        Codex_RegionName_24 = 24,
        [Description("Galactic Centre")]
        Codex_RegionName_1 = 1,
        [Description("Hawking's Gap")]
        Codex_RegionName_19 = 19,
        [Description("Hieronymus Delta")]
        Codex_RegionName_25 = 25,
        [Description("Inner Orion Spur")]
        Codex_RegionName_18 = 18,
        [Description("Inner Orion-Perseus Conflux")]
        Codex_RegionName_8 = 8,
        [Description("Inner Scutum-Centaurus Arm")]
        Codex_RegionName_9 = 9,
        [Description("Izanami")]
        Codex_RegionName_7 = 7,
        [Description("Kepler's Crest")]
        Codex_RegionName_41 = 41,
        [Description("Lyra's Song")]
        Codex_RegionName_38 = 38,
        [Description("Mare Somnia")]
        Codex_RegionName_22 = 22,
        [Description("Newton's Vault")]
        Codex_RegionName_13 = 13,
        [Description("Norma Arm")]
        Codex_RegionName_5 = 5,
        [Description("Norma Expanse")]
        Codex_RegionName_10 = 10,
        [Description("Odin's Hold")]
        Codex_RegionName_4 = 4,
        [Description("Orion-Cygnus Arm")]
        Codex_RegionName_16 = 16,
        [Description("Outer Arm")]
        Codex_RegionName_27 = 27,
        [Description("Outer Orion Spur")]
        Codex_RegionName_35 = 35,
        [Description("Outer Orion-Perseus Conflux")]
        Codex_RegionName_15 = 15,
        [Description("Outer Scutum-Centaurus Arm")]
        Codex_RegionName_26 = 26,
        [Description("Perseus Arm")]
        Codex_RegionName_30 = 30,
        [Description("Ryker's Hope")]
        Codex_RegionName_3 = 3,
        [Description("Sagittarius-Carina Arm")]
        Codex_RegionName_21 = 21,
        [Description("Sanguineous Rim")]
        Codex_RegionName_34 = 34,
        [Description("Temple")]
        Codex_RegionName_17 = 17,
        [Description("Tenebrae")]
        Codex_RegionName_39 = 39,
        [Description("The Abyss")]
        Codex_RegionName_40 = 40,
        [Description("The Conduit")]
        Codex_RegionName_14 = 14,
        [Description("The Veils")]
        Codex_RegionName_12 = 12,
        [Description("The Void")]
        Codex_RegionName_42 = 42,
        [Description("Trojan Belt")]
        Codex_RegionName_11 = 11,
        [Description("Vulcan Gate")]
        Codex_RegionName_32 = 32,
        [Description("Xibalba")]
        Codex_RegionName_37 = 37,
    }

    [Flags]
    public enum GalacticRegionsFlags : long
    {
        [Description("All")]
        Unknown = 0,
        [Description("Galactic Centre")]
        Codex_RegionName_1 = 1,
        [Description("Empyrean Straits")]
        Codex_RegionName_2 = 2,
        [Description("Ryker's Hope")]
        Codex_RegionName_3 = 4,
        [Description("Odin's Hold")]
        Codex_RegionName_4 = 8,
        [Description("Norma Arm")]
        Codex_RegionName_5 = 16,
        [Description("Arcadian Stream")]
        Codex_RegionName_6 = 32,
        [Description("Izanami")]
        Codex_RegionName_7 = 64,
        [Description("Inner Orion-Perseus Conflux")]
        Codex_RegionName_8 = 128,
        [Description("Inner Scutum-Centaurus Arm")]
        Codex_RegionName_9 = 256,
        [Description("Norma Expanse")]
        Codex_RegionName_10 = 512,
        [Description("Trojan Belt")]
        Codex_RegionName_11 = 1024,
        [Description("The Veils")]
        Codex_RegionName_12 = 2048,
        [Description("Newton's Vault")]
        Codex_RegionName_13 = 4096,
        [Description("The Conduit")]
        Codex_RegionName_14 = 8192,
        [Description("Outer Orion-Perseus Conflux")]
        Codex_RegionName_15 = 16384,
        [Description("Orion-Cygnus Arm")]
        Codex_RegionName_16 = 32768,
        [Description("Temple")]
        Codex_RegionName_17 = 65536,
        [Description("Inner Orion Spur")]
        Codex_RegionName_18 = 131072,
        [Description("Hawking's Gap")]
        Codex_RegionName_19 = 262144,
        [Description("Dryman's Point")]
        Codex_RegionName_20 = 524288,
        [Description("Sagittarius-Carina Arm")]
        Codex_RegionName_21 = 1048576,
        [Description("Mare Somnia")]
        Codex_RegionName_22 = 2097152,
        [Description("Acheron")]
        Codex_RegionName_23 = 4194304,
        [Description("Formorian Frontier")]
        Codex_RegionName_24 = 8388608,
        [Description("Hieronymus Delta")]
        Codex_RegionName_25 = 16777216,
        [Description("Outer Scutum-Centaurus Arm")]
        Codex_RegionName_26 = 33554432,
        [Description("Outer Arm")]
        Codex_RegionName_27 = 67108864,
        [Description("Aquila's Halo")]
        Codex_RegionName_28 = 134217728,
        [Description("Errant Marches")]
        Codex_RegionName_29 = 268435456,
        [Description("Perseus Arm")]
        Codex_RegionName_30 = 536870912,
        [Description("Formidine Rift")]
        Codex_RegionName_31 = 1073741824,
        [Description("Vulcan Gate")]
        Codex_RegionName_32 = 2147483648,
        [Description("Elysian Shore")]
        Codex_RegionName_33 = 4294967296,
        [Description("Sanguineous Rim")]
        Codex_RegionName_34 = 8589934592,
        [Description("Outer Orion Spur")]
        Codex_RegionName_35 = 17179869184,
        [Description("Achilles's Altar")]
        Codex_RegionName_36 = 34359738368,
        [Description("Xibalba")]
        Codex_RegionName_37 = 68719476736,
        [Description("Lyra's Song")]
        Codex_RegionName_38 = 137478953471,
        [Description("Tenebrae")]
        Codex_RegionName_39 = 274877906944,
        [Description("The Abyss")]
        Codex_RegionName_40 = 549755813888,
        [Description("Kepler's Crest")]
        Codex_RegionName_41 = 1099511627776,
        [Description("The Void")]
        Codex_RegionName_42 = 2199023255552,
    }

    public enum AtmosphereDescription
    {
        [Description("No Atmosphere")]
        None,
        [Description("Ammonia Atmosphere")]
        ammonia_atmosphere,
        [Description("Ammonia Rich Atmosphere")]
        ammonia_rich_atmosphere,
        [Description("Argon Atmosphere")]
        argon_atmosphere,
        [Description("Argon Rich Atmosphere")]
        argon_rich_atmosphere,
        [Description("Carbon Dioxide Atmosphere")]
        carbon_dioxide_atmosphere,
        [Description("Carbon Dioxide Rich Atmosphere")]
        carbon_dioxide_rich_atmosphere,
        [Description("Helium Atmosphere")]
        helium_atmosphere,
        [Description("Hot Argon Atmosphere")]
        hot_argon_atmosphere,
        [Description("Hot Argon Rich Atmosphere")]
        hot_argon_rich_atmosphere,
        [Description("Hot Carbon Dioxide Atmosphere")]
        hot_carbon_dioxide_atmosphere,
        [Description("Hot Carbon Dioxide Rich Atmosphere")]
        hot_carbon_dioxide_rich_atmosphere,
        [Description("Hot Metallic Vapour Atmosphere")]
        hot_metallic_vapour_atmosphere,
        [Description("Hot Silicate Vapour Atmosphere")]
        hot_silicate_vapour_atmosphere,
        [Description("Hot Sulfur Dioxide Atmosphere")]
        hot_sulfur_dioxide_atmosphere,
        [Description("Hot Sulphur Dioxide Atmosphere")]
        hot_sulphur_dioxide_atmosphere,
        [Description("Hot Thick Ammonia Atmosphere")]
        hot_thick_ammonia_atmosphere,
        [Description("Hot Thick Ammonia Rich Atmosphere")]
        hot_thick_ammonia_rich_atmosphere,
        [Description("Hot Thick Argon Atmosphere")]
        hot_thick_argon_atmosphere,
        [Description("Hot Thick Argon Rich Atmosphere")]
        hot_thick_argon_rich_atmosphere,
        [Description("Hot Thick Carbon Dioxide Atmosphere")]
        hot_thick_carbon_dioxide_atmosphere,
        [Description("Hot Thick Carbon Dioxide Rich Atmosphere")]
        hot_thick_carbon_dioxide_rich_atmosphere,
        [Description("Hot Thick Metallic Vapour Atmosphere")]
        hot_thick_metallic_vapour_atmosphere,
        [Description("Hot Thick Methane Atmosphere")]
        hot_thick_methane_atmosphere,
        [Description("Hot Thick Methane Rich Atmosphere")]
        hot_thick_methane_rich_atmosphere,
        [Description("Hot Thick Nitrogen Atmosphere")]
        hot_thick_nitrogen_atmosphere,
        [Description("Hot Thick Silicate Vapour Atmosphere")]
        hot_thick_silicate_vapour_atmosphere,
        [Description("Hot Thick Sulfur Dioxide Atmosphere")]
        hot_thick_sulfur_dioxide_atmosphere,
        [Description("Hot Thick Sulphur Dioxide Atmosphere")]
        hot_thick_sulphur_dioxide_atmosphere,
        [Description("Hot Thick Water Atmosphere")]
        hot_thick_water_atmosphere,
        [Description("Hot Thick Water Rich Atmosphere")]
        hot_thick_water_rich_atmosphere,
        [Description("Hot Thin Carbon Dioxide Atmosphere")]
        hot_thin_carbon_dioxide_atmosphere,
        [Description("Hot Thin Metallic Vapour Atmosphere")]
        hot_thin_metallic_vapour_atmosphere,
        [Description("Hot Thin Silicate Vapour Atmosphere")]
        hot_thin_silicate_vapour_atmosphere,
        [Description("Hot Thin Sulfur Dioxide Atmosphere")]
        hot_thin_sulfur_dioxide_atmosphere,
        [Description("Hot Thin Sulphur Dioxide Atmosphere")]
        hot_thin_sulphur_dioxide_atmosphere,
        [Description("Hot Water Atmosphere")]
        hot_water_atmosphere,
        [Description("Hot Water Rich Atmosphere")]
        hot_water_rich_atmosphere,
        [Description("Methane Atmosphere")]
        methane_atmosphere,
        [Description("Methane Rich Atmosphere")]
        methane_rich_atmosphere,
        [Description("Neon Rich Atmosphere")]
        neon_rich_atmosphere,
        [Description("Nitrogen Atmosphere")]
        nitrogen_atmosphere,
        [Description("Oxygen Atmosphere")]
        oxygen_atmosphere,
        [Description("Sulfur Dioxide Atmosphere")]
        sulfur_dioxide_atmosphere,
        [Description("Sulphur Dioxide Atmosphere")]
        sulphur_dioxide_atmosphere,
        [Description("Thick  Atmosphere")]
        thick__atmosphere,
        [Description("Thick Ammonia Atmosphere")]
        thick_ammonia_atmosphere,
        [Description("Thick Ammonia Rich Atmosphere")]
        thick_ammonia_rich_atmosphere,
        [Description("Thick Argon Atmosphere")]
        thick_argon_atmosphere,
        [Description("Thick Argon Rich Atmosphere")]
        thick_argon_rich_atmosphere,
        [Description("Thick Carbon Dioxide Atmosphere")]
        thick_carbon_dioxide_atmosphere,
        [Description("Thick Carbon Dioxide Rich Atmosphere")]
        thick_carbon_dioxide_rich_atmosphere,
        [Description("Thick Helium Atmosphere")]
        thick_helium_atmosphere,
        [Description("Thick Methane Atmosphere")]
        thick_methane_atmosphere,
        [Description("Thick Methane Rich Atmosphere")]
        thick_methane_rich_atmosphere,
        [Description("Thick Nitrogen Atmosphere")]
        thick_nitrogen_atmosphere,
        [Description("Thick Sulfur Dioxide Atmosphere")]
        thick_sulfur_dioxide_atmosphere,
        [Description("Thick Sulphur Dioxide Atmosphere")]
        thick_sulphur_dioxide_atmosphere,
        [Description("Thick Water Atmosphere")]
        thick_water_atmosphere,
        [Description("Thick Water Rich Atmosphere")]
        thick_water_rich_atmosphere,
        [Description("Thin  Atmosphere")]
        thin__atmosphere,
        [Description("Thin Ammonia Atmosphere")]
        thin_ammonia_atmosphere,
        [Description("Thin Ammonia Rich Atmosphere")]
        thin_ammonia_rich_atmosphere,
        [Description("Thin Argon Atmosphere")]
        thin_argon_atmosphere,
        [Description("Thin Argon Rich Atmosphere")]
        thin_argon_rich_atmosphere,
        [Description("Thin Carbon Dioxide Atmosphere")]
        thin_carbon_dioxide_atmosphere,
        [Description("Thin Carbon Dioxide Rich Atmosphere")]
        thin_carbon_dioxide_rich_atmosphere,
        [Description("Thin Helium Atmosphere")]
        thin_helium_atmosphere,
        [Description("Thin Methane Atmosphere")]
        thin_methane_atmosphere,
        [Description("Thin Methane Rich Atmosphere")]
        thin_methane_rich_atmosphere,
        [Description("Thin Neon Atmosphere")]
        thin_neon_atmosphere,
        [Description("Thin Neon Rich Atmosphere")]
        thin_neon_rich_atmosphere,
        [Description("Thin Nitrogen Atmosphere")]
        thin_nitrogen_atmosphere,
        [Description("Thin Oxygen Atmosphere")]
        thin_oxygen_atmosphere,
        [Description("Thin Sulfur Dioxide Atmosphere")]
        thin_sulfur_dioxide_atmosphere,
        [Description("Thin Sulphur Dioxide Atmosphere")]
        thin_sulphur_dioxide_atmosphere,
        [Description("Thin Water Atmosphere")]
        thin_water_atmosphere,
        [Description("Thin Water Rich Atmosphere")]
        thin_water_rich_atmosphere,
        [Description("Water Atmosphere")]
        water_atmosphere,
        [Description("Water Rich Atmosphere")]
        water_rich_atmosphere,
    }

    [Flags]
    public enum PlanetMaterial
    {
        None = 0,
        [Description("Antimony")]
        antimony = 1 << 0,
        [Description("Arsenic")]
        arsenic = 1 << 1,
        [Description("Cadmium")]
        cadmium = 1 << 2,
        [Description("Carbon")]
        carbon = 1 << 3,
        [Description("Chromium")]
        chromium = 1 << 4,
        [Description("Germanium")]
        germanium = 1 << 5,
        [Description("Iron")]
        iron = 1 << 6,
        [Description("Manganese")]
        manganese = 1 << 7,
        [Description("Mercury")]
        mercury = 1 << 8,
        [Description("Molybdenum")]
        molybdenum = 1 << 9,
        [Description("Nickel")]
        nickel = 1 << 10,
        [Description("Niobium")]
        niobium = 1 << 11,
        [Description("Phosphorus")]
        phosphorus = 1 << 12,
        [Description("Polonium")]
        polonium = 1 << 13,
        [Description("Ruthenium")]
        ruthenium = 1 << 14,
        [Description("Selenium")]
        selenium = 1 << 15,
        [Description("Sulphur")]
        sulphur = 1 << 16,
        [Description("Technetium")]
        technetium = 1 << 17,
        [Description("Tellurium")]
        tellurium = 1 << 18,
        [Description("Tin")]
        tin = 1 << 19,
        [Description("Tungsten")]
        tungsten = 1 << 20,
        [Description("Vanadium")]
        vanadium = 1 << 21,
        [Description("Yttrium")]
        yttrium = 1 << 22,
        [Description("Zinc")]
        zinc = 1 << 23,
        [Description("Zirconium")]
        zirconium = 1 << 24,
    }

    [Flags]
    public enum Volcanism
    {
        [Description("No Volcanism")]
        None = 0,
        [Description("Carbon Dioxide Geysers Volcanism")]
        carbon_dioxide_geysers_volcanism = 1 << 0,
        [Description("Major Carbon Dioxide Geysers Volcanism")]
        major_carbon_dioxide_geysers_volcanism = 1 << 1,
        [Description("Major Metallic Magma Volcanism")]
        major_metallic_magma_volcanism = 1 << 2,
        [Description("Major Nitrogen Geysers Volcanism")]
        major_nitrogen_geysers_volcanism = 1 << 3,
        [Description("Major Rocky Magma Volcanism")]
        major_rocky_magma_volcanism = 1 << 4,
        [Description("Major Silicate Vapour Geysers Volcanism")]
        major_silicate_vapour_geysers_volcanism = 1 << 5,
        [Description("Major Water Geysers Volcanism")]
        major_water_geysers_volcanism = 1 << 6,
        [Description("Major Water Magma Volcanism")]
        major_water_magma_volcanism = 1 << 7,
        [Description("Metallic Magma Volcanism")]
        metallic_magma_volcanism = 1 << 8,
        [Description("Minor Ammonia Magma Volcanism")]
        minor_ammonia_magma_volcanism = 1 << 9,
        [Description("Minor Carbon Dioxide Geysers Volcanism")]
        minor_carbon_dioxide_geysers_volcanism = 1 << 10,
        [Description("Minor Metallic Magma Volcanism")]
        minor_metallic_magma_volcanism = 1 << 11,
        [Description("Minor Methane Magma Volcanism")]
        minor_methane_magma_volcanism = 1 << 12,
        [Description("Minor Nitrogen Geysers Volcanism")]
        minor_nitrogen_geysers_volcanism = 1 << 13,
        [Description("Minor Nitrogen Magma Volcanism")]
        minor_nitrogen_magma_volcanism = 1 << 14,
        [Description("Minor Rocky Magma Volcanism")]
        minor_rocky_magma_volcanism = 1 << 15,
        [Description("Minor Silicate Vapour Geysers Volcanism")]
        minor_silicate_vapour_geysers_volcanism = 1 << 16,
        [Description("Minor Water Geysers Volcanism")]
        minor_water_geysers_volcanism = 1 << 17,
        [Description("Minor Water Magma Volcanism")]
        minor_water_magma_volcanism = 1 << 18,
        [Description("Rocky Magma Volcanism")]
        rocky_magma_volcanism = 1 << 19,
        [Description("Silicate Vapour Geysers Volcanism")]
        silicate_vapour_geysers_volcanism = 1 << 20,
        [Description("Water Geysers Volcanism")]
        water_geysers_volcanism = 1 << 21,
        [Description("Water Magma Volcanism")]
        water_magma_volcanism = 1 << 22,
    }

    public enum AtmosphereChemical
    {
        [Description("Ammonia")]
        Ammonia,
        [Description("Argon")]
        Argon,
        [Description("Carbon Dioxide")]
        CarbonDioxide,
        [Description("Helium")]
        Helium,
        [Description("Hydrogen")]
        Hydrogen,
        [Description("Iron")]
        Iron,
        [Description("Methane")]
        Methane,
        [Description("Neon")]
        Neon,
        [Description("Nitrogen")]
        Nitrogen,
        [Description("Oxygen")]
        Oxygen,
        [Description("Silicates")]
        Silicates,
        [Description("Sulphur Dioxide")]
        SulphurDioxide,
        [Description("Water")]
        Water,
    }
}
