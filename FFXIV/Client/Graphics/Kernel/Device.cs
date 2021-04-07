
using System.Runtime.InteropServices;


namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel
{
    // Client::Graphics::Kernel::Device
    //   Client::Graphics::Singleton
    [StructLayout(LayoutKind.Explicit, Size = 0x210)]
    public unsafe struct Device
    {
        [FieldOffset(0x80)] public SwapChain* SwapChain;
        [FieldOffset(0x94)] public int D3DFeatureLevel; // D3D_FEATURE_LEVEL enum
        [FieldOffset(0x98)] public void* DXGIFactory; // IDXGIFactory1
        [FieldOffset(0xA8)] public void* D3D11Device; // ID3D11Device1
        [FieldOffset(0xB0)] public void* D3D11DeviceContext; // ID3D11DeviceContext1
    }
}
