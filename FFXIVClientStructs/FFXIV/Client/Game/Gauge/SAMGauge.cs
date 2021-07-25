using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct SAMGauge
    {
        [FieldOffset(3)] public byte Kenki;
        [FieldOffset(4)] public byte MeditationStacks;
        [FieldOffset(5)] public byte SenFlags;
    }
}
