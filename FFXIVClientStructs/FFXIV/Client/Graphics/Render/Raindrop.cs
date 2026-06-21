namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Raindrop
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct Raindrop {
    [FieldOffset(0x08)] public Renderer* RaindropRenderer;

    // Client::Graphics::Render::Raindrop::Renderer
    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public struct Renderer;
}
