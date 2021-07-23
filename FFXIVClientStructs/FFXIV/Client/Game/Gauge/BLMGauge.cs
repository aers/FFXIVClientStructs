using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct BLMGauge
    {
        [FieldOffset(0)] public short TimeUntilNextPolyglot;  // enochian timer
        [FieldOffset(2)] public short ElementTimeRemaining;  // umbral ice and astral fire timer
        [FieldOffset(4)] public byte ElementStance; // umbral ice or astral fire
        [FieldOffset(5)] public byte NumUmbralHearts;
        [FieldOffset(6)] public byte NumPolyglotStacks;
        [FieldOffset(7)] public byte EnochianState;
    }
}
