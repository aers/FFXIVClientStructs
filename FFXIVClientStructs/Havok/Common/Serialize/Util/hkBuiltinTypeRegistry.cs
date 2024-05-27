using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Reflection.Registry;

namespace FFXIVClientStructs.Havok.Common.Serialize.Util;

[GenerateInterop, Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkBuiltinTypeRegistry {
    [StaticAddress("8B DA 48 8B 0D ?? ?? ?? ?? 48 8B 01 FF 50 28", 5, isPointer: true)]
    public static partial hkBuiltinTypeRegistry* Instance();

    [VirtualFunction(4)]
    public partial hkTypeInfoRegistry* GetTypeInfoRegistry();

    [VirtualFunction(5)]
    public partial hkClassNameRegistry* GetClassNameRegistry();
}
