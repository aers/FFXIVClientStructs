using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct SCHGauge
    {
        [FieldOffset(2)] public byte NumAetherflowStacks;
        [FieldOffset(3)] public byte FairyGaugeAmount;
        [FieldOffset(4)] public short SeraphTimer;
        [FieldOffset(6)] public byte DismissedFairy;
    }
}
