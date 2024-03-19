namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::Device
//   Client::Graphics::Singleton

// Client::Graphics::Kernel::DeviceDX11
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct Device {
    [FieldOffset(0x8)] public void* ContextArray; // Client::Graphics::Kernel::Context array
    [FieldOffset(0x10)] public void* RenderThread; // Client::Graphics::Kernel::RenderThread
    [FieldOffset(0x70)] public SwapChain* SwapChain;
    [FieldOffset(0x7A)] public byte RequestResolutionChange;
    [FieldOffset(0x88)] public uint Width;
    [FieldOffset(0x8C)] public uint Height;
    [FieldOffset(0x90)] public float AspectRatio;
    [FieldOffset(0x94)] public float GammaCorrection;
    [FieldOffset(0x98)] public int ColorFilter;
    [FieldOffset(0x9C)] public float ColorFilterRange;
    [FieldOffset(0xA4)] public int FrameRateDivider;
    [FieldOffset(0x1B0)] public void* hWnd;
    [FieldOffset(0x1C0)] public uint NewWidth;
    [FieldOffset(0x1C4)] public uint NewHeight;
    [FieldOffset(0x1C8)] public int FrameRate;
    [FieldOffset(0x220)] public int D3DFeatureLevel; // D3D_FEATURE_LEVEL enum
    [FieldOffset(0x228)] public void* DXGIFactory; // IDXGIFactory1
    [FieldOffset(0x230)] public void* DXGIOutput; // IDXGIOutput6
    [FieldOffset(0x238)] public void* D3D11Forwarder; // CID3D11Forwarder (ID3D11Device vtbl present here)
    [FieldOffset(0x240)] public void* D3D11DeviceContext; // ID3D11DeviceContext5
    [FieldOffset(0x250)] public void* ImmediateContext; // Client::Graphics::Kernel::Device::ImmediateContext

    [StaticAddress("48 8B 0D ?? ?? ?? ?? 48 8D 54 24 ?? F3 0F 10 44 24", 3, isPointer: true)]
    public static partial Device* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 06 8B C3")]
    public partial ConstantBuffer* CreateConstantBuffer(int byteSize, uint flags, uint unk);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 0F 48 8D 54 24")]
    public partial Texture* CreateTexture2D(int* size, byte mipLevel, uint textureFormat, uint flags, uint unk);
}
