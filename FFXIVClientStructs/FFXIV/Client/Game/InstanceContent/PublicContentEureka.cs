using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentEureka
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<PublicContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x13B0)]
public unsafe partial struct PublicContentEureka {
    [FieldOffset(0x1178)] public ushort Unk1090; // if set, prints log message 9068 in chat ("Character progression enhancement will be applied to all participants in this duty.")
    [FieldOffset(0x117A)] public ushort Unk1092; // if set, prints log message 4217 in chat ("To facilitate the successful completion of this duty, you have been granted the power of the Echo.")
    [FieldOffset(0x117C)] public byte MaxElementalLevel; // if set, prints log message 9067 in chat ("If your elemental level is above <value>, it will be synced.")

    [FieldOffset(0x1100)] public uint CurrentExperience;
    [FieldOffset(0x1184)] public uint NeededExperience;
    [FieldOffset(0x1188)] public ushort MagiaAetherCharge;
    [FieldOffset(0x118A)] public byte Fire;
    [FieldOffset(0x118B)] public byte Ice;
    [FieldOffset(0x118C)] public byte Wind;
    [FieldOffset(0x118D)] public byte Earth;
    [FieldOffset(0x118E)] public byte Lightning;
    [FieldOffset(0x118F)] public byte Water;
    [FieldOffset(0x1190)] public byte Magicite;
    [FieldOffset(0x1191)] public byte MagiaAether;
    [FieldOffset(0x1198), FixedSizeArray] internal FixedSizeArray4<Utf8String> _publicContentTextDataStrings;  // starting at row 2000
    [FieldOffset(0x1338)] public Utf8String Unk1250;
}
