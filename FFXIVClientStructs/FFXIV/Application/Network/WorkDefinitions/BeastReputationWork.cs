namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct BeastReputationWork {
    [FieldOffset(0x08)] public byte Rank;
    [FieldOffset(0x0A)] public ushort Value;
}