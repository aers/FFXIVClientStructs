namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::JobSystem<T>
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct JobSystem {
    [FieldOffset(0)] public void* Vtbl;

    [FieldOffset(0x20)] public void* CallbackThisArg;
    [FieldOffset(0x28)] public delegate* unmanaged<void*, void*, void> CallbackFunction;
}
