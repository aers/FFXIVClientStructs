namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::OrnamentContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct OrnamentContainer {
    [FieldOffset(0x10)] public Ornament* OrnamentObject;
    [FieldOffset(0x18)] public ushort OrnamentId;

    [FieldOffset(0x34)] public ushort AutoUmbrellaOrnamentId;
    [FieldOffset(0x38)] public float AutoUmbrellaCooldown; // cooldown for ExecuteCommand
    [FieldOffset(0x3C)] private uint UnkWeatherCheckResult; // based on the functions below
    [FieldOffset(0x40)] private float UnkAutoUmbrellaSpeed; // for cooldown??
    [FieldOffset(0x44)] private bool Unk44; // is assigned DrawObject.IsCoveredFromRain
    [FieldOffset(0x48)] private int CurrentWeatherCheckIndex; // for the functions array below
    // array pointing to 2 classes sharing an interface
    // 1st (rainy weather check): checks CurrentWeather is (7 or 8 or 10) and float at EnvState+0x170 > 0.0
    // 2nd (clear weather check): checks CurrentWeather is (1 or 2 or 13 or 14)
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray2<Pointer<nint>> _unkWeatherCheckClasses;
    // 4 bits each. not sure of the meaning
    [FieldOffset(0x60)] public byte WeatherCoverFlags;
    [FieldOffset(0x61)] public byte RaycastCoverFlags;
    [FieldOffset(0x64), FixedSizeArray] internal FixedSizeArray4<uint> _unk64;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 7B ?? 48 8B 74 24")]
    public partial void SetupOrnament(short ornamentId, uint param);
}
