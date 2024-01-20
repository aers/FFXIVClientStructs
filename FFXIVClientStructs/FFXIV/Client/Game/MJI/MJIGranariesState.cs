namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIGranaryState
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct MJIGranaryState {
    public const int MaxNormalResources = 20;

    [FieldOffset(0x00)] public byte ActiveExpeditionId; // MJIStockyardManagementArea
    [FieldOffset(0x01)] public byte RemainingDays;
    [FieldOffset(0x02)] public byte RareResourcePouchId; // MJIItemPouch
    [FieldOffset(0x04)] public short RareResourceCount;
    [FieldOffset(0x06)] public fixed byte NormalResourcePouchIds[MaxNormalResources];
    [FieldOffset(0x1A)] public fixed short NormalResourceCounts[MaxNormalResources];
    [FieldOffset(0x44)] public uint FinishTime; // unix timestamp
}

// Client::Game::MJI::MJIGranariesState
// ctor "48 89 7C 24 ?? 45 33 D2 48 8D 51 02"
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct MJIGranariesState {
    public const int MaxGranaries = 2;

    [FixedSizeArray<MJIGranaryState>(MaxGranaries)]
    [FieldOffset(0)] public fixed byte Granary[MaxGranaries * 0x48];
    //[FieldOffset(0x90)] public void* u90; // some connection to agent

    [MemberFunction("E8 ?? ?? ?? ?? C7 83 ?? ?? ?? ?? ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 54 24")]
    public partial void CollectResources(byte granaryIndex);

    [MemberFunction("48 83 EC 38 45 0F B6 C9")]
    public partial void SelectExpeditionCommit(byte granaryIndex, byte expeditionId, byte numDays);
}
