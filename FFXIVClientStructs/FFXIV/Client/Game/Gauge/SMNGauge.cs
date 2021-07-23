using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct SMNGauge
    {
        [FieldOffset(0)] public short timerRemaining;
        [FieldOffset(2)] public byte returnSummon;
        [FieldOffset(3)] public byte returnSummonGlam;
        [FieldOffset(4)] public byte numStacks;
    }
}
