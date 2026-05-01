namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::BGInstancingRenderer
//   Client::Graphics::Render::BaseRenderer
[GenerateInterop]
[Inherits<BaseRenderer>]
[StructLayout(LayoutKind.Explicit, Size = 0x18E00)]
public partial struct BGInstancingRenderer {
    [FieldOffset(0x18538)] public bool Wireframe;
}
