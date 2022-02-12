namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkEventListener

// size = 0x8
// no explicit constructor, just an event interface with 3 virtual functions
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct AtkEventListener
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x0)] public void** vfunc;
}