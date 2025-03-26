using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Container.String;
using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Common.Serialize.Util;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkRootLevelContainer {
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct NamedVariant {
        [FieldOffset(0x00)] public hkStringPtr Name;
        [FieldOffset(0x08)] public hkStringPtr ClassName;
        [FieldOffset(0x10)] public hkRefPtr<hkReferencedObject> Variant;
    }

    [FieldOffset(0x00)] public hkArray<NamedVariant> NamedVariants;

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC 20 33 DB 48 8B EA"), GenerateStringOverloads]
    public partial void* findObjectByType(CStringPointer typeName, void* prevObject);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC 20 33 DB 48 8B EA"), GenerateStringOverloads]
    public partial void* findObjectByName(CStringPointer objectName, void* prevObject);
}
