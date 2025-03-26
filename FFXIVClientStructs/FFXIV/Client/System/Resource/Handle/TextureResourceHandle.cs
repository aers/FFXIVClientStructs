using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::TextureResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
// ctor "40 53 48 83 EC 30 48 8B 44 24 ?? 48 8B D9 48 89 44 24 ?? 48 8B 44 24 ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 81 A3"
[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe partial struct TextureResourceHandle {
    [FieldOffset(0xB0)] public TexFileHeader Header;
    [FieldOffset(0x128)] public Texture* Texture;
    /// <remarks> Only known valid during <see cref="ResourceHandle.Load"/>. </remarks>
    [FieldOffset(0x130)] public Texture* TextureWhileLoading;
    /// <remarks> Only known valid during <see cref="ResourceHandle.Load"/>. </remarks>
    [FieldOffset(0x148)] public void* DataWhileLoading;

    // From Lumina.Data.Files.TexFile.TexHeader.
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct TexFileHeader {
        [FieldOffset(0)] public TextureFlags Type;
        [FieldOffset(0x4)] public TextureFormat Format;
        [FieldOffset(0x8)] public ushort Width;
        [FieldOffset(0xA)] public ushort Height;
        [FieldOffset(0xC)] public ushort Depth;
        [FieldOffset(0xE)] public byte MipCountAndFlag;
        [FieldOffset(0xF)] public byte ArraySize;
        [FieldOffset(0x10)] private FixedSizeArray3<uint> _lodOffsets;
        [FieldOffset(0x1C)] private FixedSizeArray13<uint> _offsetsToSurfaces;
    }
}
