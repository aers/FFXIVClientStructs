namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyNoviceNetwork
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.NoviceNetwork)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct InfoProxyNoviceNetwork {
    [MemberFunction("48 89 44 24 ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CB")]
    [GenerateStringOverloads]
    public partial bool InviteToNoviceNetwork(ulong contentId, ushort worldId, byte* name);
}
