using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::ContentsFinder
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ContentsFinder {
    [StaticAddress("0F B6 FA 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 78 59 02", 6)]
    public static partial ContentsFinder* Instance();

    [FieldOffset(0x18)] public LootRule LootRules;

    [FieldOffset(0x19)] public bool IsUnrestrictedParty;
    [FieldOffset(0x1A)] public bool IsMinimalIL;
    [FieldOffset(0x1B)] public bool IsSilenceEcho;
    [FieldOffset(0x1C)] public bool IsExplorerMode;
    [FieldOffset(0x1D)] public bool IsLevelSync;
    [FieldOffset(0x1E)] public bool IsLimitedLevelingRoulette;
    [FieldOffset(0x20)] public ContentsFinderQueueInfo QueueInfo;

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 0F B6 48")]
    public partial ContentsFinderQueueInfo* GetQueueInfo();

    public enum LootRule : byte {
        Normal = 0,
        GreedOnly = 1,
        Lootmaster = 2
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct ContentsFinderQueueInfo {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray5<QueueEntry> _queuedEntries;

    [FieldOffset(0x28)] public uint QueuedClassJobId;

    [FieldOffset(0x40)] public int EnteredQueueTimestamp;
    [FieldOffset(0x44)] public int QueueReadyTimestamp;

    [FieldOffset(0x4C)] public int NextQueueUpdateTimestamp;

    [FieldOffset(0x55)] public QueueStates QueueState;

    [FieldOffset(0x5A)] public byte QueuedContentRouletteId;
    [FieldOffset(0x5B)] public sbyte ClampedPositionInQueue;
    [FieldOffset(0x5C)] public sbyte PositionInQueue;

    [FieldOffset(0x62)] public QueueInfoState InfoState;

    [FieldOffset(0x7C)] public QueueEntry PoppedQueueEntry;

    [FieldOffset(0x88)] public bool PoppedContentIsUnrestrictedParty;
    [FieldOffset(0x89)] public bool PoppedContentIsMinimalIL;
    [FieldOffset(0x8A)] public bool PoppedContentIsLevelSync;
    [FieldOffset(0x8B)] public bool PoppedContentIsSilenceEcho;
    [FieldOffset(0x8C)] public bool PoppedContentIsExplorerMode;

    public DateTime GetEnteredQueueDateTime() => DateTime.UnixEpoch.AddSeconds(EnteredQueueTimestamp);
    public DateTime GetQueueReadyDateTime() => DateTime.UnixEpoch.AddSeconds(QueueReadyTimestamp);

    [MemberFunction("40 53 57 41 57 48 83 EC 30 0F B6 41 55")]
    public partial void ProcessInfoState(QueueStates newState, QueueInfoState* newInfoState);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 13 44 0F B6 C7")]
    public partial void SetQueuedLanguages(byte languageFlags);

    [MemberFunction("C6 01 00 44 8B CA")]
    public partial void SetQueuedContentFinderConditions(uint conditionCount, int* conditionIds);

    [MemberFunction("41 0F B6 C0 89 51 28")]
    public partial void SetQueuedJobAndRoulette(uint classJobId, byte a3, byte a4, byte contentRouletteId);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 8B FA 48 8B D9 45 84 C0")]
    public partial void UpdateQueueState(QueueStates newState, bool beganQueue);

    [MemberFunction("4C 8B DC 53 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 80 79")]
    public partial void QueueRoulette(byte contentRouletteId, byte a3 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? B0 ?? 44 88 B6 ?? ?? ?? ?? E9 ?? ?? ?? ?? 44 0F B6 86")]
    public partial void QueueDuties(uint* entries, int entryCount, byte a4 = 0);

    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 0F B6 49 ?? 8D 41")]
    public partial void CancelQueue();

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct QueueEntry {
        [FieldOffset(0x0)] public ContentsId.ContentsType ContentType;
        [FieldOffset(0x4), CExporterUnion("Id")] public uint ConditionId;
        [FieldOffset(0x4), CExporterUnion("Id")] public byte RouletteId;
    }

    public enum QueueStates : byte {
        None = 0,
        Pending = 1,
        Queued = 2,
        Ready = 3,
        Accepted = 4,
        InContent = 5
    }
}


[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct QueueInfoState {
    [FieldOffset(0x2)] public QueueContentType ContentType;
    [FieldOffset(0x3)] public bool IsReservingServer;

    // ContentType: 0
    [FieldOffset(0x4)] public byte PositionInQueue;

    // ContentType: 0-3
    [FieldOffset(0x5)] public bool AverageWaitTime;

    // ContentType: 1
    [FieldOffset(0x8)] public byte TanksFound;
    [FieldOffset(0x9)] public byte TanksNeeded;
    [FieldOffset(0xA)] public byte HealersFound;
    [FieldOffset(0xB)] public byte HealersNeeded;
    [FieldOffset(0xC)] public byte DPSFound;
    [FieldOffset(0xD)] public byte DPSNeeded;

    // ContentType: 2
    [FieldOffset(0xE)] public byte PlayersFound;
    [FieldOffset(0xF)] public byte PlayersNeeded;

    public enum QueueContentType : byte {
        PositionAndWaitTime = 0, // Roulette
        THDAndWaitTime = 1,
        PlayersAndWaitTime = 2,
        WaitTime = 3,
        None4 = 4,
        None5 = 5
    }
}
