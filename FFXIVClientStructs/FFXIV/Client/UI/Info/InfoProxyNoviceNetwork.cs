namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.NoviceNetwork)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
public unsafe partial struct InfoProxyNoviceNetwork {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 45 33 C9")]
    [GenerateStringOverloads]
    public partial bool InviteToNoviceNetwork(ulong contentId, ushort worldId, byte* name);
}
