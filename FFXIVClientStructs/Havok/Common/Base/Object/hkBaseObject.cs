namespace FFXIVClientStructs.Havok.Common.Base.Object;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct hkBaseObject {
    [VirtualFunction(0)]
    public partial hkBaseObject* Dtor(byte freeFlags);
}
