namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4008)]
public unsafe partial struct AtkSimpleTweenHolder {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray2048<Pointer<AtkSimpleTween>> _list;
    [FieldOffset(0x4000)] public uint NextId;
}
