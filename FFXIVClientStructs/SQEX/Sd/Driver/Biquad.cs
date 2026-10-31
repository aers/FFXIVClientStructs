namespace FFXIVClientStructs.SQEX.Sd.Driver;

/// <summary>
/// One direct form I biquad stage of the mixer effects, with 16 lanes (one per channel):
/// <c>y = x * B0 + x1 * B1 + x2 * B2 + y1 * A1 + y2 * A2</c>, so the feedback coefficients are stored negated.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct Biquad {
    [FieldOffset(0x000), FixedSizeArray] internal FixedSizeArray16<float> _a1;
    [FieldOffset(0x040), FixedSizeArray] internal FixedSizeArray16<float> _a2;
    [FieldOffset(0x080), FixedSizeArray] internal FixedSizeArray16<float> _b0;
    [FieldOffset(0x0C0), FixedSizeArray] internal FixedSizeArray16<float> _b1;
    [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray16<float> _b2;

    /// <summary> The previous inputs. </summary>
    [FieldOffset(0x140), FixedSizeArray] internal FixedSizeArray16<float> _x1;
    [FieldOffset(0x180), FixedSizeArray] internal FixedSizeArray16<float> _x2;

    /// <summary> The previous outputs. </summary>
    [FieldOffset(0x1C0), FixedSizeArray] internal FixedSizeArray16<float> _y1;
    [FieldOffset(0x200), FixedSizeArray] internal FixedSizeArray16<float> _y2;
}
