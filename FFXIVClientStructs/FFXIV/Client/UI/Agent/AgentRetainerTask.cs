using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRetainerTask
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.RetainerTask)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentRetainerTask {
    // 00 - None
    // 01 - Request Assignment
    // 02 - Venture in Progress
    // 03 - Completed Venture
    [FieldOffset(0x28)] public uint DisplayType;

    [FieldOffset(0x30)] public AtkModuleInterface.AtkEventInterface* EventInterface;

    [FieldOffset(0x38)] public uint OpenerAddonId;

    [FieldOffset(0x40)] public Data RetainerData;

    // Set when venture is complete
    [FieldOffset(0x44), Obsolete("Use RetainerData.RewardXP")] public uint RewardXP;

    // Set when venture is complete
    [FieldOffset(0x50), FixedSizeArray, Obsolete("Use RetainerData.RewardItemIds")] internal FixedSizeArray2<uint> _rewardItemIds;

    // Set when venture is complete
    [FieldOffset(0x58), FixedSizeArray, Obsolete("Use RetainerData.RewardItemCount")] internal FixedSizeArray2<uint> _rewardItemCount;

    [FieldOffset(0x6C)] public uint RetainerTaskLvRange;

    [FieldOffset(0x74)] public uint RetainerTaskId;

    [FieldOffset(0x7C)] public uint EntityId;

    [FieldOffset(0x80)] public bool IsLoading;

    // Set when venture in progress
    [FieldOffset(0x84)] public uint XPToReward;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct Data {
        [FieldOffset(0x0)] public ushort RewardRetainerTaskId;
        [FieldOffset(0x4)] public uint RewardXP;
        [FieldOffset(0x8)] private uint Unk8;
        [FieldOffset(0xC)] private byte RewardItemCount2;
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray2<uint> _rewardItemIds;
        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray2<uint> _rewardItemCount;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 9B ?? ?? ?? ?? 48 8B CF 48 8B 17 FF 52 48 89 83 ?? ?? ?? ?? 33 D2 48 8D 4D A0")]
    public partial void OpenRetainerTaskResult(AtkModuleInterface.AtkEventInterface* eventInterface, Data* resultData);
}
