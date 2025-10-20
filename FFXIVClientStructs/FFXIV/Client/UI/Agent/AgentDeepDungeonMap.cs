using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentDeepDungeonMap
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.DeepDungeonMap)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentDeepDungeonMap {
    [FieldOffset(0x28)] public AgentDeepDungeonMapData* Data;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct AgentDeepDungeonMapData {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray25<sbyte> _map;
    [FieldOffset(0x19), FixedSizeArray] internal FixedSizeArray25<sbyte> _roomIndex;
    [FieldOffset(0x32)] public byte RoomIndexCount;
    [FieldOffset(0x33)] public byte DeepDungeonId; // 1 POTD 2 HOH, see DeepDungeon sheet
    [FieldOffset(0x35)] public bool MapLocked;

    [FieldOffset(0x38)] public AgentDeepDungeonMapEffectData EffectDataCurrent;
    [FieldOffset(0xA8)] public AgentDeepDungeonMapEffectData EffectDataNext;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct AgentDeepDungeonMapEffectData {
    [FieldOffset(0x0)] public int EffectId;
    [FieldOffset(0x4)] public uint EffectStatusIcon;
    [FieldOffset(0x8)] public Utf8String EffectName;
}
