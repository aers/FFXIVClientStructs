using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x26)]
public unsafe partial struct WeeklyBingo
{
    [FieldOffset(0x06)] public fixed byte WeeklyBingoOrderData[16];
    [FieldOffset(0x16)] public byte WeeklyBingoRewardData;
    [FieldOffset(0x1A)] private readonly ushort _stickers;
    [FieldOffset(0x20)] private readonly uint _flags;
    [FieldOffset(0x22)] private fixed byte _taskStatus[4];

    [FieldOffset(0x26)] public byte RequestOpenBingoNo;

    [FieldOffset(0x62)] public byte ExpMultiplier;
    [FieldOffset(0x63)] public bool Unk63;
    
    [StaticAddress("88 05 ?? ?? ?? ?? 8B 43 18", 2)]
    public static partial WeeklyBingo* Instance();
    
    /// <summary>Returns the expiration of the players Wondrous Tails Journal as UTC DateTime.</summary>
    public DateTime ExpireDateTime => DateTime.UnixEpoch.AddSeconds(GetExpireUnixTimestamp());

    /// <summary>Returns the current number of second chance points.</summary>
    public uint NumSecondChancePoints => GetFlagsValue(3);

    /// <summary>Returns whether the player has the book or not.</summary>
    public bool HasBook => GetFlagsValue(5) != 0;

    /// <summary>Returns the number of placed stickers.</summary>
    public int NumPlacedStickers => BitOperations.PopCount(_stickers);
    
    /// <summary>Returns the value of the requested flag.</summary>
    /// <param name="mode">
    /// The following modes have been found:<br/>
    /// 3 = second chance count<br/>
    /// 5 = weather player has book
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? 3B C3 0F 93 C0")]
    private partial uint GetFlagsValue(uint mode);
    
    /// <summary>Returns whether the Wondrous Tails Journal has expired or not.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1D 48 8B 4B 10")]
    public partial bool IsExpired();
    
    /// <summary>Returns the expiration of the players Wondrous Tails Journal as a unix timestamp.</summary>
    [MemberFunction("8B 81 ?? ?? ?? ?? C1 E8 04 25")]
    public partial uint GetExpireUnixTimestamp();
    
    /// <summary>Returns whether the task is complete or not.</summary>
    /// <param name="index">Task index, starting at 1.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 41 8B D7 88 06")]
    public partial bool IsStickerPlaced(int index);
    
    /// <summary>Returns the stored state of the indexed task.</summary>
    /// <param name="index">Task index, starting at 0.</param>
    [MemberFunction("48 8B C1 83 FA 10")]
    public partial WeeklyBonusTaskStatus GetTaskStatus(int index);
    
    /// <summary>Returns the experience multiplier.</summary>
    /// <remarks>The experience reward is being calculated as: Current Job Experience / 100 * WeeklyBonusExpMultiplier</remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 0F AF C3")]
    public partial uint GetExpMultiplier();
    
    public enum WeeklyBonusTaskStatus
    {
        /// <summary>Incomplete task.</summary>
        Open,
        /// <summary>Completed task, but sticker not placed.</summary>
        Claimable,
        /// <summary>Completed task and sticker placed.</summary>
        Claimed,
    }
}