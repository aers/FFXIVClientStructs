namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Footprint
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct Footprint {
    [FieldOffset(0x08)] public Renderer* FootprintRenderer;

    // Client::Graphics::Render::Footprint::Renderer
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct Renderer;
}
