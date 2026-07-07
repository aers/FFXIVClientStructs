namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyContentMember
//   Client::UI::Info::InfoProxyCommonList
//     Client::UI::Info::InfoProxyPageInterface
//       Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.ContentMember)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0xD58)]
public unsafe partial struct InfoProxyContentMember {
    [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray200<ContentMemberData> _memberData;
    [FieldOffset(0xD50)] public byte DisplayFlags; // bit0: show in-duty, bit1: show exploring
    [FieldOffset(0xD54)] public int SortMode; // 1=Location, 2=UIPriority, 3=Name, 4=TimeElapsed, 5=MKDSupportJob

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ContentMemberData {
        [FieldOffset(0x0)] public uint EntityId;
        [FieldOffset(0x4)] public uint TimeElapsedSeconds;
        [FieldOffset(0x8)] public ushort Location; // TerritoryType
        [FieldOffset(0xA)] public byte UIPriority; // from ClassJob sheet
        [FieldOffset(0xB)] public byte Flags; // bit0 = IsExploringDungeon
        [FieldOffset(0xC)] public byte MKDSupportJob;
        [FieldOffset(0xD)] public byte MKDSupportJobLevel; // secondary sort within same job
    }
}
