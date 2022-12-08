using System.Runtime.CompilerServices;
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
public unsafe struct DeepDungeonStatusData {
	[FieldOffset(0x00)] public uint Level;
	[FieldOffset(0x04)] public uint MaxLevel;
	[FieldOffset(0x08)] public uint ClassJobId;

	[FieldOffset(0x18)] public fixed byte Pomander[16 * 0x70]; // 16 * DeepDungeonStatusItem
	[FieldOffset(0x718)] public fixed byte Magicite[4 * 0x70]; // 4 * DeepDungeonStatusItem

	public Span<DeepDungeonStatusItem> PomanderSpan => new(Unsafe.AsPointer(ref Pomander[0]), 16);
	public Span<DeepDungeonStatusItem> MagiciteSpan => new(Unsafe.AsPointer(ref Magicite[0]), 4);
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public struct DeepDungeonStatusItem {
	[FieldOffset(0x00)] public uint ItemId; // DeepDungeonItem for Pomander, DeepDungeonMagicStone for Magicite
	[FieldOffset(0x04)] public uint Icon;
	[FieldOffset(0x08)] public Utf8String Name;
}