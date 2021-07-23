using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct DRGGauge
    {
        [FieldOffset(0)] public short BotdTimer;
        [FieldOffset(2)] public byte BotdState;
        [FieldOffset(3)] public byte EyeCount;
    }
}
