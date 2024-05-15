using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Animation.Mapper;

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public struct hkaSkeletonMapper {
    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public hkaSkeletonMapperData Mapping;
}
