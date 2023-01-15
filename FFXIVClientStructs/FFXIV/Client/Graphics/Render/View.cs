using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;
// Client::Graphics::Render::View

[StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
public unsafe partial struct View
{
    [FieldOffset(0x0)] public void* Vtbl;
    [FieldOffset(0x8)] public uint Flags;
    [FieldOffset(0x10)] public Rectangle CanvasRegion;
    [FixedSizeArray<SubView>(16)]
    [FieldOffset(0x20)] public fixed byte SubViewArray[0x58 * 0x10]; // 16 Client::Graphics::Render::SubView
}