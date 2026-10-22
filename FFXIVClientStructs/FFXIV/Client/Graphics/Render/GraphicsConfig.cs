namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::GraphicsConfig
//   Client::Graphics::Singleton
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct GraphicsConfig {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 0F B6 8B ?? ?? ?? ?? 88 48", 3, isPointer: true)]
    public static partial GraphicsConfig* Instance();

    [FieldOffset(0x08)] public uint UpdateFlags;
    // most fields are named after the corresponding ConfigOption
    [FieldOffset(0x0C)] public byte Gamma;

    [FieldOffset(0x10)] public bool LodType;

    [FieldOffset(0x12)] public bool ShadowLOD;
    [FieldOffset(0x13)] public bool ShadowBgLOD;
    /// <summary> Gates the occlusion tests in <see cref="Culling.CullingManager"/>. Not tied to a ConfigOption, set on load. </summary>
    [FieldOffset(0x14)] public bool OcclusionCulling;

    [FieldOffset(0x15)] public bool CharaWetness;
    [FieldOffset(0x16)] public bool CharaOutline; // based on the state of AtkUnitManagerFlags.UiHidden
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

    /// <summary> Set when the DynamicRezoType option is not 0. </summary>
    [FieldOffset(0x44)] public byte DynamicRezoEnable;
    /// <summary>
    /// Enables render scaling together with <see cref="DynamicRezoEnable"/> or DLSS.
    /// While false the render height stays at <see cref="RenderTargetManager.MaxRenderHeight"/> and DLSS uses DLAA.
    /// Set from the flags of the scene. False when a scene starts.
    /// </summary>
    [FieldOffset(0x45)] public bool DynamicRezoActive;

    [FieldOffset(0x46)] public bool DynamicRezoEnableCutScene;

    [FieldOffset(0x49)] public byte DynamicRezoThreshold;

    [FieldOffset(0x4C)] public float GraphicsRezoScale;

    /// <summary> The option value plus one: 1 = AMD FSR, 2 = NVIDIA DLSS. Reset to 1 without <see cref="Kernel.Device.IsDlssSupported"/>. </summary>
    [FieldOffset(0x54)] public byte GraphicsRezoUpscaleType;
    /// <summary>
    /// Quality mode of <see cref="PostEffect.Dlss.UpdateSettings"/>. Set to <see cref="DlssQualityPreset.Balanced"/>
    /// when <see cref="GraphicsRezoUpscaleType"/> changes. Ignored while <see cref="DynamicRezoActive"/> is false.
    /// </summary>
    [FieldOffset(0x55)] public DlssQualityPreset DlssQuality;

    [FieldOffset(0x56)] public bool GrassEnableDynamicInterference;

    [FieldOffset(0x65)] public bool HousingSSAOEnable;
    [FieldOffset(0x66)] public bool PortraitPreview; // GPose: Preview the framing of the camera composition used in portrait mode.
    [FieldOffset(0x67)] public bool PortraitMode; // GPose: Enter portrait mode, rotating the camera ninety degrees.<br>* Screenshots must be taken manually.

    [FieldOffset(0x6A)] public bool IsIndoor; // This is true when the layouts lvb path contains "ind/", like for houses, apartments, or chambers.

    [FieldOffset(0x78)] public float JitterMultiplier;
    [FieldOffset(0x80)] private ulong PendingEventFlags;
    [FieldOffset(0x88)] private ulong EventFlags;

    public bool ResetTemporalHistory => (EventFlags & 1) != 0;
}

/// <summary>
/// Value of <see cref="GraphicsConfig.DlssQuality"/>. 1 to 6 select an NGX quality mode, other values make
/// <see cref="PostEffect.Dlss.UpdateSettings"/> fail.
/// </summary>
public enum DlssQualityPreset : byte {
    /// <summary>
    /// Picks a mode from the output pixel count: DLAA below 2,073,600 (1920x1080), Quality up to 3,686,400 (2560x1440),
    /// Performance up to 8,294,400 (3840x2160), Ultra Performance above.
    /// </summary>
    Automatic = 0,
    DLAA = 1,
    UltraQuality = 2,
    Quality = 3,
    Balanced = 4,
    Performance = 5,
    UltraPerformance = 6,
}
