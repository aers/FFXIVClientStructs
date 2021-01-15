using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Client.Graphics.Render
{
    // Client::Graphics::Kernel::Texture
    //   Client::Graphics::Kernel::Resource
    //     Client::Graphics::Kernel::DelayedReleaseClassBase
    //       Client::Graphics::ReferencedClassBase
    //   Client::Graphics::Kernel::Notifier

    // renderer texture object, contains platform specific render objects (DX9/DX11/PS3/PS4)

    // size = 0xA8
    // ctor E8 ? ? ? ? 48 8B F8 48 85 C0 74 23 44 8B 43 40 
    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public unsafe struct Texture
    {
        [FieldOffset(0x0)] public void* vtbl; // Client::Graphics::Kernel::Resource
        [FieldOffset(0x20)] public void* vtbl_2; // Client::Graphics::Kernel::Notifier
        // texture object starts at 0x28
    }
}
