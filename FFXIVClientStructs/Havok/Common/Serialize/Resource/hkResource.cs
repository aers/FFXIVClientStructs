using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Reflection.Registry;

namespace FFXIVClientStructs.Havok.Common.Serialize.Resource;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkResource {
    [FieldOffset(0x0)] public hkReferencedObject HkReferencedObject;

    [VirtualFunction(7)]
    [GenerateCStrOverloads]
    public partial void* GetContentsPointer(byte* className, hkTypeInfoRegistry* typeInfoRegistry);
}
