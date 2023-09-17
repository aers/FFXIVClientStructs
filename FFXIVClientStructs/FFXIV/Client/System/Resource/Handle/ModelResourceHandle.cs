namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public struct ModelResourceHandle {
    [FieldOffset(0x00)] public ResourceHandle ResourceHandle;

    [FieldOffset(0x208)] public StdMap<Pointer<byte>, short> Attributes;
    [FieldOffset(0x228)] public StdMap<Pointer<byte>, short> Shapes;
}
