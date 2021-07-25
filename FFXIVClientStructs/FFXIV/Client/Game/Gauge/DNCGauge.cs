using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public unsafe struct DNCGauge
    {
        [FieldOffset(0)] public byte NumFeathers;
        [FieldOffset(1)] public byte Esprit;
        [FieldOffset(2)] public fixed byte StepOrder[4];
        [FieldOffset(6)] public byte NumCompleteSteps;
    }
}
