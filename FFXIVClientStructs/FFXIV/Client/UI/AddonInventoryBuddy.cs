using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventoryBuddy
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InventoryBuddy")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x498)]
public unsafe partial struct AddonInventoryBuddy {
    [FieldOffset(0x220), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkComponentRadioButton>> _tabs;
    [FieldOffset(0x230), FixedSizeArray] internal FixedSizeArray70<Pointer<AtkComponentDragDrop>> _slots;
    [FieldOffset(0x488)] public byte TabIndex;

    [MemberFunction("4C 8B DC 53 57 41 56 48 83 EC 60")]
    public partial void SetTab(byte tab);
}
