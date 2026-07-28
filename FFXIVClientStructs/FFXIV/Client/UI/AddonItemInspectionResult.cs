using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemInspectionResult
//   Client::UI::AddonItemDetailBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("ItemInspectionResult")]
[GenerateInterop]
[Inherits<AddonItemDetailBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct AddonItemInspectionResult {
    [FieldOffset(0x238)] public Utf8String ItemName;
    [FieldOffset(0x2A0)] public Utf8String ItemNameAlt;
    [FieldOffset(0x308)] public byte ShowingAltName;
}
