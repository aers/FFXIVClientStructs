namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::ImmediateContext

// Client::Graphics::Kernel::ImmediateContextDX11
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1858)]
public unsafe partial struct ImmediateContext {
    // Offset 0 is ID3D11DeviceContext

    // <remark>
    // Reset and assigned each rendered frame from Device->SwapChain->BackBuffer
    // </remark>
    [FieldOffset(0x28)] public Texture* BackBufferReference;

    [FieldOffset(0xBE8)] public void* D3D11DeviceContext;
}
