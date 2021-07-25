using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct WHMGauge
    {
        [FieldOffset(2)] public short LilyTimer;
        [FieldOffset(4)] public byte NumLilies;
        [FieldOffset(5)] public byte NumBloodLily;
    }
}
