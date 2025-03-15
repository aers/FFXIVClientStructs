using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::LogViewer
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public unsafe partial struct LogViewer {
    [FieldOffset(0x10)] public AddonChatLogPanel* ChatLogPanel;
    [FieldOffset(0x18)] public AtkTextNode* ChatText;

    [FieldOffset(0x20)] public AtkComponentNode* ScrollBarNode;
    [FieldOffset(0x28)] public AtkComponentScrollBar* ScrollBarComponent;

    [FieldOffset(0x38)] public AtkStage* AtkStage;

    [FieldOffset(0x48)] public byte FontSize;

    [FieldOffset(0x4C)] public uint FirstLineVisible;
    [FieldOffset(0x50)] public uint LastLineVisible;

    [FieldOffset(0x5C)] public uint TotalLineCount;
    [FieldOffset(0x60)] public ushort ChatTextWidth; // ChatText->GetWidth()
    [FieldOffset(0x62)] public ushort DisplayableLineCount; // ChatText->GetHeight() / LineSpacing

    [FieldOffset(0x88)] public NumberArrayData* NumberArrayData;
    [FieldOffset(0x90)] public uint MessagesAboveCurrent;

    [FieldOffset(0xA8)] public AtkTimer AtkTimer;

    [FieldOffset(0xD9)] public byte IsScrolledBottom;

    [FieldOffset(0xF9)] public byte IsContextMenuShown;

    [FieldOffset(0x120)] public bool IsMaximized;
    [FieldOffset(0x121)] public bool IsSelectingText;

    [MemberFunction("48 85 D2 0F 84 ?? ?? ?? ?? 4C 8B DC 55 56 41 55 49 8D AB")]
    public partial void HandleLinkClick(LinkData* linkData);
}
