using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkTexture
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkTexture : ICreatable {
    // union type
    [FieldOffset(0x8), CExporterUnion("Texture")] public AtkTextureResource* Resource;
    [FieldOffset(0x8), CExporterUnion("Texture")] public void* Crest;
    [FieldOffset(0x8), CExporterUnion("Texture")] public Texture* KernelTexture;
    [FieldOffset(0x10)] public TextureType TextureType;
    [FieldOffset(0x11)] private bool CachedIsTextureReady; // Use IsTextureReady() to get this

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 87 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 4C 89 AF")]
    public partial void Ctor();

    [MemberFunction("E9 ?? ?? ?? ?? 0F BA F0 14")]
    public partial int LoadIconTexture(uint iconId, IconSubFolder iconSubFolder = IconSubFolder.None);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 2F 48 8B 83"), GenerateStringOverloads]
    public partial int LoadTexture(CStringPointer path, int scale = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 66 41 03 46")]
    public partial uint GetTextureWidth();

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 C6 8B C0")]
    public partial uint GetTextureHeight();

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 10 02")]
    public partial int ReleaseTexture();

    [MemberFunction("80 79 10 01 75 44")]
    public partial int GetLoadState();

    [MemberFunction("0F B6 41 11 48 8B D1")]
    public partial bool IsTextureReady();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 57 ?? 4C 8B C0 48 8B CB E8 ?? ?? ?? ?? 48 8B 5C 24 ?? B0")]
    public partial Texture* GetKernelTexture();

    /// <summary>
    /// Expects a 255 byte large buffer to store string result, does not automatically add null terminator, use a 0-initialized byte buffer.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 90 48 FF C7")]
    public static partial int GetIconPath(byte* buffer, uint iconId, int textureScale, IconSubFolder iconSubFolder);

    [VirtualFunction(0)]
    public partial void Destroy(bool free);

    // Based on call from AtkImageNode.LoadTextureWithDefaultVersion
    [GenerateStringOverloads]
    public int LoadTextureWithDefaultVersion(CStringPointer path)
        => LoadTexture(path, AtkStage.Instance()->AtkTextureResourceManager->DefaultTextureScale);
}

public enum TextureType : byte {
    Resource = 1,
    Crest = 2,
    KernelTexture = 3
}
