using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::View
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct View {
    // TODO check and update for 7.2
    [FieldOffset(0x8)] public uint Flags;
    //[FieldOffset(0x10)] public Rectangle CanvasRegion;
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray16<SubView> _subViews;
}
