using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("RaidFinder")]
[StructLayout(LayoutKind.Explicit, Size = 0xEF0)]
public unsafe partial struct AddonRaidFinder
{
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x288)] public AtkComponentList* DutyList;
    [FieldOffset(0x290)] public AtkComponentNode* CategoryDescriptionComponent;
    [FieldOffset(0x298)] public AtkComponentScrollBar* CategoryDescriptionScrollBar;
    [FieldOffset(0x2A0)] public AtkTextNode* ItemLevelText;
    [FieldOffset(0x2A8)] public AtkComponentButton* UnselectButton;
    [FieldOffset(0x2B0)] public AtkComponentDropDownList* OrderByDropDownList;
    [FieldOffset(0x2B8)] public AtkComponentButton* DutyTypeButton;

    [FieldOffset(0x378)] public Utf8String RaidsTooltipString;
    [FieldOffset(0x3E0)] public Utf8String TrialsTooltipString;
    [FieldOffset(0x448)] public Utf8String UltimatesTooltipString;
    
    [FieldOffset(0x4D4)] public int SelectedRow;

    [FixedSizeArray<RaidFinderDutyEntry>(8)]
    [FieldOffset(0x4E8)] public fixed byte EntryInfoArray[0x140 * 8];
}

[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public struct RaidFinderDutyEntry
{
    [FieldOffset(0x00)] public Utf8String DutyName;
    [FieldOffset(0x68)] public Utf8String DutyLevel;
    [FieldOffset(0xD0)] public Utf8String CurrentlyRecruitingPartiesCount;
    
    // There are 8 bytes worth of additional data at the end, not sure what exactly they mean
}
