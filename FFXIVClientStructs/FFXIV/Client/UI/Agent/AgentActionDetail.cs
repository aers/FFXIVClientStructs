using FFXIVClientStructs.FFXIV.Client.Enums;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentActionDetail
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ActionDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 01 8B FA 48 8B D9 74 ?? 0F B6 41", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AgentActionDetail {
    [FieldOffset(0x28)] public NumberArrayData* NumberArray; // NumberArrayType.ActionDetail
    [FieldOffset(0x30)] public StringArrayData* StringArray; // StringArrayType.ActionDetail
    [FieldOffset(0x38)] public DetailKind ActionKind;
    [FieldOffset(0x3C)] public uint ActionId;
    [FieldOffset(0x40)] public uint OriginalId; // Example: Summon Topaz
    [FieldOffset(0x44)] public uint AdjustedId; // Example: Summon Titan II
    [FieldOffset(0x48)] private uint Unk48;
    [FieldOffset(0x4C)] private uint Unk4C;
    [FieldOffset(0x50)] private int Unk50;
    [FieldOffset(0x54)] private uint Unk54;
    [FieldOffset(0x58)] private int Unk58;
    [FieldOffset(0x5C)] private int Unk5C;
    [FieldOffset(0x60)] private int Unk60;
    [FieldOffset(0x64)] private bool Unk64;
    [FieldOffset(0x65)] public bool IsLovmActionDetail;
    [FieldOffset(0x66)] private byte Unk66;
    [FieldOffset(0x67)] private byte Unk67;

    // flag & 1 = get AdjustedActionId
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 F8 0F")]
    public partial void HandleActionHover(DetailKind actionKind, uint actionId, int flag, bool isLovmActionDetail, int a5, int a6);
}
