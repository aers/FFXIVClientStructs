namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::BGInstancingRenderer
//   Client::Graphics::Render::BaseRenderer
[GenerateInterop]
[Inherits<BaseRenderer>]
[StructLayout(LayoutKind.Explicit, Size = 0x20E60)]
public partial struct BGInstancingRenderer {
    [FieldOffset(0x20589)] public bool Wireframe;
}
