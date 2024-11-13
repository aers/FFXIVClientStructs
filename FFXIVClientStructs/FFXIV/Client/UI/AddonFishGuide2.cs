using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFishGuide2
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FishGuide2")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xAB8)]
public partial struct AddonFishGuide2 {
    [FieldOffset(0x2A8)] public TabController TabController;
}
