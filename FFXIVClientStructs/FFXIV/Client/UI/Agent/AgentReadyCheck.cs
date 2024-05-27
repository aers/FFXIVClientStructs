namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ReadyCheck)]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentReadyCheck {

    [FixedSizeArray<ReadyCheckEntry>(48)]
    [FieldOffset(0xB0)] public fixed byte ReadyCheckEntries[16 * 48];

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
