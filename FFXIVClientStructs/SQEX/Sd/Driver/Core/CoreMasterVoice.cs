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
    /// <summary> Master bed and Master ambisonics get a low-pass filter and the equalizer selected by <c>SoundManager.SetEqualizerType</c>. </summary>
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray4<Pointer<ICoreEffect>> _effects;
    [FieldOffset(0xB0)] public int EffectCount;

    /// <summary> The master volume, the user's master volume slider multiplied by <c>SoundManager.ActiveVolume</c>, applied after every submix. </summary>
    [FieldOffset(0xB4)] public float Volume;
    [FieldOffset(0xD8)] public uint Format;
    [FieldOffset(0xDC)] public MasterBusId BusId;
    [FieldOffset(0xE5), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;

    /// <summary> 5 entries; unused entries are null. </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 48 8B E8", 3)]
    public static partial CoreMasterVoice** Instances();

    /// <summary> Replaces the effects with the first <paramref name="count"/> entries of <paramref name="effects"/>. </summary>
    /// <returns> 0. </returns>
    [VirtualFunction(2)]
    public partial int SetEffects(ICoreEffect** effects, int count);

    /// <summary> Sets <see cref="Volume"/>. </summary>
    /// <returns> 0, or -1 without changing it if <paramref name="fadeTicks"/> is not 0. </returns>
    [VirtualFunction(13)]
    public partial int SetVolume(float volume, uint fadeTicks);

    /// <summary> Adds <paramref name="frames"/> frames of interleaved samples in <paramref name="format"/> to this voice, scaled by <paramref name="gain"/>. </summary>
    [VirtualFunction(15)]
    public partial void MixIn(float* buffer, uint frames, float gain, uint format);
}
