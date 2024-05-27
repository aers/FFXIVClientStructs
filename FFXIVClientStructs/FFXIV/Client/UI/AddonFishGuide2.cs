using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("FishGuide2")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA98)]
public partial struct AddonFishGuide2 {
    [FieldOffset(0x290)] public TabController TabController;
}
