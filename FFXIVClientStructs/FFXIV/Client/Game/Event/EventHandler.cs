using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe struct EventHandler {
	[FieldOffset(0x08)] public StdSet<Pointer<GameObject>> EventObjects;
	[FieldOffset(0x18)] public EventSceneModuleUsualImpl* EventSceneModule;
	[FieldOffset(0x20)] public EventHandlerInfo Info;
	
	[FieldOffset(0xC8)] public Utf8String UnkString0;
	[FieldOffset(0x168)] public Utf8String UnkString1;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public struct EventHandlerInfo {
	[FieldOffset(0x00)] public EventId EventId;
	[FieldOffset(0x04)] public byte Flags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public struct EventId {
	[FieldOffset(0x00)] public uint Id;
	[FieldOffset(0x00)] public ushort EntryId;
	[FieldOffset(0x02)] public EventHandlerType Type;
	public static implicit operator uint(EventId id) => id.Id;
	public static implicit operator EventId(uint id) => new() { Id = id };
}

public enum EventHandlerType : ushort {
	Quest = 0x0001,
	Warp = 0x0002,
	GatheringPoint = 0x0003,
	Shop = 0x0004,
	Aetheryte = 0x0005,
	GuildLeveAssignment = 0x0006,
	DefaultTalk = 0x0009,
	Craft = 0x000A,
	CustomTalk = 0x000B,
	CompanyLeveOfficer = 0x000C,
	Array = 0x000D,
	CraftLeve = 0x000E,
	GimmickAccessor = 0x000F,
	GimmickBill = 0x0010,
	GimmickRect = 0x0011,
	ChocoboTaxiStand = 0x0012,
	Opening = 0x0013,
	ExitRange = 0x0014,
	Fishing = 0x0015,
	GrandCompanyShop = 0x0016,
	GuildOrderGuide = 0x0017,
	GuildOrderOfficer = 0x0018,
	ContentNpc = 0x0019,
	Story = 0x001A,
	SpecialShop = 0x001B,
	ContentTalk = 0x001C,
	InstanceContentGuide = 0x001D,
	HousingAethernet = 0x001E,
	FcTalk = 0x001F,
	Adventure = 0x0021,
	DailyQuestSupply = 0x0022,
	TripleTriad = 0x0023,
	GoldSaucerArcadeMachine = 0x0024,
	LotteryExchangeShop = 0x0034,
	TripleTriadCompetition = 0x0037,

	BattleLeveDirector = 0x8001,
	GatheringLeveDirector = 0x8002,
	InstanceContentDirector = 0x8003,
	PublicContentDirector = 0x8004,
	QuestBattleDirector = 0x8006,
	CompanyLeveDirector = 0x8007,
	TreasureHuntDirector = 0x8009,
	GoldSaucerDirector = 0x800A,
	DpsChallengeDirector = 0x800D,
	FateDirector = 0x801A
}