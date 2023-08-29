using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ContextMenu")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public struct AddonContextMenu {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
}
