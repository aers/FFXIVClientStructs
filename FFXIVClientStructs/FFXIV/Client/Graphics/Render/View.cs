using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::View
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
public unsafe partial struct View {
    [FieldOffset(0x8)] public uint Flags;
    [FieldOffset(0x10)] public Rectangle CanvasRegion;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray16<SubView> _subViews;
}
