using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Shader;

[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public struct CameraParameter {
    [FieldOffset(0x0)]
    public Vector4 ViewMatrixX;
    [FieldOffset(0x10)]
    public Vector4 ViewMatrixY;
    [FieldOffset(0x20)]
    public Vector4 ViewMatrixZ;

    [FieldOffset(0x30)]
    public Vector4 InverseViewMatrixX;
    [FieldOffset(0x40)]
    public Vector4 InverseViewMatrixY;
    [FieldOffset(0x50)]
    public Vector4 InverseViewMatrixZ;

    [FieldOffset(0x60)]
    public Matrix4x4 ViewProjectionMatrix;

    [FieldOffset(0xA0)]
    public Matrix4x4 InverseViewProjectionMatrix;

    [FieldOffset(0xE0)]
    public Matrix4x4 InverseProjectionMatrix;

    [FieldOffset(0x120)]
    public Matrix4x4 ProjectionMatrix;

    [FieldOffset(0x160)]
    public Matrix4x4 MainViewToProjectionMatrix;

    [FieldOffset(0x1A0)]
    public Vector3 EyePosition;

    [FieldOffset(0x1B0)]
    public Vector3 LookAtVector;
}
