using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFishingNote
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FishingNote")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1710)]
public partial struct AddonFishingNote {
    [FieldOffset(0x2F0)] public Atk2DAreaMap Atk2DAreaMap;
}
