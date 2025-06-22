using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ContentsFinder)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x2450)]
public unsafe partial struct AgentContentsFinder {
    [FieldOffset(0x28)] public AgentContentsFinderInterface InterfaceSub;

    [FieldOffset(0x8A8)] public AgentContentsFinderReward RewardSub;

    // Offset can be found with "48 8D BE ? ? ? ? 48 85 DB"
    [FieldOffset(0x1E70)] public RewardContextMenuEventHandler RewardContextMenuHandler;

    [FieldOffset(0x1E98)] public StdVector<Pointer<Contents>> ContentList;
    [FieldOffset(0x1EB0)] public StdVector<ContentsId> SelectedContent;
    [FieldOffset(0x1EC8)] public ContentsId SelectedDuty;
    [FieldOffset(0x1ECC), Obsolete("Use SelectedDuty.Id instead")] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette
    [FieldOffset(0x1ED8)] public byte NumCollectedRewards; // Value used for "Reward already received"
    // TODO: change to bool
    [FieldOffset(0x1ED9)] public byte HasRouletteSelected; // Prevents more roulettes from being selected

    // TODO: this is part of an event interface class
    [FieldOffset(0x1F18)] public UIModule* UIModule;

    [FieldOffset(0x1F28), FixedSizeArray] internal FixedSizeArray10<Utf8String> _strings; // Tooltips and Category headers, ie "Gil", "Trials (Endwalker)"

    [FieldOffset(0x2391), FixedSizeArray] internal FixedSizeArray11<ContentsRouletteRole> _contentRouletteRoleBonuses;

    [FieldOffset(0x239C)] public uint DutyPenaltyMinutes;
    [FieldOffset(0x23A0)] public uint UnkPenaltyMinutes;

    [FieldOffset(0x23D4)] public int CurrentTimestamp;

    [FieldOffset(0x23DC)] public int RecruitingParties;
    [FieldOffset(0x23E0)] public byte SelectedTab;

    [FieldOffset(0x23E8)] private bool TabChanged;
    [FieldOffset(0x23E9)] public bool ListChanged;
    [FieldOffset(0x23EA)] private bool DetailsChanged;

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B F9 41 0F B6 E8")]
    public partial void OpenRegularDuty(uint contentsFinderCondition, bool hideIfShown = false);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 48 83 C4 20")]
    public partial void OpenRouletteDuty(byte roulette, bool hideIfShown = false);

    [MemberFunction("40 53 48 83 EC ?? 48 8B 01 48 8B D9 FF 50 ?? 84 C0 74 ?? 48 8B CB C6 83")]
    public partial void Refresh();

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 06 48 8B CE 48 81 C4")]
    public partial void UpdateAddon();

    [GenerateInterop]
    [Inherits<AtkModuleInterface.AtkEventInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct RewardContextMenuEventHandler {
        [FieldOffset(0x10)] public uint AddonId;
        [FieldOffset(0x18)] public AgentContentsFinderReward.ItemWrap* SelectedReward;
    }
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
[StructLayout(LayoutKind.Explicit, Size = 0x15C8)]
public unsafe partial struct AgentContentsFinderReward {
    [FieldOffset(0x00)] public RewardWrap NormalItems; // Actual items, e.g "Cracked Cluster"
    [FieldOffset(0x220), FixedSizeArray] internal FixedSizeArray5<InventoryItem> _unkItems;
    [FieldOffset(0x388)] public RewardWrap BonusItems; // Actual items, e.g "Cracked Cluster"
    [FieldOffset(0x5A8)] public RewardWrap UnkItemsWrap;

    [FieldOffset(0x7D0)] public ExcelSheet* ItemSheet;

    [FieldOffset(0x7F0), FixedSizeArray] internal FixedSizeArray7<ItemWrap> _normalRewards;
    [FieldOffset(0xD68), FixedSizeArray] internal FixedSizeArray5<ItemWrap> _unkRewards;
    [FieldOffset(0x1150), FixedSizeArray] internal FixedSizeArray5<ItemWrap> _bonusRewards; // "In Need" and "Completion Bonus"

    [FieldOffset(0x1538), FixedSizeArray] internal FixedSizeArray16<Pointer<InventoryItem>> _itemRewards;
    [FieldOffset(0x15C0)] public uint ItemRewardCount; // Actual items, not EXP

    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public unsafe partial struct ItemWrap {
        [FieldOffset(0x00)] public InventoryItem Item;
        [FieldOffset(0x48)] public uint IsValid; // 0x0 not valid, 0x2 valid
        [FieldOffset(0x4C)] public uint ItemId;
        [FieldOffset(0x50)] public int Quantity;
        [FieldOffset(0x54)] public uint IconId;
        [FieldOffset(0x58)] public Utf8String String;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x220)]
    public unsafe partial struct RewardWrap {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray7<InventoryItem> _items;
        [FieldOffset(0x1F8), FixedSizeArray] internal FixedSizeArray9<int> _rewards;
        [FieldOffset(0x21C)] private byte Unk21C; // 7.1
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x880)]
public unsafe partial struct AgentContentsFinderInterface {
    [FieldOffset(0x00)] public AgentContentsFinder* AgentContentsFinder;
    [FieldOffset(0x10)] public Utf8String Description;
    [FieldOffset(0x78)] public UnkItemsSub UnkSub;

    [FieldOffset(0x840)] public ExcelSheet* InstanceContentSheet;
    [FieldOffset(0x848)] public ExcelSheet* ContentFinderConditionTransientSheet;
    [FieldOffset(0x850)] public ExcelSheet* InstanceContentRewardItemSheet;
    [FieldOffset(0x858)] public nint ExcelSheetWaiterInstanceContent;
    [FieldOffset(0x860)] public nint ExcelSheetWaiterContentFinderConditionTransient;
    [FieldOffset(0x868)] public nint ExcelSheetWaiterInstanceContentRewardItem;

    [FieldOffset(0x870)] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette

    [StructLayout(LayoutKind.Explicit, Size = 0x7C8)]
    public unsafe partial struct UnkItemsSub {
    }
}
