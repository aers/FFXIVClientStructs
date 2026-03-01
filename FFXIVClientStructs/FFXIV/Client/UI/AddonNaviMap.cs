using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonNaviMap
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_NaviMap")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3A90)]
public partial struct AddonNaviMap {
    [FieldOffset(0x238)] public Atk2DMap Atk2DMap;
}
