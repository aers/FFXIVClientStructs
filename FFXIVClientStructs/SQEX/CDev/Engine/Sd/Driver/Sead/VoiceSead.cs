using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver.Sead;

// SQEX::CDev::Engine::Sd::Driver::Sead::VoiceSead
//   SQEX::CDev::Engine::Sd::Driver::IVoice
//     SQEX::CDev::Engine::Sd::SdMemoryAllocator
//   SQEX::Sd::Driver::Core::ICoreSourceVoiceCallback
/// <summary>
/// The driver side of a <see cref="CoreSourceVoice"/>. It feeds the decoded samples of a <see cref="SoundTrack"/> to the voice and sends it the volume.
/// </summary>
/// <remarks>
/// The voices are taken from a pool of the driver. The volume sent to the voice is <see cref="Volume"/> times <see cref="ReleaseVolume"/>.
/// </remarks>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 5F 10 48 89 07", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct VoiceSead {
    /// <summary> The interface the <see cref="CoreSourceVoice"/> holds as <see cref="CoreSourceVoice.Callback"/>. </summary>
    [FieldOffset(0x08)] public nint CoreSourceVoiceCallback;

    /// <summary> Set by <see cref="SetTrack"/>. </summary>
    [FieldOffset(0x10)] public SoundTrack* Track;
    [FieldOffset(0x20)] public CoreSourceVoice* CoreSourceVoice;

    /// <summary> The duration of <see cref="ReleaseVolume"/>'s fade. </summary>
    [FieldOffset(0x28)] public int ReleaseFadeTicks;

    /// <summary> 1.0f. When the voice is released while it still plays, the driver fades it to 0 over <see cref="ReleaseFadeTicks"/> and frees the voice after that. </summary>
    /// <remarks> Set by <see cref="SetReleaseVolume"/>. </remarks>
    [FieldOffset(0x2C)] public float ReleaseVolume;

    /// <summary> The result of <see cref="SoundTrack.CalculateVolume"/>, set by <see cref="SetVolume"/>. </summary>
    [FieldOffset(0x30)] public float Volume;

    [VirtualFunction(4)]
    public partial void SetTrack(SoundTrack* track);

    /// <summary> Sets <see cref="Volume"/> and sends <see cref="Volume"/> * <see cref="ReleaseVolume"/> to the <see cref="CoreSourceVoice"/>. </summary>
    [VirtualFunction(19)]
    public partial void SetVolume(float volume);

    [VirtualFunction(34)]
    public partial void SetReleaseFadeTicks(int fadeTicks);

    [VirtualFunction(35)]
    public partial int GetReleaseFadeTicks();

    /// <summary> Sets <see cref="ReleaseVolume"/> and sends the volume like <see cref="SetVolume"/>. </summary>
    [VirtualFunction(36)]
    public partial void SetReleaseVolume(float volume);
}
