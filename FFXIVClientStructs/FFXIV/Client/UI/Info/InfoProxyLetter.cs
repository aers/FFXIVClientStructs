using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyLetter
//   Client::UI::Info::InfoProxyPageInterface
//     Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Letter)]
[GenerateInterop]
[Inherits<InfoProxyPageInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x76E0)]
public unsafe partial struct InfoProxyLetter {
    [FieldOffset(0x20)] public uint NumOfDeniedLetters;
    [FieldOffset(0x24)] public ushort NumAttachments;
    [FieldOffset(0x26)] public byte NumNewLetters;
    [FieldOffset(0x27)] public byte NumLettersFromFriends; // 100 max
    [FieldOffset(0x28)] public byte NumLettersFromPurchases; // 20 max
    [FieldOffset(0x29)] public byte NumLettersFromGameMasters; // 10 max
    [FieldOffset(0x2A)] public bool HasLettersFromGameMasters;
    [FieldOffset(0x2B)] public bool HasLettersFromSupportDesk;
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray130<Letter> _letters;
    //0xCC0 After
    [FieldOffset(0x5178)] public Utf8String UnkString0;
    [FieldOffset(0x51E0)] public Utf8String UnkString1;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public unsafe partial struct Letter {
        [FieldOffset(0x00)] public long SenderContentId;// 0xFFFFFFFF for Store
        [FieldOffset(0x08)] public int Timestamp;
        [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray5<ItemAttachment> _attachments;
        [FieldOffset(0x38)] public uint Gil;
        [FieldOffset(0x3C)] public bool Read;

        [FieldOffset(0x3F), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _sender;
        [FieldOffset(0x5F), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _messagePreview;

        [StructLayout(LayoutKind.Explicit, Size = 0x8)]
        public partial struct ItemAttachment {
            [FieldOffset(0x0)] public uint ItemId;
            [FieldOffset(0x4)] public uint Count;
        }
    }
}
