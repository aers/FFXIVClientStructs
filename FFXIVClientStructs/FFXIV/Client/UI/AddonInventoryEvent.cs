using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryEvent")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct AddonInventoryEvent {
    [FieldOffset(0x258), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentRadioButton>> _buttons;

    [FieldOffset(0x290)] public AtkAddonControl AddonControl;

    [FieldOffset(0x308)] public int TabIndex;

    [MemberFunction("E8 ?? ?? ?? ?? EB 09 83 FF 01")]
    public partial void SetTab(int tab);
}
