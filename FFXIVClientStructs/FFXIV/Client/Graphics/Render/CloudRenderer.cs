namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::CloudRenderer
//   Client::Graphics::Render::BaseRenderer
[GenerateInterop]
[Inherits<BaseRenderer>]
[StructLayout(LayoutKind.Explicit, Size = 0x480)]
public partial struct CloudRenderer {
    [FieldOffset(0x110)] public ShadowCamera ShadowCamera;
}
