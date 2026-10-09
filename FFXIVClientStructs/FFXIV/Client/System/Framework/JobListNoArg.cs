namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::JobListNoArg
//   Client::System::Framework::JobListInterface
//     Client::System::Common::NonCopyable
//   Client::System::Framework::Task
/// <summary> Runs <see cref="Function"/> once per task, without arguments. </summary>
[GenerateInterop]
[Inherits<JobListInterface>, Inherits<Task>(parentOffset: 0x38)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 7B 18 48 89 7B 20 48 89 7B 28 48 89 7B 30 48 89 7B 40 48 89 7B 48 48 89 7B 50 48 89 7B 58 48 89 03 48 8D 05 ?? ?? ?? ?? 48 89 43 38 B8 FF FF FF FF 48 89 7B 60 48 89 7B 68 89 7B 70", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct JobListNoArg {
    [FieldOffset(0x70)] public int ClaimLimit;
    [FieldOffset(0x74)] public int ClaimedTasks;
    [FieldOffset(0x78)] public void* Function;
    [FieldOffset(0x80)] public void* Object;
    [FieldOffset(0x88)] public fixed byte Thunk[0x10];
}
