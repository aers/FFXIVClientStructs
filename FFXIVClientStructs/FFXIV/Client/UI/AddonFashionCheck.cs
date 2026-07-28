using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFashionCheck
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FashionCheck")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2F8)]
public unsafe partial struct AddonFashionCheck {
    [FieldOffset(0x238)] public PreviewController PreviewController;
    [FieldOffset(0x2F0)] private byte Unk2F0;
}
