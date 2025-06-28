using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerItemTransferProgress
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerItemTransferProgress")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 0F 57 C0 48 89 03 33 C0 0F 11 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ??", 3, 74)]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonRetainerItemTransferProgress {
    [FieldOffset(0x238)] public AtkTextNode* EntrustAllItemsButton; // Node 2
    [FieldOffset(0x240)] public AtkComponentButton* CloseWindowButton; // Node 9
    [FieldOffset(0x248)] public AtkResNode* ProgressBar; // Node 7
    [FieldOffset(0x250)] public ushort Progress; // Node 7
}
