using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerItemTransferList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2c8)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 33 D2 48 8D 8B ?? ?? ?? ?? 48 89 03 41 B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? B8 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 83 8B", 3)]
public unsafe partial struct AddonRetainerItemTransferList {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkTextNode* SomeText; // Node 6
    [FieldOffset(0x228)] public AtkComponentButton* ConfirmButton; // Node 7
    [FieldOffset(0x230)] public AtkComponentButton* CancelButton; // Node 8

    // Don't know what the real max size is?
    [FieldOffset(0x238)] public fixed byte ListItems[10]; // Node 8
}
