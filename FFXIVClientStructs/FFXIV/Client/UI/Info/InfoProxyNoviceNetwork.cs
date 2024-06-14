namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyNoviceNetwork
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.NoviceNetwork)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct InfoProxyNoviceNetwork {
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 50 48 8B 9C 24")]
    [GenerateStringOverloads]
    public partial bool InviteToNoviceNetwork(ulong contentId, ushort worldId, byte* name);
}
