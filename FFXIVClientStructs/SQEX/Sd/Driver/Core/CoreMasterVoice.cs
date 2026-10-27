namespace FFXIVClientStructs.SQEX.Sd.Driver.Core;

// SQEX::Sd::Driver::Core::CoreMasterVoice
//   SQEX::Sd::Driver::Core::ICoreMasterVoice
//   SQEX::Sd::Driver::Core::ICoreSubmixVoice
//   SQEX::Sd::Driver::Core::ICoreVoice
//   SQEX::Sd::SeadObject<1,16>
/// <summary>
/// A master voice of the software mixer, one for every <see cref="MasterBusId"/>.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct CoreMasterVoice {
    /// <summary> The master volume, the user's master volume slider multiplied by <c>SoundManager.ActiveVolume</c>, applied after every submix. </summary>
    [FieldOffset(0xB4)] public float Volume;
    [FieldOffset(0xD8)] public uint Format;
    [FieldOffset(0xDC)] public MasterBusId BusId;
    [FieldOffset(0xE5), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;

    /// <summary> Sets <see cref="Volume"/>. </summary>
    /// <returns> 0, or -1 without changing it if <paramref name="fadeTicks"/> is not 0. </returns>
    [VirtualFunction(13)]
    public partial int SetVolume(float volume, uint fadeTicks);

    /// <summary> Adds <paramref name="frames"/> frames of interleaved samples in <paramref name="format"/> to this voice, scaled by <paramref name="gain"/>. </summary>
    [VirtualFunction(15)]
    public partial void MixIn(float* buffer, uint frames, float gain, uint format);
}
