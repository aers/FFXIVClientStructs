namespace FFXIVClientStructs.SQEX.Sd.Driver.Core;

// SQEX::Sd::Driver::Core::CoreSubmixVoice
//   SQEX::Sd::Driver::Core::ICoreSubmixVoice
//   SQEX::Sd::Driver::Core::ICoreVoice
//   SQEX::Sd::SeadObject<1,16>
/// <summary>
/// A submix of the software mixer. Source voices and other submixes add their output to it, it runs its effects and sends the result on to
/// other submixes or to a <see cref="CoreMasterVoice"/>.
/// </summary>
/// <remarks>
/// The game creates 14 of them: No effect, Reverb, Premaster, Water, Water depth, Analyze SE, Analyze Env/Voice, Analyze BGM, Vibration,
/// Stringendo, Player, Party, Other and Music.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x160)]
public unsafe partial struct CoreSubmixVoice {
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray5<VoiceSend> _sends;

    /// <summary> The number of voices this submix sends its output to. </summary>
    [FieldOffset(0xE0)] public int SendCount;

    /// <summary> Run in order on the sum of the inputs, before the sends. </summary>
    [FieldOffset(0xE8), FixedSizeArray] internal FixedSizeArray4<Pointer<ICoreEffect>> _effects;
    [FieldOffset(0x108)] public int EffectCount;
    [FieldOffset(0x138)] public uint Format;
    [FieldOffset(0x13E), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;

    /// <summary> 15 entries, in the order listed above; unused entries are null. </summary>
    [StaticAddress("48 83 EC 28 48 63 D1 48 8D 0D ?? ?? ?? ??", 10)]
    public static partial CoreSubmixVoice** Instances();

    /// <summary> Adds <paramref name="frames"/> frames of interleaved samples in <paramref name="format"/> to this voice, scaled by <paramref name="gain"/>. </summary>
    [VirtualFunction(15)]
    public partial void MixIn(float* buffer, uint frames, float gain, uint format);
}
