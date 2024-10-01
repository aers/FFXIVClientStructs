namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[GenerateInterop(isInherited: true)]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentExplorationInterface {
}


[Agent(AgentId.SubmersibleExploration)]
[GenerateInterop]
[Inherits<AgentExplorationInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public partial struct AgentSubmersibleExploration {
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray5<byte> _selectedPoints;
    [FieldOffset(0x55)] public byte SelectedPointsCount;

    [FieldOffset(0x5C)] public uint VoyageDistance;
    [FieldOffset(0x60)] public uint CeruleumTanks;

    [FieldOffset(0x64)] public uint Exp;
    [FieldOffset(0x68)] public uint CeruleumTanksInInventory;
    [FieldOffset(0x6C)] public uint VoyageDistanceMax;

    [FieldOffset(0x78)] public uint StartingPointId;
    [FieldOffset(0x80)] public uint MapImageId;
    [FieldOffset(0x84)] public byte MapId;

}
