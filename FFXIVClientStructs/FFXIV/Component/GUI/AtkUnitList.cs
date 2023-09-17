namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkUnitList
// ctor inlined
[StructLayout(LayoutKind.Explicit, Size = 0x810)]
public unsafe partial struct AtkUnitList {
    [FieldOffset(0x0)] public void* vtbl;
    [FixedSizeArray<Pointer<AtkUnitBase>>(256)]
    [FieldOffset(0x8)] public fixed byte Entries[256 * 0x8];
    [FieldOffset(0x808)] public ushort Count;
}
