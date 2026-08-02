namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::QuestCustomTodoManager
//   Client::Game::ServerRequestCallbackInterface
[GenerateInterop]
[Inherits<ServerRequestCallbackInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct QuestCustomTodoManager {
    [StaticAddress("48 8B 1D ?? ?? ?? ?? 0F BA E9 ?? E8 ?? ?? ?? ?? 4C 8B C0", 3, isPointer: true)]
    public static partial QuestCustomTodoManager* Instance();

    // These arrays hold the current values.
    // The DataType column on the row decides which array to use. 0 = Data8, 1 = Data16
    // The Index on the row decides which element in the array is used.
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray10<byte> _data8;
    [FieldOffset(0x12), FixedSizeArray] internal FixedSizeArray10<ushort> _data16;

    [FieldOffset(0x28)] public byte Flags;
    [FieldOffset(0x29)] public byte QuestCount;
    [FieldOffset(0x2A), FixedSizeArray] internal FixedSizeArray30<ushort> _questIds;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? ?? ?? ?? 49 8B CE FF 50 ?? 48 8B C8 BA")]
    public partial bool IsComplete(ushort internalQuestId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 44 24 ?? 66 3B 6C 24")]
    public partial void GetProgress(QuestCustomTodoProgress* outProgress, ushort internalQuestId, byte index);
}

[StructLayout(LayoutKind.Explicit, Size = 0x05)]
public struct QuestCustomTodoProgress {
    [FieldOffset(0x00)] public ushort CurValue;
    [FieldOffset(0x02)] public ushort MaxValue;
    [FieldOffset(0x04)] public byte DataType;
}
