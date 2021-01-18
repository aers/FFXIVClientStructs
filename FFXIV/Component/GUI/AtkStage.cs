using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Client.UI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // probably belongs to something other than AtkStage 
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct TextureResource
    {
        [FieldOffset(0x0)] public uint TexPathHash; // crc32(full path)
        [FieldOffset(0x4)] public uint Unk_1; // defaults to 0xFFFFFFFF which is -1 so might be signed
        [FieldOffset(0x8)] public TextureResourceHandle* TexFileResourceHandle;
        [FieldOffset(0x10)] public Texture* KernelTextureObject; // Client::Graphics::Kernel::Texture, renderer texture obj
        [FieldOffset(0x18)] public ushort Count_1; // both of these are some sort of reference/use count
        [FieldOffset(0x1A)] public byte Count_2;
    }

    // Component::GUI::AtkStage
    //   Component::GUI::AtkEventTarget

    // size = 0x75DF8
    // ctor E8 ? ? ? ? 48 8B F8 48 89 BE ? ? ? ? 48 8B 43 10 
    [StructLayout(LayoutKind.Explicit, Size = 0x75DF8)]
    public unsafe struct AtkStage
    {
        [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
        [FieldOffset(0x20)] public RaptureAtkUnitManager* RaptureAtkUnitManager;
    }
}
