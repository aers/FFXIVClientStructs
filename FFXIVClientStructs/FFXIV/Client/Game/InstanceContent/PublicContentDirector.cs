using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentDirector
//   Client::Game::InstanceContent::ContentDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 89 03 48 8D 8B"
[StructLayout(LayoutKind.Explicit, Size = 0x1090)]
public unsafe partial struct PublicContentDirector {
    [FieldOffset(0x00)] public ContentDirector ContentDirector;
    // fields from PublicContent sheet
    [FieldOffset(0xC48)] public uint NameOffset; // quite useless here
    [FieldOffset(0xC4C)] public uint MapIcon;
    [FieldOffset(0xC50)] public uint TextDataStart;
    [FieldOffset(0xC54)] public uint TextDataEnd;
    [FieldOffset(0xC58)] public uint StartCutscene;
    [FieldOffset(0xC5C)] public uint LGBEventRange;
    [FieldOffset(0xC60)] public uint LGBPopRange;
    [FieldOffset(0xC64)] public uint EndCutscene;
    [FieldOffset(0xC68)] public ushort Timelimit;
    [FieldOffset(0xC6A)] public ushort ContentFinderCondition;
    [FieldOffset(0xC6C)] public ushort AdditionalData;
    [FieldOffset(0xC6E)] public ushort Unknown0;
    [FieldOffset(0xC70)] public ushort Unknown1;
    [FieldOffset(0xC72)] public ushort Unknown2;
    [FieldOffset(0xC74)] public ushort Unknown3;
    [FieldOffset(0xC76)] public PublicContentDirectorType Type;
    [FieldOffset(0xC77)] public byte Unknown4;

    [MemberFunction("40 53 57 48 83 EC 78 48 8B D9 48 8D 0D")]
    public static partial nint HandleEnterContentInfoPacket(EnterContentInfo* packet);
}

public enum PublicContentDirectorType : byte {
    BondingCeremony = 1,
    TripleTriad = 2,
    Eureka = 3,
    CalamityRetold = 4, // seems to be only for the rising event in 2018
    LeapOfFaith = 5,
    Diadem = 6,
    Bozja = 7,
    Delubrum = 8,
    IslandSanctuary = 9,
    FallGuys = 10,
}
