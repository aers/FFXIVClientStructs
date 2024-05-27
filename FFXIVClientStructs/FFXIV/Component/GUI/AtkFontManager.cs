using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
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

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xF0)]
    public unsafe partial struct Font {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<Pointer<TextureResourceHandle>> _textureResourceHandles;
        [FieldOffset(0x58), FixedSizeArray] internal FixedSizeArray10<Pointer<Texture>> _textures;
        [FieldOffset(0xE8)] public ushort TextureCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct GfdFont {
        [FieldOffset(0x00)] public TextureResourceHandle* TextureResourceHandle;
        [FieldOffset(0x08)] private ResourceHandle* GfdResourceHandle; // probably only available during setup, because it's null afterwards
        [FieldOffset(0x10)] public Texture* Texture;
    }
}
