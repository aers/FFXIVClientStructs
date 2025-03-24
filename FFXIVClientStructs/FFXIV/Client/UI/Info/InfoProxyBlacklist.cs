using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyBlacklist
//   Client::UI::Info::InfoProxyPageInterface
//     Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Blacklist)]
[GenerateInterop]
[Inherits<InfoProxyPageInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x13D8)]
public unsafe partial struct InfoProxyBlacklist {
    [FieldOffset(0x20)] public Utf8String LastBlockedNameContacts; // Gets set with contacts
    [FieldOffset(0x88)] public Utf8String LastBlockedNameChat; // Gets set with chat and contacts
    [FieldOffset(0xF0), FixedSizeArray] internal FixedSizeArray200<BlockedCharacter> _blockedCharacters; // does not clean up removed characters, read only until BlockedCharactersCount
    [FieldOffset(0x13B0)] public int BlockedCharactersCount;
    [FieldOffset(0x13B8)] public StdMap<ulong, int> AccountIdMap;
    [FieldOffset(0x13C8)] public StdMap<ulong, int> ContentIdMap;

    [MemberFunction("48 89 5C 24 ?? 4C 8B 91 ?? ?? ?? ?? 33 C0")]
    public partial void GetBlockResult(BlockResult* outBlockResult, ulong accountId, ulong contentId);

    [MemberFunction("48 83 EC 48 F6 81 ?? ?? ?? ?? ?? 75 ?? 33 C0 48 83 C4 48")]
    public partial BlockResultType GetBlockResultType(ulong accountId, ulong contentId);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct BlockedCharacter {
        [FieldOffset(0x0)] public CStringPointer Name;
        [FieldOffset(0x8)] public ulong Id; // accountId for new, contentId for old
        [FieldOffset(0x10)] public byte Flag;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public struct BlockResult {
        [FieldOffset(0x0)] public BlockResultType Type;
        [FieldOffset(0x8)] public BlockedCharacter* BlockedCharacterPtr;
        [FieldOffset(0x10)] public int BlockedCharacterIndex;
    }

    public enum BlockResultType {
        NotBlocked = 1,
        BlockedByAccountId = 2,
        BlockedByContentId = 3,
    }
}
