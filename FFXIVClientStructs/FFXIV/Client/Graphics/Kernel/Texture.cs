namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::Texture
//   Client::Graphics::Kernel::Resource
//     Client::Graphics::Kernel::DelayedReleaseClassBase
//       Client::Graphics::ReferencedClassBase
//   Client::Graphics::Kernel::Notifier
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 41 B9 ?? ?? ?? ?? 48 89 07 48 8B CF"
// renderer texture object, contains platform specific render objects (DX9/DX11/PS3/PS4)
[GenerateInterop]
[Inherits<Notifier>(parentOffset: 0x20)]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct Texture {
    [FieldOffset(0x38)] public uint ActualWidth;
    [FieldOffset(0x38), Obsolete($"Use {nameof(ActualWidth)}")] public uint Width;
    [FieldOffset(0x3C)] public uint ActualHeight;
    [FieldOffset(0x3C), Obsolete($"Use {nameof(ActualHeight)}")] public uint Height;
    /// <remarks>Can be > ActualWidth, for example on render targets with dynamic resolution.</remarks>
    [FieldOffset(0x40)] public uint AllocatedWidth;
    [FieldOffset(0x40), Obsolete($"Use {nameof(AllocatedWidth)}")] public uint Width2;
    /// <remarks>Can be > ActualHeight, for example on render targets with dynamic resolution.</remarks>
    [FieldOffset(0x44)] public uint AllocatedHeight;
    [FieldOffset(0x44), Obsolete($"Use {nameof(AllocatedHeight)}")] public uint Height2;
    [FieldOffset(0x48)] public uint Width3; // new in 6.3, so far observed to always be the same as ActualWidth
    [FieldOffset(0x4C)] public uint Height3; // new in 6.3, so far observed to always be the same as ActualHeight
    [FieldOffset(0x50)] public uint Depth; // for 3d textures like the legacy material tiling texture
    [FieldOffset(0x54)] public byte MipLevel;
    [FieldOffset(0x55)] public byte Unk_55;
    [FieldOffset(0x56)] public byte Unk_56;
    [FieldOffset(0x57)] public byte Unk_57;
    [FieldOffset(0x58)] public TextureFormat TextureFormat;
    [FieldOffset(0x5C)] public uint Flags;
    [FieldOffset(0x60)] public byte ArraySize; // new in 6.3
    [FieldOffset(0x68)] public void* D3D11Texture2D; // ID3D11Texture2D1
    [FieldOffset(0x70)] public void* D3D11ShaderResourceView; // ID3D11ShaderResourceView1

    // TODO: use TextureFormat enum for textureFormat API 12 spec
    public static Texture* CreateTexture2D(int width, int height, byte mipLevel, uint textureFormat, uint flags, uint unk) {
        var size = stackalloc int[2];
        size[0] = width;
        size[1] = height;
        return CreateTexture2D(size, mipLevel, textureFormat, flags, unk);
    }

    // TODO: use TextureFormat enum for textureFormat API 12 spec
    public static Texture* CreateTexture2D(int* size, byte mipLevel, uint textureFormat, uint flags, uint unk)
        => Device.Instance()->CreateTexture2D(size, mipLevel, textureFormat, flags, unk);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 02 25")]
    public partial bool InitializeContents(void* contents);

    [VirtualFunction(2u)]
    public partial void IncRef();

    [VirtualFunction(3u)]
    public partial void DecRef();
}

// See also DXGI_FORMATs that end with the same names.
public enum TextureFormat : uint {
    L8_UNORM = 0x1130,
    A8_UNORM = 0x1131,
    R8_UNORM = 0x1132,
    R8_UINT = 0x1133,
    R16_UINT = 0x1140,
    R32_UINT = 0x1150,
    R8G8_UNORM = 0x1240,
    B4G4R4A4_UNORM = 0x1440,
    B5G5R5A1_UNORM = 0x1441,
    B8G8R8A8_UNORM = 0x1450,
    [Obsolete($"Use {nameof(B8G8R8A8_UNORM)}", true)]
    R8G8B8A8 = 0x1450,
    B8G8R8X8_UNORM = 0x1451,
    R16_FLOAT = 0x2140,
    R32_FLOAT = 0x2150,
    R16G16_FLOAT = 0x2250,
    R32G32_FLOAT = 0x2260,
    R11G11B10_FLOAT = 0x2350,
    R16G16B16A16_FLOAT = 0x2460,
    R32G32B32A32_FLOAT = 0x2470,
    BC1_UNORM = 0x3420,
    BC2_UNORM = 0x3430,
    BC3_UNORM = 0x3431,
    /// <remarks> Can also be R16_TYPELESS or R16_UNORM depending on context. </remarks>
    D16_UNORM = 0x4140,
    /// <remarks> Can also be R24G8_TYPELESS or R24_UNORM_X8_TYPELESS depending on context. </remarks>
    D24_UNORM_S8_UINT = 0x4250, // depth 28 stencil 8, see MS texture formats on google if you really care :)
    [Obsolete($"Use {nameof(D24_UNORM_S8_UINT)}", true)]
    D24S8 = 0x4250,
    /// <remarks> Can also be R16_TYPELESS or R16_UNORM depending on context. </remarks>
    D16_UNORM_2 = 0x5140,
    /// <remarks> Can also be R24G8_TYPELESS or R24_UNORM_X8_TYPELESS depending on context. </remarks>
    D24_UNORM_S8_UINT_2 = 0x5150,
    BC4_UNORM = 0x6120,
    BC5_UNORM = 0x6230,
    BC6H_SF16 = 0x6330,
    BC7_UNORM = 0x6432,
    R16_UNORM = 0x7140,
    R16G16_UNORM = 0x7250,
    R10G10B10A2_UNORM_2 = 0x7350,
    R10G10B10A2_UNORM = 0x7450,
    /// <remarks> Can also be R24G8_TYPELESS or R24_UNORM_X8_TYPELESS depending on context. </remarks>
    D24_UNORM_S8_UINT_3 = 0x8250,
}
