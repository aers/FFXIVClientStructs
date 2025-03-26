namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::GraphicsConfig
//   Client::Graphics::Singleton
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct GraphicsConfig {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 0F B6 8B ?? ?? ?? ?? 88 48", 3, isPointer: true)]
    public static partial GraphicsConfig* Instance();

    [FieldOffset(0x08)] public uint UpdateFlags;
    // most fields are named after the corresponding ConfigOption
    [FieldOffset(0x0C)] public byte Gamma;

    [FieldOffset(0x10)] public bool LodType;

    [FieldOffset(0x12)] public bool ShadowLOD;
    [FieldOffset(0x13)] public bool ShadowBgLOD;

    [FieldOffset(0x17)] public bool ParallaxOcclusion;
    [FieldOffset(0x18)] public bool Tessellation;

    [FieldOffset(0x20)] public byte ReflectionType;
    [FieldOffset(0x21)] public bool GlareRepresentation;
    [FieldOffset(0x22)] public byte GrassQuality;
    [FieldOffset(0x23)] public byte SSAO;
    [FieldOffset(0x24)] public byte Glare;
    [FieldOffset(0x25)] public bool GlareStrong; // Glare >= 2
    [FieldOffset(0x26)] public bool DepthOfField;

    [FieldOffset(0x28)] public bool RadialBlur;
    [FieldOffset(0x29)] public bool Vignetting;

    [FieldOffset(0x2C)] public uint AntiAliasing;
    [FieldOffset(0x30)] public byte TextureFilterQuality;
    [FieldOffset(0x31)] public byte TextureAnisotropicQuality;

    [FieldOffset(0x33)] public bool TranslucentQuality;
    [FieldOffset(0x34)] public byte ShadowVisibilityTypeFlags;
    [FieldOffset(0x35)] public byte ShadowSoftShadowType;
    [FieldOffset(0x36)] public byte ShadowTextureSizeType;
    [FieldOffset(0x37)] public byte ShadowCascadeCountType;
    [FieldOffset(0x39)] public byte TargetCircleType;
    [FieldOffset(0x3A)] public byte TargetLineType;
    [FieldOffset(0x3B)] public byte LinkLineType;

    [FieldOffset(0x40)] public byte CharaLight;
    [FieldOffset(0x41)] public byte ShadowLightValidType;

    [FieldOffset(0x44)] public byte DynamicRezoEnable;

    [FieldOffset(0x46)] public bool DynamicRezoEnableCutScene;

    [FieldOffset(0x49)] public byte DynamicRezoThreshold;

    [FieldOffset(0x4C)] public float GraphicsRezoScale;

    [FieldOffset(0x54)] public byte GraphicsRezoUpscaleType;

    [FieldOffset(0x56)] public bool GrassEnableDynamicInterference;
}
