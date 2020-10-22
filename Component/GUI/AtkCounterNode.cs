using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkCounterNode
    //   Component::GUI::AtkResNode
    //     Component::GUI::AtkEventTarget

    // size = 0x128
    // common CreateAtkNode function E8 ? ? ? ? 48 8B 4E 08 49 8B D5 
    // type 5
    [StructLayout(LayoutKind.Explicit, Size = 0x128)]
    public unsafe struct AtkCounterNode
    {
        [FieldOffset(0x0)] public AtkResNode AtkResNode;
        [FieldOffset(0xC0)] public FFXIVString NodeText;
    }
}
