using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::CraftEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x478)]
public unsafe partial struct CraftEventHandler {
    [FieldOffset(0x1B8 + 0x00), CExporterExcelBegin("Recipe")] public uint RequiredQuality;
    [FieldOffset(0x1B8 + 0x04)] public uint Quest;
    [FieldOffset(0x1B8 + 0x08)] public int Number;
    [FieldOffset(0x1B8 + 0x0C)] public int CraftType;
    [FieldOffset(0x1B8 + 0x10)] public int ItemResult;
    [FieldOffset(0x1B8 + 0x14), FixedSizeArray] internal FixedSizeArray8<int> _ingredient;
    [FieldOffset(0x1B8 + 0x34)] public int StatusRequired;
    [FieldOffset(0x1B8 + 0x38)] public int ItemRequired;
    [FieldOffset(0x1B8 + 0x3C)] public ushort RecipeLevelTable;
    [FieldOffset(0x1B8 + 0x3E)] public ushort MaxAdjustableJobLevel;
    [FieldOffset(0x1B8 + 0x40)] public ushort RecipeNotebookList;
    [FieldOffset(0x1B8 + 0x42)] public ushort DisplayPriority;
    [FieldOffset(0x1B8 + 0x44)] public ushort DifficultyFactor;
    [FieldOffset(0x1B8 + 0x46)] public ushort QualityFactor;
    [FieldOffset(0x1B8 + 0x48)] public ushort DurabilityFactor;
    [FieldOffset(0x1B8 + 0x4A)] public ushort RequiredCraftsmanship;
    [FieldOffset(0x1B8 + 0x4C)] public ushort RequiredControl;
    [FieldOffset(0x1B8 + 0x4E)] public ushort QuickSynthCraftsmanship;
    [FieldOffset(0x1B8 + 0x50)] public ushort QuickSynthControl;
    [FieldOffset(0x1B8 + 0x52)] public ushort SecretRecipeBook;
    [FieldOffset(0x1B8 + 0x54)] public ushort CollectableMetadata;
    [FieldOffset(0x1B8 + 0x56)] public ushort PatchNumber;
    [FieldOffset(0x1B8 + 0x58)] public byte AmountResult;
    [FieldOffset(0x1B8 + 0x59), FixedSizeArray] internal FixedSizeArray8<byte> _amountIngredient;
    [FieldOffset(0x1B8 + 0x61)] public byte MaterialQualityFactor;
    [FieldOffset(0x1B8 + 0x62)] public byte CollectableMetadataKey;
    [FieldOffset(0x1B8 + 0x63), CExporterExcelEnd] public byte BitField63;

    [FieldOffset(0x2C0)] public Utf8String RecipeName;
    [FieldOffset(0x328 + 0x00), CExporterExcelBegin("RecipeLevelTable")] public uint Quality;
    [FieldOffset(0x328 + 0x04)] public ushort SuggestedCraftsmanship;
    [FieldOffset(0x328 + 0x06)] public ushort Difficulty;
    [FieldOffset(0x328 + 0x08)] public ushort Durability;
    [FieldOffset(0x328 + 0x0A)] public ushort ConditionsFlag;
    [FieldOffset(0x328 + 0x0C)] public byte ClassJobLevel;
    [FieldOffset(0x328 + 0x0D)] public byte Stars;
    [FieldOffset(0x328 + 0x0E)] public byte ProgressDivider;
    [FieldOffset(0x328 + 0x0F)] public byte QualityDivider;
    [FieldOffset(0x328 + 0x10)] public byte ProgressModifier;
    [FieldOffset(0x328 + 0x11), CExporterExcelEnd] public byte QualityModifier;

    [FieldOffset(0x3A0)] public ExcelSheet* RecipeSheet1;
    [FieldOffset(0x3B0)] public ExcelSheet* RecipeSheet2;
    [FieldOffset(0x3C0)] public ExcelSheet* RecipeSheet3;
    [FieldOffset(0x3C8)] public ExcelSheet* ItemSheet;

    [FieldOffset(0x408)] public uint DataSource;
    [FieldOffset(0x40C)] public CraftStateFlags StateFlags;

    [FieldOffset(0x414)] public ushort RecipeId;
    [FieldOffset(0x416)] public ushort StepNumber;

    [FieldOffset(0x427)] public CraftCondition Condition;
    [FieldOffset(0x428)] public CraftFlags CraftFlags;
    [FieldOffset(0x42A), FixedSizeArray] internal FixedSizeArray2<ushort> _WKSClassLevels;
    [FieldOffset(0x42E), FixedSizeArray] internal FixedSizeArray2<byte> _WKSClassJobs;

    [MemberFunction("E8 ?? ?? ?? ?? B0 ?? E9 ?? ?? ?? ?? 49 8B D6")]
    public partial void EndCraftingMode();
}

[Flags]
public enum CraftStateFlags : uint {
    Unk1 = 1 << 0,
    NotFirstStep = 1 << 1,
    Unk2 = 1 << 4,
    StandardTouchProc = 1 << 27,
    AdvancedTouchProc = 1 << 28,
    ObservedProc = 1 << 29,
    NoMoreCarefulObservation = 1 << 30,
    NoMoreHeartAndSoul = 1u << 31
}

[Flags]
public enum CraftFlags : byte {
    ExecutingAction2 = 1 << 0,
    Unk1 = 1 << 1,
    NotTrialSynthesis = 1 << 2,
    ExecutingAction1 = 1 << 3,
    Unk2 = 1 << 4,
    Unk3 = 1 << 5
}

public enum CraftCondition : byte {
    Normal = 1,
    Good,
    Excellent,
    Poor,

    Centered,
    Sturdy,
    Pliant,
    Malleable,
    Primed,
    GoodOmen,
}
