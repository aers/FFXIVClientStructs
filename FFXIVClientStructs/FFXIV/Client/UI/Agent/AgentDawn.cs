using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Dawn)]
[GenerateInterop]
[Inherits<AgentDawnInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct AgentDawn {
    [FieldOffset(0x30)] public DawnData* Data;

    [MemberFunction("40 56 48 83 EC 70 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 8B F1 E8")]
    public partial void RegisterForDuty();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B CE E8 ?? ?? ?? ?? 49 8B CE E8 ?? ?? ?? ?? C6 46 ?? 00 E9 ?? ?? ?? ?? 48 8D 4F ?? E8 ?? ?? ?? ?? 49 8B 4E")]
    public partial void SelectContentEntry(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 80 FB 01 75 ?? 41 C6 46 ?? 00 49 8B CE")]
    public partial void SetupDefaultParty();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 46 ?? FE 00")]
    public partial void UpdateAddon();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x658B8)]
    public partial struct DawnData {
        [FieldOffset(0x08)] public AgentDawnInterface.DawnContentData ContentData;
        [FieldOffset(0x4DF8)] public AgentDawnInterface.DawnMemberData MemberData;
        [FieldOffset(0x648A0)] public AgentDawnInterface.DawnPartyData PartyData;

        [FieldOffset(0x648B0), FixedSizeArray] internal FixedSizeArray256<AtkValue> _atkValues;

        [FieldOffset(0x658B0)] public uint ModalAddonId;
        [FieldOffset(0x658B4)] public uint Flags;
    }
}
