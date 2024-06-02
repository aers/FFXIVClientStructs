using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentAozContentBriefing
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.AozContentBriefing)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
public unsafe partial struct AgentAozContentBriefing {
    [FieldOffset(0x28)] public AozContentData* AozContentData;
    [FieldOffset(0x30)] public Utf8String WeeklyNoviceTitle;
    [FieldOffset(0x98)] public Utf8String WeeklyModerateTitle;
    [FieldOffset(0x100)] public Utf8String WeeklyAdvancedTitle;
    [FieldOffset(0x168)] public AozWeeklyFlags WeeklyCompletion;
    [FieldOffset(0x169), FixedSizeArray] internal FixedSizeArray3<byte> _weeklyAozContentIds;
    [FieldOffset(0x16C), FixedSizeArray] internal FixedSizeArray3<byte> _noviceRequirements;
    [FieldOffset(0x16F), FixedSizeArray] internal FixedSizeArray3<byte> _moderateRequirements;
    [FieldOffset(0x172), FixedSizeArray] internal FixedSizeArray3<byte> _advancedRequirements;
    [FieldOffset(0x175), FixedSizeArray] internal FixedSizeArray3<byte> _unkBytes;
    [FieldOffset(0x178)] public byte* NoviceRequirementsPtr;
    [FieldOffset(0x180)] public byte* ModerateRequirementsPtr;
    [FieldOffset(0x188)] public byte* AdvancedRequirementsPtr;
    [FieldOffset(0x190)] private byte _UnkFlags;

    [MemberFunction("4C 8B C1 80 FA 03")]
    public partial bool IsWeeklyChallengeComplete(byte challenge);

    public bool IsWeeklyChallengeComplete(AozWeeklyChallenge challenge) => IsWeeklyChallengeComplete((byte)challenge);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct AozContentData {
    [FieldOffset(0x04)] private int _UnkLoadState;
    [FieldOffset(0x0C)] public int SelectedContentIndex;
    [FieldOffset(0x10)] public int MaxContentEntries;

    [FieldOffset(0x40)] public int CurrentContentIndex;
    [FieldOffset(0x44)] private uint _UnkState;
    [FieldOffset(0x48)] public byte CurrentActIndex;
    [FieldOffset(0x49)] public byte CurrentEnemyIndex;

    [FieldOffset(0x4A), FixedSizeArray] internal FixedSizeArray3<AozArrangementData> _arrangements;

    [FieldOffset(0x228)] public Utf8String NoviceString;
    [FieldOffset(0x290)] public Utf8String ModerateString;
    [FieldOffset(0x2F8)] public Utf8String AdvancedString;

    [FieldOffset(0x360), FixedSizeArray] internal FixedSizeArray3<AozWeeklyReward> _weeklyRewards;

    [FieldOffset(0x37C)] private float _UnkFloat;
}

[StructLayout(LayoutKind.Explicit, Size = 0x7A)]
public unsafe struct AozArrangementData {
    [FieldOffset(0x01)] public byte Count;
    [FieldOffset(0x02), FixedSizeArray] internal FixedSizeArray30<ushort> _enemies;
    [FieldOffset(0x3E), FixedSizeArray] internal FixedSizeArray30<ushort> _positions;
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

public enum AozWeeklyChallenge {
    Novice = 0,
    Moderate = 1,
    Advanced = 2,
}
