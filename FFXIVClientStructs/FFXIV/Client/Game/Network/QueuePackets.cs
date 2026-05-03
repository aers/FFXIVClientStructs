using FFXIVClientStructs.FFXIV.Client.Enums;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct QueueUpdatePacket {
    [FieldOffset(0x00)] public ContentsFinderQueueState QueueState;
    [FieldOffset(0x01)] public byte ClassJobId;
    [FieldOffset(0x02)] public ContentsFinder.Language LanguageFlags;
    [FieldOffset(0x08)] public QueueFlags Flags;
    [FieldOffset(0x10)] public byte RouletteId;
    [FieldOffset(0x13)] public bool BeganQueue;
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray5<uint> _contentFinderConditions;

    [Flags]
    public enum QueueFlags : ulong {
        // Queue Pop Flags
        ReqsDisabled = 0x8,
        Unrestricted = 0x2000,
        MinIlvl = 0x4000,
        GreedOnly = 0x8000,
        Lootmaster = 0x10000,
        IsSynced = 0x200000,
        LimitedLevelingRoulette = 0x400000,
        SilenceEcho = 0x10000000,
        IsExplorer = 0x100000000,
        InProgressParty = 0x80,

        // Queue Join Flags
        Unk20 = 0x20,
        Unk_A = 1 << 30,
        Unk_B = 0x20000,
        Unk_C = 0x400,
        Unk_D = 0x40,
        RequestJoinPartyInProgress = 0x2,
        Unk_F = 0x20000000,
        InitiatedByPartyMember = 0x4,
        Unk_H = 0x10
    }
}


[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public struct QueueInfoStatePacket {
    [FieldOffset(0x00)] public ContentsFinderQueueState QueueState;
    [FieldOffset(0x04)] public QueueInfoState InfoState;
}