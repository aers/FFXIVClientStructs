namespace FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver;

// SQEX::CDev::Engine::Sd::Driver::RootSound
//   SQEX::CDev::Engine::Sd::Driver::ISound
//     SQEX::CDev::Engine::Sd::SdMemoryAllocator
/// <summary>
/// A sound created from a sound entry of a loaded SCD bank. The random, cycle, stream and other sound types derive from it.
/// </summary>
/// <remarks>
/// The derived types start their own fields at 0x480.
/// </remarks>
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x480)]
public unsafe partial struct RootSound {
    [FieldOffset(0x10)] private nint Unk10; // set from the third constructor argument

    /// <summary> Byte 1 of the SCD sound entry. Selects the <see cref="Bus"/> the sound is played on, same as <c>SoundBus</c>. </summary>
    [FieldOffset(0x19)] public byte BusId;

    /// <summary>
    /// Bytes 8-11 of the extended block of the SCD sound entry, 0 if it has none. The voice routing and the sound volume read these bits:<br/>
    /// 0 - <see cref="UsesDefaultRouting"/>: skips the BGEnv and underwater routing<br/>
    /// 1 - <see cref="SendsToVibration"/>: adds a send to the vibration submix<br/>
    /// 2 - <see cref="IsVibrationOnly"/>: only goes to the pad vibration master<br/>
    /// 3 - <see cref="SendsToVibration2"/>: also adds the vibration send<br/>
    /// 4 - <see cref="UsesPlayerCategoryVolume"/>: the volume is scaled by the player, party or other volume of <see cref="PlayerCategory"/><br/>
    /// 5 - <see cref="UsesPlayerCategoryRouting"/>: candidate for the player, party or other equalizer submix<br/>
    /// 6 - <see cref="UsesOutputFormat1"/>: the voice is created with output format 1
    /// </summary>
    [BitField<bool>(nameof(UsesDefaultRouting), 0)]
    [BitField<bool>(nameof(SendsToVibration), 1)]
    [BitField<bool>(nameof(IsVibrationOnly), 2)]
    [BitField<bool>(nameof(SendsToVibration2), 3)]
    [BitField<bool>(nameof(UsesPlayerCategoryVolume), 4)]
    [BitField<bool>(nameof(UsesPlayerCategoryRouting), 5)]
    [BitField<bool>(nameof(UsesOutputFormat1), 6)]
    [FieldOffset(0x30)] public uint ExtendedFlags;

    /// <summary> <see cref="ApplyBusVolume"/> stores the volume of the sound's <see cref="Bus"/> in <see cref="DynamicValue.Scale"/>. </summary>
    /// <remarks>
    /// Multiplied with the other volume terms of the sound when the volume of its voice is calculated.
    /// Stays at 1.0f for a sound that <see cref="Bus.AddSound"/> could not add.
    /// </remarks>
    [FieldOffset(0x38)] public DynamicValue BusVolume;
    [FieldOffset(0x60)] private DynamicValue Unk60;

    [FieldOffset(0x88)] private DynamicValue Unk88;

    /// <summary> One of the two playback speed terms, the other one is the object at 0x280. </summary>
    [FieldOffset(0xB0)] public DynamicValue Pitch;

    /// <summary> Faded to 0 when the sound is paused and back to 1 when it resumes, over the fade ticks of the request. The tracks pause when it reaches 0. </summary>
    [FieldOffset(0xD8)] public DynamicValue PauseVolume;

    /// <summary> The float at byte 8 of the SCD sound entry, copied when the version of the bank is 2 or more. Stream sounds set it from their stream. </summary>
    [FieldOffset(0x12C)] public float EntryVolume;

    /// <summary> Set by <see cref="SetLayoutVolume"/>. The layout sounds (<c>SQEX::CDev::Engine::Sd::Layout</c>) set it through their <c>SoundController</c> from the position of the listener. </summary>
    [FieldOffset(0x130)] public float LayoutVolume;

    /// <summary> Faded by <see cref="SetCommandVolume"/>. Command 7 of a stream sound fades it on every sound that matches the command. </summary>
    [FieldOffset(0x160)] public DynamicValue CommandVolume;

    /// <summary> Routes the sound like the listener was underwater. </summary>
    [FieldOffset(0x225)] public bool UseWaterRouting;

    [FieldOffset(0x31C)] public int TrackCount;
    [FieldOffset(0x320), FixedSizeArray] internal FixedSizeArray32<Pointer<SoundTrack>> _tracks;

    /// <summary> The entry of the level table (block 3 of the SCD sound entry) <see cref="LevelVolume"/> was last faded to. </summary>
    [FieldOffset(0x44D)] public byte Level;

    /// <summary> 0 selects the player's volume and equalizer submix, 1 the party's, 3 the other players'. </summary>
    [FieldOffset(0x450)] public int PlayerCategory;

    /// <summary> Faded by <see cref="SetLevel"/> to the volume of an entry of the level table, with its fade-up or fade-down time. </summary>
    [FieldOffset(0x458)] public DynamicValue LevelVolume;

    /// <summary> The player, party and other volumes the volume of the sound is scaled by when it has <see cref="UsesPlayerCategoryVolume"/>, selected by <see cref="PlayerCategory"/> (0, 1, 3). </summary>
    /// <remarks> Not applied while <see cref="IgnorePlayerCategoryVolume"/> is 1. </remarks>
    [StaticAddress("F3 44 0F 10 05 ?? ?? ?? ?? EB ?? 83 F8 01", 5)]
    public static partial float* PlayerCategoryVolumes();

    /// <summary> 1 while the mode of <c>SoundManager</c> at 0x268 is 1. </summary>
    [StaticAddress("E8 ?? ?? ?? ?? 83 F8 01 74 ?? 48 8B 03", [1, 2])]
    public static partial int* IgnorePlayerCategoryVolume();

    /// <summary> The volume of the sound, set as the scale of <see cref="SoundTrack.Volume"/> on every track. </summary>
    /// <remarks>
    /// The product of <see cref="LevelVolume"/>, <see cref="BusVolume"/>, <see cref="EntryVolume"/>, <see cref="LayoutVolume"/>, <see cref="CommandVolume"/>,
    /// <see cref="PauseVolume"/> and, for a sound with <see cref="UsesPlayerCategoryVolume"/>, the entry of <see cref="PlayerCategoryVolumes"/>.
    /// </remarks>
    [MemberFunction("40 53 48 83 EC 50 0F 29 74 24 40 48 8B D9 0F 29 7C 24 30 44 0F 29 44 24 20 F3 44 0F 10 05 ?? ?? ?? ??")]
    public partial float CalculateVolume();

    /// <summary> Called by the <see cref="Bus"/> for every sound on it when its volume changes. </summary>
    [VirtualFunction(23)]
    public partial void ApplyBusVolume(float volume);

    /// <summary> Fades <see cref="PauseVolume"/> to 0 over <paramref name="fadeTicks"/>, then pauses the tracks. </summary>
    [VirtualFunction(6)]
    public partial void Pause(uint fadeTicks);

    /// <summary> Resumes the tracks and fades <see cref="PauseVolume"/> back to 1 over <paramref name="fadeTicks"/>. </summary>
    [VirtualFunction(8)]
    public partial void Resume(uint fadeTicks);

    [VirtualFunction(16)]
    public partial void SetCommandVolume(float volume, uint fadeTicks);

    [VirtualFunction(25)]
    public partial void SetLayoutVolume(float volume);

    /// <summary> Fades <see cref="LevelVolume"/> to the entry <paramref name="level"/> of the level table, with the fade-up time of the current entry when the level rises and its fade-down time when it falls. </summary>
    /// <param name="level">Ignored when it is not below the number of entries, or when it is the current <see cref="Level"/> and <paramref name="immediate"/> is false.</param>
    /// <param name="immediate">Sets the volume without a fade.</param>
    [VirtualFunction(35)]
    public partial void SetLevel(uint level, bool immediate);

    /// <summary> Stops the sound, fading out over <paramref name="fadeTicks"/>. </summary>
    /// <remarks> Stops all tracks at once when <paramref name="fadeTicks"/> is 0, the state has bit 0x10 or <see cref="BusVolume"/> is 0, so a muted sound has no fade-out. </remarks>
    [VirtualFunction(4)]
    public partial void Stop(uint fadeTicks);

    [VirtualFunction(48)]
    public partial int GetPlayerCategory();

    [VirtualFunction(52)]
    public partial byte GetBusId();

    [VirtualFunction(109)]
    public partial bool GetUseWaterRouting();
}
