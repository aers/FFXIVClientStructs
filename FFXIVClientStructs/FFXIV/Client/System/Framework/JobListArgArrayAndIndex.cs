namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::JobListArgArrayAndIndex
//   Client::System::Framework::JobListInterface
//     Client::System::Common::NonCopyable
//   Client::System::Framework::Task
/// <summary>
/// Runs <see cref="Function"/> once per task, passing the task index. Every Client::Graphics::JobSystem uses one,
/// with one task per pool thread, each calling the system's help function.
/// </summary>
[GenerateInterop]
[Inherits<JobListInterface>, Inherits<Task>(parentOffset: 0x38)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 49 89 77 18 49 89 77 20 49 89 77 28 49 89 77 30 49 89 77 40", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct JobListArgArrayAndIndex {
    [FieldOffset(0x70)] public void* Args;
    [FieldOffset(0x78)] public int ClaimLimit;
    [FieldOffset(0x7C)] public int ClaimedTasks;
    [FieldOffset(0x80)] public void* Function;
    [FieldOffset(0x88)] public void* Object;
    [FieldOffset(0x90)] public fixed byte Thunk[0x10];
    [FieldOffset(0xA0)] public int NextIndex;
}
