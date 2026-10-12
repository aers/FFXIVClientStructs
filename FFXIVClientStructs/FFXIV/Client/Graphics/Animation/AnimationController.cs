using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.Havok.Animation.Animation;
using FFXIVClientStructs.Havok.Animation.Playback.Control;
using FFXIVClientStructs.Havok.Animation.Playback.Control.Default;
using static FFXIVClientStructs.Havok.Animation.Playback.Control.Default.hkaDefaultAnimationControl;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

// Client::Graphics::Animation::AnimationController
//   Client::Graphics::ReferencedClassBase
//   hkaDefaultAnimationControlListener
[Inherits<ReferencedClassBase>]
[Inherits<hkaDefaultAnimationControlListener>(parentOffset: 0x10)]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AnimationController {
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray4<Pointer<IAnimationControllerListener>> _listeners;
    [FieldOffset(0x38)] public hkaDefaultAnimationControl* HavokAnimationControl;
    [FieldOffset(0x40)] public PartialAnimationPackResourceHandle* PapResourceHandle;
    [FieldOffset(0x48)] internal void* Unk48;
    [FieldOffset(0x50)] public ushort IntroDurationFrames; // How many frames should be skipped after the first time the animation plays.
    [FieldOffset(0x52)] public bool IsInIntro; // Whether we have yet to finish playing the intro section of the animation (see IntroTimeFrames).
    [FieldOffset(0x53)] public byte HavokAnimatedSkeletonIndex; // Index into PartialSkeleton.HavokAnimatedSkeletons
    [FieldOffset(0x54)] public float CurrentWeight;

    /// <summary>
    /// Sets the initial play parameters to use.
    /// </summary>
    [MemberFunction("48 83 EC 38 4C 8B 41 38")]
    public partial void SetPlayParams(PlayAnimationParams* playParams);

    /// <summary>
    /// Causes the animation to fade out over the given number of seconds.
    /// </summary>
    /// <param name="durationSeconds">The duration of the fade.</param>
    [MemberFunction("48 83 EC 18 48 8B 51 38")]
    public partial void EaseOut(float durationSeconds);

    /// <summary>
    /// Sets the pap resource handle being used by this animation controller.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 0F 48 8B D3")]
    public partial void SetPapResourceHandle(PartialAnimationPackResourceHandle* papResourceHandle);

    /// <summary>
    /// Creates <see cref="HavokAnimationControl"/> based on the given animation binding and parameters.
    /// </summary>
    /// <param name="animationBinding">The animation binding to create the control for.</param>
    /// <param name="startEasedIn">Whether to start the animation fully eased in, or to ease in gradually.</param>
    /// <param name="maxCycles">The max number of times to loop the animation.</param>
    [MemberFunction("E8 ?? ?? ?? ?? F3 41 0F 10 46 ?? 38 5E 53")]
    public partial void CreateAnimationControl(hkaAnimationBinding* animationBinding, bool startEasedIn, short maxCycles);

    /// <summary>
    /// Updates <see cref="IsInIntro"/> and the clip start time if the intro section has finished playing.
    /// </summary>
    /// <remarks>
    /// The intro period is the first <see cref="IntroDurationFrames"/> frames of the animation.
    /// </remarks>
    [MemberFunction("80 79 52 00 74 49")]
    public partial void ApplyIntroCheck();
}
