namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::QuestWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct QuestWork {
    [FieldOffset(0x08)] public ushort QuestId;
    [FieldOffset(0x0A)] public byte Sequence;
    [BitField<bool>(nameof(IsPriority), 0)]
    [BitField<int>(nameof(RewardItemArrayIndex), 1, 2)]
    [BitField<bool>(nameof(IsHidden), 3)]
    [FieldOffset(0x0B)] public byte Flags;
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray6<byte> _variables;
    [FieldOffset(0x12)] public byte AcceptClassJob;
}
