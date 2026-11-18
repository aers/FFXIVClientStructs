using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver;

// SQEX::Sd::Driver::Equalizer
//   SQEX::Sd::Driver::Effect
//     SQEX::Sd::SeadObject<2,16>
//     SQEX::Sd::Driver::Core::ICoreEffect
/// <summary> The equalizer of the Player, Party and Other submixes: cascaded <see cref="Biquad"/> stages, set when the mixer is created and constant after that. </summary>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 07 48 8D 4F 18", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct Equalizer {
    /// <summary> The interface held by the submix. </summary>
    [FieldOffset(0x08)] public ICoreEffect CoreEffect;

    /// <summary> Returned by <see cref="ICoreEffect.IsBypassed"/>. </summary>
    [FieldOffset(0x10)] public bool Bypassed;

    /// <summary> 4. The 8-channel path always runs 4 stages. </summary>
    [FieldOffset(0x40)] public int BandCount;
    [FieldOffset(0x48)] public Biquad* Bands;
}
