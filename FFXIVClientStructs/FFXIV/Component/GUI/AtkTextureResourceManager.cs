using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AtkTextureResourceManager {
    [FieldOffset(0x00)] public StdLinkedList<Pointer<AtkTextureResource>> LoadedTextures;
    [FieldOffset(0x18)] public int DefaultTextureScale;
    [FieldOffset(0x20)] public ExdModule* ExdModule;
    [FieldOffset(0x28)] public int IconLanguageSheetId;
    [FieldOffset(0x2C)] public int IconLanguage;
    // Icon ranges are inclusive: id ∈ [a,b]
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray4<StdPair<uint, uint>> _localizedIconRange;
    [FieldOffset(0x50)] public uint LocalizedIconRangeCount;

    /// <summary>
    /// Unloads the texture if the reference count is 1, otherwise decrements the textures reference count.
    /// </summary>
    /// <param name="textureHandle">Pointer to a texture resource</param>
    /// <returns>-1 if the textureHandle is null, 0 otherwise</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 45 84 F6")]
    public partial int UnloadTexture(TextureResourceHandle* textureHandle);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 74 35 48 8B 48 08")]
    public partial AtkTextureResource* LoadIconTexture(int iconId, IconSubFolder folder);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B F8 48 85 C0 74 52"), GenerateStringOverloads]
    public partial AtkTextureResource* LoadTexture(CStringPointer path, int textureScale);
}

public enum IconSubFolder {
    None,
    HighQuality,         // "hq/"
    Japanese,            // "ja/"
    English,             // "en/"
    German,              // "de/"
    French,              // "fr/"
    ChineseSimplified,   // "chs/"
    ChineseTraditional,  // "cht/"
    Korean,              // "ko/"
    ChineseTraditional2, // "tc/"
}
