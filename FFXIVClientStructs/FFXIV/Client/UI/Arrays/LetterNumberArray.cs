using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 146 * 4)]
public unsafe partial struct LetterNumberArray {
    public static LetterNumberArray* Instance() => (LetterNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Letter)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray146<int> _data;

    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray130<LetterLetterNumberArray> _allLetters;

    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray100<LetterLetterNumberArray> _friendLetters;
    [FieldOffset(100 * 4), FixedSizeArray] internal FixedSizeArray20<LetterLetterNumberArray> _storeLetters;
    [FieldOffset(120 * 4), FixedSizeArray] internal FixedSizeArray10<LetterLetterNumberArray> _gmLetters;

    [FieldOffset(130 * 4)] public int LettersInMailbox;
    [FieldOffset(131 * 4)] public int LettersFromGameMasters;
    [FieldOffset(132 * 4)] public int LettersFromStore;
    [FieldOffset(133 * 4)] public int UnclaimedGoods;

    [FieldOffset(135 * 4)] public bool CanSpeedUpStoreProcess;
    [FieldOffset(136 * 4)] public bool ClientOccupiedSendingLetter;

    [FieldOffset(138 * 4)] public bool ClientAcquiringLetters;

    [FieldOffset(140 * 4)] public int AttatchedGilAmount;
    [FieldOffset(141), FixedSizeArray] internal FixedSizeArray5<int> _attatchedItemIds;

    [CExportIgnore]
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
    public unsafe partial struct LetterLetterNumberArray {
        [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1<int> _data;

        [FieldOffset(3)] public LetterLetterMessageStatus MessageStatus;
        [FieldOffset(2)] public byte UnkFlag1;
        [FieldOffset(1)] public byte UnkFlag2;
        [FieldOffset(0)] public byte UnkFlag3;  // This is definitely some kind of, user grabbed items, user opened type flag that sends a web request.

        public enum LetterLetterMessageStatus : byte {
            FromFriendRead = 0x01,              // Grey message in mailbox
            FromFriendUnread = 0x02,            // Ping and Green message in mailbox
            FromFriendReadButIgnored = 0x03,    // Green message in mailbox
            FromStoreRead = 0x11,               // Grey message in mailbox
            FromStoreUnread = 0x12,             // Ping and Green message in mailbox
            FromStoreReadButIgnored = 0x13,     // Green message in mailbox
            FromGMRead = 0x21,                  // Grey message in mailbox
            FromGMUnread = 0x22,                // Ping and Green message in mailbox
            FromGMReadButIgnored = 0x23         // Green message in mailbox
        }
    }
}
