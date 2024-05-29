namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[GenerateInterop]
[Inherits<Task>]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public partial struct RootTask {
    [FieldOffset(0x38)] public Task UnkTask;
}
