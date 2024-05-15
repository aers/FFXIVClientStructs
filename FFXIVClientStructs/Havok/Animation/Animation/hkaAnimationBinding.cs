using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Container.String;
using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Animation.Animation;

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct hkaAnimationBinding {
    public enum BlendHintEnum {
        Normal = 0x0,
        AdditiveDeprecated = 0x1,
        Additive = 0x2,
    }

    public struct DefaultStruct {
        public fixed int DefaultOffsets[6];
        public byte BlendHint;
    }

    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public hkStringPtr OriginalSkeletonName;
    [FieldOffset(0x18)] public hkRefPtr<hkaAnimation> Animation;
    [FieldOffset(0x20)] public hkArray<short> TransformTrackToBoneIndices;
    [FieldOffset(0x30)] public hkArray<short> FloatTrackToFloatSlotIndices;
    [FieldOffset(0x40)] public hkArray<short> PartitionIndices;
    [FieldOffset(0x50)] public hkEnum<BlendHintEnum, sbyte> BlendHint;
}
