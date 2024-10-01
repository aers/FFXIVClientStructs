using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ContentsFinder)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x2228)]
public unsafe partial struct AgentContentsFinder {
    [FieldOffset(0x28)] public AgentContentsFinderInterface InterfaceSub;

    [FieldOffset(0x7D8)] public AgentContentsFinderReward RewardSub;

    [FieldOffset(0x1C70)] public StdVector<Pointer<Contents>> ContentList;
    [FieldOffset(0x1C88)] public StdVector<ContentsId> SelectedContent;

    [FieldOffset(0x1CA4)] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette
    [FieldOffset(0x1CB0)] public byte NumCollectedRewards; // Value used for "Reward already received"
    [FieldOffset(0x1CB1)] public byte HasRouletteSelected; // Prevents more roulettes from being selected

    [FieldOffset(0x1CF0)] public UIModule* UIModule;

    [FieldOffset(0x1D00), FixedSizeArray] internal FixedSizeArray10<Utf8String> _strings; // Tooltips and Category headers, ie "Gil", "Trials (Endwalker)"

    [FieldOffset(0x2169), FixedSizeArray] internal FixedSizeArray11<ContentsRouletteRole> _contentRouletteRoleBonuses;

    [FieldOffset(0x2174)] public uint DutyPenaltyMinutes;
    [FieldOffset(0x2178)] public uint UnkPenaltyMinutes;

    [FieldOffset(0x21AC)] public int CurrentTimestamp;
    [FieldOffset(0x21B8)] public byte SelectedTab;

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B F9 41 0F B6 E8")]
    public partial void OpenRegularDuty(uint contentsFinderCondition, bool hideIfShown = false);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 48 83 C4 20")]
    public partial void OpenRouletteDuty(byte roulette, bool hideIfShown = false);
}

public enum ContentsRouletteRole : byte {
    Tank = 0,
    Healer = 1,
    Dps = 2,
    None = 3,
}

[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public struct Contents {
    [FieldOffset(0x00)] public Utf8String RequiredLevel;
    [FieldOffset(0x68)] public Utf8String Name;
    [FieldOffset(0xD0)] public ContentsId Id;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct ContentsId {
    public enum ContentsType : byte {
        None,
        Roulette, // Id refers to ContentRoulette sheet
        Regular, // Id refers to ContentFinderCondition sheet
    }

    [FieldOffset(0x0)] public ContentsType ContentType;
    [FieldOffset(0x4)] public uint Id;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1470)]
public unsafe partial struct AgentContentsFinderReward {
    [FieldOffset(0x00)] public RewardWrap NormalItems; // Actual items, e.g "Cracked Cluster"
    [FieldOffset(0x1E8), FixedSizeArray] internal FixedSizeArray5<InventoryItem> _unkItems;
    [FieldOffset(0x328)] public RewardWrap BonusItems; // Actual items, e.g "Cracked Cluster"
    [FieldOffset(0x510)] public RewardWrap UnkItemsWrap;

    [FieldOffset(0x700)] public ExcelSheet* ItemSheet;

    [FieldOffset(0x720), FixedSizeArray] internal FixedSizeArray7<ItemWrap> _normalRewards;
    [FieldOffset(0xC60), FixedSizeArray] internal FixedSizeArray5<ItemWrap> _unkRewards;
    [FieldOffset(0x1020), FixedSizeArray] internal FixedSizeArray5<ItemWrap> _bonusRewards; // "In Need" and "Completion Bonus"

    [FieldOffset(0x13E0), FixedSizeArray] internal FixedSizeArray16<Pointer<InventoryItem>> _itemRewards;
    [FieldOffset(0x1468)] public uint ItemRewardCount; // Actual items, not EXP

    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public unsafe partial struct ItemWrap {
        [FieldOffset(0x00)] public InventoryItem Item;
        [FieldOffset(0x40)] public uint IsValid; // 0x0 not valid, 0x2 valid
        [FieldOffset(0x44)] public uint ItemId;
        [FieldOffset(0x48)] public int Quantity;
        [FieldOffset(0x4C)] public uint IconId;
        [FieldOffset(0x50)] public Utf8String String;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
    public unsafe partial struct RewardWrap {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray7<InventoryItem> _items;
        [FieldOffset(0x1C0), FixedSizeArray] internal FixedSizeArray9<int> _rewards;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x7B0)]
public unsafe partial struct AgentContentsFinderInterface {
    [FieldOffset(0x00)] public AgentContentsFinder* AgentContentsFinder;
    [FieldOffset(0x10)] public Utf8String Description;
    [FieldOffset(0x78)] public UnkItemsSub UnkSub;

    [FieldOffset(0x770)] public ExcelSheet* InstanceContentSheet;
    [FieldOffset(0x778)] public ExcelSheet* ContentFinderConditionTransientSheet;
    [FieldOffset(0x780)] public ExcelSheet* InstanceContentRewardItemSheet;
    [FieldOffset(0x788)] public nint ExcelSheetWaiterInstanceContent;
    [FieldOffset(0x790)] public nint ExcelSheetWaiterContentFinderConditionTransient;
    [FieldOffset(0x798)] public nint ExcelSheetWaiterInstanceContentRewardItem;

    [FieldOffset(0x7A0)] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette

    [StructLayout(LayoutKind.Explicit, Size = 0x6F8)]
    public unsafe partial struct UnkItemsSub {
    }
}
