using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("MobHunt")]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonMobHunt {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public AtkComponentButton* NextPageButton;
    [FieldOffset(0x228)] public AtkComponentButton* PreviousPageButton;
    [FieldOffset(0x230)] public AtkComponentButton* OpenMapButton;
    [FieldOffset(0x238)] public int CurrentPage;
}
