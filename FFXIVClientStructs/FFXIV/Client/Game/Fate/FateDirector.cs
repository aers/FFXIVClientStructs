using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

[StructLayout(LayoutKind.Explicit, Size = 0x4f8)]
public struct FateDirector
{
    [FieldOffset(0x00)] public Director Director;
    [FieldOffset(0x4B8)] public byte FateLevel;
    [FieldOffset(0x4C0)] public uint FateNpcObjectId;
    [FieldOffset(0x4CC)] public ushort FateId;
}