using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Class name unknown
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct AtkTextureResource {
    [FieldOffset(0x0)] public uint TexPathHash; // crc32(full path)
    [FieldOffset(0x4)] public int IconID;
    [FieldOffset(0x8)] public TextureResourceHandle* TexFileResourceHandle;

    [FieldOffset(0x10)] public Texture* KernelTextureObject; // Client::Graphics::Kernel::Texture, renderer texture obj

    [FieldOffset(0x18)] public ushort Count;
    [FieldOffset(0x1A)] public byte Version;
    [FieldOffset(0x1B)] public byte ShareCount;
}
