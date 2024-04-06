using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentEureka
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[StructLayout(LayoutKind.Explicit, Size = 0x12C8)]
public unsafe partial struct PublicContentEureka {
    [FieldOffset(0x00)] public PublicContentDirector PublicContentDirector;
    [FieldOffset(0x1090)] public ushort Unk1090; // if set, prints log message 9068 in chat ("Character progression enhancement will be applied to all participants in this duty.")
    [FieldOffset(0x1092)] public ushort Unk1092; // if set, prints log message 4217 in chat ("To facilitate the successful completion of this duty, you have been granted the power of the Echo.")
    [FieldOffset(0x1094)] public byte MaxElementalLevel; // if set, prints log message 9067 in chat ("If your elemental level is above <value>, it will be synced.")

    [FieldOffset(0x1098)] public uint CurrentExperience;
    [FieldOffset(0x109C)] public uint NeededExperience;
    [FieldOffset(0x10A0)] public ushort MagiaAetherCharge;
    [FieldOffset(0x10A2)] public byte Fire;
    [FieldOffset(0x10A3)] public byte Ice;
    [FieldOffset(0x10A4)] public byte Wind;
    [FieldOffset(0x10A5)] public byte Earth;
    [FieldOffset(0x10A6)] public byte Lightning;
    [FieldOffset(0x10A7)] public byte Water;
    [FieldOffset(0x10A8)] public byte Magicite;
    [FieldOffset(0x10A9)] public byte MagiaAether;

    [FixedSizeArray<Utf8String>(4)]
    [FieldOffset(0x10B0)] public fixed byte PublicContentTextDataStrings[0x68 * 4]; // starting at row 2000
    [FieldOffset(0x1250)] public Utf8String Unk1250;
}
