using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ContextMenu")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public struct AddonContextMenu
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [Obsolete("Use AtkUnitBase.AtkValues instead.", true)][FieldOffset(0x160)] public unsafe AtkValue* AtkValues;
    [Obsolete("Use AtkUnitBase.AtkValuesCount instead.", true)][FieldOffset(0x1CA)] public ushort AtkValuesCount;
}