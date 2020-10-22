using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkNineGridNode
    //   Component::GUI::AtkResNode
    //     Component::GUI::AtkEventTarget

    // size = 0xC8
    // common CreateAtkNode function E8 ? ? ? ? 48 8B 4E 08 49 8B D5 
    // type 4
    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public unsafe struct AtkNineGridNode
    {
        [FieldOffset(0x0)] public AtkResNode AtkResNode;
    }
}
