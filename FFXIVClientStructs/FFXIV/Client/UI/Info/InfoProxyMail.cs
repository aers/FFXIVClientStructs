namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct InfoProxyMail
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FixedSizeArray<Entry>(20)]
    [FieldOffset(0x40)] public fixed byte List[20 * 0xa0];
    //0xCC0 After

    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public unsafe partial struct Entry
    {
        //[FieldOffset(0x00)] public long Unk0; 0xFFFFFFFF
        [FieldOffset(0x08)] public uint Timestamp;
        [FieldOffset(0x3F)] public fixed byte Betreff[97];
    }
}
