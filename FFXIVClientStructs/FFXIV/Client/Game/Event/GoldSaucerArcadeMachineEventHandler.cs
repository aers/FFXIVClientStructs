using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::GoldSaucerArcadeMachineEventHandler
//   Client::Game::Event::GoldSaucerEventHandler
//     Client::Game::Event::EventHandler
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<GoldSaucerEventHandler>, Inherits<AtkModuleInterface.AtkEventInterface>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 07 48 8D B7 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 AF ?? ?? ?? ?? 48 8B CE 48 89 87", 3, 276)]
[StructLayout(LayoutKind.Explicit, Size = 0x588)]
public unsafe partial struct GoldSaucerArcadeMachineEventHandler {
    [FieldOffset(0x1D0)] private bool Unk1D0;
    [FieldOffset(0x1D8)] public GoldSaucerEventHandler.EventContext EventContext;

    [FieldOffset(0x2E8), FixedSizeArray] internal FixedSizeArray4<uint> _eventSceneTaskIDs;
    [FieldOffset(0x2F8)] public StdVector<DirectorTodo> DirectorTodos;

    [FieldOffset(0x310)] public GoldSaucerArcadeMachineState State;
    [FieldOffset(0x314)] public GoldSaucerArcadeMachineUIState UIState;
    [FieldOffset(0x318)] public uint StartActionTimelineID;
    [FieldOffset(0x31C), FixedSizeArray] internal FixedSizeArray4<ResultPresentation> _resultPresentations;
    [FieldOffset(0x340)] private SheetWaiter ExcelSheetWaiter;

    /// <remarks>GoldSaucerArcadeMachine.Name</remarks>
    [FieldOffset(0x3A0)] public Utf8String Name;
    [FieldOffset(0x408)] public Utf8String* CurrentDescription;
    /// <remarks>GoldSaucerArcadeMachine.PayoutExplanation</remarks>
    [FieldOffset(0x410)] public Utf8String PayoutExplanation;
    /// <remarks>GoldSaucerArcadeMachine.Description</remarks>
    [FieldOffset(0x478)] public Utf8String Description;
    /// <remarks>GoldSaucerArcadeMachine.TotalPayoutText</remarks>
    [FieldOffset(0x4E0)] public Utf8String TotalPayoutText;

    [FieldOffset(0x548)] public int TimeoutSeconds;
    [FieldOffset(0x54C)] public int TimeLimit;
    [FieldOffset(0x550)] public uint EndTimestamp;
    [FieldOffset(0x554)] public int PausedTimeRemaining;
    [FieldOffset(0x558)] public uint BalloonMessageID;
    /// <remarks>GoldSaucerArcadeMachine.FailImage</remarks>
    [FieldOffset(0x55C)] public uint FailImageID;
    [FieldOffset(0x560)] private int CurrentPayout;
    [FieldOffset(0x564)] private int PotentialPayout;
    [FieldOffset(0x568)] private uint LogMessageID;
    [FieldOffset(0x56C)] public ushort Progress;
    [FieldOffset(0x56E)] public ushort EntryFee;
    [FieldOffset(0x570)] public bool HasMultipleRounds;
    [FieldOffset(0x571)] public GoldSaucerArcadeMachineType MachineType;
    [FieldOffset(0x572)] public sbyte PlayerOffsetX;
    [FieldOffset(0x573)] public sbyte PlayerOffsetY;
    [FieldOffset(0x574)] public sbyte PlayerOffsetZ;
    [FieldOffset(0x575)] private byte ResultUpdateDelayTenths;
    [FieldOffset(0x576)] public sbyte BalloonOffsetX;
    [FieldOffset(0x577)] public sbyte BalloonOffsetY;
    [FieldOffset(0x578)] public sbyte BalloonOffsetZ;
    [FieldOffset(0x579)] private byte RoundTransitionDelayTenths;
    [FieldOffset(0x57A)] public byte MaxProgress;
    [FieldOffset(0x57B)] public byte RoundsPlayed;
    [FieldOffset(0x57C)] public byte RoundCount;
    [FieldOffset(0x57D)] public byte CurrentRound;
    [FieldOffset(0x580)] private uint Flags;

    [MemberFunction("48 8B 05 ?? ?? ?? ?? C3 CC CC CC CC CC CC CC CC 40 53 48 83 EC ?? 66 89 91")]
    public static partial BattleChara* GetLocalPlayer();
    
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 45 33 C9 45 33 C0 33 D2 48 8B CE")]
    public static partial void BeginAgentGame();
    
    [MemberFunction("E8 ?? ?? ?? ?? 8B D7 C7 83 ?? ?? ?? ?? ?? ?? ?? ?? 48 8B CB 48 83 C4 ?? 5F 5B E9 ?? ?? ?? ?? 3B BB")]
    public static partial void PrepareNextRound();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 80 BC 24 ?? ?? ?? ?? ?? 0F 86")]
    public static partial void ShowRoundResult();

    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC ?? 0F B7 D9 45 33 C0 B9 ?? ?? ?? ?? 33 D2 E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 8B D3 48 89 6C 24")]
    public static partial GoldSaucerArcadeMachineEventHandler* Create(ushort eventID);
    
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 E8 ?? ?? ?? ?? 33 ED 48 8D 05 ?? ?? ?? ?? 48 89 07 48 8D B7")]
    public partial GoldSaucerArcadeMachineEventHandler* Ctor();

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 8D 05 ?? ?? ?? ?? 48 89 81 ?? ?? ?? ?? B8")]
    public partial void Finalizer();

    [MemberFunction("40 53 48 83 EC ?? 66 89 91 ?? ?? ?? ?? 48 8B D9 33 D2")]
    public partial void SetProgress(ushort progress);

    [MemberFunction("40 53 48 83 EC ?? 83 A1 ?? ?? ?? ?? ?? 48 8B D9 48 8B 01")]
    public partial void PauseTimer();

    [MemberFunction("83 A1 ?? ?? ?? ?? ?? C3 CC CC CC CC CC CC CC CC 4C 8B DC")]
    public partial void ResumeTimer();

    [MemberFunction("4C 8B DC 53 55 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 8B EA")]
    public partial DirectorTodo* GetOrCreateDirectorTodo(uint todoID);

    [MemberFunction("4C 8B DC 53 41 54 41 55 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 45 33 FF")]
    public partial void OnExcelSheetLoaded(void* loadedSheet, void*** rows, ulong rowCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CE E8 ?? ?? ?? ?? EB ?? 45 33 C9")]
    public partial void OpenGameUI();

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B CD 45 8B C6 41 0F B6 D7")]
    public partial void CloseGameUI();

    [MemberFunction("40 57 48 83 EC ?? 48 8B F9 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 ?? 48 8B 10 48 8B C8 FF 92")]
    public partial void ResetAgentAndSharedTimelines();

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 89 6C 24 ?? 48 8D 99")]
    public partial void StartGame();

    [MemberFunction("40 57 48 83 EC ?? B8 ?? ?? ?? ?? 48 8B F9 66 39 41")]
    public partial void FinalizeGame();

    [MemberFunction("48 83 EC ?? 83 B9 ?? ?? ?? ?? ?? 74 ?? 83 89")]
    public partial void SendMachineAction(uint action);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F1 48 8D 99 ?? ?? ?? ?? BF ?? ?? ?? ?? 33 ED 8B 13")]
    public partial void ClearEventSceneTasks();

    [MemberFunction("85 D2 0F 84 ?? ?? ?? ?? 48 89 6C 24 ?? 57 48 83 EC ?? 48 8B F9 48 89 74 24")]
    public partial void ShowBalloonMessage(uint balloonMessageID);

    [MemberFunction("48 89 74 24 ?? 57 48 83 EC ?? 48 83 79 ?? ?? 8B FA")]
    public partial void ResetAgentStatesExcept(uint state);

    [MemberFunction("40 53 55 56 57 41 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B F1 45 8B F1 48 8B 0D ?? ?? ?? ?? 41 8B E8 8B FA")]
    public partial void UpdateAgentAndDirectorTodo(int state, int currentValue, int neededValue, int result0, int result1, int result2);

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 0D ?? ?? ?? ?? 41 8B F9")]
    public partial void SendAgentResultUpdate(int result0, int result1, uint result2);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 0D ?? ?? ?? ?? 41 8B D9 41 8B F8 8B F2 E8 ?? ?? ?? ?? 48 85 C0 74 ?? 4C 8B 10 48 8B C8 41 FF 92 ?? ?? ?? ?? 48 8B C8 BA ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0")]
    public partial void SendAgentPhaseMessage(int phase, int value0, int value1);

    [GenerateInterop]
    [Inherits<ExcelSheetWaiter>]
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct SheetWaiter {
        [FieldOffset(0x30)] public ulong RefCount;
        [FieldOffset(0x38)] public GoldSaucerArcadeMachineEventHandler* EventHandler;
        [FieldOffset(0x40)] public void* Callback;
        [FieldOffset(0x48)] public int CallbackThisOffset;
        [FieldOffset(0x50)] public ExcelSheet* ExcelSheet;
        [FieldOffset(0x58)] public bool IsLoaded;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct ResultPresentation {
        [FieldOffset(0x00)] public uint ActionTimelineID;
        [FieldOffset(0x04)] public uint TimelineIndex;
    }
}

public enum GoldSaucerArcadeMachineState {
    None = 0,
    Ready = 1,
    Playing = 2,
}

public enum GoldSaucerArcadeMachineUIState {
    Closed = 0,
    Open = 1,
    Playing = 2,
}

public enum GoldSaucerArcadeMachineType : byte {
    MonsterToss = 0,
    CuffACur = 1,
    CrystalTowerStriker = 2,
    MooglesPaw = 3,
    TheFinerMiner = 4,
    OutOnALimb = 5,
}
