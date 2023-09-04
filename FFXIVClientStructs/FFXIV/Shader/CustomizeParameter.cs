using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Shader;

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public struct CustomizeParameter {
    /// <summary>
    /// XYZ : Skin diffuse color, as squared RGB.
    /// W : Muscle tone.
    /// </summary>
    [FieldOffset(0x0)]
    public Vector4 SkinColor;
    /// <summary>
    /// XYZ : Skin specular color, as squared RGB.
    /// </summary>
    [FieldOffset(0x10)]
    public Vector4 SkinFresnelValue0;

    /// <summary>
    /// XYZ : Lip diffuse color, as squared RGB.
    /// W : Lip opacity.
    /// </summary>
    [FieldOffset(0x20)]
    public Vector4 LipColor;

    /// <summary>
    /// XYZ : Hair primary color, as squared RGB.
    /// </summary>
    [FieldOffset(0x30)]
    public Vector3 MainColor;
    /// <summary>
    /// XYZ : Hair specular color, as squared RGB.
    /// </summary>
    [FieldOffset(0x40)]
    public Vector3 HairFresnelValue0;
    /// <summary>
    /// XYZ : Hair highlight color, as squared RGB.
    /// </summary>
    [FieldOffset(0x50)]
    public Vector3 MeshColor;

    /// <summary>
    /// XYZ : Left eye color, as squared RGB.
    /// W : Face paint (UV2) U multiplier.
    /// </summary>
    [FieldOffset(0x60)]
    public Vector4 LeftColor;
    /// <summary>
    /// XYZ : Right eye color, as squared RGB.
    /// W : Face paint (UV2) U offset.
    /// </summary>
    [FieldOffset(0x70)]
    public Vector4 RightColor;

    /// <summary>
    /// XYZ : Race feature color, as squared RGB.
    /// </summary>
    [FieldOffset(0x80)]
    public Vector3 OptionColor;
}
