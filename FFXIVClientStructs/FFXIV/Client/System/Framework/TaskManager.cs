namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::TaskManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct TaskManager {
    [StaticAddress("4C 89 35 ?? ?? ?? ?? ?? ?? ?? 39 0D", 3, isPointer: true)]
    public static partial TaskManager* Instance();

    [FieldOffset(0x08), Obsolete("Use Pool")] public TaskManagerOsData OsData;
    [FieldOffset(0x08)] public JobPool Pool;
    [FieldOffset(0x58)] public RootTask* TaskList;
    [FieldOffset(0x60)] public uint TaskCount;
    [FieldOffset(0x68)] public void* UserData; // Set to a float* to Framework->FrameDelta

    // Lower priority = executed first
    [MemberFunction("8B C2 48 6B D0 78 48 03 51 58")]
    public partial void AddTask(uint priority, Task* task);

    public Span<RootTask> TaskListSpan => new(TaskList, (int)TaskCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 85 C9 74 ?? F3 0F 10 8B")]
    public partial void ExecuteAllTasks(float* dt);

    /// <summary>
    /// Prepares the job list and puts it on the <see cref="JobQueue"/>, then wakes one thread if the list has a single
    /// task, otherwise every thread. Returns without waiting, use <see cref="JobListInterface.Wait"/> to join.
    /// </summary>
    [MemberFunction("40 53 57 48 83 EC 58 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 40 48 8B 02")]
    public partial void ScheduleJobList(JobListInterface* jobList);

    // Client::System::Framework::TaskManager::JobPool
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x4C)]
    public partial struct JobPool {
        [FieldOffset(0x00)] public bool Initialized;
        [FieldOffset(0x08)] public InnerThread** Threads;
        [FieldOffset(0x10)] public int ThreadCount;

        /// <summary> Threads pass a pointer to this to every task they run. </summary>
        [FieldOffset(0x38)] public int TaskContext;
        [FieldOffset(0x40)] public nint Handle; // Win32 HANDLE type

        public Span<Pointer<InnerThread>> ThreadsSpan => new(Threads, ThreadCount);

        /// <summary> Signals every thread that has fewer than 2 pending wakes. </summary>
        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4C 24 ?? BA ?? ?? ?? ?? FF 15")]
        public partial void WakeAllThreads();

        // Client::System::Framework::TaskManager::JobPool::InnerThread
        //   Client::System::Threading::Thread
        //     Client::System::Common::NonCopyable
        [GenerateInterop]
        [Inherits<Threading.Thread>]
        [StructLayout(LayoutKind.Explicit, Size = 0x48)]
        public partial struct InnerThread {
            [FieldOffset(0x28)] public JobPool* Pool;
            [FieldOffset(0x30)] public int Index;
            [FieldOffset(0x34)] private byte Unk34;
            [FieldOffset(0x35)] private byte Unk35; // wakes skip the thread while set
            /// <summary> Wake requests not yet consumed. The thread sleeps on <see cref="EventHandle2"/> when this drops to 0. </summary>
            [FieldOffset(0x38)] public int PendingWakes;
            [FieldOffset(0x40)] public nint EventHandle2; // Thread already has an EventHandle, not sure why there is a second one
        }
    }

    // Client::System::Framework::TaskManager::RootTask
    //   Client::System::Framework::Task
    [GenerateInterop]
    [Inherits<Task>]
    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public partial struct RootTask {
        [FieldOffset(0x38)] private Task UnkTask;
    }
}

// TODO: remove. was replaced with JobPool
[StructLayout(LayoutKind.Explicit, Size = 0x4C)]
public unsafe struct TaskManagerOsData {
    [FieldOffset(0x40)] public nint Handle; // Win32 HANDLE type
}
