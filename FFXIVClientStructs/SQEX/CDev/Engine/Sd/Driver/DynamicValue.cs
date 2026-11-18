namespace FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver;

// SQEX::CDev::Engine::Sd::Driver::DynamicValue
//   SQEX::CDev::Engine::Sd::SdMemoryAllocator
/// <summary>
/// A float that fades linearly from its current value to a target over a number of ticks.
/// </summary>
/// <remarks>
/// Used for the category volumes (<see cref="Bus"/>) and for the volume and pitch terms of a <c>RootSound</c>.
/// <see cref="GetValue"/> returns <see cref="Current"/> multiplied by <see cref="Scale"/>.
/// </remarks>
[GenerateInterop(isInherited: true)]
[Inherits<SdMemoryAllocator>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct DynamicValue {
    /// <summary> The value right now, moved towards <see cref="Target"/> by <see cref="StepPerTick"/> on every tick. </summary>
    [FieldOffset(0x08)] public float Current;
    [FieldOffset(0x0C)] public float Target;
    [FieldOffset(0x10)] public float StepPerTick; // set by StartFade
    [FieldOffset(0x14)] public int RemainingTicks; // 0 when the fade is done
    [FieldOffset(0x18)] public int TotalTicks;
    [FieldOffset(0x1C)] public float StartValue; // Current when the fade was started

    /// <summary> Multiplied into the result of <see cref="GetValue"/>, 1.0f by default. </summary>
    /// <remarks> <c>RootSound.ApplyBusVolume</c> sets this. </remarks>
    [FieldOffset(0x20)] public float Scale;
    [FieldOffset(0x24)] private bool Unk24; // set by SetScale, cleared by Update

    /// <summary> The upper 4 bits of the tick argument of <see cref="StartFade"/>. </summary>
    [FieldOffset(0x25)] public byte Curve;
    [FieldOffset(0x26)] private bool Unk26;

    /// <summary> While set, <see cref="IsActive"/> returns false. </summary>
    [FieldOffset(0x27)] public bool Suspended;

    /// <summary> Sets <see cref="Current"/> and <see cref="Target"/> to <paramref name="value"/> and clears the fade. </summary>
    [VirtualFunction(1)]
    public partial void Reset(float value);

    /// <summary> Advances the fade by <paramref name="ticks"/>. </summary>
    [VirtualFunction(2)]
    public partial void Update(int ticks);

    /// <summary> True while a fade is running. </summary>
    [VirtualFunction(3)]
    public partial bool IsActive();

    /// <summary> <see cref="Current"/> multiplied by <see cref="Scale"/>. </summary>
    [VirtualFunction(4)]
    public partial float GetValue();

    /// <summary> Advances the fade by <paramref name="ticks"/> without clearing the flags at 0x24 and 0x26 like <see cref="Update"/> does. </summary>
    [VirtualFunction(5)]
    public partial void Advance(int ticks);

    /// <summary> Sets <see cref="Scale"/> and the flag at 0x24. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 83 A6 ?? ?? ?? ?? ?? 48 8B C6")]
    public partial void SetScale(float scale);

    /// <summary> Sets <see cref="Current"/> and <see cref="Target"/> to <paramref name="value"/> without a fade. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 39 9D")]
    public partial void SetImmediate(float value);

    /// <summary> Starts a fade from <see cref="Current"/> to <paramref name="target"/>. </summary>
    /// <param name="target">The value to fade to.</param>
    /// <param name="ticksAndCurve">The lower 28 bits are the duration in ticks (0 sets the value immediately), the upper 4 bits are stored in <see cref="Curve"/>.</param>
    [MemberFunction("41 8B C0 0F 28 D1 25")]
    public partial void StartFade(float target, uint ticksAndCurve);
}
