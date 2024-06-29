using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonChatLogPanel
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ChatLogPanel_0", "ChatLogPanel_1", "ChatLogPanel_2", "ChatLogPanel_3")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3E0)]
public unsafe partial struct AddonChatLogPanel {
    [FieldOffset(0x290)] public AtkTextNode* ChatText;
    [FieldOffset(0x2C0)] public byte FontSize;
    [FieldOffset(0x2C4)] public uint FirstLineVisible;
    [FieldOffset(0x2C8)] public uint LastLineVisible;
    [FieldOffset(0x2D0)] public uint Unknown2C0;
    [FieldOffset(0x2D4)] public uint TotalLineCount;
    [FieldOffset(0x308)] public uint MessagesAboveCurrent;
    [FieldOffset(0x351)] public byte IsScrolledBottom;
}
