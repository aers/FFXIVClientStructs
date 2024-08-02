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

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct BlockedCharacter {
        [FieldOffset(0x0)] public byte* Name;
        [FieldOffset(0x8)] public ulong Id; // accountId for new, contentId for old
        [FieldOffset(0x10)] public byte Flag;
    }
}
