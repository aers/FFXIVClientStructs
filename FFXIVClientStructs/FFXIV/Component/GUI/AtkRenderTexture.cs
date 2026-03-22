using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkRenderTexture
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct AtkRenderTexture {
    [FieldOffset(0x08)] public Texture* Texture;
    [FieldOffset(0x10)] public byte TextureScale;
}
