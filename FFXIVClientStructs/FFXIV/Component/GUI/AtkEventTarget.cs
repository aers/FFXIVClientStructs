namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkEventTarget
// no explicit constructor, just an event interface with 2 virtual functions
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct AtkEventTarget {
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x0), CExportIgnore] public void** vfunc;
}
