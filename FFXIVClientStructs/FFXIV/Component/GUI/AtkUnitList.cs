namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkUnitList

// size = 0x810
// ctor inlined

[StructLayout(LayoutKind.Explicit, Size = 0x810)]
public unsafe struct AtkUnitList
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public AtkUnitBase* AtkUnitEntries; // array of pointers 0x8-0x808
    [FieldOffset(0x808)] public uint Count;
}