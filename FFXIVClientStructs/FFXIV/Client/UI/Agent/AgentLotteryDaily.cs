namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.LotteryDaily)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct AgentLotteryDaily {
    [FieldOffset(0x28)] public int Status; // 1 selecting numbers, 2 picking row, 3 done, 4 got payout

    [FieldOffset(0x38), FixedSizeArray] internal FixedSizeArray9<byte> _numbers;

    [MemberFunction("40 53 48 83 EC ?? 48 63 C2 48 8B D9 44 88 44")]
    public partial void UpdateNumber(int index, byte value);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 74 24 ?? 89 BB")]
    public partial void UpdatePayout(int sum, int mgp);
}
