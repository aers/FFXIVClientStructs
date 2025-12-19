using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentOccultCrescent
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<PublicContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x3360)]
public unsafe partial struct PublicContentOccultCrescent {
    [FieldOffset(0x1380)] public OccultCrescentMKDData MKDData;
    [FieldOffset(0x13A8)] public DynamicEventContainer DynamicEventContainer;
    [FieldOffset(0x3128)] public OccultCrescentState State;
    [FieldOffset(0x3192)] private byte Unk3192;
    [FieldOffset(0x3193)] private byte Unk3193;
    [FieldOffset(0x3194)] private uint Unk3194;
    [FieldOffset(0x3198)] private byte Unk3198;

    [FieldOffset(0x31A0)] private StdPair<uint, uint>* Unk31A0; // array of 6, <layout id, quest id>
    [FieldOffset(0x31A8)] private float Unk31A8; // some countdown, re-check the colision and quest state
    [FieldOffset(0x31AC)] private byte Unk31AC; // count for the array at 0x31A0

    [FieldOffset(0x31B0), FixedSizeArray] internal FixedSizeArray4<Utf8String> _strings;

    [FieldOffset(0x335D)] public bool StateLoaded;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 08 0F B6 CB")]
    public static partial PublicContentOccultCrescent* GetInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 89 AD")]
    public static partial OccultCrescentMKDData* GetMKDData();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B E8 48 85 C0 75 12")]
    public static partial OccultCrescentState* GetState();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? BF ?? ?? ?? ?? EB ?? 41 0F B6 45")]
    public static partial bool IsChainTarget(Character.Character* chara);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 06 48 8B CE FF 50 ?? EB ?? 48 8B 06 48 8B CE C7 46")]
    public static partial bool ChangeSupportJob(byte id);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public partial struct OccultCrescentMKDData {
    [FieldOffset(0x00), CExporterExcelBegin("MKDData")] public uint QuestId;
    [FieldOffset(0x04)] public uint ZoneNameId; // Addon RowId
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray3<uint> _currencyItemIds;
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray3<uint> _currencyNameIds; // Addon RowIds
    [FieldOffset(0x20)] private byte Unknown8; // Minimum Knowledge Level?
    [FieldOffset(0x21), CExporterExcelEnd] private byte Unknown9;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x69)] // unsure how long
public partial struct OccultCrescentState {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray16<uint> _supportJobExperience;
    [FieldOffset(0x40)] public uint CurrentKnowledge;
    [FieldOffset(0x44)] public uint NeededKnowledge;
    [FieldOffset(0x48)] public uint NeededJobExperience;
    [FieldOffset(0x4C)] public ushort Silver;
    [FieldOffset(0x4E)] public ushort Gold;
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray16<byte> _supportJobLevels;
    [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedTeleportBitmask; // for TelepotTown
    [FieldOffset(0x62)] public byte CurrentSupportJob; // MKDSupportJob RowId
    [FieldOffset(0x63)] public byte KnowledgeLevelSync;
    [FieldOffset(0x64)] private byte Unk64;
    [FieldOffset(0x65)] private byte Unk65; // related to Sanguine Cipher item count, cur?
    [FieldOffset(0x66)] private byte Unk66; // related to Sanguine Cipher item count, max?
    [FieldOffset(0x67)] private byte Unk67;
    [FieldOffset(0x68)] private byte Unk68; // flags
}
