namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::DailyQuestWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct DailyQuestWork {
    [FieldOffset(0x08)] public ushort QuestId;
    [BitField<bool>(nameof(IsCompleted), 0)]
    [FieldOffset(0x0A)] public byte Flags;
}
