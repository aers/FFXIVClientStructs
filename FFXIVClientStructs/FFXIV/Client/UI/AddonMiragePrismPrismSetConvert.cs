using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismSetConvert
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismSetConvert")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x598)]
public unsafe partial struct AddonMiragePrismPrismSetConvert {
    [FieldOffset(0x238)] private AtkResNode* Unk238;
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentButton>> _tabButtons;
    [FieldOffset(0x268)] private AtkTextNode* Unk268;
    [FieldOffset(0x270)] private AtkResNode* Unk270;

    [FieldOffset(0x278), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _itemSlots;
    [FieldOffset(0x2C0), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkResNode>> _itemSlotNodes2;
    [FieldOffset(0x308), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkResNode>> _itemSlotNodes6;
    [FieldOffset(0x350), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkImageNode>> _itemSlotImages5;
    [FieldOffset(0x398), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkImageNode>> _itemSlotImages7;

    [FieldOffset(0x3E0)] private AtkTextNode* Unk3E0;
    [FieldOffset(0x3E8)] private AtkTextNode* Unk3E8;
    [FieldOffset(0x3F0)] public AtkComponentButton* StoreAsGlamourButton;

    [FieldOffset(0x3F8)] private Utf8String Unk3F8;
    [FieldOffset(0x460)] private Utf8String Unk460;
    [FieldOffset(0x4C8)] private nint Unk4C8;
    [FieldOffset(0x4D0)] private byte Unk4D0;
    [FieldOffset(0x4D1)] private byte Unk4D1;
}
