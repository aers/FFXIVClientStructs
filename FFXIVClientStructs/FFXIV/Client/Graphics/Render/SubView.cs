using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;
// Client::Graphics::Render::SubView

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct SubView
{
    [FieldOffset(0x0)] public void* Vtbl;
    [FieldOffset(0x8)] public uint Flags;
    [FieldOffset(0x10)] public Rectangle ViewportRegion;
    [FieldOffset(0x20)] public void* Camera; // Client::Graphics::Render::Camera
    [FieldOffset(0x28)] public Texture* RenderTarget_1;
    [FieldOffset(0x30)] public Texture* RenderTarget_2;
    [FieldOffset(0x38)] public Texture* RenderTarget_3;
    [FieldOffset(0x40)] public Texture* RenderTarget_4;
    [FieldOffset(0x48)] public uint RenderTargetUsedCount;
    [FieldOffset(0x50)] public Texture* DepthStencil;
}