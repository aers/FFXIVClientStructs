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
    [FieldOffset(0x38)] public DynamicValue BusVolume;
    [FieldOffset(0x60)] private DynamicValue Unk60;

    /// <summary> One of the volume terms of <see cref="CalculateVolume"/>. </summary>
    [FieldOffset(0x88)] public DynamicValue Volume;

    /// <summary> One of the two playback speed terms, the other one is the object at 0x280. </summary>
    [FieldOffset(0xB0)] public DynamicValue Pitch;
    [FieldOffset(0xD8)] private DynamicValue UnkD8;

    /// <summary> Multiplied into the result of <see cref="CalculateVolume"/>. </summary>
    [FieldOffset(0x220)] public float VolumeScale;

    /// <summary> Routes the sound like the listener was underwater. </summary>
    [FieldOffset(0x225)] public bool UseWaterRouting;

    /// <summary> The product of three values the sound start picks from the volume parameters of the SCD entry. </summary>
    [FieldOffset(0x23C)] public float ParameterVolume;

    /// <summary> 0 selects the player's volume and equalizer submix, 1 the party's, 3 the other players'. </summary>
    [FieldOffset(0x450)] public int PlayerCategory;

    /// <summary> The volume sent to the voice of the sound. </summary>
    /// <remarks>
    /// Calls <see cref="DynamicValue.GetValue"/> on <see cref="Volume"/> and on the object at 0x128 and multiplies the results with
    /// <see cref="ParameterVolume"/>. The product goes through the volume curve of the driver (the identity with <c>VOLUME_CURVE OLD</c> from the
    /// driver config, which the game uses) and is multiplied with <see cref="VolumeScale"/>.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 C8 49 8B CF FF 93 ?? ?? ?? ?? 49 8B 4F")]
    public partial float CalculateVolume();

    /// <summary> Called by the <see cref="Bus"/> for every sound on it when its volume changes. </summary>
    [VirtualFunction(23)]
    public partial void ApplyBusVolume(float volume);

    [VirtualFunction(48)]
    public partial int GetPlayerCategory();

    [VirtualFunction(52)]
    public partial byte GetBusId();

    [VirtualFunction(109)]
    public partial bool GetUseWaterRouting();
}
