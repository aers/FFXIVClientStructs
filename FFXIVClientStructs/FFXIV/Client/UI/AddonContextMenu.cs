using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ContextMenu")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public struct AddonContextMenu
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x160), Obsolete("use AtkUnitBase.AtkValues")] public unsafe AtkValue* AtkValues;
    [FieldOffset(0x1CA), Obsolete("use AtkUnitBase.AtkValuesCount")] public ushort AtkValuesCount;
}