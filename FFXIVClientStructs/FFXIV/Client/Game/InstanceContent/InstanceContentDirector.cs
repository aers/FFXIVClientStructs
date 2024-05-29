namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentDirector
//   Client::Game::InstanceContent::ContentDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 80 E3 01"
[GenerateInterop(isInherited: true)]
[Inherits<ContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x1CB0)]
public unsafe partial struct InstanceContentDirector {
    //[FieldOffset(0x730), FixedSizeArray] internal FixedSizeArray168<byte> _instanceContentExcelRow;

    /// <summary>
    /// This field is stored in minutes
    /// </summary>
    [FieldOffset(0xCCC)] public ushort ContentTimeMax;

    [FieldOffset(0xCE4)] public InstanceContentType InstanceContentType;
}

public enum InstanceContentType : byte {
    Raid = 1,
    Dungeon = 2,
    GuildOrder = 3, // Guildhests
    Trial = 4,
    CrystallineConflict = 5,
    Frontlines = 6,
    QuestBattle = 7,
    BeginnerTraining = 8,
    DeepDungeon = 9,
    TreasureHuntDungeon = 10,
    SeasonalDungeon = 11,
    RivalWing = 12,
    MaskedCarnivale = 13,
    Mahjong = 14,
    GoldSaucer = 15, // only used for Air Force One in Gold Saucer
    OceanFishing = 16,
    UnrealTrial = 17,
    TripleTriad = 18,
    VariantDungeon = 19,
    CriterionDungeon = 20
}
