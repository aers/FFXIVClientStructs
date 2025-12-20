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
[StructLayout(LayoutKind.Explicit, Size = 0x15B8)]
public unsafe partial struct PublicContentEureka {
    [FieldOffset(0x1380)] private ushort Unk1380; // if set, prints log message 9068 in chat ("Character progression enhancement will be applied to all participants in this duty.")
    [FieldOffset(0x1382)] private ushort Unk1382; // if set, prints log message 4217 in chat ("To facilitate the successful completion of this duty, you have been granted the power of the Echo.")
    [FieldOffset(0x1384)] public byte MaxElementalLevel; // if set, prints log message 9067 in chat ("If your elemental level is above <value>, it will be synced.")

    [FieldOffset(0x1388)] public uint CurrentExperience;
    [FieldOffset(0x138C)] public uint NeededExperience;
    [FieldOffset(0x1390)] public ushort MagiaAetherCharge;
    [FieldOffset(0x1392)] public byte Fire;
    [FieldOffset(0x1393)] public byte Ice;
    [FieldOffset(0x1394)] public byte Wind;
    [FieldOffset(0x1395)] public byte Earth;
    [FieldOffset(0x1396)] public byte Lightning;
    [FieldOffset(0x1397)] public byte Water;
    [FieldOffset(0x1398)] public byte Magicite;
    [FieldOffset(0x1399)] public byte MagiaAether;
    [FieldOffset(0x13A0), FixedSizeArray] internal FixedSizeArray4<Utf8String> _publicContentTextDataStrings;  // starting at row 2000
    [FieldOffset(0x1540)] private Utf8String Unk1540;
}
