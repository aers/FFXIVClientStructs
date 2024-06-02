namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::DailyQuestWork
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct DailyQuestWork {
    [FieldOffset(0x08)] public ushort QuestId;
    [FieldOffset(0x0A)] public byte Flags;

    public bool IsCompleted => (Flags & 1) != 0;
}
