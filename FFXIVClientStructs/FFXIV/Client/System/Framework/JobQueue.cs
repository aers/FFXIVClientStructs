namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::JobQueue<128>
/// <summary>
/// The ring that every <see cref="TaskManager.JobPool"/> thread takes work from. Threads only claim tasks from the head entry,
/// one per lock, and the head advances when its last task is claimed.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4C30)]
public unsafe partial struct JobQueue {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 8B 05 ?? ?? ?? ?? 4C 8D 0D ?? ?? ?? ?? 48 8B 0B 0F 57 C9", 15)]
    public static partial JobQueue* Instance();

    [FieldOffset(0x00)] public uint WriteIndex;
    [FieldOffset(0x04)] public uint ReadIndex;
    [FieldOffset(0x08)] private fixed byte Lock[0x28]; // CRITICAL_SECTION
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray128<JobQueueListData> _entries;

    // Client::System::Framework::JobQueue<128>::JobQueueListData
    //   Client::System::Framework::Task
    /// <summary> An entry whose job has no object is handed out as the task itself. </summary>
    [GenerateInterop]
    [Inherits<Task>]
    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public partial struct JobQueueListData {
        [FieldOffset(0x38)] public JobListInterface.JobDescriptor Job;
        [FieldOffset(0x88)] public nint* CompletionEvent; // HANDLE*, signaled when the entry leaves the queue
    }
}
