namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentEureka
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<PublicContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x15B8)]
public unsafe partial struct PublicContentEureka {
    [FieldOffset(0x1380)] private ushort Unk1380; // if set, prints log message 9068 in chat ("Character progression enhancement will be applied to all participants in this duty.")
    [FieldOffset(0x1382)] private ushort Unk1382; // if set, prints log message 4217 in chat ("To facilitate the successful completion of this duty, you have been granted the power of the Echo.")
    [FieldOffset(0x1384)] public byte MaxElementalLevel; // if set, prints log message 9067 in chat ("If your elemental level is above <value>, it will be synced.")

    [FieldOffset(0x1388)] public EurekaState State;
    [FieldOffset(0x1388), Obsolete("Use State.CurrentExperience")] public uint CurrentExperience;
    [FieldOffset(0x138C), Obsolete("Use State.NeededExperience")] public uint NeededExperience;
    [FieldOffset(0x1390), Obsolete("Use State.MagiaAetherCharge")] public ushort MagiaAetherCharge;
    [FieldOffset(0x1392), Obsolete("Use State.Fire")] public byte Fire;
    [FieldOffset(0x1393), Obsolete("Use State.Ice")] public byte Ice;
    [FieldOffset(0x1394), Obsolete("Use State.Wind")] public byte Wind;
    [FieldOffset(0x1395), Obsolete("Use State.Earth")] public byte Earth;
    [FieldOffset(0x1396), Obsolete("Use State.Lightning")] public byte Lightning;
    [FieldOffset(0x1397), Obsolete("Use State.Water")] public byte Water;
    [FieldOffset(0x1398), Obsolete("Use State.Magicite")] public byte Magicite;
    [FieldOffset(0x1399), Obsolete("Use State.MagiaAether")] public byte MagiaAether;
    [FieldOffset(0x13A0), FixedSizeArray] internal FixedSizeArray4<Utf8String> _publicContentTextDataStrings;  // starting at row 2000
    [FieldOffset(0x1540)] private Utf8String Unk1540;

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B 54 24")]
    public static partial EurekaState* GetState();
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x12)]
public partial struct EurekaState {
    [FieldOffset(0x00)] public uint CurrentExperience;
    [FieldOffset(0x04)] public uint NeededExperience;
    [FieldOffset(0x08)] public ushort MagiaAetherCharge;
    [FieldOffset(0x0A)] public byte Fire;
    [FieldOffset(0x0B)] public byte Ice;
    [FieldOffset(0x0C)] public byte Wind;
    [FieldOffset(0x0D)] public byte Earth;
    [FieldOffset(0x0E)] public byte Lightning;
    [FieldOffset(0x0F)] public byte Water;
    [FieldOffset(0x10)] public byte Magicite;
    [FieldOffset(0x11)] public byte MagiaAether;
}
