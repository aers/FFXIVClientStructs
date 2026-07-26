namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public partial struct FateRewardPacket {
    [FieldOffset(0x00)] public uint Experience;
    [FieldOffset(0x04)] public uint BonusExperience; // maybe?
    [FieldOffset(0x08)] public uint GilAmount;
    [FieldOffset(0x0C)] public uint GCSealsAmount;
    [FieldOffset(0x10)] private uint Unk10; // Some Item Id?
    [FieldOffset(0x14)] public uint FateTokenTypeAmount;
    [FieldOffset(0x18)] public ushort FateId;
    [FieldOffset(0x1A)] private ushort Unk1A; // Some Item Amount?
    [FieldOffset(0x1C)] public byte FateTokenTypeId;
    [FieldOffset(0x1D)] private byte Unk1D; // flags/bitfield
    [FieldOffset(0x1E)] private byte Unk1E;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray5<ItemReward> _itemRewards;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public partial struct ItemReward {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint Amount;
    }
}
