using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAreaMap
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("AreaMap")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x7E0)]
public unsafe partial struct AddonAreaMap {
    [FieldOffset(0x240)] public AtkComponentMap* ComponentMap;

    [FieldOffset(0x3A8)] public Atk2DAreaMap AreaMap;

    [FieldOffset(0x7B0)] public ushort MouseXInteger;
    [FieldOffset(0x7B2)] public ushort MouseXDecimal;
    [FieldOffset(0x7B4)] public ushort MouseYInteger;
    [FieldOffset(0x7B6)] public ushort MouseYDecimal;

    public Vector2 MouseCoords => new(MouseXInteger + MouseXDecimal / 100f, MouseYInteger + MouseYDecimal / 100f);
}
