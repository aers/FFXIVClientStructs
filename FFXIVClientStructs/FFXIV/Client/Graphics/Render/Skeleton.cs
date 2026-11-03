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

    [FieldOffset(0x60)] public AnimationResourceHandle** AnimationResourceHandles; // TODO: This type is not a resource handle and needs a better name

    // Client::Graphics::Animation::PartialSkeleton array, size = PartialSkeletonCount
    [FieldOffset(0x68)] public PartialSkeleton* PartialSkeletons;

    [FieldOffset(0x70)] public LookAtIkModule* LookAtIkModule;
    [FieldOffset(0x78)] public ChainIkModule* ChainIkModule;
    [FieldOffset(0x80)] public SlopeIkModule* SlopeIkModule;
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

    /// <summary>
    /// The index of the <c>"eyes"</c> or <c>"Eyes"</c> group in <see cref="LookAtIkModule"/>, or <c>-1</c>.
    /// </summary>
    [FieldOffset(0xE8)] public sbyte EyesLookAtGroupIndex;
    /// <summary>
    /// The index of the <c>"eyes2"</c> or <c>"Eyes2"</c> group in <see cref="LookAtIkModule"/>, or <c>-1</c>.
    /// </summary>
    [FieldOffset(0xE9)] public sbyte Eyes2LookAtGroupIndex;
    [FieldOffset(0xEC)] public int IsUpdatingIk; // InterlockExchange this value as a mutex for the IK update task

    public Span<Bone> AttachBonesSpan => new(AttachBones, (int)AttachBoneCount);
    public Span<BoneIndexMask> BoneMasksSpan => new(AttachBoneMasks, (int)AttachBoneCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 5D")]
    public partial void CreateLookIkModule();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 8B ?? ?? ?? ?? C1 E9 09")]
    public partial void CreateChainIkModule();

    [MemberFunction("E8 ?? ?? ?? ?? B0 01 48 83 C4 60 5B C3 32 C0")]
    public partial void CreateSlopeIkModule();

    /// <summary> Samples and finishes the animation of every skeleton from <paramref name="first"/> on. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 48 8B 6C 24 58")]
    public static partial void UpdateAnimations(Skeleton* first, float deltaTime);

    /// <summary> Blend timers and pose copies after sampling. Run by <see cref="UpdateAnimations"/> in attach depth order, parents first. </summary>
    [MemberFunction("48 89 5C 24 18 55 48 83 EC 30 48 8B E9")]
    public partial void FinishAnimation(float deltaTime);

    /// <summary> Skeletons in attach depth order, parents first. Rebuilt by <see cref="UpdateAnimations"/>. </summary>
    [StaticAddress("89 35 ?? ?? ?? ?? 48 8D 3D ?? ?? ?? ?? 83 FE 01", 9)]
    public static partial SortedSkeletonList* SortedSkeletons();

    /// <summary> Count of <see cref="SortedSkeletons"/>, -1 once the frame's look-at IK has run. </summary>
    [StaticAddress("89 35 ?? ?? ?? ?? 48 8D 3D ?? ?? ?? ?? 83 FE 01", 2)]
    public static partial int* SortedSkeletonCount();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x8800)]
    public partial struct SortedSkeletonList {
        [FieldOffset(0x0000), FixedSizeArray] internal FixedSizeArray2048<SortedSkeleton> _entries;
        /// <summary> Set where an entry starts a new depth. </summary>
        [FieldOffset(0x8000), FixedSizeArray] internal FixedSizeArray2048<bool> _depthChanged;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SortedSkeleton {
        [FieldOffset(0x00)] public Skeleton* Skeleton;
        [FieldOffset(0x08)] public int Depth; // owner parent chain length
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x2)]
    public partial struct BoneIndexMask {
        [BitField<ushort>(nameof(BoneIdx), 0, 12)]
        [BitField<byte>(nameof(PartialSkeletonIdx), 12, 4)]
        [FieldOffset(0x0)] public ushort SkeletonIdxBoneIdx;
    }
}
