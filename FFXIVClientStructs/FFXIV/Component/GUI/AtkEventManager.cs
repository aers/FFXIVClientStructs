namespace FFXIVClientStructs.FFXIV.Component.GUI;

// not entirely sure this class exists
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct AtkEventManager
{
    [FieldOffset(0x0)] public AtkEvent* Event; // linked list of events using AtkEvent->NextEvent
}