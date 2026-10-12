namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::NotifierBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct NotifierBase {
    [VirtualFunction(0)]
    public partial NotifierBase* Dtor(byte freeFlags);
}
