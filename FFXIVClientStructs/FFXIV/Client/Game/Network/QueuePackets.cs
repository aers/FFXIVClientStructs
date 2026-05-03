using FFXIVClientStructs.FFXIV.Client.Enums;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct QueueUpdatePacket {
    [FieldOffset(0x00)] public ContentsFinderQueueState QueueState;
    [FieldOffset(0x01)] public byte ClassJobId;
    [FieldOffset(0x02)] public Language LanguageFlags;
    [FieldOffset(0x08)] public QueueFlags Flags;
    [FieldOffset(0x10)] public byte RouletteId;
    [FieldOffset(0x13)] public bool BeganQueue;
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray5<uint> _contentFinderConditions;

    [Flags]
    public enum QueueFlags : ulong {
        None = 0,
        Unk0 = 1UL << 0,

        // Queue Join Flags
        RequestJoinPartyInProgress = 1UL << 1,
        InitiatedByPartyMember     = 1UL << 2,

        // Queue Pop Flags
        ReqsDisabled               = 1UL << 3,
        Unk4                       = 1UL << 4,
        Unk5                       = 1UL << 5,
        Unk6                       = 1UL << 6,
        InProgressParty            = 1UL << 7,
        Unk8                       = 1UL << 8,
        Unk9                       = 1UL << 9,
        Unk10                      = 1UL << 10,
        GreedOnly                  = 1UL << 11,
        Unk12                      = 1UL << 12,
        Unrestricted               = 1UL << 13,
        MinIlvl                    = 1UL << 14,
        Unk15                      = 1UL << 15,
        Lootmaster                 = 1UL << 16,
        Unk17                      = 1UL << 17,
        Unk18                      = 1UL << 18,
        Unk19                      = 1UL << 19,
        Unk20                      = 1UL << 20,
        IsSynced                   = 1UL << 21,
        LimitedLevelingRoulette    = 1UL << 22,
        Unk23                      = 1UL << 23,
        Unk24                      = 1UL << 24,
        Unk25                      = 1UL << 25,
        Unk26                      = 1UL << 26,
        Unk27                      = 1UL << 27,
        SilenceEcho                = 1UL << 28,
        Unk29                      = 1UL << 29,
        Unk30                      = 1UL << 30,
        Unk31                      = 1UL << 31,
        IsExplorer                 = 1UL << 32,
    }

    [Flags]
    public enum Language : byte {
        Japanese = 1,
        English = 2,
        German = 4,
        French = 8
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public struct QueueInfoStatePacket {
    [FieldOffset(0x00)] public ContentsFinderQueueState QueueState;
    [FieldOffset(0x04)] public QueueInfoState InfoState;
}
