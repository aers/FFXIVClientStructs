using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DeepDungeonStatus)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentDeepDungeonStatus {
    [FieldOffset(0x28)] public DeepDungeonStatusData* Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8D8)]
[GenerateInterop]
public unsafe partial struct DeepDungeonStatusData {
    [FieldOffset(0x00)] public uint Level;
    [FieldOffset(0x04)] public uint MaxLevel;
    [FieldOffset(0x08)] public uint ClassJobId;

    [FieldOffset(0x18)][FixedSizeArray] internal FixedSizeArray16<DeepDungeonStatusItem> _pomander;
    [FieldOffset(0x718)][FixedSizeArray] internal FixedSizeArray4<DeepDungeonStatusItem> _magicite;
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public struct DeepDungeonStatusItem {
    [FieldOffset(0x00)] public uint ItemId; // DeepDungeonItem for Pomander, DeepDungeonMagicStone for Magicite
    [FieldOffset(0x04)] public uint Icon;
    [FieldOffset(0x08)] public Utf8String Name;
}
