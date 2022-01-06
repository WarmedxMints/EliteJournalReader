using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Description("O CLASS STAR")]
        O,
        [Description("B CLASS STAR")]
        B,
        [Description("A CLASS STAR")]
        A,
        [Description("F CLASS STAR")]
        F,
        [Description("G CLASS STAR")]
        G,
        [Description("K CLASS STAR")]
        K,
        [Description("M CLASS STAR")]
        M,
        [Description("L CLASS STAR")]
        L,
        [Description("T CLASS STAR")]
        T,
        [Description("Y CLASS STAR")]
        Y,

        // proto stars
        [Description("TTS PROTO STAR")]
        TTS,
        [Description("AEBE PROTO STAR")]
        AeBe,

        // wolf-rayet
        [Description("W WOLF-RAYLET")]
        W,
        [Description("WN WOLF-RAYLET")]
        WN,
        [Description("WNC WOLF-RAYLET")]
        WNC,
        [Description("WC WOLF-RAYLET")]
        WC,
        [Description("WO WOLF-RAYLET")]
        WO,

        // carbon stars
        [Description("CS CARBON STAR")]
        CS,
        [Description("C CARBON STAR")]
        C,
        [Description("CN CARBON STAR")]
        CN,
        [Description("CJ  CARBON STAR")]
        CJ,
        [Description("CH CLASS CARBON STAR")]
        CH,
        [Description("CHD CLASS CARBON STAR")]
        CHd,
        [Description("MS CLASS CARBON STAR")]
        MS,
        [Description("S CLASS CARBON STAR")]
        S,

        // white dwarfs
        [Description("D CLASS WHITE DWARF STAR")]
        D,
        [Description("DA CLASS WHITE DWARF STAR")]
        DA,
        [Description("DAB CLASS WHITE DWARF STAR")]
        DAB,
        [Description("DAO CLASS WHITE DWARF STAR")]
        DAO,
        [Description("DAZ CLASS WHITE DWARF STAR")]
        DAZ,
        [Description("DAV CLASS WHITE DWARF STAR")]
        DAV,
        [Description("DB CLASS WHITE DWARF STAR")]
        DB,
        [Description("DBZ CLASS WHITE DWARF STAR")]
        DBZ,
        [Description("DBV CLASS WHITE DWARF STAR")]
        DBV,
        [Description("DO CLASS WHITE DWARF STAR")]
        DO,
        [Description("DOV CLASS WHITE DWARF STAR")]
        DOV,
        [Description("DQ CLASS WHITE DWARF STAR")]
        DQ,
        [Description("DC CLASS WHITE DWARF STAR")]
        DC,
        [Description("DCV CLASS WHITE DWARF STAR")]
        DCV,
        [Description("DX CLASS WHITE DWARF STAR")]
        DX,

        // neutron
        [Description("NEUTRON STAR")]
        N,

        // black hole
        [Description("BLACK HOLE")]
        H,

        // exotic
        [Description("EXOTIC")]
        X,

        // other
        [Description("SUPER MASSIVE BLACK HOLE")]
        SupermassiveBlackHole,
        [Description("A CLASS SUPER GIANT")]
        A_BlueWhiteSuperGiant,
        [Description("F CLASS SUPER GIANT")]
        F_WhiteSuperGiant,
        [Description("M CLASS SUPER GIANT")]
        M_RedSuperGiant,
        [Description("M CLASS GIANT")]
        M_RedGiant,
        [Description("K CLASS GIANT")]
        K_OrangeGiant,
        [Description("ROGUE PLANET")]
        RoguePlanet,
        [Description("NEBULA")]
        Nebula,
        [Description("STELLA REMNANT")]
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
}
