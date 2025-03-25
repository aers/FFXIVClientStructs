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
[StructLayout(LayoutKind.Explicit, Size = 0x1410)]
public unsafe partial struct PublicContentEureka {
    [FieldOffset(0x11D8)] public ushort Unk1090; // if set, prints log message 9068 in chat ("Character progression enhancement will be applied to all participants in this duty.")
    [FieldOffset(0x11DA)] public ushort Unk1092; // if set, prints log message 4217 in chat ("To facilitate the successful completion of this duty, you have been granted the power of the Echo.")
    [FieldOffset(0x11DC)] public byte MaxElementalLevel; // if set, prints log message 9067 in chat ("If your elemental level is above <value>, it will be synced.")

    [FieldOffset(0x11E0)] public uint CurrentExperience;
    [FieldOffset(0x11E4)] public uint NeededExperience;
    [FieldOffset(0x11E8)] public ushort MagiaAetherCharge;
    [FieldOffset(0x11EA)] public byte Fire;
    [FieldOffset(0x11EB)] public byte Ice;
    [FieldOffset(0x11EC)] public byte Wind;
    [FieldOffset(0x11ED)] public byte Earth;
    [FieldOffset(0x11EE)] public byte Lightning;
    [FieldOffset(0x11EF)] public byte Water;
    [FieldOffset(0x11F0)] public byte Magicite;
    [FieldOffset(0x11F1)] public byte MagiaAether;
    [FieldOffset(0x11F8), FixedSizeArray] internal FixedSizeArray4<Utf8String> _publicContentTextDataStrings;  // starting at row 2000
    [FieldOffset(0x1398)] public Utf8String Unk1250;
}
