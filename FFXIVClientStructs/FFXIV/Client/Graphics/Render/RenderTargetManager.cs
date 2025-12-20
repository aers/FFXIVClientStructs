using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::RenderTargetManager
//   Client::Graphics::Singleton
//   Client::Graphics::Kernel::Notifier
[GenerateInterop]
[Inherits<Notifier>]
[StructLayout(LayoutKind.Explicit, Size = 0x730)]
public unsafe partial struct RenderTargetManager {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 44 8B 86", 3, isPointer: true)]
    public static partial RenderTargetManager* Instance();

    /// <remarks>
    /// | Index | Type                                 |
    /// | ----- | ------------------------------------ |
    /// | 0     | RGB: World-space normal map / A: ??? |
    /// | 1     | ???                                  |
    /// | 2     | RGB: Diffuse map / A: ???            |
    /// | 3     | ???                                  |
    /// | 4     | ???                                  |
    /// </remarks>
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray5<Pointer<Texture>> _gBuffers;
    [FieldOffset(0x48)] internal Texture* Unk48; // Light?
    [FieldOffset(0x50)] internal Texture* Shadow;
    [FieldOffset(0x58)] internal Texture* LightDiffuse;
    [FieldOffset(0x60)] internal Texture* LightSpecular;
    [FieldOffset(0x68)] internal Texture* Unk68; // VFX?
    [FieldOffset(0x70)] internal Texture* Unk70; // Depth/Stencil?
    [FieldOffset(0x78)] internal Texture* Unk78; // depends on byte at GraphicsConfig+0x43
    [FieldOffset(0x80)] internal Texture* Unk80; // Looks the same as Unk70
    [FieldOffset(0x88)] internal Texture* Unk88; // Looks the same as Unk70
    [FieldOffset(0x90)] internal Texture* Unk90; // Looks the same as Unk70
    [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray5<Pointer<Texture>> _semitransparentGBuffers;
    [FieldOffset(0xC0)] internal Texture* UnkC0; // Light?
    [FieldOffset(0xC8)] internal Texture* SemitransparentShadow;
    [FieldOffset(0xD0)] internal Texture* SemitransparentLightDiffuse;
    [FieldOffset(0xD8)] internal Texture* SemitransparentLightSpecular;
    [FieldOffset(0xE0)] internal Texture* UnkE0; // VFX?
    [FieldOffset(0xE8)] internal Texture* UnkE8; // Looks the same as Unk70
    [FieldOffset(0xF0)] internal Texture* UnkF0; // null?
    [FieldOffset(0xF8)] internal Texture* UnkF8; // null?
    [FieldOffset(0x100)] internal Texture* Unk100; // Looks the same as Unk68
    [FieldOffset(0x108)] internal Texture* Unk108;
    [FieldOffset(0x110)] internal Texture* Unk110; // Opaque passes, seems to combine screen-space coordinates and depth somehow?
    [FieldOffset(0x118)] internal Texture* Unk118; // Equivalent of Unk110 for semitransparent passes
    [FieldOffset(0x120)] internal Texture* Unk120;
    [FieldOffset(0x128)] internal Texture* Unk128;
    [FieldOffset(0x130)] internal Texture* Unk130;
    [FieldOffset(0x138)] internal Texture* Unk138; // Depth of player's character viewed from below?
    [FieldOffset(0x140)] internal Texture* Unk140;
    [FieldOffset(0x148)] internal Texture* Unk148;
    [FieldOffset(0x150)] internal Texture* Unk150; // null?
    [FieldOffset(0x158)] internal Texture* Unk158;
    [FieldOffset(0x160), FixedSizeArray] internal FixedSizeArray4<Pointer<Texture>> _unk160; // Shadows?
    [FieldOffset(0x180)] internal Texture* Unk180; // Shadows?
    [FieldOffset(0x188), FixedSizeArray] internal FixedSizeArray20<Pointer<Texture>> _unk188; // Shadows?
    [FieldOffset(0x228)] internal Texture* Unk228; // Shadows?
    [FieldOffset(0x230), FixedSizeArray] internal FixedSizeArray4<Pointer<Texture>> _unk230; // Shadows?
    [FieldOffset(0x250)] internal Texture* Unk250;
    [FieldOffset(0x258)] internal Texture* Unk258; // Looks the same as Unk68
    [FieldOffset(0x260)] internal Texture* Unk260; // Bloom?
    [FieldOffset(0x268)] internal Texture* Unk268; // Sun?
    [FieldOffset(0x270)] internal Texture* Unk270; // Some compositing mask?
    [FieldOffset(0x278)] internal Texture* Unk278; // Sun?
    [FieldOffset(0x280)] internal Texture* Unk280; // Vignetting? (depends on that graphics setting)
    [FieldOffset(0x288)] internal Texture* Unk288; // Looks the same as Unk68 but downscaled 1:4
    [FieldOffset(0x290)] internal Texture* Unk290;
    [FieldOffset(0x298)] internal Texture* Unk298; // Looks the same as Unk260 but downscaled 1:2
    [FieldOffset(0x2A0), FixedSizeArray] internal FixedSizeArray3<Pointer<Texture>> _unk2A0; // Bloom?
    [FieldOffset(0x2B8), FixedSizeArray] internal FixedSizeArray2<Pointer<Texture>> _unk2B8;
    /// <remarks> Use <see cref="GetCharaViewTexture(uint)"/> instead. </remarks>
    [FieldOffset(0x2C8), FixedSizeArray] internal FixedSizeArray8<Pointer<Texture>> _charaViewTextures; // resulting image
    // CharaView targets:
    [FieldOffset(0x308), FixedSizeArray] internal FixedSizeArray5<Pointer<Texture>> _charaViewGBuffers;
    [FieldOffset(0x330)] internal Texture* Unk330;
    [FieldOffset(0x338)] internal Texture* Unk338; // null?
    [FieldOffset(0x340)] internal Texture* Unk340; // null?
    [FieldOffset(0x348)] internal Texture* Unk348; // null?
    [FieldOffset(0x350)] internal Texture* Unk350; // null?
    [FieldOffset(0x358)] internal Texture* Unk358; // Equivalent of Unk110 for CharaView
    [FieldOffset(0x360)] internal Texture* Unk360; // Depth/Stencil for CharaView?
    [FieldOffset(0x368)] internal Texture* Unk368; // Looks the same as Unk360
    [FieldOffset(0x370)] internal Texture* Unk370; // temp target for ui when changing graphic settings
    // CharaView semitransparent targets:
    [FieldOffset(0x378), FixedSizeArray] internal FixedSizeArray5<Pointer<Texture>> _charaViewSemitransparentGBuffers;
    [FieldOffset(0x3A0)] internal Texture* Unk3A0; // null?
    [FieldOffset(0x3A8)] internal Texture* Unk3A8; // null?
    [FieldOffset(0x3B0)] internal Texture* Unk3B0; // null?
    [FieldOffset(0x3B8)] internal Texture* Unk3B8; // null?
    [FieldOffset(0x3C0)] internal Texture* Unk3C0; // null?
    [FieldOffset(0x3C8)] internal Texture* Unk3C8; // Some portrait semitransparent buffer?
    [FieldOffset(0x3D0)] internal Texture* Unk3D0;
    [FieldOffset(0x3D8)] internal Texture* Unk3D8;
    [FieldOffset(0x3E0)] internal Texture* Unk3E0; // Equivalent of Unk270 for CharaView
    [FieldOffset(0x3E8), FixedSizeArray] internal FixedSizeArray2<Pointer<Texture>> _unk3E8;
    [FieldOffset(0x3F8), FixedSizeArray] internal FixedSizeArray2<Pointer<Texture>> _unk3F8;
    [FieldOffset(0x408), FixedSizeArray] internal FixedSizeArray3<Pointer<Texture>> _unk408;
    [FieldOffset(0x420)] internal Texture* Unk420;
    [FieldOffset(0x428)] public uint Resolution_Width;
    [FieldOffset(0x42C)] public uint Resolution_Height;
    [FieldOffset(0x430)] public uint ShadowMap_Width;
    [FieldOffset(0x434)] public uint ShadowMap_Height;
    [FieldOffset(0x438)] public uint NearShadowMap_Width;
    [FieldOffset(0x43C)] public uint NearShadowMap_Height;
    [FieldOffset(0x440)] public uint FarShadowMap_Width;
    [FieldOffset(0x444)] public uint FarShadowMap_Height;
    [FieldOffset(0x448)] private bool UnkBool_1;

    [FieldOffset(0x4A8)] internal Texture* Unk4A8; // Looks the same as Unk68
    [FieldOffset(0x4B0)] internal Texture* Unk4B0; // Looks the same as Unk68

    [FieldOffset(0x4C0)] internal Texture* Unk4C0; // Looks the same as Unk68
    [FieldOffset(0x4C8)] internal Texture* Unk4C8; // Looks the same as Unk68
    [FieldOffset(0x4D0)] internal Texture* Unk4D0; // Looks the same as Unk68
    [FieldOffset(0x4D8)] internal Texture* Unk4D8; // Looks the same as Unk68
    [FieldOffset(0x4E0)] internal Texture* Unk4E0;
    [FieldOffset(0x4E8)] internal Texture* Unk4E8;

    [FieldOffset(0x528)] internal Texture* Unk528;
    [FieldOffset(0x530)] internal Texture* Unk530;

    [FieldOffset(0x540)] internal Texture* Unk540;
    [FieldOffset(0x548)] internal Texture* Unk548;
    [FieldOffset(0x550)] internal Texture* Unk550;
    [FieldOffset(0x558)] internal Texture* Unk558;
    [FieldOffset(0x560)] internal Texture* Unk560;
    [FieldOffset(0x568)] internal Texture* Unk568;
    [FieldOffset(0x570)] internal Texture* Unk570;
    [FieldOffset(0x578)] internal Texture* Unk578; // apparently BackBuffer, see 48 89 87 ?? ?? ?? ?? 48 8B 47 ?? 48 89 87 ?? ?? ?? ?? 8B 06
    [FieldOffset(0x580)] internal Texture* Unk580;
    [FieldOffset(0x588)] internal Texture* Unk588;
    [FieldOffset(0x590)] internal Texture* Unk590;
    [FieldOffset(0x598)] internal Texture* Unk598;
    [FieldOffset(0x5A0)] internal Texture* Unk5A0;
    [FieldOffset(0x5A8)] internal Texture* Unk5A8;
    [FieldOffset(0x5B0)] internal Texture* Unk5B0;
    [FieldOffset(0x5B8)] internal Texture* Unk5B8;
    [FieldOffset(0x5C0)] internal Texture* Unk5C0;
    [FieldOffset(0x5C8)] internal Texture* Unk5C8;
    [FieldOffset(0x5D0)] internal Texture* Unk5D0;
    [FieldOffset(0x5D8)] internal Texture* Unk5D8; // AO?
    [FieldOffset(0x5E0)] internal Texture* Unk5E0;
    [FieldOffset(0x5E8)] internal Texture* Unk5E8;
    [FieldOffset(0x5F0)] internal Texture* Unk5F0;
    [FieldOffset(0x5F8)] internal Texture* Unk5F8;
    [FieldOffset(0x600)] internal Texture* Unk600;
    [FieldOffset(0x608)] internal Texture* Unk608; // GTAO stuff?
    [FieldOffset(0x610)] internal Texture* Unk610; // GTAO stuff?
    [FieldOffset(0x618)] internal Texture* Unk618; // GTAO stuff?
    [FieldOffset(0x620)] internal Texture* Unk620; // GTAO stuff?
    [FieldOffset(0x628)] internal Texture* Unk628;
    [FieldOffset(0x630)] internal Texture* Unk630; // GTAO stuff?
    [FieldOffset(0x638)] internal Texture* Unk638;
    [FieldOffset(0x640)] internal Texture* Unk640;
    [FieldOffset(0x648)] internal Texture* Unk648;
    [FieldOffset(0x650)] internal Texture* Unk650;
    [FieldOffset(0x658)] internal Texture* Unk658;
    [FieldOffset(0x660)] internal Texture* Unk660;
    [FieldOffset(0x668)] internal Texture* Unk668;
    [FieldOffset(0x670)] internal Texture* Unk670;
    [FieldOffset(0x678)] internal Texture* Unk678;
    [FieldOffset(0x680)] internal Texture* Unk680;
    [FieldOffset(0x688)] internal Texture* Unk688; // Looks the same as Unk68
    [FieldOffset(0x690)] internal Texture* Unk690; // Looks the same as Unk70
    [FieldOffset(0x698)] internal nint Unk698; // Unknown class, implements C::G::K::Notifier, holds a bunch of D3D11 objects
    [FieldOffset(0x6A0)] internal nint Unk6A0; // Same class as Unk698
    // bunch of floats
    [FieldOffset(0x6E0)] public float FrametimeAverage; // Offset most likely wrong, idk the right one

    [FieldOffset(0x6EC)] public float GraphicsRezoScale; // Offset most likely wrong, idk the right one

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 48 8B D0 FF D3")]
    public partial Texture* GetCharaViewTexture(uint clientObjectIndex);
}
