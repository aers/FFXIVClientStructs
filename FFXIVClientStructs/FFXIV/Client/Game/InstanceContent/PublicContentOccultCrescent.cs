namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentOccultCrescent
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<PublicContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x33A0)]
public unsafe partial struct PublicContentOccultCrescent {
    [FieldOffset(0x1380)] public OccultCrescentMKDData MKDData;
    [FieldOffset(0x13B8)] public DynamicEventContainer DynamicEventContainer;
    [FieldOffset(0x3138)] public OccultCrescentState State;

    [FieldOffset(0x31E0)] private StdPair<uint, uint>* Unk31A0; // array of 6, <layout id, quest id>
    [FieldOffset(0x31E8)] private float Unk31A8; // some countdown, re-check the colision and quest state
    [FieldOffset(0x31EC)] private byte Unk31AC; // count for the array at 0x31E0

    [FieldOffset(0x31F0), FixedSizeArray] internal FixedSizeArray4<Utf8String> _strings;

    [FieldOffset(0x339D)] public bool StateLoaded;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 08 0F B6 CB")]
    public static partial PublicContentOccultCrescent* GetInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C0 48 85 C0 0F 84 ?? ?? ?? ?? 48 89 AD")]
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
    // TODO: this needs updating, sheet changed
    [FieldOffset(0x00), CExporterExcelBegin("MKDData")] public uint QuestId;
    [FieldOffset(0x04)] public uint ZoneNameId; // Addon RowId
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray3<uint> _currencyItemIds;
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray3<uint> _currencyNameIds; // Addon RowIds
    [FieldOffset(0x20)] private byte Unknown8; // Minimum Knowledge Level?
    [FieldOffset(0x21), CExporterExcelEnd] private byte Unknown9;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x9C)] // unsure how long
public partial struct OccultCrescentState {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray24<uint> _supportJobExperience;
    [FieldOffset(0x60)] public uint CurrentKnowledge;
    [FieldOffset(0x64)] public uint NeededKnowledge;
    [FieldOffset(0x68)] public uint NeededJobExperience;
    [FieldOffset(0x6C)] public ushort Silver;
    [FieldOffset(0x6E)] public ushort Gold;

    [FieldOffset(0x76), FixedSizeArray] internal FixedSizeArray24<byte> _supportJobLevels;
    
    [FieldOffset(0x8E), FixedSizeArray] internal FixedSizeArray3<byte> _unlockedTeleportBitmask; // for TelepotTown
    [FieldOffset(0x91)] public byte CurrentSupportJob; // MKDSupportJob RowId
    [FieldOffset(0x92)] public byte KnowledgeLevelSync;
    [FieldOffset(0x93)] private byte Unk93;
    [FieldOffset(0x94)] private byte Unk94; // related to Sanguine Cipher item count, cur?
    [FieldOffset(0x95)] private byte Unk95; // related to Sanguine Cipher item count, max?
    [FieldOffset(0x96)] private byte Unk96;
    [FieldOffset(0x97)] private byte Unk97; // flags
}
