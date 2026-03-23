using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonBagWidget
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_BagWidget")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonBagWidget {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentButton>> _bagButtonComponents;
    [FieldOffset(0x258)] public AtkComponentButton* EquipmentButtonComponent;
}
