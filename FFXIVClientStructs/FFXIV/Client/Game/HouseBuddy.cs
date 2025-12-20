using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HouseBuddy
// Chocobo Stable
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct HouseBuddy {
    /// <remarks> Used for LogMessage#4466,4486. </remarks>
    [FieldOffset(0x08), FixedSizeArray(isString: true)] internal FixedSizeArray21<byte> _name;

    /// <remarks> Used for LogMessage#4468. Add +10 for actual rank. </remarks>
    [FieldOffset(0x24)] public byte NewMaxRank;

    /// <remarks> Used for LogMessage#4467. </remarks>
    [FieldOffset(0x28)] public uint FavoriteFoodItemId;

    [FieldOffset(0x30)] public StdVector<BuddyDataEntry> BuddyData;

    [FieldOffset(0x48)] public uint BuddyObjectSetupState;
    [FieldOffset(0x50)] public BattleChara* BuddyObject;
    [FieldOffset(0x58)] public int BuddyObjectIndex; // naming is weird. this is the ObjectIndex

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct BuddyDataEntry {
        [FieldOffset(0x00)] public uint EntityId;
        [FieldOffset(0x08)] public long LastUpdate;
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray3<uint> _bardingIds;
        [FieldOffset(0x1C)] public byte ModelScaleId;
        [FieldOffset(0x1D)] public byte StainId;
        [FieldOffset(0x1E)] public byte EventState;
    }
}
