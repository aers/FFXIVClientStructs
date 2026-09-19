using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

// Client::Graphics::PostEffect::PostEffectManager
//   Client::Graphics::Singleton
//   Client::Graphics::Kernel::Notifier
[GenerateInterop]
[Inherits<Notifier>(parentOffset: 0x08)]
[StructLayout(LayoutKind.Explicit, Size = 0x48C0)]
public unsafe partial struct PostEffectManager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? 8B 81 70 44 00 00 C1 E8 08 A8 01 0F 85", 3, isPointer: true)]
    public static partial PostEffectManager* Instance();

    [FieldOffset(0x488)] public PostEffectChain DepthOfFieldChain;
    [FieldOffset(0x4C0)] public PostEffectChain DepthOfFieldCoCChain;
    [FieldOffset(0x4F8)] public PostEffectChain UpdatedDepthOfFieldChain;
    [FieldOffset(0x5D8)] public PostEffectChain ColorFilterChain;
    [FieldOffset(0x610)] public PostEffectChain VignettingChain;
    [FieldOffset(0x4010)] public Texture* SceneInput;
    [FieldOffset(0x4030)] public Texture* Depth;
    [FieldOffset(0x4078)] public Texture* SceneOutput;
    [FieldOffset(0x40A0)] private Texture* Unk40A0;
    [FieldOffset(0x40A8)] private Texture* Unk40A8;
    [FieldOffset(0x40B0)] private Texture* Unk40B0;
    [FieldOffset(0x40B8)] private Texture* Unk40B8;
    [FieldOffset(0x40C8)] private Texture* Unk40C8;
    [FieldOffset(0x40D0)] private Texture* Unk40D0;
    [FieldOffset(0x4410)] public ulong InitializedEffects;
    [FieldOffset(0x4470)] public PostEffectFlags Flags;
    [FieldOffset(0x46E8)] public PostEffectDepthOfFieldParameters DepthOfField;
    [FieldOffset(0x471C)] public Vector4 ColorFilterCurve;
    [FieldOffset(0x472C)] public ColorFilterParameters ColorFilter;
    [FieldOffset(0x4808)] public PostEffectVignettingParameters Vignetting;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct ColorFilterParameters {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray3<Vector4> _matrix; // 3x4 RGB transform
        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray3<Vector4> _darkMatrix;
        [FieldOffset(0x60)] public global::System.Numerics.Vector3 DarkParameters;
        [FieldOffset(0x6C)] public float Strength;
    }
}

[Flags]
public enum PostEffectFlags : uint {
    None = 0,
    AmbientOcclusion = 1 << 0,
    AntiAliasing = 1 << 1,
    Sky = 1 << 2,
    Moon = 1 << 3,
    SkyHaloRainbow = 1 << 4,
    Halo = 1 << 5,
    Fog = 1 << 6,
    DepthOfField = 1 << 7,
    CameraMotionBlur = 1 << 8,
    RadialBlur = 1 << 9,
    Glare = 1 << 10,
    GodRays = 1 << 11,
    LensFlare = 1 << 12,
    ToneMapping = 1 << 13,
    Saturate = 1 << 14,
    ColorFilterDarkBlend = 1 << 15,
    Vignetting = 1 << 16,
    ToneAdjust = 1 << 17,
    ChromaticAberration = 1 << 18,
    LetterBox = 1 << 19,
}
