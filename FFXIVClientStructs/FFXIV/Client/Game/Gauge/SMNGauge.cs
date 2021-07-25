using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct SMNGauge
    {
        [FieldOffset(0)] public short TimerRemaining;
        [FieldOffset(2)] public byte ReturnSummon;
        [FieldOffset(3)] public byte ReturnSummonGlam;
        [FieldOffset(4)] public byte NumStacks;
    }
}
