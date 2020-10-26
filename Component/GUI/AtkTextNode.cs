using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkTextNode
    //   Component::GUI::AtkResNode
    //     Component::GUI::AtkEventTarget

    // simple text node

    // size = 0x158
    // common CreateAtkNode function E8 ? ? ? ? 48 8B 4E 08 49 8B D5 
    // type 3
    [StructLayout(LayoutKind.Explicit, Size = 0x158)]
    public unsafe struct AtkTextNode
    {
        [FieldOffset(0x0)] public AtkResNode AtkResNode;
        [FieldOffset(0xAC)] public byte ForegroundRed;
        [FieldOffset(0xAD)] public byte ForegroundGreen;
        [FieldOffset(0xAE)] public byte ForegroundBlue;
        [FieldOffset(0xAF)] public byte ForegroundAlpha;
        [FieldOffset(0xB0)] public byte BackgroundRed;
        [FieldOffset(0xB1)] public byte BackgroundGreen;
        [FieldOffset(0xB2)] public byte BackgroundBlue;
        [FieldOffset(0xB3)] public byte BackgroundAlpha;
        [FieldOffset(0xB8)] public FFXIVString NodeText;
    }
}
