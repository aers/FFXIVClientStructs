namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
[GenerateInterop]
[Inherits<Task>]
public partial struct RootTask {
    [FieldOffset(0x38)] public Task UnkTask;
}
