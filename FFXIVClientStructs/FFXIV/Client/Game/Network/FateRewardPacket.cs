namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public partial struct FateRewardPacket {
    [FieldOffset(0x00)] public uint Experience;
    [FieldOffset(0x04)] public uint BonusExperience; // maybe?
    [FieldOffset(0x08)] public uint GilAmount;
    [FieldOffset(0x0C)] public uint GCSealsAmount;
    [FieldOffset(0x10)] public uint ItemId; // tomestones?
    [FieldOffset(0x14)] public uint FateTokenTypeAmount;
    [FieldOffset(0x18)] public ushort FateId;
    [FieldOffset(0x1A)] public ushort ItemAmount;
    [FieldOffset(0x1C)] public byte FateTokenTypeId;
    [FieldOffset(0x1D)] public FateRewardFlag Flags;
    [FieldOffset(0x1E)] public FateRewardMedal Medal;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray5<ItemReward> _itemRewards;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public partial struct ItemReward {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint Amount;
    }
}

[Flags]
public enum FateRewardFlag : byte {
    Success = 1 << 0,
    SuppressPopup = 1 << 3,
    Bonus = 1 << 4,
}

public enum FateRewardMedal : byte {
    Gold = 0,
    Silver = 1,
    Bronze = 2,
    CriticalEngagement = 3,
}
