using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonChatLogPanel
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ChatLogPanel_0", "ChatLogPanel_1", "ChatLogPanel_2", "ChatLogPanel_3")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3E8)]
public unsafe partial struct AddonChatLogPanel {
    [FieldOffset(0x238)] public AtkResNode* ContainerNode;
    [FieldOffset(0x240)] public AtkComponentButton* ResizeButton;
    [FieldOffset(0x248)] public AtkCollisionNode* PanelCollisionNode;
    [FieldOffset(0x250)] public AtkCollisionNode* TabCollisionNode;
    [FieldOffset(0x258)] public AtkImageNode* TabStartImageNode;
    [FieldOffset(0x260)] public AtkTextNode* TabLabelNode;
    [FieldOffset(0x268)] public AtkComponentBase* ChatComponent;
    [FieldOffset(0x270)] public AtkTextNode* ChatText;
    [FieldOffset(0x278)] public AtkComponentBase* TabComponent;
    [FieldOffset(0x280)] public LogViewer LogViewer;

    [FieldOffset(0x3DE)] public bool IsResizing;
}
