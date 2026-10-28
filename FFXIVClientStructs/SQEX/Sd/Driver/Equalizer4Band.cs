using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver;

// SQEX::Sd::Driver::Equalizer4Band
//   SQEX::Sd::Driver::Effect
//     SQEX::Sd::SeadObject<2,16>
//     SQEX::Sd::Driver::Core::ICoreEffect
/// <summary>
/// The user equalizer on Master bed and Master ambisonics, created by <c>EqualizerSead</c>. <c>SoundManager.SetEqualizerType</c> sets its bands
/// from one of five presets, so it runs after every submix.
/// </summary>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 4B 30 48 8D 05 ?? ?? ?? ??", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xBB0)]
public unsafe partial struct Equalizer4Band {
    /// <summary> The interface held by the master voice. </summary>
    [FieldOffset(0x08)] public ICoreEffect CoreEffect;

    /// <summary> Returned by <see cref="ICoreEffect.IsBypassed"/>. </summary>
    [FieldOffset(0x10)] public bool Bypassed;

    [FieldOffset(0x2A0), FixedSizeArray] internal FixedSizeArray4<Biquad> _stages;

    /// <summary> Multiplied into the output of the last stage. </summary>
    [FieldOffset(0xBA0)] public float Gain;
}
