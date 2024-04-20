using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryEvent")]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct AddonInventoryEvent {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FixedSizeArray<Pointer<AtkComponentRadioButton>>(5)]
    [FieldOffset(0x258)] public fixed byte Buttons[8 * 5];

    [FieldOffset(0x308)] public int TabIndex;

    [MemberFunction("E8 ?? ?? ?? ?? EB 09 83 FF 01")]
    public partial void SetTab(int tab);
}
