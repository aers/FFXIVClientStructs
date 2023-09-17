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
}
