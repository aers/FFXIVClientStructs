namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ReadyCheck)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct AgentReadyCheck {

    [FieldOffset(0xB0), FixedSizeArray] internal FixedSizeArray48<ReadyCheckEntry> _readyCheckEntries;

    [MemberFunction("40 ?? 48 83 ?? ?? 48 8B ?? E8 ?? ?? ?? ?? 48 ?? ?? ?? 33 C0 ?? 89")]
    public partial void InitiateReadyCheck();

    [MemberFunction("40 ?? 53 48 ?? ?? ?? ?? 48 81 ?? ?? ?? ?? ?? 48 8B ?? ?? ?? ?? ?? 48 33 ?? ?? 89 ?? ?? ?? 83 ?? ?? ?? 48 8B ?? 75 ?? 48")]
    public partial void EndReadyCheck();

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ReadyCheckEntry {
        [FieldOffset(0x00)] public ulong ContentId;
        [FieldOffset(0x08)] public ReadyCheckStatus Status;
    }

    public enum ReadyCheckStatus : byte {
        Unknown = 0,
        AwaitingResponse = 1,
        Ready = 2,
        NotReady = 3,
        MemberNotPresent = 4
    }
}
