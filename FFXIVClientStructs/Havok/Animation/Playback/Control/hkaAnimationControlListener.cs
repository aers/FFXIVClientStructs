namespace FFXIVClientStructs.Havok.Animation.Playback.Control;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct hkaAnimationControlListener {
    [VirtualFunction(0)]
    public partial void ControlDeletedCallback(hkaAnimationControl* control);

    [VirtualFunction(1)]
    public partial hkaAnimationControlListener* Dtor(byte freeFlags);
}
