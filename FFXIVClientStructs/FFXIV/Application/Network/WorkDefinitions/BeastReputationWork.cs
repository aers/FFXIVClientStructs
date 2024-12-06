namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::BeastReputationWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct BeastReputationWork {
    [FieldOffset(0x08)] public byte Rank; // high bit is set if rank was increased today; remaining bits is actual rank
    [FieldOffset(0x0A)] public ushort Value;
}
