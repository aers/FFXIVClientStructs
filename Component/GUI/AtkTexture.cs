using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkTexture

    // size = 0x18
    // no explicit ctor
    [StructLayout(LayoutKind.Explicit, Size=0x18)]
    public unsafe struct AtkTexture
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public TexHolder* TextureInfo;
        [FieldOffset(0x10)] public byte UnkBool_1;
        [FieldOffset(0x11)] public byte UnkBool_2;
    }
}
