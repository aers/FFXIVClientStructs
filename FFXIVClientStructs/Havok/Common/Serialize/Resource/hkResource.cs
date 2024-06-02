using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Reflection.Registry;

namespace FFXIVClientStructs.Havok.Common.Serialize.Resource;

[GenerateInterop]
[Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkResource {
    [VirtualFunction(7), GenerateStringOverloads]
    public partial void* GetContentsPointer(byte* className, hkTypeInfoRegistry* typeInfoRegistry);
}
