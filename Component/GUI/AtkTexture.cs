using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkTexture

    // size = 0x10
    // no explicit ctor
    [StructLayout(LayoutKind.Explicit, Size=0x10)]
    public unsafe struct AtkTexture
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public void* TexHandle;
    }
}
