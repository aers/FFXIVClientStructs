namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

// Client::System::Scheduler::Instance::CharacterObject
//   Client::System::Scheduler::SchedulerInstanceObject
[GenerateInterop]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public partial struct CharacterObject {
    [FieldOffset(0x80)] public int Index;
    [FieldOffset(0x84)] public int SpawnIndex;

    [FieldOffset(0xAC)] public int Race;
    [FieldOffset(0xB0)] public int Tribe;
}
