using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel.Sheets;

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
    [FieldOffset(0x5E)] public ushort ClassJobId;
    [FieldOffset(0x60)] public ushort ClassJobLevel;
    [FieldOffset(0x64)] public uint NpcId;
    [FieldOffset(0x78)] public ushort RemainingAllowances;
    [FieldOffset(0x7A)] public short LevelUnlocked;
    [FieldOffset(0x7C)] public byte CanGlamour;

    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray3<ItemInfo> _items;

    [FieldOffset(0x138)] public ENpcResident* ENpcResidentRow;
    [FieldOffset(0x140)] public Item* Item1Row;
    [FieldOffset(0x148)] public Item* Item2Row;
    [FieldOffset(0x150)] public Item* Item3Row;

    [FieldOffset(0x158), FixedSizeArray] internal FixedSizeArray3<AgentDeliveryItemInfo> _deliveryInfo;

    [FieldOffset(0x470)] public Item* Item1Reward1Row;
    [FieldOffset(0x478)] public Item* Item2Reward1Row;
    [FieldOffset(0x480)] public Item* Item3Reward1Row;
    [FieldOffset(0x488)] public Item* Item1Reward2Row;
    [FieldOffset(0x490)] public Item* Item2Reward2Row;
    [FieldOffset(0x498)] public Item* Item3Reward2Row;
    [FieldOffset(0x4A0)] public Item* GilRow;
    [FieldOffset(0x4A8)] public Item* CrafterScripRow1;
    [FieldOffset(0x4B0)] public Item* CrafterScripRow2;
    [FieldOffset(0x4B8)] public Item* GathererScripRow1;
    [FieldOffset(0x4C0)] public Item* GathererScripRow2;
    [FieldOffset(0x4C8)] public FishingSpot* FishingSpotRow;
    [FieldOffset(0x4D0)] public SpearfishingNotebook* SpearfishingNotebookRow;

    [FieldOffset(0x4D8)] public uint CrafterScripId1;
    [FieldOffset(0x4DC)] public uint CrafterScripId2;
    [FieldOffset(0x4E0)] public uint GathererScripId1;
    [FieldOffset(0x4E4)] public uint GathererScripId2;
    [FieldOffset(0x4E8)] public uint TimeRemainingHours;
    [FieldOffset(0x4EC)] public uint TimeRemainingMinutes;

    [StructLayout(LayoutKind.Explicit, Size = 0x1A)]
    public struct SatisfactionSupplyNpcInfo {
        [FieldOffset(0x00)] public uint Id;
        [FieldOffset(0x04)] public uint SatisfactionRank;
        [FieldOffset(0x14)] public ushort SelectedItemIndex;
        [FieldOffset(0x19)] public byte IsQuestSomething;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public struct ItemInfo {
        [FieldOffset(0x00)] public uint Id;
        [FieldOffset(0x04)] public ushort Collectability1;
        [FieldOffset(0x06)] public ushort Collectability2;
        [FieldOffset(0x08)] public ushort Collectability3;
        [FieldOffset(0x0A)] public ushort Bonus;
        [FieldOffset(0x0C)] public uint Reward1Id;
        [FieldOffset(0x10)] public uint Reward2Id;

        // These 2 are only set for Fishing items
        [FieldOffset(0x38)] public ushort FishingSpotId;
        [FieldOffset(0x3A)] public ushort SpearFishingSpotId;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct AgentDeliveryItemInfo {
    [FieldOffset(0xA0)] public Utf8String ItemName;
}
