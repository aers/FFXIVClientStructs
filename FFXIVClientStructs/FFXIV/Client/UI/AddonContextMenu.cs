using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public struct AddonContextMenu
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x160)] public unsafe AtkValue* AtkValues;
    [FieldOffset(0x1CA)] public ushort AtkValuesCount;
}