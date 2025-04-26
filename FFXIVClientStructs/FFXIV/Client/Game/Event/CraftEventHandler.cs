using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::CraftEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x4D8)]
public unsafe partial struct CraftEventHandler {
    [FieldOffset(0x218), FixedSizeArray] internal FixedSizeArray106<byte> _recipeExcelRows;
    [FieldOffset(0x320)] public Utf8String RecipeName;
    [FieldOffset(0x390), FixedSizeArray] internal FixedSizeArray20<byte> _recipeLevelTableExcelRows;
    [FieldOffset(0x3F8)] public ExcelSheet* RecipeSheet1;
    [FieldOffset(0x408)] public ExcelSheet* RecipeSheet2;
    [FieldOffset(0x418)] public ExcelSheet* RecipeSheet3;
    [FieldOffset(0x420)] public ExcelSheet* ItemSheet;
    [FieldOffset(0x450)] public uint DataSource;
    [FieldOffset(0x454)] public CraftStateFlags StateFlags;
    [FieldOffset(0x45E)] public ushort StepNumber;
    [FieldOffset(0x46F)] public CraftCondition Condition;
    [FieldOffset(0x470)] public CraftFlags CraftFlags;
    [FieldOffset(0x48A), FixedSizeArray] internal FixedSizeArray2<ushort> _WKSClassLevels;
    [FieldOffset(0x48E), FixedSizeArray] internal FixedSizeArray2<byte> _WKSClassJobs;
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
public enum CraftFlags : uint {
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
