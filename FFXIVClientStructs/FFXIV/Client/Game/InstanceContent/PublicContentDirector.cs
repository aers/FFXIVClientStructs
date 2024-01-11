using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

[StructLayout(LayoutKind.Explicit, Size = 0x1090)]
public unsafe partial struct PublicContentDirector {
    [FieldOffset(0x00)] public ContentDirector ContentDirector;

    /// <summary>
    /// This field is stored in minutes
    /// </summary>
    [FieldOffset(0xC68)] public ushort ContentTimeMax;

    [FieldOffset(0xC76)] public PublicContentDirectorType PublicContentDirectorType;

    [MemberFunction("40 53 57 48 83 EC 78 48 8B D9 48 8D 0D")]
    public static partial nint HandleEnterContentInfoPacket(EnterContentInfo* packet);
}

public enum PublicContentDirectorType : uint {
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
