using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.SatisfactionSupply)]
[StructLayout(LayoutKind.Explicit, Size = 0x500)]
public unsafe partial struct AgentSatisfactionSupply {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x40)] public SatisfactionSupplyNpcInfo NpcInfo;
    [FieldOffset(0x5E)] public ushort ClassJobId;
    [FieldOffset(0x60)] public ushort ClassJobLevel;
    [FieldOffset(0x64)] public uint NpcId;
    [FieldOffset(0x78)] public ushort RemainingAllowances;
    [FieldOffset(0x7A)] public short LevelUnlocked;
    [FieldOffset(0x7C)] public byte CanGlamour;

    [FixedSizeArray<ItemInfo>(3)]
    [FieldOffset(0x80)] public fixed byte Item[0x3C * 3];

    [FieldOffset(0x138)] public void* ENpcResidentRow;
    [FieldOffset(0x140)] public void* Item1Row;
    [FieldOffset(0x148)] public void* Item2Row;
    [FieldOffset(0x150)] public void* Item3Row;

    [FixedSizeArray<AgentDeliveryItemInfo>(3)]
    [FieldOffset(0x158)] public fixed byte DeliveryInfo[0x108 * 3];

    [FieldOffset(0x470)] public void* Item1Reward1Row;
    [FieldOffset(0x478)] public void* Item2Reward1Row;
    [FieldOffset(0x480)] public void* Item3Reward1Row;
    [FieldOffset(0x488)] public void* Item1Reward2Row;
    [FieldOffset(0x490)] public void* Item2Reward2Row;
    [FieldOffset(0x498)] public void* Item3Reward2Row;
    [FieldOffset(0x4A0)] public void* GilRow;
    [FieldOffset(0x4A8)] public void* WhiteCrafterScriptRow;
    [FieldOffset(0x4B0)] public void* PurpleCrafterScriptRow;
    [FieldOffset(0x4B8)] public void* WhiteGathererScriptRow;
    [FieldOffset(0x4C0)] public void* PurpleGathererScriptRow;
    [FieldOffset(0x4C8)] public void* FishingSpotRow;
    [FieldOffset(0x4D0)] public void* SpearFishingNotebookRow;

    [FieldOffset(0x4D8)] public uint WhiteCrafterScrriptId;
    [FieldOffset(0x4DC)] public uint PurpleCrafterScriptId;
    [FieldOffset(0x4E0)] public uint WhiteGathererScriptId;
    [FieldOffset(0x4E4)] public uint PurpleGathererScriptId;
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
