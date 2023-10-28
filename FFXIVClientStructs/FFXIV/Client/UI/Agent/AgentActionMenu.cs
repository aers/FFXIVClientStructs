using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ActionMenu)]
[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe partial struct AgentActionMenu {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x30)] public uint JobIconId;
    [FieldOffset(0x34)] public uint Level;
    [FieldOffset(0x38)] public uint JobId;
    [FieldOffset(0x3C)] public uint ClassId;
    [FieldOffset(0x40)] public uint ClassJobCategoryId;
    [FieldOffset(0x44)] public bool JobStoneEquipped;

    [FieldOffset(0x54)] public int Flags;

    [FieldOffset(0x5C)] public bool CompactView;

    [FieldOffset(0x60)] public uint OpenUpgradeActionId;

    [FieldOffset(0x68)] public StdVector<ActionData> ClassActionList;
    [FieldOffset(0x80)] public StdVector<ActionData> JobActionList;
    [FieldOffset(0x98)] public StdVector<ActionData> TraitList;
    [FieldOffset(0xB0)] public StdVector<ActionData> GeneralList;
    [FieldOffset(0xC8)] public StdVector<ActionData> CompanionOrderList;
    [FieldOffset(0xE0)] public StdVector<ActionData> SquadronOrderList;
    [FieldOffset(0xF8)] public StdVector<ActionData> MainCommandList;
    [FieldOffset(0x110)] public StdVector<ActionData> PetActionList;
    [FieldOffset(0x128)] public StdVector<ActionData> PetOrderList;
    [FieldOffset(0x140)] public StdVector<ActionData> PerformanceList;
    [FieldOffset(0x158)] public StdVector<ActionData> ExtraList;
    [FieldOffset(0x170)] public StdVector<ActionData> CombatRoleActionList;
    [FieldOffset(0x188)] public StdVector<ActionData> GatheringRoleActionList;

    [FieldOffset(0x1E0)] public Utf8String ClassJobTitle;
    //[FieldOffset(0x248)] public Utf8String UnkString248;

    [FieldOffset(0x2B8)] public StdVector<ExtraCommandData> ExtraCommandData;
    [FieldOffset(0x2D0)] public void* ExtraCommandExcelSheet;
    [FieldOffset(0x2E0)] public uint UpgradeAddonId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public struct ActionData {
    [FieldOffset(0x00)] public Utf8String DisplayString;
    [FieldOffset(0x68)] public uint ActionId;
    [FieldOffset(0x6C)] public uint UnkValue0;
    [FieldOffset(0x70)] public uint ActionCategoryId;
    [FieldOffset(0x74)] public uint IconId;
    [FieldOffset(0x78)] public uint Level; // or flags?
    [FieldOffset(0x81)] public bool IsSlotable;
}

[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public struct ExtraCommandData {
    [FieldOffset(0x08)] public Utf8String Name;
    [FieldOffset(0x70)] public Utf8String Description;
}
