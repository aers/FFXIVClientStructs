using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct ASTGauge
    {
        [FieldOffset(4)] public byte Card;
        [FieldOffset(5)] public unsafe fixed byte Seals[3];
    }
}
