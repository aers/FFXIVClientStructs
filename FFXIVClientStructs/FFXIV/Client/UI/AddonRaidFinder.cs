using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRaidFinder
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RaidFinder")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xF90)]
public unsafe partial struct AddonRaidFinder {
    [FieldOffset(0x238)] public AtkAddonControl AddonControl;

    [FieldOffset(0x2A0)] public AtkComponentList* DutyList;
    [FieldOffset(0x2A8)] public AtkComponentNode* CategoryDescriptionComponent;
    [FieldOffset(0x2B0)] public AtkComponentScrollBar* CategoryDescriptionScrollBar;
    [FieldOffset(0x2B8)] public AtkTextNode* ItemLevelText;
    [FieldOffset(0x2C0)] public AtkComponentButton* UnselectButton;
    [FieldOffset(0x2C8)] public AtkComponentDropDownList* OrderByDropDownList;
    [FieldOffset(0x2D0)] public AtkComponentButton* DutyTypeButton;

    [FieldOffset(0x390)] public Utf8String RaidsTooltipString;
    [FieldOffset(0x3F8)] public Utf8String TrialsTooltipString;
    [FieldOffset(0x460)] public Utf8String UltimatesTooltipString;

    [FieldOffset(0x4EC)] public int HighlightedRow;
    [FieldOffset(0x4F4)] public int NumDisplayedEntries; // Use to index into EntryInfoArray
    [FieldOffset(0x4F8)] public int SelectedTab;

    [FieldOffset(0x500), FixedSizeArray] internal FixedSizeArray8<RaidFinderDutyEntry> _entries;
}

[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public struct RaidFinderDutyEntry {
    [FieldOffset(0x00)] public Utf8String DutyName;
    [FieldOffset(0x68)] public Utf8String DutyLevel;
    [FieldOffset(0xD0)] public Utf8String CurrentlyRecruitingPartiesCount;

    [FieldOffset(0x138)] public RaidFinderEntryFlags Flags;
    // There are 8 bytes worth of additional data at the end, not sure what exactly they mean
}

[Flags]
public enum RaidFinderEntryFlags : byte {
    AvailableForSelection = 0x01, // Checkbox is available and can be checked
    Selected = 0x02,
    Locked = 0x04, // Unable to select duty due to not meeting conditions

    Ultimate = 0x08,
    Unreal = 0x20,
    Extreme = 0x40,
}
