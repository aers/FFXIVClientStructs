namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// there's 20+ of these but these are the ones I've encountered/debugged
public enum TextureFormat : uint
{
    R8G8B8A8 = 5200,
    D24S8 = 16976 // depth 28 stencil 8, see MS texture formats on google if you really care :)
}

// Client::Graphics::Kernel::Texture
//   Client::Graphics::Kernel::Resource
//     Client::Graphics::Kernel::DelayedReleaseClassBase
//       Client::Graphics::ReferencedClassBase
//   Client::Graphics::Kernel::Notifier

// renderer texture object, contains platform specific render objects (DX9/DX11/PS3/PS4)

// size = 0xA8
// ctor E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 41 B9 ?? ?? ?? ?? 48 89 07 48 8B CF
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe struct Texture
{
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x20)] public Notifier Notifier;
    [FieldOffset(0x38)] public uint Width;
    [FieldOffset(0x3C)] public uint Height;
    [FieldOffset(0x40)] public uint Width2;
    [FieldOffset(0x44)] public uint Height2;
    [FieldOffset(0x48)] public uint Width3; // new in 6.3
    [FieldOffset(0x4C)] public uint Height3; // new in 6.3
    [FieldOffset(0x50)] public uint Depth; // for 3d textures like the material tiling texture
    [FieldOffset(0x54)] public byte MipLevel;
    [FieldOffset(0x55)] public byte Unk_55;
    [FieldOffset(0x56)] public byte Unk_56;
    [FieldOffset(0x57)] public byte Unk_57;
    [FieldOffset(0x58)] public TextureFormat TextureFormat;
    [FieldOffset(0x5C)] public uint Flags;
    [FieldOffset(0x60)] public byte Unk_60; // new in 6.3, maybe a bool
    [FieldOffset(0x68)] public void* D3D11Texture2D; // ID3D11Texture2D1
    [FieldOffset(0x70)] public void* D3D11ShaderResourceView; // ID3D11ShaderResourceView1
}
