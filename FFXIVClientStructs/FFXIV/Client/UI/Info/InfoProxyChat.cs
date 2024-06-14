namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyChat
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Chat)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct InfoProxyChat {
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C8 44 8D 43")]
    public partial byte* GetLinkShellName(uint index);
}
