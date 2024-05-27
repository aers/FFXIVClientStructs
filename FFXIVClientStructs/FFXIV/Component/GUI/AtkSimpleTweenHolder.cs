namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x4008)]
public unsafe partial struct AtkSimpleTweenHolder {
    [FixedSizeArray<Pointer<AtkSimpleTween>>(2048)]
    [FieldOffset(0)] public fixed byte List[0x8 * 2048];
    [FieldOffset(0x4000)] public uint NextId;
}
