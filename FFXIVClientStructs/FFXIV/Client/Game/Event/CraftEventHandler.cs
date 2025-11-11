using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::CraftEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x4D8)]
public unsafe partial struct CraftEventHandler {
    [FieldOffset(0x218 + 0x00), CExporterExcelBegin("Recipe")] public uint RequiredQuality;
    [FieldOffset(0x218 + 0x04)] public uint Quest;
    [FieldOffset(0x218 + 0x08)] public int Number;
    [FieldOffset(0x218 + 0x0C)] public int CraftType;
    [FieldOffset(0x218 + 0x10)] public int ItemResult;
    [FieldOffset(0x218 + 0x14), FixedSizeArray] internal FixedSizeArray8<int> _ingredient;
    [FieldOffset(0x218 + 0x34)] public int StatusRequired;
    [FieldOffset(0x218 + 0x38)] public int ItemRequired;
    [FieldOffset(0x218 + 0x3C)] public ushort RecipeLevelTable;
    [FieldOffset(0x218 + 0x3E)] public ushort MaxAdjustableJobLevel;
    [FieldOffset(0x218 + 0x40)] public ushort RecipeNotebookList;
    [FieldOffset(0x218 + 0x42)] public ushort DisplayPriority;
    [FieldOffset(0x218 + 0x44)] public ushort DifficultyFactor;
    [FieldOffset(0x218 + 0x46)] public ushort QualityFactor;
    [FieldOffset(0x218 + 0x48)] public ushort DurabilityFactor;
    [FieldOffset(0x218 + 0x4A)] public ushort RequiredCraftsmanship;
    [FieldOffset(0x218 + 0x4C)] public ushort RequiredControl;
    [FieldOffset(0x218 + 0x4E)] public ushort QuickSynthCraftsmanship;
    [FieldOffset(0x218 + 0x50)] public ushort QuickSynthControl;
    [FieldOffset(0x218 + 0x52)] public ushort SecretRecipeBook;
    [FieldOffset(0x218 + 0x54)] public ushort CollectableMetadata;
    [FieldOffset(0x218 + 0x56)] public ushort PatchNumber;
    [FieldOffset(0x218 + 0x58)] public byte AmountResult;
    [FieldOffset(0x218 + 0x59), FixedSizeArray] internal FixedSizeArray8<byte> _amountIngredient;
    [FieldOffset(0x218 + 0x61)] public byte MaterialQualityFactor;
    [FieldOffset(0x218 + 0x62)] public byte CollectableMetadataKey;
    [FieldOffset(0x218 + 0x63), CExporterExcelEnd] public byte BitField63;

    [FieldOffset(0x320)] public Utf8String RecipeName;
    [FieldOffset(0x388 + 0x00), CExporterExcelBegin("RecipeLevelTable")] public uint Quality;
    [FieldOffset(0x388 + 0x04)] public ushort SuggestedCraftsmanship;
    [FieldOffset(0x388 + 0x06)] public ushort Difficulty;
    [FieldOffset(0x388 + 0x08)] public ushort Durability;
    [FieldOffset(0x388 + 0x0A)] public ushort ConditionsFlag;
    [FieldOffset(0x388 + 0x0C)] public byte ClassJobLevel;
    [FieldOffset(0x388 + 0x0D)] public byte Stars;
    [FieldOffset(0x388 + 0x0E)] public byte ProgressDivider;
    [FieldOffset(0x388 + 0x0F)] public byte QualityDivider;
    [FieldOffset(0x388 + 0x10)] public byte ProgressModifier;
    [FieldOffset(0x388 + 0x11), CExporterExcelEnd] public byte QualityModifier;

    [FieldOffset(0x400)] public ExcelSheet* RecipeSheet1;
    [FieldOffset(0x410)] public ExcelSheet* RecipeSheet2;
    [FieldOffset(0x420)] public ExcelSheet* RecipeSheet3;
    [FieldOffset(0x428)] public ExcelSheet* ItemSheet;

    [FieldOffset(0x468)] public uint DataSource;
    [FieldOffset(0x46c)] public CraftStateFlags StateFlags;

    [FieldOffset(0x474)] public ushort RecipeId;
    [FieldOffset(0x476)] public ushort StepNumber;

    [FieldOffset(0x487)] public CraftCondition Condition;
    [FieldOffset(0x488)] public CraftFlags CraftFlags;
    [FieldOffset(0x48A), FixedSizeArray] internal FixedSizeArray2<ushort> _WKSClassLevels;
    [FieldOffset(0x48E), FixedSizeArray] internal FixedSizeArray2<byte> _WKSClassJobs;

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
