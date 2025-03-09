using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DawnStory)]
[GenerateInterop]
[Inherits<AgentDawnInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentDawnStory {
    [FieldOffset(0x30)] public DawnStoryData* Data;

    [MemberFunction("40 57 48 83 EC 30 48 8B 05 ?? ?? ?? ?? 48 33 C4")]
    public partial void RegisterForDuty();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B CE E8 ?? ?? ?? ?? 49 8B CE E8 ?? ?? ?? ?? C6 46 ?? 00 E9 ?? ?? ?? ?? 48 8D 4F ?? E8 ?? ?? ?? ?? 0F B6 D0")]
    public partial void SelectContentEntry(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6C 24 ?? 40 80 FE 01")]
    public partial void SetupDefaultParty();

    [MemberFunction("E8 ?? ?? ?? ?? C6 46 ?? 00 E9 ?? ?? ?? ?? 32 C9")]
    public partial void UpdateAddon();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x670C0)]
    public partial struct DawnStoryData {
        [FieldOffset(0x08)] public AgentDawnInterface.DawnContentData ContentData;
        [FieldOffset(0x4DF8)] public AgentDawnInterface.DawnMemberData MemberData;
        [FieldOffset(0x648A0)] public AgentDawnInterface.DawnPartyData PartyData;

        [FieldOffset(0x648B0)] public uint RewardItemCount;
        [FieldOffset(0x648B8), FixedSizeArray] internal FixedSizeArray2<DawnRewardItemEntry> _rewardItems;
        [FieldOffset(0x649A8), FixedSizeArray] internal FixedSizeArray489<AtkValue> _atkValues;

        [FieldOffset(0x66838)] public uint ModalAddonId;
        [FieldOffset(0x6683C)] public uint Flags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public struct DawnRewardItemEntry {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint IconId;
        [FieldOffset(0x08)] public uint Amount;
        [FieldOffset(0x10)] public Utf8String Name;
    }
}
