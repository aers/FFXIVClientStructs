using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkComponentUnknownButton
    //   Component::GUI::AtkComponentButton
    //     Component::GUI::AtkComponentBase
    //       Component::GUI::AtkEventListener

    // size = 0xF0
    // common CreateAtkComponent function 8B FA 33 DB E8 ? ? ? ? 
    // type ?
    [StructLayout(LayoutKind.Explicit, Size = 0x120)]
    public unsafe struct AtkComponentUnknownButton
    {
        [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    }
}
