namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkEventTarget

// size = 0x8
// no explicit constructor, just an event interface with 2 virtual functions

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct AtkEventTarget
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x0)] public void** vfunc;
}