using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
// Client::Graphics::Kernel::SwapChain
//   Client::Graphics::Kernel::Resource
//     Client::Graphics::DelayedReleaseClassBase
//       Client::Graphics::ReferencedClassBase
//   Client::Graphics::Kernel::Notifier

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe struct SwapChain
{
    [FieldOffset(0x38)] public uint Width;
    [FieldOffset(0x3C)] public uint Height;
    [FieldOffset(0x58)] public Texture* BackBuffer;
    [FieldOffset(0x60)] public Texture* DepthStencil;
    [FieldOffset(0x68)] public void* DXGISwapChain; // IDXGISwapChain
}