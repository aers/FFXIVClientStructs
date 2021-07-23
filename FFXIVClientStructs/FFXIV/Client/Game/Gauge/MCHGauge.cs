using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct MCHGauge
    {
        [FieldOffset(0)] public short OverheatTimeRemaining;
        [FieldOffset(2)] public short RobotTimeRemaining;
        [FieldOffset(4)] public byte Heat;
        [FieldOffset(5)] public byte Battery;
        [FieldOffset(6)] public byte LastRobotBatteryPower;
        [FieldOffset(7)] public byte TimerActive;
    }
}
