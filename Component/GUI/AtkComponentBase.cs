using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkComponentBase
    //   Component::GUI::AtkEventListener

    // base class for UI components that are more complicated than a single node

    // size = 0xC0
    // common CreateAtkComponent function 8B FA 33 DB E8 ? ? ? ? 
    // type 0
    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public unsafe struct AtkComponentBase
    {
        [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
    }
}
