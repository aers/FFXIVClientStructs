namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyPartyInvite
//   Client::UI::Info::InfoProxyInvitedList
//      Client::UI::Info::InfoProxyInterface
//   Client::UI::Info::InfoProxyInvitedInterface
[InfoProxy(InfoProxyId.PartyInvite)]
[GenerateInterop]
[Inherits<InfoProxyInvitedList>, Inherits<InfoProxyInvitedInterface>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 43 ?? 66 89 AB", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct InfoProxyPartyInvite {
    [FieldOffset(0x03C)] public uint InviteTime;
    [FieldOffset(0x042)] public ushort InviterWorldId;
    [FieldOffset(0x048)] public Utf8String InviterName;
    [FieldOffset(0x0B0)] public Utf8String InviterNameWithHomeworld;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B FF 48 8D 4D"), GenerateStringOverloads]
    public partial bool InviteToParty(ulong contentId, CStringPointer name, ushort worldId);

    [MemberFunction("48 83 EC 38 41 B1 09")]
    public partial bool InviteToPartyContentId(ulong contentId, ushort worldId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 48 85 C0 74")]
    public partial bool InviteToPartyInInstanceByContentId(ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 93 ?? ?? ?? ?? 48 8B CE E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 83")]
    public partial bool InviteToPartyInInstanceByEntityId(uint entityId);

    [VirtualFunction(13)]
    public partial bool AcceptInvitation(CStringPointer inviterName, bool accept);
}
