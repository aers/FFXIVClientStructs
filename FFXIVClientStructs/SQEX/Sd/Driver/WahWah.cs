using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver;

// SQEX::Sd::Driver::WahWah
//   SQEX::Sd::Driver::Effect
//     SQEX::Sd::SeadObject<2,16>
//     SQEX::Sd::Driver::Core::ICoreEffect
/// <summary>
/// The effect of the Water submix. Every frame the three band-pass stages get the centre frequency
/// <c>base * 2^(depth2 * sin(phase2) + depth1 * sin(phase1 + k * 2pi / 3))</c> for stage k; the output is their sum times the wet level plus the
/// input times the dry level.
/// </summary>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 4B 18 48 8D 05 ?? ?? ?? ?? 48 89 43 08 E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ??", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x890)]
public unsafe partial struct WahWah {
    /// <summary> The interface held by the submix. </summary>
    [FieldOffset(0x08)] public ICoreEffect CoreEffect;

    /// <summary> Returned by <see cref="ICoreEffect.IsBypassed"/>. </summary>
    [FieldOffset(0x10)] public bool Bypassed;

    /// <summary>
    /// 0 base frequency, 1 bandwidth, 2 and 4 LFO rates, 3 and 5 LFO depths, 6 dry level, 7 wet level, 8 and 9 LFO phases
    /// (advanced by the rates every frame and wrapped at pi).
    /// </summary>
    [FieldOffset(0x1A0), FixedSizeArray] internal FixedSizeArray10<float> _parameters;

    /// <summary> The coefficients are recomputed from the parameters every frame. </summary>
    [FieldOffset(0x1D0), FixedSizeArray] internal FixedSizeArray3<Biquad> _stages;
}
