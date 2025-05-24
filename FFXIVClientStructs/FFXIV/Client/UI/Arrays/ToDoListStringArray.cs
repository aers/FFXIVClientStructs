using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 212 * 8)]
public unsafe partial struct ToDoListStringArray {
    public static ToDoListStringArray* Instance() => (ToDoListStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.ToDoList)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray212<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray5<CStringPointer> _queuedDuties;

    // 5 is usually blank to skip a line
    [FieldOffset(5 * 8), FixedSizeArray] internal FixedSizeArray4<CStringPointer> _queueStatusMessages;

    // All Titles and then all Detail items in order, compacted
    [FieldOffset(9 * 8), FixedSizeArray] internal FixedSizeArray60<CStringPointer> _questTexts;

    // 69-118 unknown

    [FieldOffset(119 * 8), FixedSizeArray] internal FixedSizeArray40<CStringPointer> _questStatusMessages;

    [FieldOffset(159 * 8)] public CStringPointer ActiveDutyTitle;
    [FieldOffset(160 * 8)] public CStringPointer LeveDescription;
    [FieldOffset(161 * 8)] public CStringPointer LeftOfDutyTimerAndIconText;
    [FieldOffset(162 * 8)] public CStringPointer DutyTimer;

    // Shows up like in Deep Dungeon
    [FieldOffset(163 * 8)] public CStringPointer DutyItemLabel;
    [FieldOffset(164 * 8)] public CStringPointer DutyItemTooltip;

    [FieldOffset(165 * 8), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _dutyObjectives;
    [FieldOffset(175 * 8), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _dutyTimers;

    [FieldOffset(185 * 8)] public CStringPointer FateTitle;
    [FieldOffset(186 * 8)] public CStringPointer FateDetail;
    [FieldOffset(187 * 8)] public CStringPointer FateLevel;
    [FieldOffset(188 * 8)] public CStringPointer FateTimer;
    [FieldOffset(189 * 8)] public CStringPointer LevelSyncButtonText;
    [FieldOffset(190 * 8), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _fateObjectives;
    [FieldOffset(200 * 8), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _fateTimers;

    [FieldOffset(210 * 8)] public CStringPointer DutyTitleText;
    [FieldOffset(211 * 8)] public CStringPointer ReadyingDutyText;
}
