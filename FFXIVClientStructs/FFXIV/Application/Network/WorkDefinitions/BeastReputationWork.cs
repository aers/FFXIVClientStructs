namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::BeastReputationWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct BeastReputationWork {
    [FieldOffset(0x08)] public byte Rank;
    [FieldOffset(0x0A)] public ushort Value;
}
