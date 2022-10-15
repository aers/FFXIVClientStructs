namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public unsafe partial struct hkaAnimationControl
{
	public hkReferencedObject hkReferencedObject;
	public float LocalTime;
	public float Weight;
	public hkArray<byte> TransformTrackWeights;
	public hkArray<byte> FloatTrackWeights;
	public hkRefPtr<hkaAnimationBinding> Binding;
	public hkArray<Pointer<hkaAnimationControlListener>> Listeners;
	public float MotionTrackWeight;

	[MemberFunction("E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8B CB 48 89 07")]
	public partial void Ctor1(hkaAnimationBinding* binding);

	[MemberFunction("48 63 41 48 45 33 C9")]
	public partial void RemoveAnimationControlListener(hkaAnimationControlListener* listener);
}