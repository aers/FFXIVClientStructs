using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // not entirely sure this class exists
    [StructLayout(LayoutKind.Explicit, Size=0x8)]
    public unsafe partial struct AtkEventManager
    {
        [FieldOffset(0x0)] public AtkEvent* Event; // linked list of events using AtkEvent->NextEvent
    }
}