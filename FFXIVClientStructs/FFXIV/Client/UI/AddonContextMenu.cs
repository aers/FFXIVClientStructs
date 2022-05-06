using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public struct AddonContextMenu
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public unsafe AtkValue* AtkValues; // bad offset?
    [FieldOffset(0x228)] public ushort AtkValuesCount; // bad offset?
}