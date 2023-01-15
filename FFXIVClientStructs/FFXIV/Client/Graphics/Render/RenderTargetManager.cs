namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;
// Client::Graphics::Render::RenderTargetManager
//   Client::Graphics::Singleton
//   Client::Graphics::Kernel::Notifier

// WARNING: THIS IS OUT OF DATE
[StructLayout(LayoutKind.Explicit, Size = 0x480)]
public unsafe partial struct RenderTargetManager
{
    [FieldOffset(0x0)] public void* vtbl;

    [FieldOffset(0x8)] public Notifier Notifier;

    // the first 65 fields seem to be render target pointers
    [FixedSizeArray<Pointer<Texture>>(65)]
    [FieldOffset(0x20)] public fixed byte RenderTargetArray[8 * 65];

    // specific ones i can name
    // offscreen renderer is used to render models for UI elements like the character window
    [FieldOffset(0x1E0)] public Texture* OffscreenRenderTarget_1;
    [FieldOffset(0x1E8)] public Texture* OffscreenRenderTarget_2;
    [FieldOffset(0x1F0)] public Texture* OffscreenRenderTarget_3;
    [FieldOffset(0x1F8)] public Texture* OffscreenRenderTarget_4;
    [FieldOffset(0x200)] public Texture* OffscreenGBuffer;
    [FieldOffset(0x208)] public Texture* OffscreenDepthStencil;

    [FieldOffset(0x210)]
    public Texture* OffscreenRenderTarget_Unk1; // these are related to offscreen renderer due to their size

    [FieldOffset(0x218)] public Texture* OffscreenRenderTarget_Unk2;
    [FieldOffset(0x220)] public Texture* OffscreenRenderTarget_Unk3;

    [FieldOffset(0x248)] public uint Resolution_Width;
    [FieldOffset(0x24C)] public uint Resolution_Height;
    [FieldOffset(0x250)] public uint ShadowMap_Width;
    [FieldOffset(0x254)] public uint ShadowMap_Height;
    [FieldOffset(0x258)] public uint NearShadowMap_Width;
    [FieldOffset(0x25C)] public uint NearShadowMap_Height;
    [FieldOffset(0x260)] public uint FarShadowMap_Width;
    [FieldOffset(0x264)] public uint FarShadowMap_Height;
    [FieldOffset(0x268)] public bool UnkBool_1;

    [FixedSizeArray<Pointer<Texture>>(49)]
    [FieldOffset(0x270)] public fixed byte RenderTargetArray2[8 * 49];

    [StaticAddress("48 8B 0D ?? ?? ?? ?? 48 8B B1 ?? ?? ?? ??", 3, isPointer: true)]
    public static partial RenderTargetManager* Instance();
    
}