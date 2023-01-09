namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentButton
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0xF0
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 1
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe struct AtkComponentButton
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;

    // based on the text size
    [FieldOffset(0xC0)] public short Left;
    [FieldOffset(0xC2)] public short Top;
    [FieldOffset(0xC4)] public short Right;
    [FieldOffset(0xC6)] public short Bottom;
    [FieldOffset(0xC8)] public AtkTextNode* ButtonTextNode;
    [FieldOffset(0xD0)] public AtkResNode* ButtonBGNode;
    [FieldOffset(0xE8)] public uint Flags;

    public bool IsEnabled => (AtkComponentBase.OwnerNode->AtkResNode.Flags & (1 << 5)) != 0;
}