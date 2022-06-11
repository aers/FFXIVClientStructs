using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 1280)]
[Addon("_CastBar")]
public struct AddonCastBar {
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public Utf8String CastName;
    [FieldOffset(0x2BC)] public ushort CastTime;
    [FieldOffset(0x2C0)] public float CastPercent;
       
}