using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Camera
//   Client::Graphics::ReferencedClassBase
[GenerateInterop(isInherited: true)]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe partial struct Camera {

    [FieldOffset(0x50)] public Matrix4x4 ProjectionMatrix;

    [FieldOffset(0xA8)] public float FoV;
    [FieldOffset(0xAC)] public float AspectRatio;
    [FieldOffset(0xB0)] public float NearPlane;
    [FieldOffset(0xB4)] public float FarPlane;
}
