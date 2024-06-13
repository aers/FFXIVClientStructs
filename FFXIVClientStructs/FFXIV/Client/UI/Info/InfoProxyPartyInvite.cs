using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyPartyInvite
//   Client::UI::Info::InfoProxyInvitedList
//      Client::UI::Info::InfoProxyInterface
//   Client::UI::Info::InfoProxyInvitedInterface
[InfoProxy(InfoProxyId.PartyInvite)]
[GenerateInterop]
[Inherits<InfoProxyInvitedList>, Inherits<InfoProxyInvitedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct InfoProxyPartyInvite {
    [FieldOffset(0x03C)] public uint InviteTime;
    [FieldOffset(0x042)] public ushort InviterWorldId;
    [FieldOffset(0x048)] public Utf8String InviterName;
    [FieldOffset(0x0B0)] public Utf8String InviterNameWithHomeworld;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B F6 48 8D 4D B0"), GenerateStringOverloads]
    public partial bool InviteToParty(ulong contentId, byte* name, ushort worldId);

    [MemberFunction("48 83 EC 38 41 B1 09")]
    public partial bool InviteToPartyContentId(ulong contentId, ushort worldId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 48 85 C0 74 65")]
    public partial bool InviteToPartyInInstance(ulong contentId);
}
