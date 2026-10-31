namespace FFXIVClientStructs.SQEX.Sd;

// SQEX::Sd::DynamicValue<2>
/// <summary> A float of the mixer effects that fades from <see cref="Start"/> to <see cref="End"/> over <see cref="Duration"/> along <see cref="Curve"/>. </summary>
/// <remarks> The effect steps <see cref="Time"/> once per period by the period length in seconds. </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct DynamicValue {
    [FieldOffset(0x08)] public float Start;
    [FieldOffset(0x0C)] public float End;

    /// <summary> Seconds since the fade started, <see cref="Start"/> is used while negative. </summary>
    [FieldOffset(0x10)] public float Time;

    /// <summary> In seconds, 0 means <see cref="End"/> applies at once. </summary>
    [FieldOffset(0x14)] public float Duration;

    /// <summary> 0 linear, 1 <c>1 - (1 - t^2)^3</c>, 2 <c>1 - (1 - t)^2</c>, 3 <c>t^2</c>, 4 <c>2^t - 1</c>, 5 <c>2 - 2^(1 - t)</c>, with <c>t = Time / Duration</c>. </summary>
    [FieldOffset(0x18)] public int Curve;
    [FieldOffset(0x1C)] public bool Fading;
}
