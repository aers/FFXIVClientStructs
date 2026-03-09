using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Light
//   Client::Graphics::Render::RenderObject
//     Client::Graphics::ReferencedClassBase
[GenerateInterop]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe partial struct Light {
    /// <summary>
    /// A special <see cref="MaxRange"/> value that disables range checks.
    /// </summary>
    /// <remarks>
    /// This seems to be used for the player-configurable lights in Group Pose.
    /// </remarks>
    public static readonly AxisAlignedBounds UnlimitedMaxRange = new AxisAlignedBounds(new Vector3(-10000.0f, -10000.0f, -10000.0f), new Vector3(10000.0f, 10000.0f, 10000.0f));

    [FieldOffset(0x18)] public LightFlags LightFlags;
    [FieldOffset(0x1C)] public LightShape LightShape;
    [FieldOffset(0x20)] public Transform* Transform;
    [FieldOffset(0x28)] internal Vector4 ColorIntensity;
    [FieldOffset(0x40)] public AxisAlignedBounds MaxRange;
    [FieldOffset(0x60)] public float ShadowPlaneNear;
    [FieldOffset(0x64)] public float ShadowPlaneFar;
    [FieldOffset(0x68)] public LightFalloffType FalloffType;
    [FieldOffset(0x70)] public Vector2 FlatLightSkewAngleDegrees;
    [FieldOffset(0x80)] public float FalloffFactor;
    [FieldOffset(0x84)] public float SpotLightAngleDegrees;
    [FieldOffset(0x88)] public float AngularFalloffDegrees;
    [FieldOffset(0x8C)] public float Range;
    [FieldOffset(0x90)] public float CharacterShadowRange;

    public Vector3 Color { readonly get => new Vector3(ColorIntensity.X, ColorIntensity.Y, ColorIntensity.Z); set => ColorIntensity = new Vector4(value, ColorIntensity.W); }
    public float Intensity { readonly get => ColorIntensity.W; set => ColorIntensity.W = value; }

    // Set by UpdateCulling based on ComputeAxisAlignedBounds
    [FieldOffset(0xA0)] public AxisAlignedBounds CullingBounds;

    // Set by UpdateCulling based on applying this light's transform to MaxRange
    [FieldOffset(0xC0)] public AxisAlignedBounds RangeBounds;
}

[Flags]
public enum LightFlags {
    SpecularHighlights = 1 << 0,
    DynamicShadows = 1 << 1,
    CharacterShadows = 1 << 2,
    ObjectShadows = 1 << 3,
}

// Client::Graphics::Render::LightingManager::LightShape
public enum LightShape : uint {
    /// <summary>
    /// A uniform ambient light with no distinct shape that applies everywhere.
    /// </summary>
    /// <remarks>
    /// Only seems to function in exterior areas.
    /// </remarks>
    WorldLight = 1,

    /// <summary>
    /// A light that emits from its location equally in all directions.
    /// </summary>
    PointLight = 2, // 'area' light

    /// <summary>
    /// A light that emits from its location in a cone along its positive Z axis.
    /// </summary>
    SpotLight = 3,

    /// <summary>
    /// A light that emits from its location in a parallelogram along its positive Z axis.
    /// </summary>
    FlatLight = 4,
}

/// <summary>
/// How the brightness of light hitting a surface varies with the distance to the surface.
/// </summary>
public enum LightFalloffType : uint {
    Linear = 0,
    Quadratic = 1,
    Cubic = 2,
}

