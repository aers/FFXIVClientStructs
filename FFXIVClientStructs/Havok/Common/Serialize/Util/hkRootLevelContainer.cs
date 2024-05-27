using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Container.String;
using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Common.Serialize.Util;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkRootLevelContainer {
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct NamedVariant {
        [FieldOffset(0x00)] public hkStringPtr Name;
        [FieldOffset(0x08)] public hkStringPtr ClassName;
        [FieldOffset(0x10)] public hkRefPtr<hkReferencedObject> Variant;
    }

    [FieldOffset(0x00)] public hkArray<NamedVariant> NamedVariants;

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC 20 33 DB 48 8B EA")]
    [GenerateCStrOverloads]
    public partial void* findObjectByType(byte* typeName, void* prevObject);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 45 1B")]
    [GenerateCStrOverloads]
    public partial void* findObjectByName(byte* objectName, void* prevObject);
}
