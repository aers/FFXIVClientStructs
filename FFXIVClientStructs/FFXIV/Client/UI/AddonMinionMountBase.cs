using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMinionMountBase
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// AddonMinionNoteBook and AddonMountNoteBook inherit from this
[GenerateInterop(isInherited: true)]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xC00)]
public partial struct AddonMinionMountBase {
    [FieldOffset(0x2B0)] public TabController TabController;

    [FieldOffset(0x8D0)] public ViewType CurrentView;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8D 42 D3 83 F8 08")]
    public partial void SwitchToFavorites();

    public enum ViewType {
        Favorites = 1,
        Normal,
        Search,
    }
}
