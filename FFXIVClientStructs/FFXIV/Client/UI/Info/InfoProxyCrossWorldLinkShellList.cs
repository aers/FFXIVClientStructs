using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.CrossWorldLinkShell)]
[StructLayout(LayoutKind.Explicit, Size = 0x558)]
public unsafe partial struct InfoProxyCrossWorldLinkShell {
    [FieldOffset(0x00)] public InfoProxyInvitedInterface InfoProxyInvitedInterface;
    [FieldOffset(0x28)] public uint NumInvites;
    //was 1 when 2 Invites
    [FieldOffset(0x30)] public byte Unk30;
    [FieldOffset(0x38)] public Utf8String InvitedName;
    [FieldOffset(0xA0)] public Utf8String UnkString0;
    [FixedSizeArray<CWLSEntry>(0x8)]
    [FieldOffset(0x108)] public fixed byte CWLSArray[8 * 0x88];
    //530 after

    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public partial struct CWLSEntry {
        [FieldOffset(0x00)] public Utf8String Name;
        //0x10 bytes
        [FieldOffset(0x78)] public uint FoundationTime;
        [FieldOffset(0x84)] public ushort MembershipType; //0 = Invitee, 1 = Memeber, 2= Leader, 3=Master

    }
}
