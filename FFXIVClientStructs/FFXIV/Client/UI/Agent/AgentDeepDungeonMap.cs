using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DeepDungeonMap)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentDeepDungeonMap {
    [FieldOffset(0x28)] public AgentDeepDungeonMapData* Data;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x36)]
public unsafe partial struct AgentDeepDungeonMapData {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray25<sbyte> _map;
    [FieldOffset(0x19), FixedSizeArray] internal FixedSizeArray25<sbyte> _roomIndex;
    [FieldOffset(0x32)] public byte RoomIndexCount;
    [FieldOffset(0x33)] public byte DeepDungeonId; // 1 POTD 2 HOH, see DeepDungeon sheet
    [FieldOffset(0x35)] public bool MapLocked;
}
