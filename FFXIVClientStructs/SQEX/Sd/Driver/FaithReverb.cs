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
