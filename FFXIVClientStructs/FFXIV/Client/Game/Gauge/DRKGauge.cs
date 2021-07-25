using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct DRKGauge
    {
        [FieldOffset(0)] public byte Blood;
        [FieldOffset(2)] public ushort DarksideTimeRemaining;
        [FieldOffset(4)] public byte DarkArtsState;
        [FieldOffset(6)] public ushort ShadowTimeRemaining;
    }
}
