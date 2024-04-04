using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkTexture
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkTexture : ICreatable {
    [FieldOffset(0x0), CExportIgnore] public void* vtbl;

    // union type
    [FieldOffset(0x8), CExporterUnion("Union.Texture")] public AtkTextureResource* Resource;
    [FieldOffset(0x8), CExporterUnion("Union.Texture")] public void* Crest;
    [FieldOffset(0x8), CExporterUnion("Union.Texture")] public Texture* KernelTexture;
    [FieldOffset(0x10)] public TextureType TextureType;
    [FieldOffset(0x11), Obsolete("Use IsTextureReady() instead")] public bool TextureReady;
    [FieldOffset(0x11)] private bool CachedIsTextureReady; // Use IsTextureReady() to get this

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 87 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 4C 89 BF")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 84 24 ?? ?? ?? ??")]
    public partial int LoadIconTexture(int iconId, int version = 1);

    [GenerateCStrOverloads]
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 6C 24 ?? 4C 8B 5C 24")]
    public partial int LoadTexture(byte* path, int version = 1);

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 10 02")]
    public partial int ReleaseTexture();

    [MemberFunction("80 79 10 01 75 44")]
    public partial int GetLoadState();

    [MemberFunction("0F B6 41 11 48 8B D1")]
    public partial bool IsTextureReady();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 57 ?? 4C 8B C0 48 8B CB E8 ?? ?? ?? ?? 48 8B 5C 24 ?? B0")]
    public partial Texture* GetKernelTexture();

    [VirtualFunction(0)]
    public partial void Destroy(bool free);
}

public enum TextureType : byte {
    Resource = 1,
    Crest = 2,
    KernelTexture = 3
}
