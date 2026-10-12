namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

// Client::Graphics::Animation::IAnimationControllerListener
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct IAnimationControllerListener {

    // 9 vfuncs, though it looks like most aren't implemented by anything.
    // Someone enterprising could hook up their own vtbl and see when they are raised!

    [VirtualFunction(2)]
    public partial void ControllerEaseInFinished(AnimationController* controller);

    [VirtualFunction(3)]
    public partial void ControllerEaseOutFinished(AnimationController* controller);

    [VirtualFunction(4)]
    public partial void ControllerLoopOverflow(AnimationController* controller, float deltaTime, uint overflows);

    [VirtualFunction(5)]
    public partial void ControllerLoopUnderflow(AnimationController* controller, float deltaTime, uint overflows);

    [VirtualFunction(7)]
    public partial void ControllerStop(AnimationController* controller, StopControllerParams* stopParams);

    [VirtualFunction(8)]
    public partial void ControllerCreated(AnimationController* controller);
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct StopControllerParams {
    [FieldOffset(0x0)] internal uint Unk0;
    [FieldOffset(0x4)] public float EaseTime;
}
