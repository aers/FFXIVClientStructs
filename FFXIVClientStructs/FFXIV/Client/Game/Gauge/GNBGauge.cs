using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct GNBGauge
    {
        [FieldOffset(0)] public byte NumAmmo;
        [FieldOffset(2)] public short MaxTimerDuration;
        [FieldOffset(4)] public byte AmmoComboStepNumber;
    }
}
