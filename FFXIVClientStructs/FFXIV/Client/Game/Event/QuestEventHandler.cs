using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::QuestEventHandler
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x610)]
public unsafe partial struct QuestEventHandler {
    [FieldOffset(0x338)] public ushort QuestId;
    [FieldOffset(0x340)] public Utf8String Title;
    [FieldOffset(0x3A8)] public Utf8String ScriptId;
    [FieldOffset(0x410)] public Utf8String ScriptPath;
    [FieldOffset(0x478)] public byte PreviousQuestJoin;
    [FieldOffset(0x47A), FixedSizeArray] internal FixedSizeArray3<ushort> _previousQuests;
    // 0x480: unknown column
    [FieldOffset(0x481)] public byte QuestLockJoin;
    [FieldOffset(0x482), FixedSizeArray] internal FixedSizeArray2<ushort> _questLocks;

    [FieldOffset(0x4BC)] public byte InstanceContentJoin;
    [FieldOffset(0x4C0), FixedSizeArray] internal FixedSizeArray3<uint> _instanceContents;
    [FieldOffset(0x4CC)] public ushort Festival;
    [FieldOffset(0x4CE)] public ushort FestivalBegin;
    [FieldOffset(0x4D0)] public ushort FestivalEnd;
    [FieldOffset(0x4D2)] public byte RepeatIntervalType;
    [FieldOffset(0x4D3)] public byte QuestRepeatFlag;
    [FieldOffset(0x4D4)] public ushort BellStart;
    [FieldOffset(0x4D6)] public ushort BellEnd;
    [FieldOffset(0x4D8)] public byte BeastTribeId;
    [FieldOffset(0x4D9)] public byte BeastTribeRank;
    [FieldOffset(0x4DA)] public ushort BeastReputationValue;
    [FieldOffset(0x4DC)] public ushort MountRequired;
    [FieldOffset(0x4DE)] public byte SatisfactionNpc;
    [FieldOffset(0x4DF)] public byte SatisfactionLevel;
    [FieldOffset(0x4E0)] public uint IssuerStart;
    [FieldOffset(0x4E4)] public uint TargetEnd;
    [FieldOffset(0x4E8)] public uint JournalGenre;
    [FieldOffset(0x4EC)] public uint IconSpecial;
    [FieldOffset(0x4F0)] public byte DailyQuestPool;


    [MemberFunction("E8 ?? ?? ?? ?? 8B 75 D0")]
    public partial void GetTodoArgs(BattleChara* localPlayer, byte idx, uint* arg0, uint* arg1, uint* arg2);

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 07 45 33 D2")]
    public partial bool IsTodoChecked(BattleChara* localPlayer, byte idx);
}
