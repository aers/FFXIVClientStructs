using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Animation.Mapper;

[GenerateInterop, Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public partial struct hkaSkeletonMapper {
    [FieldOffset(0x10)] public hkaSkeletonMapperData Mapping;
}
