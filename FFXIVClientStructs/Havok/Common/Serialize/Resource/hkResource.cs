namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkResource {
    [FieldOffset(0x0)] public hkReferencedObject HkReferencedObject;

    [VirtualFunction(7)]
    [GenerateCStrOverloads]
    public partial void* GetContentsPointer(byte* className, hkTypeInfoRegistry* typeInfoRegistry);
}
