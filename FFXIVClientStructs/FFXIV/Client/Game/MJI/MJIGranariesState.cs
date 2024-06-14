namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIGranaryState
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct MJIGranaryState {
    [FieldOffset(0x00)] public byte ActiveExpeditionId; // MJIStockyardManagementArea
    [FieldOffset(0x01)] public byte RemainingDays;
    [FieldOffset(0x02)] public byte RareResourcePouchId; // MJIItemPouch
    [FieldOffset(0x04)] public short RareResourceCount;
    [FieldOffset(0x06), FixedSizeArray] internal FixedSizeArray20<byte> _normalResourcePouchIds;
    [FieldOffset(0x1A), FixedSizeArray] internal FixedSizeArray20<byte> _normalResourceCounts;
    [FieldOffset(0x44)] public int FinishTime; // unix timestamp
}

// Client::Game::MJI::MJIGranariesState
// ctor "48 89 5C 24 ?? 33 DB 4C 8D 41"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct MJIGranariesState {
    public const int MaxGranaries = 2;

    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray2<MJIGranaryState> _granary;
    //[FieldOffset(0x90)] public void* u90; // some connection to agent

    [MemberFunction("E8 ?? ?? ?? ?? C7 83 ?? ?? ?? ?? ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 54 24")]
    public partial void CollectResources(byte granaryIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 74 24 ?? 48 8D 93 ?? ?? ?? ??")]
    public partial void SelectExpeditionCommit(byte granaryIndex, byte expeditionId, byte numDays);
}
