using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryBuddy")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x498)]
public unsafe partial struct AddonInventoryBuddy {
    [FieldOffset(0x220), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkComponentRadioButton>> _tabs;
    [FieldOffset(0x230), FixedSizeArray] internal FixedSizeArray70<Pointer<AtkComponentDragDrop>> _slots;
    [FieldOffset(0x488)] public byte TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B 5C 24 ?? 48 83 C4 20")]
    public partial void SetTab(byte tab);
}
