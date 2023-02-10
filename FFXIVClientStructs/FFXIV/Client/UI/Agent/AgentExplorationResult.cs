using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct AgentAirshipExplorationResult {
	[FieldOffset(0x00)] public AgentExplorationResultInterface Interface;

	public static AgentAirshipExplorationResult* Instance() => (AgentAirshipExplorationResult*)AgentModule.Instance()->GetAgentByInternalId(AgentId.AirShipExplorationResult);
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct AgentSubmersibleExplorationResult {
	[FieldOffset(0x00)] public AgentExplorationResultInterface Interface;

	public static AgentSubmersibleExplorationResult* Instance() => (AgentSubmersibleExplorationResult*)AgentModule.Instance()->GetAgentByInternalId(AgentId.SubmersibleExplorationResult);
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct AgentExplorationResultInterface {
	[FieldOffset(0x00)] public AgentInterface AgentInterface;
	[FieldOffset(0x28)] public uint ItemId; // fuel tank or something
	[FieldOffset(0x30)] public ExplorationResultData* Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x3CB0)]
public unsafe partial struct ExplorationResultData {
	[FixedSizeArray<AtkValue>(151)]
	[FieldOffset(0x00)] public fixed byte ValueArray[0x10 * 151];

	[FieldOffset(0x988)] public Utf8String Rating;

	[FixedSizeArray<Utf8String>(100)]
	[FieldOffset(0x10E8)] public fixed byte StringArray[0x68 * 100];
}