using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentSatisfactionSupply
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.SatisfactionSupply)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x500)]
public unsafe partial struct AgentSatisfactionSupply {

    [FieldOffset(0x40)] public SatisfactionSupplyNpcInfo NpcInfo;
    [FieldOffset(0x5C)] public bool HaveExpRewards;
    [FieldOffset(0x5E)] public ushort ClassJobId;
    [FieldOffset(0x60)] public ushort ClassJobLevel;

    [FieldOffset(0x64)] public SatisfactionSupplyManager.NpcInfo NpcData;

    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray3<ItemInfo> _items;

    [FieldOffset(0x138)] public void* ENpcResidentRow;
    [FieldOffset(0x140)] public void* Item1Row;
    [FieldOffset(0x148)] public void* Item2Row;
    [FieldOffset(0x150)] public void* Item3Row;

    [FieldOffset(0x158), FixedSizeArray] internal FixedSizeArray3<AgentDeliveryItemInfo> _deliveryInfo;

    [FieldOffset(0x470)] public void* Item1Reward1Row;
    [FieldOffset(0x478)] public void* Item2Reward1Row;
    [FieldOffset(0x480)] public void* Item3Reward1Row;
    [FieldOffset(0x488)] public void* Item1Reward2Row;
    [FieldOffset(0x490)] public void* Item2Reward2Row;
    [FieldOffset(0x498)] public void* Item3Reward2Row;
    [FieldOffset(0x4A0)] public void* GilRow;
    [FieldOffset(0x4A8)] public void* CrafterScripRow1;
    [FieldOffset(0x4B0)] public void* CrafterScripRow2;
    [FieldOffset(0x4B8)] public void* GathererScripRow1;
    [FieldOffset(0x4C0)] public void* GathererScripRow2;
    [FieldOffset(0x4C8)] public void* FishingSpotRow;
    [FieldOffset(0x4D0)] public void* SpearfishingNotebookRow;

    [FieldOffset(0x4D8)] public uint CrafterScripId1;
    [FieldOffset(0x4DC)] public uint CrafterScripId2;
    [FieldOffset(0x4E0)] public uint GathererScripId1;
    [FieldOffset(0x4E4)] public uint GathererScripId2;
    [FieldOffset(0x4E8)] public uint TimeRemainingHours;
    [FieldOffset(0x4EC)] public uint TimeRemainingMinutes;

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct SatisfactionSupplyNpcInfo {
        [FieldOffset(0x00)] public uint Id;
        [FieldOffset(0x04)] public uint SatisfactionRank;
        [FieldOffset(0x10)] public bool Valid;
        [FieldOffset(0x11)] public bool Initialized;
        [FieldOffset(0x12)] public bool AddonUpdated;
        [FieldOffset(0x13)] public bool ForceRefresh;
        [FieldOffset(0x14)] public ushort SelectedItemIndex;
        [FieldOffset(0x19)] public byte IsQuestSomething; // TODO: doesn't seem right, 0x18 is used as a dword...
    }

    // TODO: this is likely part of SatisfactionSupplyManager, since it's filled by one of its member functions (assuming agent knows about manager and not vice versa)
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public partial struct ItemInfo {
        [FieldOffset(0x00)] public uint Id;
        [FieldOffset(0x04)] public ushort Collectability1;
        [FieldOffset(0x06)] public ushort Collectability2;
        [FieldOffset(0x08)] public ushort Collectability3;
        [FieldOffset(0x0A)] public bool IsBonus;
        [FieldOffset(0x0C)] public uint Reward1Id;
        [FieldOffset(0x10)] public uint Reward2Id;
        [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray3<ushort> _reward1Quantity; // per quality level
        [FieldOffset(0x1A), FixedSizeArray] internal FixedSizeArray3<ushort> _reward2Quantity; // per quality level
        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray3<ushort> _satisfactionQuantity; // per quality level
        [FieldOffset(0x26), FixedSizeArray] internal FixedSizeArray3<ushort> _gilQuantity; // per quality level
        [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray3<int> _expQuantity; // per quality level

        // These 2 are only set for Fishing items
        [FieldOffset(0x38)] public ushort FishingSpotId;
        [FieldOffset(0x3A)] public ushort SpearFishingSpotId;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct AgentDeliveryItemInfo {
    [FieldOffset(0xA0)] public Utf8String ItemName;
}
