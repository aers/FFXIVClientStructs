namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct SharedGroupResourceHandle {
    [FieldOffset(0xB0)] public byte* SceneChunk;
}
