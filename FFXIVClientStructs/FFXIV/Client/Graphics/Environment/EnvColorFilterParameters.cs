using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Environment;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5C)]
public unsafe partial struct EnvColorFilterParameters {
    [FieldOffset(0x00)] public Vector4 Curve;
    [FieldOffset(0x10)] public float Hue;
    [FieldOffset(0x14)] public float Saturation;
    [FieldOffset(0x18)] public float Brightness;
    [FieldOffset(0x1C)] public float Contrast;
    [FieldOffset(0x20)] public global::System.Numerics.Vector3 TintColor;
    [FieldOffset(0x2C)] public float TintStrength;
    [FieldOffset(0x30)] public float Sepia;
    [FieldOffset(0x34)] public float Monochrome;
    [FieldOffset(0x38)] public float Invert;
    [FieldOffset(0x3C)] public float DarkSaturation;
    [FieldOffset(0x40)] public global::System.Numerics.Vector3 DarkTintColor;
    [FieldOffset(0x4C)] public float DarkThreshold;
    [FieldOffset(0x50)] public float DarkRange;
    [FieldOffset(0x54)] public float DarkTintStrength;
    [FieldOffset(0x58)] public float Strength;

    [MemberFunction("E8 ?? ?? ?? ?? 8B 46 78 48 8D 55 ?? F3 0F 10 45 ??")]
    public partial void BuildMatrix(Matrix4x4* output);
}
