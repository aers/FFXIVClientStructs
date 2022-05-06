using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public struct AddonContextMenu
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
}