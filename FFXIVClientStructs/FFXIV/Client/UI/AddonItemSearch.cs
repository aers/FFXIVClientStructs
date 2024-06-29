using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemSearch
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 33 ED 48 8D 05 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 89 03 48 89 AB"
[Addon("ItemSearch")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x4048)]
public unsafe partial struct AddonItemSearch {
    [FieldOffset(0x240)] public SearchMode Mode;
    [FieldOffset(0x244)] public int SelectedFilter;

    [FieldOffset(0x248)] public Utf8String SearchText;
    [FieldOffset(0x2B0)] public Utf8String SearchText2;

    [FieldOffset(0x4B8), FixedSizeArray] internal FixedSizeArray96<Utf8String> _filterLabels;

    [FieldOffset(0x2DC0)] public AtkComponentTextInput* SearchTextInput;
    [FieldOffset(0x2DC8)] public AtkComponentButton* SearchButton;

    [FieldOffset(0x2DF0)] public AtkComponentList* ResultsList;

    [FieldOffset(0x3220)] public AtkComponentCheckBox* PartialSearchCheckBox;

    [FieldOffset(0x3EEB)] public bool PartialMatch;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B DE 48 8D 7D 30")]
    public partial void RunSearch(bool ignoreFilters = false);

    [MemberFunction("E8 ?? ?? ?? ?? EB 41 41 8D 40 FD")]
    public partial void SetModeFilter(SearchMode mode, int filter);

    public enum SearchMode : uint {
        Normal = 0,
        ArmsFilter = 1,
        EquipmentFilter = 2,
        ItemsFilter = 3,
        HousingFilter = 4,
        Wishlist = 5,
        Favorites = 6,
        Unset = 7
    }
}
