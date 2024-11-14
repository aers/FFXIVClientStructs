using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_MiniTalk")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x4A0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 4C 89 A3 ?? ?? ?? ?? 48 8D 8B", 3)]
public unsafe partial struct AddonMiniTalk {

    [FieldOffset(0x248), FixedSizeArray] internal FixedSizeArray10<TalkBubbleEntry> _talkBubbles;

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public struct TalkBubbleEntry {
        [FieldOffset(0x08)] public AtkComponentNode* ComponentNode;
        [FieldOffset(0x10)] public AtkComponentNode* ComponentNode2; // same as above?
        [FieldOffset(0x18)] public AtkResNode* BubbleResNode; // inside component node
        [FieldOffset(0x20)] public AtkTextNode* BubbleTextNode;
        [FieldOffset(0x28)] public AtkNineGridNode* BubbleNineGridNode;
        [FieldOffset(0x30)] public AtkImageNode* BubbleImageNode;
    }
}
