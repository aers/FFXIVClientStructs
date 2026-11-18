using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver;

// SQEX::Sd::Driver::SimpleFilter
//   SQEX::Sd::Driver::Effect
//     SQEX::Sd::SeadObject<2,16>
//     SQEX::Sd::Driver::Core::ICoreEffect
/// <summary>
/// The one-pole filter of a <see cref="CoreSourceVoice"/> on a 3D <c>Bus</c>, its only effect: <c>y = x * B + y1 * A</c> per channel.
/// </summary>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 4B 18 48 8D 05 ?? ?? ?? ?? 48 89 43 08 E8 ?? ?? ?? ?? 48 8D 4B 50", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct SimpleFilter {
    /// <summary> The interface held by the voice. </summary>
    [FieldOffset(0x08)] public ICoreEffect CoreEffect;

    /// <summary> Returned by <see cref="ICoreEffect.IsBypassed"/>. </summary>
    [FieldOffset(0x10)] public bool Bypassed;

    /// <summary> In Hz. </summary>
    [FieldOffset(0x18)] public DynamicValue Cutoff;

    /// <summary>
    /// 0 off (<see cref="A"/> 0, <see cref="B"/> 1), 1 low-pass (<c>A = exp(-w)</c>), 2 high-pass (<c>A = exp(w - pi)</c>),
    /// with <c>w = 2pi * cutoff / rate</c> and <c>B = 1 - A</c>.
    /// </summary>
    [FieldOffset(0x48)] public int Type;
    [FieldOffset(0x50)] public float A;
    [FieldOffset(0x54)] public float B;
}
