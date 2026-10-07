namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::Texture
//   Client::Graphics::Kernel::Resource
//     Client::Graphics::Kernel::DelayedReleaseClassBase
//       Client::Graphics::ReferencedClassBase
//   Client::Graphics::Kernel::Notifier
// renderer texture object, contains platform specific render objects (DX9/DX11/PS3/PS4)
[GenerateInterop]
[Inherits<Notifier>(parentOffset: 0x20)]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct Texture {
    [FieldOffset(0x38)] public uint ActualWidth;
    [FieldOffset(0x3C)] public uint ActualHeight;
    /// <remarks>Can be > ActualWidth, for example on render targets with dynamic resolution.</remarks>
    [FieldOffset(0x40)] public uint AllocatedWidth;
    /// <remarks>Can be > ActualHeight, for example on render targets with dynamic resolution.</remarks>
    [FieldOffset(0x44)] public uint AllocatedHeight;
    [FieldOffset(0x48)] public uint Width3; // new in 6.3, so far observed to always be the same as ActualWidth
    [FieldOffset(0x4C)] public uint Height3; // new in 6.3, so far observed to always be the same as ActualHeight
    [FieldOffset(0x50)] public uint Depth; // for 3d textures like the legacy material tiling texture
    [FieldOffset(0x54)] public byte MipLevel;
    [FieldOffset(0x55)] private byte Unk55;
    [FieldOffset(0x56)] private byte Unk56;
    [FieldOffset(0x57)] private byte Unk57;
    [FieldOffset(0x58)] public TextureFormat TextureFormat;
    [FieldOffset(0x5C)] public TextureFlags Flags;
    [FieldOffset(0x60)] public byte ArraySize; // Face count for cube arrays.
    [FieldOffset(0x68)] public void* D3D11Texture2D; // ID3D11Texture2D1
    [FieldOffset(0x70)] public void* D3D11ShaderResourceView; // ID3D11ShaderResourceView1

    // Each mip of each array element needs its own render target
    [FieldOffset(0x80)] public TextureMipRenderTarget* MipRenderTargets;

    public TextureMipRenderTarget* GetMipRenderTarget(int mipLevel, int arrayElementIndex = 0) {
        // Each mip is stored contiguously. So all elements of the first mip, then the second, etc.
        return &MipRenderTargets[mipLevel * ArraySize + arrayElementIndex];
    }

    public static Texture* CreateTexture2D(int width, int height, byte mipLevel, TextureFormat textureFormat, TextureFlags flags, uint unk) {
        var size = stackalloc int[2];
        size[0] = width;
        size[1] = height;
        return CreateTexture2D(size, mipLevel, textureFormat, flags, unk);
    }

    public static Texture* CreateTexture2D(int* size, byte mipLevel, TextureFormat textureFormat, TextureFlags flags, uint unk)
        => Device.Instance()->CreateTexture2D(size, mipLevel, textureFormat, flags, unk);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? ?? ?? 25 ?? ?? ?? ?? 3D")]
    public partial bool InitializeContents(void* contents);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B D8 48 39 7D")]
    public partial void* Map2D(uint mipLevel, TextureMapResult* result);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 5C 24 ?? EB")]
    public partial void Unmap2D(uint mipLevel);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 56 08 8B CB")]
    public partial void* Map3D(uint mipLevel, TextureMapResult* result);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 C6 FF C5")]
    public partial void Unmap3D(uint mipLevel);

    [MemberFunction("E8 ?? ?? ?? ?? 89 7C 24 ?? 48 8B F0")]
    public partial void* MapCube(uint mipLevel, uint faceIndex, TextureMapResult* result);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 54 24 ?? FF C3")]
    public partial void UnmapCube(uint mipLevel, uint faceIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B E8 48 85 C0 74 ?? 41 8B D5")]
    public partial void* Map2DArray(uint mipLevel, uint arraySlice, TextureMapResult* result);

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 45 0F")]
    public partial void Unmap2DArray(uint mipLevel, uint arraySlice);

    /// <remarks>KeepCpuCopy branch ignores faceIndex.</remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B E8 48 85 C0 74 ?? 8B D7 49 8B CD")]
    public partial void* MapCubeArray(uint mipLevel, uint cubeIndex, uint faceIndex, TextureMapResult* result);

    [MemberFunction("E8 ?? ?? ?? ?? FF C3 41 3B DE 72 ?? FF C6")]
    public partial void UnmapCubeArray(uint mipLevel, uint cubeIndex, uint faceIndex);

    [MemberFunction("44 8B 41 38 48 8B C1 8B CA")]
    public partial uint GetRowPitch(uint mipLevel);

    [MemberFunction("E8 ?? ?? ?? ?? 8B FD 44 8B F0")]
    public partial uint GetDepthPitch(uint mipLevel);

    [VirtualFunction(2u)]
    public partial void IncRef();

    [VirtualFunction(3u)]
    public partial void DecRef();
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct TextureMapResult {
    [FieldOffset(0x00)] public uint RowPitch;
    [FieldOffset(0x04)] public uint DepthPitch;
    [FieldOffset(0x08)] public void* Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct TextureMipRenderTarget {
    [FieldOffset(0x00)] public void* D3D11RenderTargetViewOrDepthStencilView; // ID3D11RenderTargetView(1?) or ID3D11DepthStencilView(1?)
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

// From Lumina.Data.Files.TexFile.Attribute.
[Flags]
public enum TextureFlags : uint {
    DiscardPerFrame = 0x1,
    DiscardPerMap = 0x2,
    Managed = 0x4,
    UserManaged = 0x8,
    CpuRead = 0x10,
    LocationMain = 0x20,
    NoGpuRead = 0x40,
    AlignedSize = 0x80,
    EdgeCulling = 0x100,
    LocationOnion = 0x200,
    ReadWrite = 0x400,
    Immutable = 0x800,
    KeepCpuCopy = 0x1000,
    TextureRenderTarget = 0x100000,
    TextureDepthStencil = 0x200000,
    TextureType1D = 0x400000,
    TextureType2D = 0x800000,
    TextureType3D = 0x1000000,
    TextureType2DArray = 0x10000000,
    TextureTypeCube = 0x2000000,
    TextureTypeCubeArray = 0x12000000,
    TextureTypeMask = 0x13C00000,
    TextureSwizzle = 0x4000000,
    TextureNoTiled = 0x8000000,
    TextureNoSwizzle = 0x80000000,
}
