namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct RootTask {
    [FieldOffset(0x00)] public Task Task;
    [FieldOffset(0x38)] public Task UnkTask;
}
