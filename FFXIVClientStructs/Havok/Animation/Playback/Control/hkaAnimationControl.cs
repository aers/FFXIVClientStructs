using FFXIVClientStructs.Havok.Animation.Animation;
using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Animation.Playback.Control;

[GenerateInterop(isInherited: true), Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct hkaAnimationControl {
    [FieldOffset(0x10)] public float LocalTime;
    [FieldOffset(0x14)] public float Weight;
    [FieldOffset(0x18)] public hkArray<byte> TransformTrackWeights;
    [FieldOffset(0x28)] public hkArray<byte> FloatTrackWeights;
    [FieldOffset(0x38)] public hkRefPtr<hkaAnimationBinding> Binding;
    [FieldOffset(0x40)] public hkArray<Pointer<hkaAnimationControlListener>> Listeners;
    [FieldOffset(0x50)] public float MotionTrackWeight;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8B CB 48 89 07")]
    public partial void Ctor1(hkaAnimationBinding* binding);

    [MemberFunction("48 63 41 48 45 33 C9")]
    public partial void RemoveAnimationControlListener(hkaAnimationControlListener* listener);
}
