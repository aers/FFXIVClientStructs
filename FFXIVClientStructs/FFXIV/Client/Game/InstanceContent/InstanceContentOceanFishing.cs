using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentOceanFishing
//   Client::Game::InstanceContent::InstanceContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
// ctor "40 53 48 83 EC ?? 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 89 03 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8D 05"
// has id >63000 in InstanceContent sheet
[GenerateInterop]
[Inherits<InstanceContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x1CA8 + 0x658)]
public unsafe partial struct InstanceContentOceanFishing {

    // Most of the fields, if not specified, can be found in "83 FA ?? 0F 87 ?? ?? ?? ?? 48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 05"

    // Row ID for IKDRoute sheet
    // Each zone (and their time of day) can be extracted from sheet
    [FieldOffset(0x1DB8)] public uint CurrentRoute;

    [FieldOffset(0x1DBC)] public OceanFishingStatus Status;

    [FieldOffset(0x1DC0)] public uint CurrentZone; // 0, 1, 2

    // It always is 420
    [FieldOffset(0x1DC4)] public uint Duration;

    // InstanceContentDirector.ContentDirector.ContentTimeLeft - TimeOffset = time left in current zone
    // After changing zones, seems to tick down independent of the UI and then jump up
    [FieldOffset(0x1DC8)] public uint TimeOffset;

    [FieldOffset(0x1DCC)] public uint WeatherId;

    [FieldOffset(0x1DD0)] public bool SpectralCurrentActive;

    // Offest, struct size and array length can be found with this sig "45 8B 84 CF ?? ?? ?? ?? 48 8B CD"
    [FieldOffset(0x1E24), FixedSizeArray] internal FixedSizeArray60<FishDataStruct> _fishData;

    // The first 10 of them are normal fish, the rest are spectral fish
    [UnscopedRef]
    public Span<FishDataStruct> FirstZoneFishData => FishData.Slice(0, 20);
    [UnscopedRef]
    public Span<FishDataStruct> SecondZoneFishData => FishData.Slice(20, 20);
    [UnscopedRef]
    public Span<FishDataStruct> ThirdZoneFishData => FishData.Slice(40, 20);

    // the function that sets the data -> "48 8D 81 ?? ?? ?? ?? B9 ?? ?? ?? ?? 0F 1F 40 ?? 48 8D 80"
    // Offsets can be found with "48 89 5C 24 ? 48 89 74 24 ? 57 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 84 24 ? ? ? ? 48 8B F1 48 8D 4C 24"
    // these are only valid when Status is Finished
    [FieldOffset(0x21E8)] public byte AllResultSize;
    [FieldOffset(0x21E9)] public byte LocalIndexInAllResult;
    [FieldOffset(0x21EA)] public IndividualResultStruct IndividualResult;
    [FieldOffset(0x220C)] public AllResultStruct LocalPlayerAllResult;
    [FieldOffset(0x2234), FixedSizeArray] internal FixedSizeArray10<AllResultStruct> _allResults;

    // Row ID for IKDPlayerMissionCondition sheet
    // Description and required amount can be extracted from sheet
    [FieldOffset(0x23C8)] public uint Mission1Type;
    [FieldOffset(0x23CC)] public uint Mission2Type;
    [FieldOffset(0x23D0)] public uint Mission3Type;

    // Progress can be larger than the mission's required amount
    [FieldOffset(0x23D4)] public ushort Mission1Progress;
    [FieldOffset(0x23D6)] public ushort Mission2Progress;
    [FieldOffset(0x23D8)] public ushort Mission3Progress;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct FishDataStruct {
        [FieldOffset(0x0)] public uint ItemId;
        // Row id for IKDFishParam sheet, can be used to retrieve fish type like jellyfish, seahorse etc.
        [FieldOffset(0x4)] public ushort FishParamId;
        [FieldOffset(0x6)] public ushort NqAmount;
        [FieldOffset(0x8)] public ushort HqAmount;
        [FieldOffset(0xC)] public uint TotalPoints;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct AllResultStruct {
        [FieldOffset(0x0)] public ushort WorldId;
        [FieldOffset(0x2)] public ushort CaughtFish;
        [FieldOffset(0x4)] public ushort TotalPoints;
        [FieldOffset(0x8), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _playerName;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x22)]
    public partial struct IndividualResultStruct {
        [FieldOffset(0x2)] public uint TotalPoints;
        [FieldOffset(0xA)] public uint ExperiencePoints;
        // Scrip introduced in the last expansion
        [FieldOffset(0xE)] public ushort Scrip1Amount;
        // Scrip that is introduced in this expansion
        [FieldOffset(0x10)] public ushort Scrip2Amount;
        // Each element is row id for IKDContentBonus
        [FieldOffset(0x12), FixedSizeArray] internal FixedSizeArray16<byte> _bonuses;
    }

    public enum OceanFishingStatus : uint {
        WaitingForPlayers = 0,
        SwitchingZone = 1,
        Fishing = 2,
        NewZone = 3,
        Finished = 4,
    }
}
