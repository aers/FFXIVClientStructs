using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct MCHGauge
    {
        [FieldOffset(0)] public short overheatTimeRemaining;
        [FieldOffset(2)] public short robotTimeRemaining;
        [FieldOffset(4)] public byte heat;
        [FieldOffset(5)] public byte battery;
        [FieldOffset(6)] public byte lastRobotBatteryPower;
        [FieldOffset(7)] public byte timerActive;
    }
}
