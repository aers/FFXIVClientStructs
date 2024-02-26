using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ContextMenu")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public partial struct AddonContextMenu {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [VirtualFunction(72)]
    public partial bool OnMenuSelected(int selectedIdx, byte a3);
}
