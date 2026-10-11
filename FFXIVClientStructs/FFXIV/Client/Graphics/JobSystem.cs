namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::JobSystem<T>
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe struct JobSystem {
    [FieldOffset(0x10)] public uint JobThreadCount;
    [FieldOffset(0x18)] private void* /* Client::System::Framework::JobListArgArrayAndIndex */ JobList;
    [FieldOffset(0x20)] public void* CallbackThisArg;
    [FieldOffset(0x28)] public delegate* unmanaged<void*, void*, void> CallbackFunction;
    [FieldOffset(0xB0)] public uint JobCount;
    [FieldOffset(0xB4)] public uint JobExecutedCount; // two different types of jobs, unsure difference
    [FieldOffset(0xB8)] public uint JobExecutedCount2;
}
