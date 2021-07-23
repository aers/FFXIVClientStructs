using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct BRDGauge
    {
        [FieldOffset(0)] public short SongTimer;
        [FieldOffset(2)] public byte NumSongStacks;
        [FieldOffset(3)] public byte SoulVoiceValue;
        [FieldOffset(4)] public byte ActiveSong;
    }
}
