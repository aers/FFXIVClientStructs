namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::QuestEffectManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct QuestEffectManager {
    [StaticAddress("4C 8B 35 ?? ?? ?? ?? 0F B7 C8", 3)]
    public static partial QuestEffectManager* Instance();

    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray47<Pointer<QuestEffectBase>> _effectHandlers;
    // [FieldOffset(0x178)] private StdList<?> UnkList;
    [FieldOffset(0x188)] private ushort UnkQuestId;
    [FieldOffset(0x18A)] private ushort UnkQuestEffectId;
    [FieldOffset(0x18C)] private ushort UnkColliderInstanceId;
    [FieldOffset(0x190)] public byte Flags;
    // [FieldOffset(0x198)] private StdList<?> UnkList2;
}

// Client::Game::QuestEffectBase
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct QuestEffectBase {
    [VirtualFunction(0)]
    public partial QuestEffectBase* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial int GetResult(uint param1, uint param2, ushort questId);

    // [VirtualFunction(2)]
    // public partial bool Vf2(int param1, ushort a3);

    // [VirtualFunction(3)]
    // public partial void Vf3(int param1);

    // [VirtualFunction(4)]
    // public partial bool Vf4();

    [VirtualFunction(5)]
    public partial uint GetLogMessageId();

    [VirtualFunction(6)]
    public partial bool SuppressLogMessage();
}
