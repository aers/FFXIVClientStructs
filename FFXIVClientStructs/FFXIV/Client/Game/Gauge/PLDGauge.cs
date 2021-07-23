using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PLDGauge
    {
        [FieldOffset(0)] public byte GaugeAmount;
    }
}
