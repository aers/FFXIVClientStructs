using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ContextMenu")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8B CB 48 89 03 E8 ?? ?? ?? ?? 33 C9 48 89 83 ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8B C3", 3)]
public partial struct AddonContextMenu {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [VirtualFunction(72)]
    public partial bool OnMenuSelected(int selectedIdx, byte a3);
}
