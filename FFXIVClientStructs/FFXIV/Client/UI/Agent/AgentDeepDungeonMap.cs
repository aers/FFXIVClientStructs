using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DeepDungeonMap)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentDeepDungeonMap {
    [FieldOffset(0x28)] public AgentDeepDungeonMapData* Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x36)]
[GenerateInterop]
public unsafe partial struct AgentDeepDungeonMapData {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray25<sbyte> _maps;
    [FieldOffset(0x19), FixedSizeArray] internal FixedSizeArray25<sbyte> _roomIndexes;
    [FieldOffset(0x32)] public byte RoomIndexCount;
    [FieldOffset(0x33)] public byte DeepDungeonId; // 1 POTD 2 HOH, see DeepDungeon sheet
    [FieldOffset(0x34)] public byte Unk_34;
    [FieldOffset(0x35)] public bool MapLocked;
}
