namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct Task {
    [FieldOffset(0x00), CExportIgnore] public void* vtbl;
    [FieldOffset(0x08)] public void* Runner;
    [FieldOffset(0x10)] public Framework* Framework;
    [FieldOffset(0x18)] public void* Func;
    // [FieldOffset(0x20)] public nint Unk; // Always 0? Probably reserved for subclasses
    [FieldOffset(0x28)] public Task* Previous;
    [FieldOffset(0x30)] public Task* Next;

    // Tasks spun up from Framework->TaskManager->RootTask pass float* frameDelta
    [VirtualFunction(1)]
    public partial void Execute(void* userData);
}

