namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::TrackingWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct TrackingWork {
    [FieldOffset(0x08)] public byte QuestType;
    [FieldOffset(0x09)] public byte Index;
}
