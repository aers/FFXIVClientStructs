using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct PostEffectVignettingParameters {
    [FieldOffset(0x00)] public float AspectRatioBlend;
    [FieldOffset(0x04)] public float RadiusSquared;
    [FieldOffset(0x08)] public float Falloff;
    [FieldOffset(0x0C)] public Vector3 Color;
}
