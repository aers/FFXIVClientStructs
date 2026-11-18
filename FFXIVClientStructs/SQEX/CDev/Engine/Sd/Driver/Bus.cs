namespace FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver;

// SQEX::CDev::Engine::Sd::Driver::Bus
//   SQEX::CDev::Engine::Sd::SdMemoryAllocator
/// <summary>
/// A sound category of the driver, there is one for every value of <c>SoundBus</c> (20).
/// Every sound is played on the bus of its category, which holds the category volume and the list of sounds playing on it.
/// </summary>
/// <remarks>
/// The volume of a bus is the product of its four faders (<see cref="GetTotalVolume"/>). When one of them changes
/// the bus re-applies it to every sound on the bus, so the user's volume settings scale the voices linearly.
/// </remarks>
[GenerateInterop(isInherited: true)]
[Inherits<SdMemoryAllocator>]
[StructLayout(LayoutKind.Explicit, Size = 0x180)]
public unsafe partial struct Bus {
    /// <summary> 1-based, the same as <c>SoundBus</c>. </summary>
    [FieldOffset(0x08)] public int Id;

    /// <summary> The first number of the <c>BUS</c> line of the driver config. </summary>
    /// <remarks>
    /// When positive, the bus gets its own pool of <c>2 * TrackCount</c> entries for the sounds added by <see cref="AddSound"/>.
    /// It is not a voice limit: the sound start compares it with <see cref="SoundCount"/>, but the check that follows always passes.
    /// </remarks>
    [FieldOffset(0x0C)] public ushort TrackCount;

    /// <summary> Set when the <c>BUS</c> line of the driver config has <c>3D</c>, clear for <c>2D</c>. </summary>
    [BitField<bool>(nameof(Is3D), 0)]
    [FieldOffset(0x0E)] public byte Flags;

    /// <summary> Set when the track count in the config is negative: the bus with the id of its absolute value, whose sound list this bus uses. </summary>
    [FieldOffset(0x10)] public Bus* Parent;

    /// <summary>
    /// The category volume set by <c>SoundManager.SetVolume</c>, the user volume slider divided by 100.
    /// </summary>
    /// <remarks>
    /// The sliders map to the buses like this:<br/>
    /// BGM: Music, TimeStretchBGM, Zingle, Orchestrion<br/>
    /// Sound Effects: SE, Foot, PlacedNPC, CommonVFX<br/>
    /// Voice: Voice<br/>
    /// System Sounds: System<br/>
    /// Ambient Sounds: BG, BGEnv, Walla, Unknown0, Unknown1, Housing, RandomWind<br/>
    /// Performance: Instruments<br/>
    /// Movie and Vibration have no slider and read 1.0f. The master volume is not part of the bus volume.
    /// </remarks>
    [FieldOffset(0x18)] public DynamicValue Volume;

    /// <summary> Started by the first increment of <see cref="Volume2RefCount"/>, reset when it drops to 0. </summary>
    [FieldOffset(0x40)] public DynamicValue Volume2;
    [FieldOffset(0x68)] public DynamicValue Volume3;
    [FieldOffset(0x90)] public DynamicValue Volume4;
    [FieldOffset(0xB8)] public int Volume2RefCount;

    /// <summary> The number of sounds added by <see cref="AddSound"/>, counted on the bus that owns the pool (0 when <see cref="Parent"/> is set). </summary>
    [FieldOffset(0x138)] public int SoundCount;

    [FieldOffset(0x17C)] private bool Unk17C; // set and cleared by the virtual functions 4-6
    [FieldOffset(0x17D)] private bool Unk17D;

    /// <summary> <see cref="BusCount"/> entries, indexed by the id minus 1. </summary>
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 48 63 C9 48 8B 44 C8 F8", 3, isPointer: true)]
    public static partial Bus** Buses();

    [StaticAddress("3B 0D ?? ?? ?? ?? 7F ?? 48 8B 05 ?? ?? ?? ??", 2)]
    public static partial int* BusCount();

    /// <param name="id">The bus id, 1-based.</param>
    [MemberFunction("3B 0D ?? ?? ?? ?? 75 ?? 48 8B 05")]
    public static partial Bus* GetById(int id);

    /// <summary> The product of the values of the four faders. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 C8 48 8B CB E8 ?? ?? ?? ?? 48 8B D3 48 8D 8F")]
    public partial float GetTotalVolume();

    /// <summary> Adds the sound to the bus and applies the bus volume to it with <see cref="RootSound.ApplyBusVolume"/>. </summary>
    /// <remarks>
    /// When the pool is full the entries of sounds whose state has bit 0x08 or 0x20, or that no longer exist, are freed first. If no entry is free the sound is not added
    /// and keeps a <see cref="RootSound.BusVolume"/> scale of 1.0f, so it ignores the category volume. Nothing is returned.
    /// </remarks>
    [VirtualFunction(2)]
    public partial void AddSound(SoundController* controller);

    /// <summary> Sets <see cref="Volume"/> (fading if <paramref name="fadeTicks"/> is not 0) and re-applies the bus volume to every sound on the bus. </summary>
    [VirtualFunction(3)]
    public partial void SetVolume(float volume, uint fadeTicks);
}
