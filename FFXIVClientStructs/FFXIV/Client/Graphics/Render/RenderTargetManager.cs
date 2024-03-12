using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::RenderTargetManager
//   Client::Graphics::Singleton
//   Client::Graphics::Kernel::Notifier
// WARNING: THIS IS OUT OF DATE
[StructLayout(LayoutKind.Explicit, Size = 0x4A0)]
public unsafe partial struct RenderTargetManager {
    [FieldOffset(0x0)] public void* vtbl;

    [FieldOffset(0x8)] public Notifier Notifier;

    // the first 65 fields seem to be render target pointers
    [FixedSizeArray<Pointer<Texture>>(65)]
    [FieldOffset(0x20)] public fixed byte RenderTargetArray[8 * 65];

    // specific ones i can name
    // offscreen renderer is used to render models for UI elements like the character window
    [FieldOffset(0x1E0), CExportIgnore] public Texture* OffscreenRenderTarget_1;
    [FieldOffset(0x1E8), CExportIgnore] public Texture* OffscreenRenderTarget_2;
    [FieldOffset(0x1F0), CExportIgnore] public Texture* OffscreenRenderTarget_3;
    [FieldOffset(0x1F8), CExportIgnore] public Texture* OffscreenRenderTarget_4;
    [FieldOffset(0x200), CExportIgnore] public Texture* OffscreenGBuffer;
    [FieldOffset(0x208), CExportIgnore] public Texture* OffscreenDepthStencil;

    [FieldOffset(0x210), CExportIgnore]
    public Texture* OffscreenRenderTarget_Unk1; // these are related to offscreen renderer due to their size

    [FieldOffset(0x218), CExportIgnore] public Texture* OffscreenRenderTarget_Unk2;
    [FieldOffset(0x220), CExportIgnore] public Texture* OffscreenRenderTarget_Unk3;

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

    [FieldOffset(0x470)] public ushort DynamicResolutionActualTargetHeight; // seems to copy TargetHeight into ActualTargetHeight?
    [FieldOffset(0x472)] public ushort DynamicResolutionTargetHeight;
    [FieldOffset(0x474)] public ushort DynamicResolutionMaximumHeight;
    [FieldOffset(0x476)] public ushort DynamicResolutionMinimumHeight;

    [StaticAddress("48 8B 0D ?? ?? ?? ?? 48 8B B1 ?? ?? ?? ??", 3, isPointer: true)]
    public static partial RenderTargetManager* Instance();

    [MemberFunction("48 8B 05 ?? ?? ?? ?? 8B CA 48 8B 84 C8")]
    public partial Texture* GetCharaViewTexture(uint clientObjectIndex);
}
