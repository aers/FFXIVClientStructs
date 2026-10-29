using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver;

// SQEX::Sd::Driver::FaithReverb
//   SQEX::Sd::Driver::Effect
//     SQEX::Sd::SeadObject<2,16>
//     SQEX::Sd::Driver::Core::ICoreEffect
/// <summary>
/// The reverb of the Reverb submix: input folded to 4 channels, filters, predelay, early reflections and a 4-line feedback delay network.
/// The output is the input times the dry level plus the reverb times the wet level.
/// </summary>
/// <remarks>
/// It has no modulation or dynamics, so it is linear and time-invariant while its parameters hold.
/// The game sets all parameters once when the mixer is created; after that only 4115 (dry level) and 4116 (wet level) change.
/// </remarks>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 49 89 06 49 8D 4E 18 48 8D 05 ?? ?? ?? ?? 49 89 46 08 E8 ?? ?? ?? ??", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x10C0)]
public unsafe partial struct FaithReverb {
    /// <summary> The interface held by the submix. </summary>
    [FieldOffset(0x08)] public ICoreEffect CoreEffect;

    /// <summary> Returned by <see cref="ICoreEffect.IsBypassed"/>. </summary>
    [FieldOffset(0x10)] public bool Bypassed;

    [FieldOffset(0x18)] private fixed byte Lock[0x28]; // CRITICAL_SECTION

    /// <summary> Parameter 4115 (dry level) in every lane. The output is the input times this plus the reverb times <see cref="WetLevel"/>. </summary>
    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray16<float> _dryLevel;

    /// <summary> Parameter 4116 (wet level) in every lane. </summary>
    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray16<float> _wetLevel;

    /// <summary> The sine and cosine of parameter 4109 times pi / 2, the mix with the early reflections. </summary>
    [FieldOffset(0xC0), FixedSizeArray] internal FixedSizeArray4<float> _mixSin;
    [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray4<float> _mixCos;

    /// <summary> Parameter 4105 in every lane. </summary>
    [FieldOffset(0xE0), FixedSizeArray] internal FixedSizeArray4<float> _gain;

    /// <summary> The four band filters of the input, applied in the order 0, 2, 3, 1. </summary>
    [FieldOffset(0xF0), FixedSizeArray] internal FixedSizeArray4<Biquad> _filters;

    /// <summary> The delay line of the early reflections, in vectors of 4 floats. </summary>
    [FieldOffset(0x9F0)] public float* TapLine;
    [FieldOffset(0x9F8)] public int TapLineLength;

    /// <summary> The gains of the 196 early reflection taps (49 per lane). </summary>
    [FieldOffset(0xA00)] public float* TapGains;

    /// <summary> The read positions of the 196 early reflection taps, from the tap times. </summary>
    [FieldOffset(0xA08)] public int* TapIndices;
    [FieldOffset(0xA10)] public int TapLineWrite;

    /// <summary> The predelay, <see cref="PredelayRead"/> is parameter 4114 (milliseconds) behind <see cref="PredelayWrite"/>. </summary>
    [FieldOffset(0xA20)] public float* PredelayLine;
    [FieldOffset(0xA28)] public int PredelayLength;
    [FieldOffset(0xA2C)] public int PredelayWrite;
    [FieldOffset(0xA30)] public int PredelayRead;

    /// <summary> The delay before the network, <see cref="LineRead"/> is parameter 4110 (milliseconds) behind <see cref="LineWrite"/>. </summary>
    [FieldOffset(0xA40)] public float* Line;
    [FieldOffset(0xA48)] public int LineLength;
    [FieldOffset(0xA4C)] public int LineWrite;
    [FieldOffset(0xA50)] public int LineRead;

    [FieldOffset(0xA60), FixedSizeArray] internal FixedSizeArray4<Pointer<float>> _subLines;
    [FieldOffset(0xA80)] public int SubLineLength;
    [FieldOffset(0xA84)] public int SubLineWrite;

    /// <summary> The read positions of the sub lines, 4 per line. </summary>
    [FieldOffset(0xA90), FixedSizeArray] internal FixedSizeArray16<int> _subLineReads;

    /// <summary> The previous output of each sub line. </summary>
    [FieldOffset(0xAD0), FixedSizeArray] internal FixedSizeArray16<float> _subLineMemory;

    /// <summary> The four lines of the feedback network. </summary>
    [FieldOffset(0xB10), FixedSizeArray] internal FixedSizeArray4<Pointer<float>> _networkLines;
    [FieldOffset(0xB30)] public int NetworkLineLength;
    [FieldOffset(0xB40), FixedSizeArray] internal FixedSizeArray4<float> _networkFeedback;
    [FieldOffset(0xB50), FixedSizeArray] internal FixedSizeArray4<float> _networkInput;

    /// <summary> The read positions of the network lines, 4 per line. </summary>
    [FieldOffset(0xB60), FixedSizeArray] internal FixedSizeArray16<int> _networkLineReads;
    [FieldOffset(0xBA0)] public int NetworkLineWrite;

    /// <summary> The gains of the network, (parameter 4112 + 1) * 10^(-3 * delay / parameter 4111), with the delays and parameter 4111 in milliseconds. </summary>
    [FieldOffset(0xBB0), FixedSizeArray] internal FixedSizeArray16<float> _feedbackGains;

    /// <summary> Parameter 4112 in every entry. </summary>
    [FieldOffset(0xBF0), FixedSizeArray] internal FixedSizeArray16<float> _feedbackDamping;

    /// <summary> The previous output of the network. </summary>
    [FieldOffset(0xC30), FixedSizeArray] internal FixedSizeArray16<float> _networkMemory;

    /// <summary>
    /// The parameters set by <see cref="SetParameter"/>. Indices of the ids 4104 to 4126:<br/>
    /// 4104: 4, 4105: 7, 4106: 10, 4107: 11, 4108: 5, 4109: 2, 4110: 6, 4111: 8, 4112: 9, 4113: 22, 4114: 3, 4115: 0,<br/>
    /// 4116: 1, 4117: 13, 4118: 14, 4119: 15, 4120: 12, 4121: 16, 4122: 17, 4123: 18, 4124: 19, 4125: 20, 4126: 21
    /// </summary>
    [FieldOffset(0xC70), FixedSizeArray] internal FixedSizeArray23<DynamicValue> _parameters;

    /// <summary> Sets a parameter. </summary>
    /// <param name="id">4104 to 4126.</param>
    /// <param name="value">Clamped to the range of the parameter.</param>
    /// <param name="fadeTime">The duration of the fade from the current value.</param>
    [VirtualFunction(3)]
    public partial void SetParameter(int id, float value, float fadeTime);

    /// <param name="value">The current value of the parameter (4119, 4120, 4123 and 4126 are stored inverted and returned as 1 / value).</param>
    /// <param name="id">4104 to 4126.</param>
    /// <returns> 0, or -1 for an unknown <paramref name="id"/>. </returns>
    [VirtualFunction(4)]
    public partial int GetParameter(float* value, int id);
}
