using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// AddonMinionNoteBook and AddonMountNoteBook inherit from this
[StructLayout(LayoutKind.Explicit, Size = 0xBF0)]
public partial struct AddonMinionMountBase {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2A0)] public TabController TabController;

    [FieldOffset(0x8C0)] public ViewType CurrentView;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8D 42 D3 83 F8 08")]
    public partial void SwitchToFavorites();

    public enum ViewType {
        Favorites = 1,
        Normal,
        Search,
    }
}
