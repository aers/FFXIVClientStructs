using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver;

// SQEX::Sd::Driver::Filter
//   SQEX::Sd::Driver::Effect
//     SQEX::Sd::SeadObject<2,16>
//     SQEX::Sd::Driver::Core::ICoreEffect
/// <summary>
/// The low-pass of the Water, Water depth and Music submixes and of Master bed and Master ambisonics, created by <c>LowpassFilterSead</c>.
/// </summary>
/// <remarks> The Water depth filter fades with the depth of the listener below the water surface. </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct Filter {
    /// <summary> The interface held by the voice. </summary>
    [FieldOffset(0x08)] public ICoreEffect CoreEffect;

    /// <summary> Returned by <see cref="ICoreEffect.IsBypassed"/>. </summary>
    [FieldOffset(0x10)] public bool Bypassed;

    [FieldOffset(0x40)] private DynamicValue Unk40;
    [FieldOffset(0x70)] private DynamicValue Unk70;
    [FieldOffset(0xA0)] private DynamicValue UnkA0;
    [FieldOffset(0xD0)] public Biquad Stage;
}
