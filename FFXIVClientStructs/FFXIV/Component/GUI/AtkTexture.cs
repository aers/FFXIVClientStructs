using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum TextureType : byte
{
    Resource = 1,
    Crest = 2,
    KernelTexture = 3
}

// Component::GUI::AtkTexture

// size = 0x18
// no explicit ctor
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkTexture : ICreatable
{
    [FieldOffset(0x0)] public void* vtbl;

    // union type
    [FieldOffset(0x8)] public AtkTextureResource* Resource;
    [FieldOffset(0x8)] public void* Crest;
    [FieldOffset(0x8)] public Texture* KernelTexture;
    [FieldOffset(0x10)] public TextureType TextureType;
    [FieldOffset(0x11)] public byte UnkBool_2;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 87 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 4C 89 BF")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 84 24 ?? ?? ?? ??")]
    public partial int LoadIconTexture(int iconId, int version);

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