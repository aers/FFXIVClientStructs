using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemSearch
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 33 ED 48 8D 05 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 89 03 48 89 AB"
[Addon("ItemSearch")]
[StructLayout(LayoutKind.Explicit, Size = 0x3EE0)]
public unsafe partial struct AddonItemSearch {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x230)] public SearchMode Mode;
    [FieldOffset(0x234)] public int SelectedFilter;

    [FieldOffset(0x238)] public Utf8String SearchText;
    [FieldOffset(0x2A0)] public Utf8String SearchText2;

    [FixedSizeArray<Utf8String>(96)]
    [FieldOffset(0x4A8)] public fixed byte FilterLabels[96 * 0x68];

    [FieldOffset(0x2DB0)] public AtkComponentTextInput* SearchTextInput;
    [FieldOffset(0x2DB8)] public AtkComponentButton* SearchButton;

    [FieldOffset(0x2DE0)] public AtkComponentList* ResultsList;

    [FieldOffset(0x3EDB)] public bool PartialMatch;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B DE 48 8D BC 24")]
    public partial void RunSearch(bool ignoreFilters = false);

    [MemberFunction("E8 ?? ?? ?? ?? EB 40 41 8D 40 FD")]
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
