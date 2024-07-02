using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Camera
//   Client::Graphics::ReferencedClassBase
[GenerateInterop(isInherited: true)]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct Camera {

    [FieldOffset(0x1A0)] public Matrix4x4 ProjectionMatrix;

    [FieldOffset(0x1E8)] public float FoV;
    [FieldOffset(0x1EC)] public float AspectRatio;
    [FieldOffset(0x1F0)] public float NearPlane;
    [FieldOffset(0x1F4)] public float FarPlane;
}
