using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x26)]
public unsafe partial struct WondrousTailsData
{
    [FieldOffset(0x06)] public fixed byte WeeklyBingoOrderData[16];
    [FieldOffset(0x16)] public byte WeeklyBingoRewardData;
    [FieldOffset(0x1A)] private readonly ushort _stickers;
    [FieldOffset(0x20)] private readonly ushort _secondChance;
    [FieldOffset(0x22)] private fixed byte _taskStatus[4];

    [StaticAddress("88 05 ?? ?? ?? ?? 8B 43 18", 2)]
    public static partial WondrousTailsData* Instance();
    
    /// <summary>
    /// Returns the stored state of the indexed task.
    /// </summary>
    /// <param name="index">The task index</param>
    /// <returns></returns>
    public ButtonState TaskStatus(int index) => (ButtonState) ((_taskStatus[index >> 2] >> ((index & 0b11) * 2)) & 0b11);
    
    /// <summary>
    /// Gets the current number of second chance points.
    /// </summary>
    public int SecondChance => (_secondChance >> 7) & 0b1111;

    /// <summary>
    /// Gets the current number of placed stickers.
    /// </summary>
    public int Stickers => BitOperations.PopCount(_stickers);
    
    public enum ButtonState
    {
        // Needs instance completion to become available
        Completable = 0b00,

        // Can click button to get a stamp right now
        AvailableNow = 0b01,

        // Already completed, needs re-roll
        Unavailable = 0b10,

        // Data is stale, unknown state
        Unknown = 0b11
    }
}