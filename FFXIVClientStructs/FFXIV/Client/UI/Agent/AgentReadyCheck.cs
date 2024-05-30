namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ReadyCheck)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct AgentReadyCheck {

    [FieldOffset(0xB0), FixedSizeArray] internal FixedSizeArray48<ReadyCheckEntry> _readyCheckEntries;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ReadyCheckEntry {
        [FieldOffset(0x00)] public long ContentId;
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
