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
[StructLayout(LayoutKind.Explicit, Size = 0x33A8)]
public unsafe partial struct PublicContentOccultCrescent {
    [FieldOffset(0x13D8)] public OccultCrescentMKDData MKDData;
    [FieldOffset(0x1400)] public DynamicEventContainer DynamicEventContainer;
    [FieldOffset(0x3180)] public OccultCrescentState State;
    [FieldOffset(0x31DA)] private byte Unk31DA;
    [FieldOffset(0x31DB)] private byte Unk31DB;
    [FieldOffset(0x31DC)] private uint Unk31DC;
    [FieldOffset(0x31E0)] private byte Unk31E0;

    [FieldOffset(0x31E8)] private StdPair<uint, uint>* Unk31E8; // array of 6, <layout id, quest id>
    [FieldOffset(0x31F0)] private float Unk31F0; // some countdown, re-check the colision and quest state
    [FieldOffset(0x31F4)] private byte Unk31F4; // count for the array at 0x31E8

    [FieldOffset(0x31F8), FixedSizeArray] internal FixedSizeArray4<Utf8String> _strings;

    [FieldOffset(0x33A5)] public bool StateLoaded;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 08 0F B6 CB")]
    public static partial PublicContentOccultCrescent* GetInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 89 AD")]
    public static partial OccultCrescentMKDData* GetMKDData();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B E8 48 85 C0 75 12")]
    public static partial OccultCrescentState* GetState();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? BB ?? ?? ?? ?? EB ?? 41 0F B6 47")]
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
    [FieldOffset(0x10), Obsolete("Use CurrencyItemIds[2] instead")] public uint CipherItemId;
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray3<uint> _currencyNameIds; // Addon RowIds
    [FieldOffset(0x1C), Obsolete("Use CurrencyNameIds[2] instead")] public int CipherNameId;
    [FieldOffset(0x20)] public byte Unknown8; // Minimum Knowledge Level?
    [FieldOffset(0x21), CExporterExcelEnd] public byte Unknown9;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5A)] // unsure how long
public partial struct OccultCrescentState {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray13<uint> _supportJobExperience;
    [FieldOffset(0x34)] public uint CurrentKnowledge;
    [FieldOffset(0x38)] public uint NeededKnowledge;
    [FieldOffset(0x3C)] public uint NeededJobExperience;
    [FieldOffset(0x40)] public ushort Silver;
    [FieldOffset(0x42)] public ushort Gold;
    [FieldOffset(0x44), FixedSizeArray] internal FixedSizeArray13<byte> _supportJobLevels;
    [FieldOffset(0x51), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedTeleportBitmask; // for TelepotTown
    [FieldOffset(0x53)] public byte CurrentSupportJob; // MKDSupportJob RowId
    [FieldOffset(0x54)] public byte KnowledgeLevelSync;
    [FieldOffset(0x55)] private byte Unk55;
    [FieldOffset(0x56)] private byte Unk56; // related to Sanguine Cipher item count, cur?
    [FieldOffset(0x57)] private byte Unk57; // related to Sanguine Cipher item count, max?
    [FieldOffset(0x58)] private byte Unk58;
    [FieldOffset(0x59)] private byte Unk59; // flags
}
