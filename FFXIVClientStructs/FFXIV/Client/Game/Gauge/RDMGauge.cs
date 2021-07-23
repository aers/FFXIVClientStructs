using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct RDMGauge
    {
        [FieldOffset(0)] public byte WhiteGauge;
        [FieldOffset(1)] public byte BlackGauge;
    }
}
