using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventoryBuddy
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InventoryBuddy")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x4A8)]
public unsafe partial struct AddonInventoryBuddy {
    [FieldOffset(0x230), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkComponentRadioButton>> _tabs;
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray70<Pointer<AtkComponentDragDrop>> _slots;
    [FieldOffset(0x498)] public byte TabIndex;

    [MemberFunction("4C 8B DC 53 57 41 56 48 83 EC 70")]
    public partial void SetTab(byte tab);
}
