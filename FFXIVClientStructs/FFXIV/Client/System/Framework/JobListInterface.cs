namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::JobListInterface
//   Client::System::Common::NonCopyable
/// <summary>
/// A batch of <see cref="TaskCount"/> tasks run by the <see cref="TaskManager.JobPool"/> threads.
/// Scheduled with <see cref="TaskManager.ScheduleJobList"/>, joined with <see cref="Wait"/>.
/// </summary>
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct JobListInterface {
    [FieldOffset(0x08)] public int TaskCount;
    /// <summary> Tasks not yet finished. The last one to finish calls <see cref="CompletionFunction"/> and sets <see cref="DoneEvent"/>. </summary>
    [FieldOffset(0x0C)] public int PendingTasks;
    [FieldOffset(0x10)] public nint DoneEvent; // HANDLE, manual reset
    [FieldOffset(0x18)] public delegate* unmanaged<void*, void*, JobListInterface*, void> CompletionFunction;
    [FieldOffset(0x20)] public void* CompletionObject;

    /// <summary> Fills in what the queue entry uses to claim this list's tasks. </summary>
    [VirtualFunction(1)]
    public partial JobDescriptor* GetJob(JobDescriptor* outJob);

    /// <summary> Waits for the previous run, then resets the claim counter, <see cref="PendingTasks"/> and <see cref="DoneEvent"/>. </summary>
    [VirtualFunction(2)]
    public partial void Prepare();

    /// <summary> Waits until every task of the list has run. </summary>
    [VirtualFunction(3)]
    public partial void Wait();

    [VirtualFunction(4)]
    public partial uint GetTaskCount();

    /// <summary>
    /// Type-erased member function call: <see cref="Invoker"/> calls <see cref="Function"/> on <see cref="Object"/>
    /// adjusted by <see cref="ThisAdjust"/>. For job lists the function claims the next task, returning it and its
    /// argument, and the number of tasks left (the queue advances when that is 0).
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct JobDescriptor {
        [FieldOffset(0x00)] public delegate* unmanaged<void*, void*, void**, int*, Task*> Invoker;
        [FieldOffset(0x08)] public void* Object;
        [FieldOffset(0x10)] public void* Function;
        [FieldOffset(0x18)] public int ThisAdjust;
    }
}
