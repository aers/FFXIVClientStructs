using FFXIVClientStructs.FFXIV.Client.Game.Network;
using static FFXIVClientStructs.FFXIV.Client.Game.Network.TofuStartSharingPacket;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.TofuHelper;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
[Inherits<HelperInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct TofuHelper {
    [FieldOffset(0x10)] public TofuHelperData* Data;

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 01 FF 90 ?? ?? ?? ?? 48 8B D3 48 8B 48 ?? 48 83 C4 ?? 5B E9 ?? ?? ?? ?? 48 8B 01 FF 90 ?? ?? ?? ?? 48 8B D3 48 8B 48 ?? 48 83 C4 ?? 5B E9 ?? ?? ?? ?? 48 83 C4")]
    public partial void HandleStartSharingPacket(ServerIpcSegment<TofuStartSharingPacket>* packet);

    [MemberFunction("E8 ?? ?? ?? ?? 66 0F 6F 05 ?? ?? ?? ?? 48 8D 8B")]
    public partial void HandleStopSharingPacket(ServerIpcSegment<TofuStopSharingPacket>* packet); 

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 8B 07 48 8B CF FF 90 ?? ?? ?? ?? 48 8B D6 48 8B 48 ?? E8 ?? ?? ?? ?? EB ?? 48 8B 07 48 8B CF FF 90 ?? ?? ?? ?? 48 8B D6 48 8B 48 ?? E8 ?? ?? ?? ?? EB")]
    public partial void HandleRealTimeUpdatePacket(ServerIpcSegment<TofuRealTimeUpdatePacket>* packet);

    [MemberFunction("48 83 EC ?? 4C 8B 51 ?? 4D 85 D2 0F 84")]
    public partial void HandleTofuConfirmationPacket(ServerIpcSegment<TofuConfirmationPacket>* packet);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3AA0)]
    public unsafe partial struct TofuHelperData {
        [FieldOffset(0x0)] public TofuBoardOverview ReceivedBoard;
        [FieldOffset(0x88)] public TofuBoardOverview ReceivedRealTimeBoard;
        [FieldOffset(0x868)] public TofuShareData TofuShareData;

        [MemberFunction("48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 2B E0 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 49 8D 78")]
        public partial bool HandleSharePacket(Utf8String* a2, TofuStartSharingPacket* packet);

        /// <summary>
        /// Function called to verify to the server the shared board was received. Prevents the server from resending the board.
        /// </summary>
        /// <param name="targetContentId">The contentId of the player who send the board.</param>
        /// <param name="boardIndexInSharedFolder">1-based index of board in shared folder</param>
        [MemberFunction("E8 ?? ?? ?? ?? 44 8B CE 44 89 6C 24")]
        public partial void SendVerificationPacket(ulong targetContentId, uint boardIndexInSharedFolder);

        /// <summary>
        /// Saves the board to the shared list and plays a sound.
        /// </summary>
        /// <param name="packetData">Pointer to the data of the packet.</param>
        /// <param name="boardInfo">Pointer to the packed board from the sender.</param>
        /// <param name="boardIndexInSharedFolder">The index of the board within the folder thats shared.  If no folder was shared, this is <c>0</c>.</param>
        /// <param name="totalBoardsInSharedFolder">The total number of boards within the shared fodler. If no folder was shared, this is <c>1</c>.</param>
        [MemberFunction("E8 ?? ?? ?? ?? 40 80 F5")]
        public partial void SaveBoardAndPlaySound(TofuSharePacketData* packetData, TofuPackedBoard* boardInfo, uint boardIndexInSharedFolder, uint totalBoardsInSharedFolder);

        /// <summary>
        /// Shows a notification for the shared board.
        /// </summary>
        /// <param name="isNotRealTimeSharing"><see langword="false" /> if the board shared is Real-Time sharing </param>
        /// <param name="openNotif"> <see langword="true"/> to open the notification, <see langword="false"/> to close the notification.</param>
        [MemberFunction("48 89 6C 24 ?? 56 41 56 41 57 48 83 EC ?? 4C 8B F9 0F B6 EA")]
        public partial void ShowSharedNotification(bool isNotRealTimeSharing, bool openNotif);
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct TofuBoardOverview {
    [FieldOffset(0x0), CExporterUnion("TofuObjects")] private nint Unk0; // Objects only exist on received boards, not in boards to be sent
    [FieldOffset(0x0), CExporterUnion("TofuObjects")] private StdVector<TofuTransferObject> Objects;
    [FieldOffset(0x18)] public Utf8String BoardName;
    [FieldOffset(0x84)] public byte BoardBackground;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3238)]
public partial struct TofuShareData {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray10<uint> _uiIndex;
    [FieldOffset(0x28)] public ulong SenderContentId;
    [FieldOffset(0x30)] private uint FolderIndex;
    [FieldOffset(0x34)] public byte TotalBoardsInSharedFolder;
    [FieldOffset(0x38)] private bool IsLastBoardInSharedFolder;
    [FieldOffset(0x39)] private bool Unk8A1;
    [FieldOffset(0x40)] private TofuShareSession ShareSession;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x31F8)]
public unsafe partial struct TofuShareSession {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray10<TofuBoardOverview> _boardOverviews;
    [FieldOffset(0x550), FixedSizeArray] internal FixedSizeArray10<TofuPackedBoard> _boards;
    [FieldOffset(0x3070), FixedSizeArray(isString: true)] internal FixedSizeArray60<byte> _folderName;
    [FieldOffset(0x30AC)] public float SendCooldownSeconds; // client side rate limit for sending consecutive boards, set to 1 second
    [FieldOffset(0x30B0)] private uint SendState;
    [FieldOffset(0x30B4)] private uint CurrentBoardIndex;
    [FieldOffset(0x30B8)] public uint TotalBoardsInSharedFolder;

    [FieldOffset(0x30DA)] private bool Unk311A;
    [FieldOffset(0x31A4)] private uint Unk31E4;

    [FieldOffset(0x31B8)] public bool IsNotSending;
    [FieldOffset(0x31C0)] public TofuHelperData* Data;
    [FieldOffset(0x31D0)] public TofuHelper* TofuHelper;
    [FieldOffset(0x31D8)] public UIModule* UIModule;
    [FieldOffset(0x31E8)] public ulong CurrentShareContentId;
}
