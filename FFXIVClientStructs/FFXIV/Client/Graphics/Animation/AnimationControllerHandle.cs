using FFXIVClientStructs.Havok.Animation.Animation;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

// Client::Graphics::Animation::AnimationControllerHandle
//   Client::Graphics::ReferencedClassBase
/// <summary>
/// A set of <see cref="AnimationController"/>s that can be controlled together as a single unit.
/// </summary>
[Inherits<ReferencedClassBase>]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AnimationControllerHandle {
    [FieldOffset(0x10)] public float PrePausePlaySpeed; // The average play speed of all the controllers when this handle was paused.
    [FieldOffset(0x14)] public bool IsPaused;
    [FieldOffset(0x18)] public StdSet<Pointer<AnimationController>> Controllers;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 40 F3 0F 10 49")]
    public partial void SetInitialParameters(PlayAnimationParams* playParams);

    [MemberFunction("E8 ?? ?? ?? ?? FF C3 3B 5F 04 72 D1")]
    public partial void AddController(AnimationController* controller);

    [MemberFunction("48 89 54 24 ?? 53 48 83 EC 20 48 8B DA")]
    public partial void RemoveController(AnimationController* controller);

    [MemberFunction("80 79 14 00 4C 8B C9 0F 85 ?? ?? ?? ?? 44 8B 51 20 0F 57 C9")]
    public partial void Pause();

    [MemberFunction("F3 0F 10 49 ?? C6 41 14 00")]
    public partial void Unpause();

    [MemberFunction("80 79 14 00 4C 8B C9 0F 85 ?? ?? ?? ?? 44 8B 51 20 0F 57 D2")]
    public partial void TogglePause();

    [MemberFunction("48 8B 49 18 48 8B 01 48 3B C1 0F 84 ?? ?? ?? ?? 0F 57 ED")]
    public partial void EaseOut(float durationSeconds);

    [MemberFunction("E8 ?? ?? ?? ?? 41 F6 45 ?? ?? 74 0D")]
    public partial void SetWeight(float weight);

    [MemberFunction("48 8B 49 18 48 8B 01 48 3B C1 74 78 0F B7 D2")]
    public partial void SetLocalTime(ushort localTimeFrames);

    [MemberFunction("48 8B 49 18 48 8B 01 48 3B C1 0F 84 ?? ?? ?? ?? 0F B7 D2")]
    public partial void SetStartTime(ushort startTimeFrames);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B 79 18 0F B7 F2")]
    public partial void SetEndTime(ushort endTimeFrames);

    [MemberFunction("48 8B 49 18 44 8B D2")]
    public partial void SetOverflowCount(uint overflowCount);

    [MemberFunction("E9 ?? ?? ?? ?? F3 0F 10 51 ?? 32 C0")]
    public partial void SetPlaybackSpeed(float speed);

    [MemberFunction("40 56 48 83 EC 30 33 F6")]
    public partial ushort GetLongestAnimationDuration();

    // Averaging an enum is... kinda cursed
    [MemberFunction("44 8B 51 20 45 85 D2 0F 84 ?? ?? ?? ?? 48 8B 49 18 45 33 C9 48 8B 01 48 3B C1 74 78")]
    public partial hkaAnimationBinding.BlendHintEnum GetAverageBlendHint();
}
