using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.LeveQuest)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public partial struct AgentLeveQuest {
    [FieldOffset(0x30)] public StdVector<QuestRewardItem> RewardItems;
    [FieldOffset(0x4C)] public int ContextMenuSelectedRewardIndex;
    [FieldOffset(0x50)] public uint LeveRowId;
    [FieldOffset(0x58)] public Utf8String LeveQuestName;
}

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct QuestRewardItem {
    [FieldOffset(0xC)] public uint ItemId;
    [FieldOffset(0x10)] public int Amount;
    [FieldOffset(0x14)] public byte Stain0Id;
}
