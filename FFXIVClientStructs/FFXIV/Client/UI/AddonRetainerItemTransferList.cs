using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerItemTransferList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 33 D2 48 8D 8B ?? ?? ?? ?? 48 89 03 41 B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? B8 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 83 8B", 3, 74)]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct AddonRetainerItemTransferList {
    [FieldOffset(0x238)] public AtkTextNode* SomeText; // Node 6
    [FieldOffset(0x240)] public AtkComponentButton* ConfirmButton; // Node 7
    [FieldOffset(0x248)] public AtkComponentButton* CancelButton; // Node 8

    // Don't know what the real max size is?
    [FieldOffset(0x250), FixedSizeArray] internal FixedSizeArray10<byte> _listItems; // Node 8
}
