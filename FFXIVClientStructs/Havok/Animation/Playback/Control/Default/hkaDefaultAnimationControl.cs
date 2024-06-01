using FFXIVClientStructs.Havok.Animation.Mapper;
using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Math.Vector;
using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Animation.Playback.Control.Default;

[GenerateInterop]
[Inherits<hkaAnimationControl>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct hkaDefaultAnimationControl {
    public enum EaseStatusEnum {
        EasingIn,
        EasedIn,
        EasingOut,
        EasedOut,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct hkaDefaultAnimationControlListener;

    [GenerateInterop]
[Inherits<hkReferencedObject>]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct hkaDefaultAnimationControlMapperData {
        [FieldOffset(0x10)] public hkaSkeletonMapper* Mapper;
        [FieldOffset(0x18)] public hkArray<short> SrcBoneToTrackIndices;
        [FieldOffset(0x28)] public hkArray<short> DstBoneToTrackIndices;
        [FieldOffset(0x38)] public hkArray<short> DstTrackToBoneIndices;
    }

    [FieldOffset(0x58)] public float MasterWeight;
    [FieldOffset(0x5C)] public float PlaybackSpeed;
    [FieldOffset(0x60)] public uint OverflowCount;
    [FieldOffset(0x64)] public uint UnderflowCount;
    [FieldOffset(0x68)] public int MaxCycles;
    [FieldOffset(0x70)] public hkVector4f EaseInCurve;
    [FieldOffset(0x80)] public hkVector4f EaseOutCurve;
    [FieldOffset(0x90)] public float EaseInvDuration;
    [FieldOffset(0x94)] public float EaseT;
    [FieldOffset(0x98)] public EaseStatusEnum EaseStatus;
    [FieldOffset(0x9C)] public float CropStartAmountLocalTime;
    [FieldOffset(0xA0)] public float CropEndAmountLocalTime;
    [FieldOffset(0xA8)] public hkArray<hkaDefaultAnimationControlListener> DefaultListeners;
    [FieldOffset(0xB8)] public hkaDefaultAnimationControlMapperData* Mapper;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B DA 48 8B F9 48 8B 52 38")]
    public partial void Ctor1(hkaDefaultAnimationControl* other);
}
