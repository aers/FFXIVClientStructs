using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1E6)]
public partial struct CharaCardPacket {
    [FieldOffset(0x000)] public CrestData FreeCompanyCrestData; // guessed
    [FieldOffset(0x008)] public ulong AccountId;
    [FieldOffset(0x010)] public ulong ContentId;
    [FieldOffset(0x018)] public uint EntityId;
    [FieldOffset(0x01C)] public uint SomeState;
    [FieldOffset(0x020)] public ushort WorldId;
    [FieldOffset(0x022)] public ushort Level;
    [FieldOffset(0x024)] public byte ClassJobId;
    [FieldOffset(0x025)] public byte Sex;
    [FieldOffset(0x026)] public byte GrandCompany;
    [FieldOffset(0x027)] public byte GcRank;
    [FieldOffset(0x028)] public CharaCardData CharaCardData;
    [FieldOffset(0x0E4), FixedSizeArray] internal FixedSizeArray193<byte> _searchComment;
    [FieldOffset(0x1A5), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    [FieldOffset(0x1C5), FixedSizeArray(isString: true)] internal FixedSizeArray22<byte> _freeCompany; // length unknown; copied from InfoProxyFreeCompany
}
