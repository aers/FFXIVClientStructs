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
/// 18 - Dawntrail Level 1<br/>
/// 19 - Dawntrail Level 2<br/>
/// 20 - Dawntrail Level 3<br/>
/// 21 - Dawntrail Elite
/// </remarks>
// Client::Game::UI::MobHunt
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct MobHunt {
    public const int MaxMarkIndex = 22;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? 0F B6 50 08 E8 ?? ?? ?? ?? 84 C0 48 8B 47 28", 3)]
    public static partial MobHunt* Instance();

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray22<byte> _availableMarkId;
    [FieldOffset(0x1E), FixedSizeArray] internal FixedSizeArray22<byte> _obtainedMarkId;

    [FieldOffset(0x34), FixedSizeArray] internal FixedSizeArray22<KillCounts> _currentKills;

    [FieldOffset(0x1EC)] public int ObtainedFlags;

    /// <param name="markIndex">Mark Bill Index 0-22</param>
    /// <param name="mobIndex">Mob Index 0-4</param>
    /// <returns>Current kill count</returns>
    [MemberFunction("80 FA 16 73 19")]
    public partial int GetKillCount(byte markIndex, byte mobIndex);

    /// <param name="markIndex">Mark Bill Index 0-22</param>
    /// <returns>MobHuntOrder Primary Row Id</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 89 44 24 38 45 8B FE")]
    public partial int GetObtainedHuntOrderRowId(byte markIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 57 28 48 8D 0D")]
    public partial int GetAvailableHuntOrderRowId(byte markIndex);

    /// <param name="itemId">Mark Bill ItemId</param>
    /// <returns>MaxMarkIndex Value Indicates Not Found</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D0 48 8D 0D ?? ?? ?? ?? 44 0F B6 E0")]
    public partial int GetMarkIndexFromItemId(uint itemId);

    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC 20 0F B6 DA 40 32 F6")]
    public partial bool IsMarkBillUnlocked(byte markIndex);

    public bool IsMarkBillObtained(int index)
        => (ObtainedFlags & 1 << index) != 0;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public partial struct KillCounts {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray5<int> _counts;

        public int this[int index] => Counts[index];
    }
}
