namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFateReward
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FateReward)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AgentFateReward {
    [FieldOffset(0x28)] public StdDeque<Reward> Rewards;
    [FieldOffset(0x50)] public int IsRewardPending; // saved as int.. dunno why. stays 1 until item rows are loaded and the Reward was shown

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 48 33 CC E8 ?? ?? ?? ?? 48 81 C4 ?? ?? ?? ?? 41 5E")]
    public partial void EnqueueReward(Reward* reward);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x168)]
    public unsafe partial struct Reward {
        [FieldOffset(0x00)] public RewardType Type;
        [FieldOffset(0x01)] public bool IsSuccess;
        [FieldOffset(0x08)] public Utf8String Name;
        [FieldOffset(0x70)] public uint Icon;
        [FieldOffset(0x74)] public uint Medal;
        // For GoldSaucerReward the Id is the index in this array of Addon RowIds: 9980, 9981, 9982, 9984, 9983, 9986, 9985, 9987, 9988, 9989, 9990, 9991, 9992, 9993, 9994, 9995, 9996
        // For WKSReward the Id is a byte, followed by a byte with flags
        [FieldOffset(0x78)] public uint Id;
        [FieldOffset(0x7C)] public byte EurekaFate;
        [FieldOffset(0x80)] public uint Experience; // Experience, Island EXP, ...
        [FieldOffset(0x84)] public byte ExperienceFlags;
        [FieldOffset(0x88)] public uint CurrencyAmount; // Gil, Seafarer's Cowrie, ...
        [FieldOffset(0x8C)] public byte CurrencyFlags;
        [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray5<ItemReward> _items;
        [FieldOffset(0x108)] public byte FateTokenTypeId;
        [FieldOffset(0x10C)] public uint FateTokenTypeItemId;
        [FieldOffset(0x110)] public uint FateTokenTypeAmount;
        [FieldOffset(0x118), CExporterExcel("Item")] public void* FateTokenTypeItemRow;
        [FieldOffset(0x120)] public byte FateTokenTypeFlags;
        [FieldOffset(0x128)] public byte GrandCompany;
        [FieldOffset(0x12C)] public uint GCSealsAmount;
        [FieldOffset(0x130), FixedSizeArray] internal FixedSizeArray3<AdditionalItemReward> _additionalItems;
        [FieldOffset(0x160)] public byte ItemProcessedBits;
        [FieldOffset(0x161)] public byte ItemProcessedCount;

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public unsafe struct ItemReward {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint Amount;
            [FieldOffset(0x08), CExporterExcel("Item")] public void* ItemRow;
            [FieldOffset(0x10)] public byte Flags;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public unsafe struct AdditionalItemReward {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint Amount;
            [FieldOffset(0x08), CExporterExcel("Item")] public void* ItemRow;
        }
    }

    public enum RewardType : byte {
        FateReward = 0,
        DynamicEventReward = 1,
        TreasureHuntReward = 2,
        GoldSaucerReward = 3,
        MJIReward = 4,
        WKSReward = 5,
    }
}
