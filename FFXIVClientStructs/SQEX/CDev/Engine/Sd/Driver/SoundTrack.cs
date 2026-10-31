namespace FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver;

/// <summary>
/// One track of a <see cref="RootSound"/>, the link between the sound and the voice that plays it.
/// </summary>
/// <remarks>
/// The tracks are taken from a pool of the driver and listed in <see cref="RootSound.Tracks"/>.
/// The name is not from the game, the class has no virtual functions.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct SoundTrack {
    /// <summary> Taken from the voice pool when the sound starts. Its <see cref="Sead.VoiceSead.Track"/> points back to the track. </summary>
    [FieldOffset(0x08)] public Sead.VoiceSead* Voice;
    [FieldOffset(0x10)] public RootSound* Owner;

    /// <summary> <see cref="DynamicValue.Scale"/> is set to <see cref="RootSound.CalculateVolume"/> of the <see cref="Owner"/>. One of the volume terms of <see cref="CalculateVolume"/>. </summary>
    [FieldOffset(0x88)] public DynamicValue Volume;

    /// <summary> Faded by a command of the track data. One of the volume terms of <see cref="CalculateVolume"/>. </summary>
    [FieldOffset(0x128)] public DynamicValue CommandVolume;

    /// <summary> The position of the track in <see cref="RootSound.Tracks"/>. </summary>
    [FieldOffset(0x208)] public int Index;

    /// <summary> Multiplied into the result of <see cref="CalculateVolume"/>. </summary>
    [FieldOffset(0x220)] public float VolumeScale;

    /// <summary> The product of three values the sound start picks from the volume parameters of the SCD entry. </summary>
    [FieldOffset(0x23C)] public float ParameterVolume;

    /// <summary> The volume sent to the <see cref="Voice"/>, stored there as <see cref="Sead.VoiceSead.Volume"/>. </summary>
    /// <remarks>
    /// Calls <see cref="DynamicValue.GetValue"/> on <see cref="CommandVolume"/> and <see cref="Volume"/> and multiplies the results with
    /// <see cref="ParameterVolume"/>. The product goes through the volume curve of the driver (the identity with <c>VOLUME_CURVE OLD</c> from the
    /// driver config, which the game uses) and is multiplied with <see cref="VolumeScale"/>.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 C8 49 8B CF FF 93 ?? ?? ?? ?? 49 8B 4F")]
    public partial float CalculateVolume();
}
