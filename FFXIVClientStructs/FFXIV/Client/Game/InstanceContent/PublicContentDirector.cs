using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentDirector
//   Client::Game::InstanceContent::ContentDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 33 C9"
[GenerateInterop(isInherited: true)]
[Inherits<ContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x1178)]
public unsafe partial struct PublicContentDirector {
    // fields from PublicContent sheet
    [FieldOffset(0xD30)] public uint NameOffset; // quite useless here
    [FieldOffset(0xD34)] public uint MapIcon;
    [FieldOffset(0xD38)] public uint TextDataStart;
    [FieldOffset(0xD3C)] public uint TextDataEnd;
    [FieldOffset(0xD40)] public uint StartCutscene;
    [FieldOffset(0xD44)] public uint LGBEventRange;
    [FieldOffset(0xD48)] public uint LGBPopRange;
    [FieldOffset(0xD4C)] public uint EndCutscene;
    [FieldOffset(0xD50)] public ushort Timelimit;
    [FieldOffset(0xD52)] public ushort ContentFinderCondition;
    [FieldOffset(0xD54)] public ushort AdditionalData;
    [FieldOffset(0xD56)] public ushort Unknown0;
    [FieldOffset(0xD58)] public ushort Unknown1;
    [FieldOffset(0xD5A)] public ushort Unknown2;
    [FieldOffset(0xD5C)] public ushort Unknown3;
    [FieldOffset(0xD5E)] public PublicContentDirectorType Type;
    [FieldOffset(0xD5F)] public byte Unknown4;

    [MemberFunction("40 53 57 48 83 EC 78 48 8B D9 48 8D 0D")]
    public static partial nint HandleEnterContentInfoPacket(EnterContentInfoPacket* packet);

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct EnterContentInfoPacket {
        [FieldOffset(0x00)] public byte NotifyType;

        /// <summary>
        /// The ID of the ContentFinderCondition EXD that has popped.
        /// </summary>
        [FieldOffset(0x1C)] public ushort ContentFinderConditionId;
    }
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
