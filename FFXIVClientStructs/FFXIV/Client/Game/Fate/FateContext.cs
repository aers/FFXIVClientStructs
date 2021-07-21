using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Fate
{
    [StructLayout(LayoutKind.Explicit, Size = 0x1000)]
    public unsafe struct FateContext
    {
        [FieldOffset(0x18)] public ushort FateId;
        [FieldOffset(0x20)] public int StartTimeEpoch;
        [FieldOffset(0x28)] public short Duration;
        [FieldOffset(0xC0)] public Utf8String Name;
        [FieldOffset(0x3AC)] public byte State;
        [FieldOffset(0x3B8)] public byte Progress;
        [FieldOffset(0x3F9)] public byte Level;
        [FieldOffset(0x450)] public float X;
        [FieldOffset(0x454)] public float Z;
        [FieldOffset(0x458)] public float Y;
        [FieldOffset(0x74E)] public ushort TerritoryID;
    }
}
