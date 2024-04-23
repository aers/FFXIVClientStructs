using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct Matrix4x3 {
    [FieldOffset(0x00), CExportIgnore] public fixed float Matrix[12];

    [FieldOffset(0x00), CExportIgnore] public Vector3 Row0;
    [FieldOffset(0x0C), CExportIgnore] public Vector3 Row1;
    [FieldOffset(0x18), CExportIgnore] public Vector3 Row2;
    [FieldOffset(0x24), CExportIgnore] public Vector3 Row3; // aka Translation

    [FieldOffset(0x00)] public float M11;
    [FieldOffset(0x04)] public float M12;
    [FieldOffset(0x08)] public float M13;
    [FieldOffset(0x0C)] public float M21;
    [FieldOffset(0x10)] public float M22;
    [FieldOffset(0x14)] public float M23;
    [FieldOffset(0x18)] public float M31;
    [FieldOffset(0x1C)] public float M32;
    [FieldOffset(0x20)] public float M33;
    [FieldOffset(0x24)] public float M41;
    [FieldOffset(0x28)] public float M42;
    [FieldOffset(0x2C)] public float M43;

    public float this[int index] {
        get => index is >= 0 and < 12 ? Matrix[index] : throw new IndexOutOfRangeException($"{index}");
        set {
            if (index is >= 0 and < 12) Matrix[index] = value;
            else throw new IndexOutOfRangeException($"{index}");
        }
    }

    public float this[int row, int column] {
        get => this[column + row * 3];
        set => this[column + row * 3] = value;
    }

    public static Matrix4x3 Identity = new() { M11 = 1, M22 = 1, M33 = 1 };

    public Matrix4x4 FullMatrix() => new() {
        M11 = M11, M12 = M12, M13 = M13, M14 = 0,
        M21 = M21, M22 = M22, M23 = M23, M24 = 0,
        M31 = M31, M32 = M32, M33 = M33, M34 = 0,
        M41 = M41, M42 = M42, M43 = M43, M44 = 1
    };

    public Vector3 TransformCoordinate(Vector3 local) => new(
        M11 * local.X + M21 * local.Y + M31 * local.Z + M41,
        M12 * local.X + M22 * local.Y + M32 * local.Z + M42,
        M13 * local.X + M23 * local.Y + M33 * local.Z + M43);
}
