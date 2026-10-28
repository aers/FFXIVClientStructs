using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver;

// SQEX::Sd::Driver::Stringendo
//   SQEX::Sd::Driver::Effect
//     SQEX::Sd::SeadObject<2,16>
//     SQEX::Sd::Driver::Core::ICoreEffect
/// <summary>
/// The pitch shifter of the Stringendo submix (TimeStretchBGM only). The input goes into a ring; two taps move through it by
/// <c>1 - 1 / ratio</c> frames per frame, are interpolated linearly and cross-faded by a window of <see cref="Phase"/>, which advances 1/6300 per frame.
/// </summary>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 8B 20 00 02 00", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x20060)]
public unsafe partial struct Stringendo {
    /// <summary> The interface held by the submix. </summary>
    [FieldOffset(0x08)] public ICoreEffect CoreEffect;

    /// <summary> Returned by <see cref="ICoreEffect.IsBypassed"/>. </summary>
    [FieldOffset(0x10)] public bool Bypassed;

    /// <summary> Eight floats per frame, whatever the channel count. </summary>
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray32768<float> _ring;

    /// <summary> In floats. </summary>
    [FieldOffset(0x20018)] public int WriteIndex;

    /// <summary> The playback speed ratio, 1.0f when the constructor runs. </summary>
    [FieldOffset(0x20020)] public DynamicValue Ratio;
    [FieldOffset(0x20050)] public float Phase;
    [FieldOffset(0x20054)] public float TapA;
    [FieldOffset(0x20058)] public float TapB;

    /// <summary> Set once <see cref="TapA"/> snapped back to 0 in this cycle of <see cref="Phase"/> (at 0.25). </summary>
    [FieldOffset(0x2005C)] public bool TapAReset;

    /// <summary> The same for <see cref="TapB"/>, at 0.75. </summary>
    [FieldOffset(0x2005D)] public bool TapBReset;
}
