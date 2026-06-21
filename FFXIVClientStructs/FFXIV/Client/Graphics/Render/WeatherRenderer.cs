namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::WeatherRenderer
//   Client::Graphics::Render::BaseRenderer
[GenerateInterop]
[Inherits<BaseRenderer>]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public partial struct WeatherRenderer {
    [FieldOffset(0x78)] public WeatherType Type;

    public enum WeatherType {
        Rain = 0,
        Snow = 1, // unused
        Dust = 2,
        Unk3 = 3, // unused
    }
}
