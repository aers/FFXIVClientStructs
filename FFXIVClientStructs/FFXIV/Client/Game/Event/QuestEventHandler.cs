using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::QuestEventHandler
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x5C0)]
public unsafe partial struct QuestEventHandler {
    [FieldOffset(0x2E0)] public ushort QuestId;
    [FieldOffset(0x2E8)] public Utf8String Title;
    [FieldOffset(0x350)] public Utf8String ScriptId;
    [FieldOffset(0x3B8)] public Utf8String ScriptPath;
    [FieldOffset(0x420)] public byte PreviousQuestJoin;
    [FieldOffset(0x422), FixedSizeArray] internal FixedSizeArray3<ushort> _previousQuests;
    // 0x428: unknown column
    [FieldOffset(0x429)] public byte QuestLockJoin;
    [FieldOffset(0x42A), FixedSizeArray] internal FixedSizeArray2<ushort> _questLocks;

    [FieldOffset(0x464)] public byte InstanceContentJoin;
    [FieldOffset(0x468), FixedSizeArray] internal FixedSizeArray3<uint> _instanceContents;
    [FieldOffset(0x474)] public ushort Festival;
    [FieldOffset(0x476)] public ushort FestivalBegin;
    [FieldOffset(0x478)] public ushort FestivalEnd;
    [FieldOffset(0x47A)] public byte RepeatIntervalType;
    [FieldOffset(0x47B)] public byte QuestRepeatFlag;
    [FieldOffset(0x47C)] public ushort BellStart;
    [FieldOffset(0x47E)] public ushort BellEnd;
    [FieldOffset(0x480)] public byte BeastTribeId;
    [FieldOffset(0x481)] public byte BeastTribeRank;
    [FieldOffset(0x482)] public ushort BeastReputationValue;
    [FieldOffset(0x484)] public ushort MountRequired;
    [FieldOffset(0x486)] public byte SatisfactionNpc;
    [FieldOffset(0x487)] public byte SatisfactionLevel;
    [FieldOffset(0x488)] public uint IssuerStart;
    [FieldOffset(0x48C)] public uint TargetEnd;
    [FieldOffset(0x490)] public uint JournalGenre;
    [FieldOffset(0x494)] public uint IconSpecial;
    [FieldOffset(0x498)] public byte DailyQuestPool;


    [MemberFunction("E8 ?? ?? ?? ?? 8B 6C 24 ?? 44 3B FD")]
    public partial void GetTodoArgs(BattleChara* localPlayer, byte idx, uint* arg0, uint* arg1, uint* arg2);

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 07 45 33 D2")]
    public partial bool IsTodoChecked(BattleChara* localPlayer, byte idx);
}
