using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::QuestEventHandler
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x618)]
public unsafe partial struct QuestEventHandler {
    [FieldOffset(0x340)] public ushort QuestId;
    [FieldOffset(0x348)] public Utf8String Title;
    [FieldOffset(0x3B0)] public Utf8String ScriptId;
    [FieldOffset(0x418)] public Utf8String ScriptPath;
    [FieldOffset(0x480)] public byte PreviousQuestJoin;
    [FieldOffset(0x482), FixedSizeArray] internal FixedSizeArray3<ushort> _previousQuests;
    // 0x488: unknown column
    [FieldOffset(0x489)] public byte QuestLockJoin;
    [FieldOffset(0x48A), FixedSizeArray] internal FixedSizeArray2<ushort> _questLocks;

    [FieldOffset(0x4C4)] public byte InstanceContentJoin;
    [FieldOffset(0x4C8), FixedSizeArray] internal FixedSizeArray3<uint> _instanceContents;
    [FieldOffset(0x4D4)] public ushort Festival;
    [FieldOffset(0x4D6)] public ushort FestivalBegin;
    [FieldOffset(0x4D8)] public ushort FestivalEnd;
    [FieldOffset(0x4DA)] public byte RepeatIntervalType;
    [FieldOffset(0x4DB)] public byte QuestRepeatFlag;
    [FieldOffset(0x4DC)] public ushort BellStart;
    [FieldOffset(0x4DE)] public ushort BellEnd;
    [FieldOffset(0x4E0)] public byte BeastTribeId;
    [FieldOffset(0x4E1)] public byte BeastTribeRank;
    [FieldOffset(0x4E2)] public ushort BeastReputationValue;
    [FieldOffset(0x4E4)] public ushort MountRequired;
    [FieldOffset(0x4E6)] public byte SatisfactionNpc;
    [FieldOffset(0x4E7)] public byte SatisfactionLevel;
    [FieldOffset(0x4E8)] public uint IssuerStart;
    [FieldOffset(0x4EC)] public uint TargetEnd;
    [FieldOffset(0x4F0)] public uint JournalGenre;
    [FieldOffset(0x4F4)] public uint IconSpecial;
    [FieldOffset(0x4F8)] public byte DailyQuestPool;


    [MemberFunction("E8 ?? ?? ?? ?? 8B 75 D0 44 3B EE")]
    public partial void GetTodoArgs(BattleChara* localPlayer, byte idx, uint* arg0, uint* arg1, uint* arg2);

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 07 45 33 D2")]
    public partial bool IsTodoChecked(BattleChara* localPlayer, byte idx);
}
