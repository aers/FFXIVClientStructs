using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[Agent(AgentId.DeepDungeonStatus)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AgentDeepDungeonStatus {
	[FieldOffset(0x00)] public AgentInterface AgentInterface;
	[FieldOffset(0x28)] public DeepDungeonStatusData* Data;

	public static AgentDeepDungeonStatus* Instance() {
		return Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentDeepDungeonStatus();
	}
}

[StructLayout(LayoutKind.Explicit, Size = 0x8D8)]
public unsafe partial struct DeepDungeonStatusData {
	[FieldOffset(0x00)] public uint Level;
	[FieldOffset(0x04)] public uint MaxLevel;
	[FieldOffset(0x08)] public uint ClassJobId;

	[FixedSizeArray<DeepDungeonStatusItem>(16)]
	[FieldOffset(0x18)] public fixed byte Pomander[16 * 0x70]; // 16 * DeepDungeonStatusItem
	[FixedSizeArray<DeepDungeonStatusItem>(4)]
	[FieldOffset(0x718)] public fixed byte Magicite[4 * 0x70]; // 4 * DeepDungeonStatusItem
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public struct DeepDungeonStatusItem {
	[FieldOffset(0x00)] public uint ItemId; // DeepDungeonItem for Pomander, DeepDungeonMagicStone for Magicite
	[FieldOffset(0x04)] public uint Icon;
	[FieldOffset(0x08)] public Utf8String Name;
}