using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[Agent(AgentId.AozContentBriefing)]
[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
public unsafe struct AgentAozContentBriefing {
	[FieldOffset(0x00)] public AgentInterface AgentInterface;
	[FieldOffset(0x28)] public AozContentData* AozContentData;
	[FieldOffset(0x30)] public Utf8String WeeklyNoviceTitle;
	[FieldOffset(0x98)] public Utf8String WeeklyModerateTitle;
	[FieldOffset(0x100)] public Utf8String WeeklyAdvancedTitle;
	[FieldOffset(0x168)] public AozWeeklyFlags WeeklyCompletion;
	[FieldOffset(0x169)] public fixed byte WeeklyAozContentId[3];
	[FieldOffset(0x16C)] public fixed byte NoviceRequirement[3];
	[FieldOffset(0x16F)] public fixed byte ModerateRequirement[3];
	[FieldOffset(0x172)] public fixed byte AdvancedRequirement[3];
	[FieldOffset(0x175)] private fixed byte _UnkBytes[3];
	[FieldOffset(0x178)] public byte* NoviceRequirements;
	[FieldOffset(0x180)] public byte* ModerateRequirements;
	[FieldOffset(0x188)] public byte* AdvancedRequirements;
	[FieldOffset(0x190)] private byte _UnkFlags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe struct AozContentData {
	[FieldOffset(0x04)] private int _UnkLoadState;
	[FieldOffset(0x0C)] public int SelectedContentIndex;
	[FieldOffset(0x10)] public int MaxContentEntries;

	[FieldOffset(0x40)] public int CurrentContentIndex;
	[FieldOffset(0x44)] private uint _UnkState;
	[FieldOffset(0x48)] public byte CurrentActIndex;
	[FieldOffset(0x49)] public byte CurrentEnemyIndex;
	
	[FieldOffset(0x4A)] public fixed byte Arrangements[3 * 0x7A]; // 3 * AozArrangementData
	[FieldOffset(0x4A)] public AozArrangementData Act1Arrangement;
	[FieldOffset(0xC4)] public AozArrangementData Act2Arrangement;
	[FieldOffset(0x13E)] public AozArrangementData Act3Arrangement;

	[FieldOffset(0x228)] public Utf8String NoviceString;
	[FieldOffset(0x290)] public Utf8String ModerateString;
	[FieldOffset(0x2F8)] public Utf8String AdvancedString;
	
	[FieldOffset(0x360)] public fixed byte WeeklyRewards[3 * 0x8]; // 3 * AozContentRewards
	[FieldOffset(0x360)] public AozWeeklyReward NoviceRewards;
	[FieldOffset(0x368)] public AozWeeklyReward ModerateRewards;
	[FieldOffset(0x370)] public AozWeeklyReward AdvancedRewards;

	[FieldOffset(0x37C)] private float _UnkFloat;
}

[StructLayout(LayoutKind.Explicit, Size = 0x7A)]
public unsafe struct AozArrangementData {
	[FieldOffset(0x01)] public byte Count;
	[FieldOffset(0x02)] public fixed ushort Enemies[30];
	[FieldOffset(0x3E)] public fixed ushort Positions[30];
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct AozWeeklyReward {
	[FieldOffset(0x00)] public ushort Gil;
	[FieldOffset(0x02)] public ushort Seals;
	[FieldOffset(0x04)] public ushort Tomes;
}

[Flags]
public enum AozWeeklyFlags : byte {
	None = 0,
	Unknown = 1,
	Novice = 2,
	Moderate = 4,
	Advanced = 8
}