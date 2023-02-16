namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x6E8)]
public unsafe struct FreeCompanyInfo
{
    [FieldOffset(0x30)] public ulong FreeCompanyId;
    [FieldOffset(0x7C)] public byte* FreeCompanyName; // null-terminated cstring
    [FieldOffset(0x93)] public byte* FounderName; // null-terminated cstring

    [FixedSizeArray<RankInfo>(11)]
    [FieldOffset(0x160)] public fixed byte RankInformation[0x58 * 11];
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct RankInfo
{
    [FieldOffset(0x00)] public short MemberCount;
    [FieldOffset(0x03)] public byte* RankName; // Null-terminated cstring
}