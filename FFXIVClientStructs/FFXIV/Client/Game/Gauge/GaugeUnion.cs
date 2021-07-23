using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct GaugeUnion
    {
        [FieldOffset(0)] public ASTGauge ASTGauge;
        [FieldOffset(0)] public BLMGauge BLMGauge;
        [FieldOffset(0)] public BRDGauge BRDGauge;
        [FieldOffset(0)] public DNCGauge DNCGauge;
        [FieldOffset(0)] public DRGGauge DRGGauge;
        [FieldOffset(0)] public DRKGauge DRKGauge;
        [FieldOffset(0)] public GNBGauge GNBGauge;
        [FieldOffset(0)] public MCHGauge MCHGauge;
        [FieldOffset(0)] public MNKGauge MNKGauge;
        [FieldOffset(0)] public NINGauge NINGauge;
        [FieldOffset(0)] public PLDGauge PLDGauge;
        [FieldOffset(0)] public RDMGauge RDMGauge;
        [FieldOffset(0)] public SAMGauge SAMGauge;
        [FieldOffset(0)] public SCHGauge SCHGauge;
        [FieldOffset(0)] public SMNGauge SMNGauge;
        [FieldOffset(0)] public WARGauge WARGauge;
        [FieldOffset(0)] public WHMGauge WHMGauge;
    }
}
