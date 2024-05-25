using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.PartyInvite)]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct InfoProxyPartyInvite {
    [FieldOffset(0x000)] public InfoProxyInvitedInterface InfoProxyInvitedInterface;
    [FieldOffset(0x03C)] public uint InviteTime;
    [FieldOffset(0x042)] public ushort InviterWorldID;
    [FieldOffset(0x048)] public Utf8String IviterName;
    [FieldOffset(0x0B0)] public Utf8String IviterNameWithHomeworld;

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 EB 51")]
    public partial byte InviteToParty(byte* name, ushort world, ulong contentId);

    [MemberFunction("48 83 EC 38 41 B1 09")]
    public partial byte InviteToPartyContentId(ulong contentId, ushort homeWorld);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 48 85 C0 74 62")]
    public partial byte InviteToPartyInInstance(ulong contentId);
}
