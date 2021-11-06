using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel
{
    // Client::Graphics::Kernel::Device
    //   Client::Graphics::Singleton
    [StructLayout(LayoutKind.Explicit, Size = 0x210)]
    public unsafe partial struct Device
    {
        [FieldOffset(0x8)] public void* ContextArray; // Client::Graphics::Kernel::Context array
        [FieldOffset(0x10)] public void* ImmediateContext; // Client::Graphics::Kernel::Device::ImmediateContext
        [FieldOffset(0x18)] public void* RenderThread; // Client::Graphics::Kernel::RenderThread
        [FieldOffset(0x80)] public SwapChain* SwapChain;
        [FieldOffset(0x94)] public int D3DFeatureLevel; // D3D_FEATURE_LEVEL enum
        [FieldOffset(0x98)] public void* DXGIFactory; // IDXGIFactory1
        [FieldOffset(0xA8)] public void* D3D11Device; // ID3D11Device1
        [FieldOffset(0xB0)] public void* D3D11DeviceContext; // ID3D11DeviceContext1

        [StaticAddress("48 8B 0D ?? ?? ?? ?? 48 8D 54 24 ?? F3 0F 10 44 24", isPointer: true)]
        public static partial Device* Instance();
    }
}