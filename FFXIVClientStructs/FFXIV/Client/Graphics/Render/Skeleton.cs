using FFXIVClientStructs.FFXIV.Client.Graphics.Animation;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Skeleton
//   Client::Graphics::ReferencedClassBase
[GenerateInterop]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe partial struct Skeleton {
    // all Skeleton objects are in a global linked list enforced by base class RenderObjectList
    [FieldOffset(0x10)] public Skeleton* LinkedListPrevious;
    [FieldOffset(0x18)] public Skeleton* LinkedListNext;
    [FieldOffset(0x20)] public Transform Transform;
    [FieldOffset(0x50)] public ushort PartialSkeletonCount;

    // Client::System::Resource::Handle::SkeletonResourceHandle pointer array, size = PartialSkeletonCount
    [FieldOffset(0x58)] public SkeletonResourceHandle** SkeletonResourceHandles;

    [FieldOffset(0x60)] public AnimationResourceHandle** AnimationResourceHandles;

    // Client::Graphics::Animation::PartialSkeleton array, size = PartialSkeletonCount
    [FieldOffset(0x68)] public PartialSkeleton* PartialSkeletons;

    // Used by attach execute type 3
    // 1. OwnerCharacter->Skeleton->AttachBonesSpan; find bone by BoneIndex matching Attach.BoneIdx
    // 2. Use the found bone's index to get the BoneIndexMask from OwnerCharacter->Skeleton->BoneMasksSpan
    // 3. Use the BoneIndexMask to get the Partial Skeleton index and Bone index in the owner's skeleton
    [FieldOffset(0x88)] public Bone* AttachBones;

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct Bone {
        [FieldOffset(0x0)] public StdString BoneName;
        [FieldOffset(0x20)] public uint BoneIndex;

        // Rest is likely rotation/translation relative to bone?
    }

    [FieldOffset(0xA0)] public uint AttachBoneCount;
    [FieldOffset(0x98)] public BoneIndexMask* AttachBoneMasks;

    [FieldOffset(0xB8)] public CharacterBase* Owner;

    public Span<Bone> AttachBonesSpan => new(AttachBones, (int)AttachBoneCount);
    public Span<BoneIndexMask> BoneMasksSpan => new(AttachBoneMasks, (int)AttachBoneCount);

    [StructLayout(LayoutKind.Explicit, Size = 0x2)]
    public struct BoneIndexMask {
        [FieldOffset(0x0)] public ushort SkeletonIdxBoneIdx;
        public readonly byte PartialSkeletonIdx => (byte)((SkeletonIdxBoneIdx >> 12) & 0xF);
        public readonly ushort BoneIdx => (ushort)(SkeletonIdxBoneIdx & 0xFFF);
    }
}
