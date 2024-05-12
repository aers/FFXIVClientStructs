using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AtkFontManager {
    [FieldOffset(0x08)] public Font* Fonts; // 41 * 0xF0
    [FieldOffset(0x10)] public ushort FontCount;
    [FieldOffset(0x18)] public GfdFont* Gfd;
    [FieldOffset(0x20)] public AtkFontCodeModule* AtkFontCodeModule;
    [FieldOffset(0x28)] public TextChecker* TextChecker;
    [FieldOffset(0x30)] public AtkTextureResourceManager* AtkTextureResourceManager;
    [FieldOffset(0x38)] public AtkFontAnalyzer* AtkFontAnalyzer;
    [FieldOffset(0x50)] public uint SetupState;

    [StructLayout(LayoutKind.Explicit, Size = 0xF0)]
    public unsafe partial struct Font {
        [FixedSizeArray<Pointer<TextureResourceHandle>>(10)]
        [FieldOffset(0)] public fixed byte TextureResourceHandles[0x8 * 10];

        [FixedSizeArray<Pointer<Texture>>(10)]
        [FieldOffset(0x58)] public fixed byte Textures[0x8 * 10];

        [FieldOffset(0xE8)] public ushort TextureCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct GfdFont {
        [FieldOffset(0x00)] public TextureResourceHandle* TextureResourceHandle;
        [FieldOffset(0x08)] private ResourceHandle* GfdResourceHandle; // probably only available during setup, because it's null afterwards
        [FieldOffset(0x10)] public Texture* Texture;
    }
}
