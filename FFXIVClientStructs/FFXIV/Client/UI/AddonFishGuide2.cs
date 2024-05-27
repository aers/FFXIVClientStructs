using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("FishGuide2")]
[StructLayout(LayoutKind.Explicit, Size = 0xA98)]
public struct AddonFishGuide2 {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x290)] public TabController TabController;
}
