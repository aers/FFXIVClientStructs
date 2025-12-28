using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventoryEvent
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InventoryEvent")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonInventoryEvent {
    [FieldOffset(0x270), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentRadioButton>> _buttons;

    [FieldOffset(0x298)] public int OpenerAddonId;

    [FieldOffset(0x2A8)] public AtkAddonControl AddonControl;

    [FieldOffset(0x320)] public int TabIndex;

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 83 FB ?? 0F 85 ?? ?? ?? ?? 48 89 AC 24")]
    public partial void SetTab(int tab);
}
