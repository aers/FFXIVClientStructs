namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::QuestWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct QuestWork {
    /// <remarks> Not a row ID in the Quest Sheet. This is only the first two bytes (e.g. row 67540 would be stored as 2004.) </remarks>
    [FieldOffset(0x08)] public ushort QuestId;
    [FieldOffset(0x0A)] public byte Sequence;
    [FieldOffset(0x0B)] public byte Flags;
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray6<byte> _variables;
    [FieldOffset(0x12)] public byte AcceptClassJob;

    public int RewardItemArrayIndex => Flags >> 1 & 3;
    public bool IsHidden => (Flags & 8) != 0;
    public bool IsPriority => (Flags & 1) != 0;
}
