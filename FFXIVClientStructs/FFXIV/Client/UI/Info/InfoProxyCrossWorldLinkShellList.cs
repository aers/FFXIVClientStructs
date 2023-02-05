using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.CrossWorldLinkShellList)]
[StructLayout(LayoutKind.Explicit, Size = 530)]
public unsafe partial struct InfoProxyCrossWorldLinkShellList
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;

    [FieldOffset(0x38)] public Utf8String UnkString0;
    [FieldOffset(0xA0)] public Utf8String UnkString1;
    [FixedSizeArray<CWLSEntry>(0x8)]
    [FieldOffset(0x108)] public fixed byte CWLSArray[8 * 0x88];
    //530 after

    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public partial struct CWLSEntry
    {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x78)] public uint FoundationTime;
        [FieldOffset(0x84)] public ushort MembershipType; //1 = Memeber, 2= Leader, 3=Master

    }
}
