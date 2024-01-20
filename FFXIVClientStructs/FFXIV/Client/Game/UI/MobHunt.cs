namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

/// <remarks>
/// Note: The game does not clear the data when a mark is completed.<br/>
/// <br/>
/// Index Order is a little weird<br/>
/// The `A Realm Reborn Elite` was added after Heavensward<br/>
/// Others follow logical sequential order:<br/>
///  0 - A Realm Reborn Level 1<br/>
///  1 - Heavensward Level 1<br/>
///  2 - Heavensward Level 2<br/>
///  3 - Heavensward Level 3<br/>
///  4 - A Realm Reborn Elite<br/>
///  5 - Heavensward Elite<br/>
///  6 - Stormblood Level 1<br/>
///  7 - Stormblood Level 2<br/>
///  8 - Stormblood Level 3<br/>
///  9 - Stormblood Elite<br/>
/// 10 - Shadowbringers Level 1<br/>
/// 11 - Shadowbringers Level 2<br/>
/// 12 - Shadowbringers Level 3<br/>
/// 13 - Shadowbringers Elite<br/>
/// 14 - Endwalker Level 1<br/>
/// 15 - Endwalker Level 2<br/>
/// 16 - Endwalker Level 3<br/>
/// 17 - Endwalker Elite
/// </remarks>
// Client::Game::UI::MobHunt
[StructLayout(LayoutKind.Explicit, Size = 0x198)]
public unsafe partial struct MobHunt {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 0F B6 50 08 E8 ?? ?? ?? ?? 84 C0 74 16", 3)]
    public static partial MobHunt* Instance();

    [FieldOffset(0x08)] public fixed byte AvailableMarkId[18];
    [FieldOffset(0x1A)] public fixed byte ObtainedMarkId[18];

    [FixedSizeArray<KillCounts>(18)]
    [FieldOffset(0x2C)] public fixed byte CurrentKills[18 * 0x14];

    [FieldOffset(0x194)] public int ObtainedFlags;

    /// <param name="markIndex">Mark Bill Index 0-18</param>
    /// <param name="mobIndex">Mob Index 0-4</param>
    /// <returns>Current kill count</returns>
    [MemberFunction("4C 8B C9 80 FA 12")]
    public partial int GetKillCount(byte markIndex, byte mobIndex);

    /// <param name="markIndex">Mark Bill Index 0-18</param>
    /// <returns>MobHuntOrder Primary Row Id</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 89 44 24 38 45 33 FF")]
    public partial int GetObtainedHuntOrderRowId(byte markIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 57 28 48 8D 0D")]
    public partial int GetAvailableHuntOrderRowId(byte markIndex);

    /// <param name="itemId">Mark Bill ItemId</param>
    /// <returns>18 Indicates Not Found</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 E0 3C 12")]
    public partial int GetMarkIndexFromItemId(int itemId);

    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC 20 40 32 F6")]
    public partial bool IsMarkBillUnlocked(byte markIndex);

    public bool IsMarkBillObtained(int index)
        => (ObtainedFlags & 1 << index) != 0;

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public struct KillCounts {
        [FieldOffset(0x00)] public fixed int Counts[5];

        public int this[int index] => Counts[index];
    }
}
