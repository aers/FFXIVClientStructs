﻿namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[InfoProxy(InfoProxyId.Mail)]
[StructLayout(LayoutKind.Explicit, Size = 0x5250)]
public unsafe partial struct InfoProxyMail
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x18)] public byte Unk18; //INcrements each time I open Mail Window
    [FieldOffset(0x19)] public byte Unk19; //INcrements each time I open Mail Window
    [FieldOffset(0x24)] public byte NumAtachments;
    [FieldOffset(0x27)] public byte NumLettersFromFriends;
    [FieldOffset(0x28)] public byte NumPurchases;
    [FixedSizeArray<Entry>(130)]
    [FieldOffset(0x30)] public fixed byte List[130 * 0xa0];
    //0xCC0 After


    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public unsafe partial struct Entry
    {
        [FieldOffset(0x00)] public long SenderContentID;// 0xFFFFFFFF for Store
        [FieldOffset(0x08)] public uint Timestamp;
        [FixedSizeArray<ItemAttachment>(5)]
        [FieldOffset(0x0C)] public fixed byte Attachments[40];
        [FieldOffset(0x38)] public uint Gil;
        [FieldOffset(0x3C)] public bool Read;

        [FieldOffset(0x3F)] public fixed byte Sender[32];
        [FieldOffset(0x5F)] public fixed byte MessagePreview[64];

        [StructLayout(LayoutKind.Explicit, Size = 0x8)]
        public partial struct ItemAttachment
        {
            [FieldOffset(0x0)] public uint ItemID;
            [FieldOffset(0x4)] public uint Count;
        }
    }
}
