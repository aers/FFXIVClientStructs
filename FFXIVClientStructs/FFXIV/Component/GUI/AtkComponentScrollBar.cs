using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentScrollBar
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 13
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public unsafe partial struct AtkComponentScrollBar : ICreatable {
    [FieldOffset(0xC0)] public AtkComponentNode* ThumbNode;
    [FieldOffset(0xC8)] public AtkComponentButton* ThumbButton;
    [FieldOffset(0xD0)] public AtkComponentNode* TrackNode;
    [FieldOffset(0xD8)] public AtkComponentButton* TrackButton;
    [FieldOffset(0xE0)] public AtkComponentButton* ArrowUpButton;
    [FieldOffset(0xE8)] public AtkComponentButton* ArrowDownButton;
    [FieldOffset(0xF0)] public AtkResNode* ContentNode; // Res or Text
    [FieldOffset(0xF8)] public AtkCollisionNode* ContentCollisionNode;
    [FieldOffset(0x100)] public AtkComponentNode* FadeTopNode;
    [FieldOffset(0x108)] public AtkComponentNode* FadeBottomNode;
    [FieldOffset(0x110)] public float OwnerNodeScale;
    [FieldOffset(0x114)] public int ScrollMaxPosition; // if ScrollPosition == ScrollMaxPosition, the FadeBottomNode fades out
    [FieldOffset(0x118)] public int ScrollPosition;
    [FieldOffset(0x11C)] public int PendingScrollPosition; // if IsBeingDragged
    [FieldOffset(0x120)] public int EmptyLength;
    [FieldOffset(0x124)] public short ThumbPositionStartOffset;
    [FieldOffset(0x126)] public short MouseDownScreenPos;
    [FieldOffset(0x128)] public short ScrollbarLength;
    [FieldOffset(0x12A)] private short Unk12A; // ThumbNode->Height?
    [FieldOffset(0x12C)] public short Margin;
    [FieldOffset(0x12E)] public short MouseWheelSpeed;
    [FieldOffset(0x130)] public short ContentNodeOffset;
    [FieldOffset(0x132)] public short ContentNodeOffScreenLength;
    [FieldOffset(0x134)] public bool IsVertical;
    [FieldOffset(0x135)] public bool IsInputVertical;
    [FieldOffset(0x136)] private bool UnkIsVertical;
    [FieldOffset(0x137)] public bool IsBeingDragged;
    [FieldOffset(0x138)] private bool Unk138;
    [FieldOffset(0x139)] private bool Unk139;
    [FieldOffset(0x13A)] private bool Unk13A;
    [FieldOffset(0x13B)] public bool IsAcceptingMouseWheelEvents;
    [FieldOffset(0x13C)] public bool IsContentNodeTextNode; // ContentNode->Type == NodeType.Text

    // Inlined in 7.0, but still around
    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 51 08 48 89 01 48 8B C1 48 89 51 10 48 89 51 18 48 89 51 20 48 89 51 28 48 89 51 30 48 89 51 38 48 89 51 40 89 51 48 48 89 51 50 48 89 51 58 48 89 51 60 48 89 51 68 89 51 70 48 89 51 78 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 66 89 91 ?? ?? ?? ?? 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 88 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ??")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 83 3E 0B")]
    public partial void SetScrollPosition(int position, bool setScrollPosition = true, bool setPendingScrollPosition = true);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 56 1E")]
    public partial void SetContentNode(AtkResNode* contentNode, AtkCollisionNode* contentCollisionNode, ushort contentCollisionNodeHeight = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 57 65")]
    public partial void SetFadeTopNode(AtkComponentNode* node);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7C 24 ?? 48 8B 5C 24 ?? 45 33 C0")]
    public partial void SetFadeBottomNode(AtkComponentNode* node);
}
