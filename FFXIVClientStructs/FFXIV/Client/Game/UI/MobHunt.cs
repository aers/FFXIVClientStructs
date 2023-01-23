namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Index Order is a little weird
// The `A Realm Reborn Elite` was added after Heavensward
// Others follow logical sequential order
//
//  0 - A Realm Reborn Level 1
//  1 - Heavensward Level 1
//  2 - Heavensward Level 2
//  3 - Heavensward Level 3
//  4 - A Realm Reborn Elite
//  5 - Heavensward Elite
//  6 - Stormblood Level 1
//  7 - Stormblood Level 2
//  8 - Stormblood Level 3
//  9 - Stormblood Elite
// 10 - Shadowbringers Level 1
// 11 - Shadowbringers Level 2
// 12 - Shadowbringers Level 3
// 13 - Shadowbringers Elite
// 14 - Endwalker Level 1
// 15 - Endwalker Level 2
// 16 - Endwalker Level 3
// 17 - Endwalker Elite

/// <summary>
/// Note: The game does not clear the data when a mark is completed.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x198)]
public unsafe partial struct MobHunt
{
    [FieldOffset(0x8)] public fixed byte unkArray[18];
    [FieldOffset(0x1A)] public fixed byte MarkID[18];
    [FieldOffset(0x2C)] public fixed int CurrentKills[18 * 5];
    [FieldOffset(0x194)] public int ObtainedFlags;
    
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 0F B6 50 08 E8 ?? ?? ?? ?? 84 C0 74 16", 3)]
    public static partial MobHunt* Instance();

    public bool IsMarkBillObtained(int index)
    {
        return (ObtainedFlags & 1 << index) != 0;
    }
    
    public Span<int> GetKillCountsForIndex(int index)
    {
        fixed (int* ptr = CurrentKills) 
        {
            return new Span<int>(ptr + 5 * index, 5);
        }
    }
}