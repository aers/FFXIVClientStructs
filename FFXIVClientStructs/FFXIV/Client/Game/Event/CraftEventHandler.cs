using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

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

[StructLayout(LayoutKind.Explicit, Size = 0x4C0)]
public unsafe struct CraftEventHandler {
    [FieldOffset(0x0)] public EventHandler EventHandler;
    [FieldOffset(0x210)] public fixed byte RecipeExcelRow[106];
    [FieldOffset(0x320)] public Utf8String RecipeName;
    [FieldOffset(0x388)] public fixed byte RecipeLevelTableExcelRow[20];
    [FieldOffset(0x3F0)] public ExcelSheet* RecipeSheet1;
    [FieldOffset(0x400)] public ExcelSheet* RecipeSheet2;
    [FieldOffset(0x410)] public ExcelSheet* RecipeSheet3;
    [FieldOffset(0x418)] public ExcelSheet* ItemSheet;
    [FieldOffset(0x448)] public uint DataSource;
    [FieldOffset(0x44C)] public CraftStateFlags StateFlags;
    [FieldOffset(0x456)] public ushort StepNumber;
    [FieldOffset(0x467)] public CraftCondition Condition;
    [FieldOffset(0x468)] public CraftFlags CraftFlags;
}
