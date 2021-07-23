using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct NINGauge
    {
        [FieldOffset(0)] public int HutonTimeLeft;
        [FieldOffset(4)] public byte Ninki;
        [FieldOffset(5)] public byte NumHutonManualCasts;
    }
}
