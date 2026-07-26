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

    // struct layout seems to differ between RewardTypes? unsure
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x168)]
    public unsafe partial struct Reward {
        [FieldOffset(0x00)] public RewardType Type;
        [FieldOffset(0x01)] private bool Unk01;
        [FieldOffset(0x08)] public Utf8String Name;
        [FieldOffset(0x70)] public uint Icon;
        [FieldOffset(0x74)] private uint Unk74;
        // For GoldSaucerReward the Id is the index in this array of Addon RowIds: 9980, 9981, 9982, 9984, 9983, 9986, 9985, 9987, 9988, 9989, 9990, 9991, 9992, 9993, 9994, 9995, 9996
        // For WKSReward the Id is a byte, followed by a byte with flags
        [FieldOffset(0x78)] public uint Id;
        [FieldOffset(0x7C)] private byte EurekaFate;
        [FieldOffset(0x7D)] private byte Unk7D;
        [FieldOffset(0x7E)] private byte Unk7E;
        [FieldOffset(0x7F)] private byte Unk7F;
        [FieldOffset(0x80)] public uint Experience; // Experience, Island EXP, ...
        [FieldOffset(0x84)] private byte Unk84;
        [FieldOffset(0x85)] private byte Unk85;
        [FieldOffset(0x86)] private byte Unk86;
        [FieldOffset(0x87)] private byte Unk87;
        [FieldOffset(0x88)] public uint CurrencyAmount; // Gil, Seafarer's Cowrie, ...
        [FieldOffset(0x8C)] private uint Unk8C;
        [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray5<ItemReward> _items;
        [FieldOffset(0x108)] public byte FateTokenTypeId;
        [FieldOffset(0x109)] private byte Unk109;
        [FieldOffset(0x10A)] private byte Unk10A;
        [FieldOffset(0x10B)] private byte Unk10B;
        [FieldOffset(0x10C)] public uint FateTokenTypeItemId;
        [FieldOffset(0x110)] public uint FateTokenTypeAmount;
        [FieldOffset(0x114)] private uint Unk114;
        [FieldOffset(0x118), CExporterExcel("Item")] public void* FateTokenTypeItemRow;
        [FieldOffset(0x120)] private byte Unk120;
        [FieldOffset(0x121)] private byte Unk121;
        [FieldOffset(0x122)] private byte Unk122;
        [FieldOffset(0x128)] public byte GrandCompany;
        [FieldOffset(0x12C)] public byte GCSealsAmount;

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public unsafe struct ItemReward {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint Amount;
            [FieldOffset(0x08), CExporterExcel("Item")] public void* ItemRow;
            [FieldOffset(0x10)] public uint Flags;
            [FieldOffset(0x14)] private uint Unk14;
        }
    }

    public enum RewardType : byte {
        FateReward = 0,
        Unk1 = 1, // ContentReward?
        Unk2 = 2, // TreasureHuntReward?
        GoldSaucerReward = 3,
        MJIReward = 4,
        WKSReward = 5,
    }
}
