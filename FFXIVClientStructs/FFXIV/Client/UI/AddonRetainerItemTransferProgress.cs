using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerItemTransferProgress
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerItemTransferProgress")]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 80 8B", 3)]
public unsafe partial struct AddonRetainerItemTransferProgress {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkTextNode* EntrustAllItemsButton; // Node 2
    [FieldOffset(0x228)] public AtkComponentButton* CloseWindowButton; // Node 9
    [FieldOffset(0x230)] public AtkResNode* ProgressBar; // Node 7
    [FieldOffset(0x238)] public ushort Progress; // Node 7
}
