using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
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
    public unsafe partial struct AtkTexture
    {
        [FieldOffset(0x0)] public void* vtbl;

        // union type
        [FieldOffset(0x8)] public AtkTextureResource* Resource;
        [FieldOffset(0x8)] public void* Crest;
        [FieldOffset(0x8)] public Texture* KernelTexture;
        [FieldOffset(0x10)] public TextureType TextureType;
        [FieldOffset(0x11)] public byte UnkBool_2;

        [MemberFunction("E8 ? ? ? ? 83 C8 FF 4C 89 BF ? ? ? ?")]
        public partial void Ctor();
    }
}