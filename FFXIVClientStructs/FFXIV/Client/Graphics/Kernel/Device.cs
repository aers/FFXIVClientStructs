namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::Device
//   Client::Graphics::Singleton

// Client::Graphics::Kernel::DeviceDX11
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8C8)]
public unsafe partial struct Device {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 7B 08 00", 3, isPointer: true)]
    public static partial Device* Instance();

    [FieldOffset(0x8)] public void* ContextArray; // Client::Graphics::Kernel::Context array
    [FieldOffset(0x10)] public void* RenderThread; // Client::Graphics::Kernel::RenderThread
    [FieldOffset(0x70)] public SwapChain* SwapChain;
    [FieldOffset(0x7A)] public byte RequestResolutionChange;
    [FieldOffset(0x8C)] public uint Width;
    [FieldOffset(0x90)] public uint Height;
    [FieldOffset(0x94)] public float AspectRatio;
    [FieldOffset(0x98)] public float GammaCorrection;
    [FieldOffset(0x9C)] public int ColorFilter;
    [FieldOffset(0xA0)] public float ColorFilterRange;

    [FieldOffset(0xAC)] public short FrameRateLimit;
    // [FieldOffset(0xAE)] public short FrameRateLimit2; ?

    [FieldOffset(0x820)] public void* hWnd;
    [FieldOffset(0x830)] public uint NewWidth;
    [FieldOffset(0x834)] public uint NewHeight;
    [FieldOffset(0x838)] public int FrameRate;

    [FieldOffset(0x890)] public int D3DFeatureLevel; // D3D_FEATURE_LEVEL enum
    [FieldOffset(0x898)] public void* DXGIFactory; // IDXGIFactory1
    [FieldOffset(0x8A0)] public void* DXGIOutput; // IDXGIOutput6
    [FieldOffset(0x8A8)] public void* D3D11Forwarder; // CID3D11Forwarder (ID3D11Device vtbl present here)
    [FieldOffset(0x8B0)] public void* D3D11DeviceContext; // ID3D11DeviceContext5

    [FieldOffset(0x8C0)] public void* ImmediateContext; // Client::Graphics::Kernel::Device::ImmediateContext

    [MemberFunction("E8 ?? ?? ?? ?? 49 89 45 48")]
    public partial ConstantBuffer* CreateConstantBuffer(int byteSize, uint flags, uint unk);

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 07 48 8D 7F 20")]
    public partial Texture* CreateTexture2D(int* size, byte mipLevel, uint textureFormat, uint flags, uint unk);
}
