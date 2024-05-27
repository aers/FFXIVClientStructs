using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.PartyInvite)]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct InfoProxyPartyInvite {
    [FieldOffset(0x000)] public InfoProxyInvitedInterface InfoProxyInvitedInterface;
    [FieldOffset(0x03C)] public uint InviteTime;
    [FieldOffset(0x042)] public ushort InviterWorldId;
    [FieldOffset(0x048)] public Utf8String IviterName;
    [FieldOffset(0x0B0)] public Utf8String IviterNameWithHomeworld;

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 EB 51"), GenerateCStrOverloads]
    public partial bool InviteToParty(ulong contentId, byte* name, ushort worldId);

    [MemberFunction("48 83 EC 38 41 B1 09")]
    public partial bool InviteToPartyContentId(ulong contentId, ushort worldId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 48 85 C0 74 62")]
    public partial bool InviteToPartyInInstance(ulong contentId);
}
