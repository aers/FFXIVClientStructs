namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::LeveWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct LeveWork {
    [FieldOffset(0x08)] public ushort LeveId;
    [FieldOffset(0x0A)] public byte Sequence;
    [BitField<bool>(nameof(IsHidden), 14)]
    [BitField<bool>(nameof(IsPriority), 15)]
    [FieldOffset(0x0C)] public ushort Flags;
    [FieldOffset(0x0E)] public ushort LeveSeed;
    [FieldOffset(0x10)] public byte ClearClass;
}
