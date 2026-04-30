namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::TerrainRenderer
//   Client::Graphics::Render::BaseRenderer
[GenerateInterop]
[Inherits<BaseRenderer>]
[StructLayout(LayoutKind.Explicit, Size = 0x4420)]
public partial struct TerrainRenderer {
    [FieldOffset(0x43B1)] public bool Wireframe;
}
