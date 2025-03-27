using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Camera
//   Client::Graphics::ReferencedClassBase
[GenerateInterop(isInherited: true)]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct Camera {
    [FieldOffset(0x010)] public Matrix4x4 ViewMatrix;
    [FieldOffset(0x050)] public Matrix4x4 ProjectionMatrix2;
    [FieldOffset(0x090)] public Vector3 Origin;
    [FieldOffset(0x1A0)] public Matrix4x4 ProjectionMatrix;

    [FieldOffset(0x1E8)] public float FoV;
    [FieldOffset(0x1EC)] public float FoV_2; // if a flag is passed to the set method this will be set alongside FoV, haven't seen anything read it
    [FieldOffset(0x1F0)] public float AspectRatio;
    [FieldOffset(0x1F4)] public float NearPlane;
    [FieldOffset(0x1F8)] public float FarPlane;
    [FieldOffset(0x1FC)] public float OrthoHeight;
    [FieldOffset(0x200)] public bool IsOrtho;

    [FieldOffset(0x203)] public bool StandardZ; // if false, use reversed Z mapping for projection matrix (far plane to 0, near plane to 1 after perspective divide)
    [FieldOffset(0x204)] public bool FiniteFarPlane; // if false, use infinite far plane for projection matrix
}
