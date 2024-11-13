using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCastBar
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_CastBar")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public partial struct AddonCastBar {
    [FieldOffset(0x238)] public Utf8String CastName;
    [FieldOffset(0x2D4)] public ushort CastTime;
    [FieldOffset(0x2D8)] public float CastPercent;
}
