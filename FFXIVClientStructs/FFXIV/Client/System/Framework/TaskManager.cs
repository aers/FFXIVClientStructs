namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x4C)]
public struct TaskManagerOsData {
    [FieldOffset(0x40)] public nint Handle; // Win32 HANDLE type
}

// Client::System::Framework::TaskManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct TaskManager {
    [StaticAddress("4D 89 66 68 4C 89 35 ?? ?? ?? ??", 7, isPointer: true)]
    public static partial TaskManager* Instance();

    [FieldOffset(0x08)] public TaskManagerOsData OsData;
    [FieldOffset(0x58)] public RootTask* TaskList;
    [FieldOffset(0x60)] public uint TaskCount;
    [FieldOffset(0x68)] public void* UserData; // Set to a float* to Framework->FrameDelta

    // Lower priority = executed first
    [MemberFunction("8B C2 48 6B D0 78 48 03 51 58")]
    public partial void AddTask(uint priority, Task* task);

    // Client::System::Framework::TaskManager::RootTask
    //   Client::System::Framework::Task
    [GenerateInterop]
    [Inherits<Task>]
    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public partial struct RootTask {
        [FieldOffset(0x38)] public Task UnkTask;
    }
}
