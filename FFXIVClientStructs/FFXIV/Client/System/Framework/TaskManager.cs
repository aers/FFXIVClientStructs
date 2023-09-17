namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x4C)]
public unsafe struct TaskManagerOsData {
    [FieldOffset(0x40)] public nint Handle; // Win32 HANDLE type
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct TaskManager {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public TaskManagerOsData OsData;
    [FieldOffset(0x58)] public RootTask* TaskList;
    [FieldOffset(0x60)] public uint TaskCount;
    [FieldOffset(0x68)] public void* UserData; // Set to a float* to Framework->FrameDelta

    // Lower priority = executed first
    [MemberFunction("8B C2 48 6B D0 78 48 03 51 58")]
    public partial void AddTask(uint priority, Task* task);
}
