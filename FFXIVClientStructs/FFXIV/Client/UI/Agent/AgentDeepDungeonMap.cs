using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[Agent(AgentId.DeepDungeonMap)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AgentDeepDungeonMap {
	[FieldOffset(0x00)] public AgentInterface AgentInterface;
	[FieldOffset(0x28)] public AgentDeepDungeonMapData* Data;

	public static AgentDeepDungeonMap* Instance() {
		return Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentDeepDungeonMap();
	}
}

[StructLayout(LayoutKind.Explicit, Size = 0x36)]
public unsafe struct AgentDeepDungeonMapData {
	[FieldOffset(0x00)] public fixed sbyte MapArray[25];
	[FieldOffset(0x19)] public fixed sbyte RoomIndexArray[25];
	[FieldOffset(0x32)] public byte RoomIndexCount;
	[FieldOffset(0x33)] public byte DeepDungeonId; // 1 POTD 2 HOH, see DeepDungeon sheet
	[FieldOffset(0x34)] public byte Unk_34;
	[FieldOffset(0x35)] public bool MapLocked;

	public Span<sbyte> MapSpan => new(Unsafe.AsPointer(ref MapArray[0]), 25);
	public Span<sbyte> IndexSpan => new(Unsafe.AsPointer(ref RoomIndexArray[0]), RoomIndexCount);
}