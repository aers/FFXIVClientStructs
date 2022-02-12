namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;
// Client::Graphics::Kernel::Notifier

// size = 0x18
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct Notifier
{
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public Notifier* Next;
    [FieldOffset(0x10)] public Notifier* Prev;
}