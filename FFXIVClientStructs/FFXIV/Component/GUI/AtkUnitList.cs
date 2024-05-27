namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkUnitList
// ctor inlined
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x810)]
public unsafe partial struct AtkUnitList {
    [FieldOffset(0x8)] internal FixedSizeArray256<Pointer<AtkUnitBase>> _entries;
    [FieldOffset(0x808)] public ushort Count;
}
