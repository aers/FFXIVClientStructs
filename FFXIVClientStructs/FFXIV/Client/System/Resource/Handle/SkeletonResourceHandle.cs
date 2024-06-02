using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.Havok.Animation.Mapper;
using FFXIVClientStructs.Havok.Animation.Rig;
using FFXIVClientStructs.Havok.Common.Serialize.Util;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::SkeletonResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x138)]
public unsafe partial struct SkeletonResourceHandle {
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct SkeletonHeader {
        [FieldOffset(0x0)] public uint SklbMagic;
        [FieldOffset(0x4)] public uint SklbVersion;
        [FieldOffset(0x8)] public uint LayerOffset;
        [FieldOffset(0xC)] public uint SklbOffset;
        [FieldOffset(0x10)] public ushort ConnectBoneIndex;
        [FieldOffset(0x12)] private ushort pad;
        [FieldOffset(0x14)] public uint CharacterId;
        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray4<uint> _skeletonMappers;
        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray4<ushort> _connectBoneIds;
    }

    [FieldOffset(0xC8)] public uint BoneCount;
    [FieldOffset(0xD0)] public hkaSkeleton* HavokSkeleton;
    [FieldOffset(0xD8)] public StdMap<uint, Pointer<hkaSkeletonMapper>> SkeletonMapperDict1;
    [FieldOffset(0xE8)] public StdMap<uint, Pointer<hkaSkeletonMapper>> SkeletonMapperDict2;
    [FieldOffset(0xF8)] public Matrix4x4* InverseBoneMatrix;
    [FieldOffset(0x100)] public hkLoader* HavokLoader;
    [FieldOffset(0x108)] public SkeletonHeader SkeletonData;
}
