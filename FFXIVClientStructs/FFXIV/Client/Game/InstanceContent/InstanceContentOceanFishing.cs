namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentOceanFishing
//   Client::Game::InstanceContent::InstanceContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
// ctor "40 53 48 83 EC ?? 48 8B D9 E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 33 C0"
// has id >63000 in InstanceContent sheet
[StructLayout(LayoutKind.Explicit, Size = 0x1CA8 + 0x658)]
public unsafe partial struct InstanceContentOceanFishing {
    [FieldOffset(0x0)] public InstanceContentDirector InstanceContentDirector;

    // Most of the fields, if not specified, can be found in "83 FA ?? 0F 87 ?? ?? ?? ?? 48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 05"

    // Row ID for IKDRoute sheet
    // Each zone (and their time of day) can be extracted from sheet
    [FieldOffset(0x1CD0)] public uint CurrentRoute;

    [FieldOffset(0x1CD4)] public OceanFishingStatus Status;

    // this should be uint, byte should be fine too since it only has 3 zones
    [FieldOffset(0x1CD8)] public byte CurrentZone; // 0, 1, 2

    // It always is 420
    [FieldOffset(0x1CDC)] public uint Duration;

    // InstanceContentDirector.ContentDirector.ContentTimeLeft - TimeOffset = time left in current zone
    // After changing zones, seems to tick down independent of the UI and then jump up
    [FieldOffset(0x1CE0)] public uint TimeOffset;

    [FieldOffset(0x1CE4)] public uint WeatherID;

    [FieldOffset(0x1CE8)] public bool SpectralCurrentActive;

    // Offest can be found with this sig "45 8B 84 CF ?? ?? ?? ?? 48 8B CD"
    // Struct size can be found with "83 C7 ?? 49 83 EE ?? 75 ?? FF C6"
    // Array size can be found with "83 FF ?? 72 ?? 4C 8B 74 24 ?? 49 8D 9F"
    [FixedSizeArray<FishDataStruct>(60)]
    [FieldOffset(0x1D3C)] public fixed byte FishData[0x10 * 60];

    // The first 10 of them are normal fish, the rest are spectral fish
    public Span<FishDataStruct> FirstZoneFishData => FishDataSpan.Slice(0, 20);
    public Span<FishDataStruct> SecondZoneFishData => FishDataSpan.Slice(20, 20);
    public Span<FishDataStruct> ThirdZoneFishData => FishDataSpan.Slice(40, 20);

    // the function that sets the data -> "48 8D 81 ?? ?? ?? ?? B9 ?? ?? ?? ?? 0F 1F 40 ?? 48 8D 80"
    // Offsets can be found with "48 89 5C 24 ? 48 89 74 24 ? 57 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 84 24 ? ? ? ? 48 8B F1 48 8D 4C 24"
    // these are only valid when Status is Finished
    [FieldOffset(0x2100)] public byte AllResultSize;
    [FieldOffset(0x2101)] public byte LocalIndexInAllResult;
    [FieldOffset(0x2102)] public IndividualResultStruct IndividualResult;
    [FieldOffset(0x2124)] public AllResultStruct LocalPlayerAllResult;
    [FixedSizeArray<AllResultStruct>(10)]
    [FieldOffset(0x214C)] public fixed byte AllResult[0x28 * 10];

    // Row ID for IKDPlayerMissionCondition sheet
    // Description and required amount can be extracted from sheet
    [FieldOffset(0x22E0)] public uint Mission1Type;
    [FieldOffset(0x22E4)] public uint Mission2Type;
    [FieldOffset(0x22E8)] public uint Mission3Type;

    // Progress can be larger than the mission's required amount
    [FieldOffset(0x22EC)] public ushort Mission1Progress;
    [FieldOffset(0x22EE)] public ushort Mission2Progress;
    [FieldOffset(0x22F0)] public ushort Mission3Progress;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct FishDataStruct {
        [FieldOffset(0x0)] public uint ItemId;
        // Row id for IKDFishParam sheet, can be used to retrieve fish type like jellyfish, seahorse etc.
        [FieldOffset(0x4)] public ushort FishParamId;
        [FieldOffset(0x6)] public ushort NqAmount;
        [FieldOffset(0x8)] public ushort HqAmount;
        [FieldOffset(0xC)] public uint TotalPoints;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct AllResultStruct {
        [FieldOffset(0x0)] public ushort WorldId;
        [FieldOffset(0x2)] public ushort CaughtFish;
        [FieldOffset(0x4)] public ushort TotalPoints;
        [FieldOffset(0x8)] public fixed byte PlayerName[32];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x22)]
    public struct IndividualResultStruct {
        [FieldOffset(0x2)] public uint TotalPoints;
        [FieldOffset(0xA)] public uint ExperiencePoints;
        // Scrip introduced in the last expansion
        [FieldOffset(0xE)] public ushort Scrip1Amount;
        // Scrip that is introduced in this expansion
        [FieldOffset(0x10)] public ushort Scrip2Amount;
        // Each element is row id for IKDContentBonus
        [FieldOffset(0x12)] public fixed byte Bonuses[16];
    }

    public enum OceanFishingStatus : uint {
        WaitingForPlayers = 0,
        SwitchingZone = 1,
        Fishing = 2,
        NewZone = 3,
        Finished = 4,
    }
}
