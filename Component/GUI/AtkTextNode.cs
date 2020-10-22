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
        [FieldOffset(0xB8)] public FFXIVString NodeText;
    }
}
