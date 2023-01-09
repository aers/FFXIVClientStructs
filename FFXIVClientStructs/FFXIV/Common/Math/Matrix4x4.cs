namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct Matrix4x4 : IEquatable<Matrix4x4>
{
    [FieldOffset(0x00)] public fixed float Matrix[16];

    [FieldOffset(0x00)] public float M11;
    [FieldOffset(0x04)] public float M12;
    [FieldOffset(0x08)] public float M13;
    [FieldOffset(0x0C)] public float M14;
    [FieldOffset(0x10)] public float M21;
    [FieldOffset(0x14)] public float M22;
    [FieldOffset(0x18)] public float M23;
    [FieldOffset(0x1C)] public float M24;
    [FieldOffset(0x20)] public float M31;
    [FieldOffset(0x24)] public float M32;
    [FieldOffset(0x28)] public float M33;
    [FieldOffset(0x2C)] public float M34;
    [FieldOffset(0x30)] public float M41;
    [FieldOffset(0x34)] public float M42;
    [FieldOffset(0x38)] public float M43;
    [FieldOffset(0x3C)] public float M44;

    public static readonly Matrix4x4 Zero = new(0.0f);
    public static readonly Matrix4x4 Identity = new() { M11 = 1.0f, M22 = 1.0f, M33 = 1.0f, M44 = 1.0f };
    public bool IsIdentity => Equals(Identity);

    public Vector3 Translation
    {
        readonly get => new(M41, M42, M43);
        set { M41 = value.X; M42 = value.Y; M43 = value.Z; }
    }

    public float this[int index]
    {
        get => index is >= 0 and < 16 ? Matrix[index] : throw new IndexOutOfRangeException($"{index}");
        set
        {
            if (index is >= 0 and < 16) Matrix[index] = value;
            else throw new IndexOutOfRangeException($"{index}");
        }
    }

    public float this[int row, int column]
    {
        get => this[column + row * 4];
        set => this[column + row * 4] = value;
    }

    public Matrix4x4(float value)
    {
        M11 = M12 = M13 = M14 =
        M21 = M22 = M23 = M24 =
        M31 = M32 = M33 = M34 =
        M41 = M42 = M43 = M44 = value;
    }

    public static Matrix4x4 CreateFromQuaternion(Quaternion quaternion)
    {
        var xx = quaternion.X * quaternion.X;
        var yy = quaternion.Y * quaternion.Y;
        var zz = quaternion.Z * quaternion.Z;

        var xy = quaternion.X * quaternion.Y;
        var wz = quaternion.Z * quaternion.W;
        var xz = quaternion.Z * quaternion.X;
        var wy = quaternion.Y * quaternion.W;
        var yz = quaternion.Y * quaternion.Z;
        var wx = quaternion.X * quaternion.W;

        return Identity with
        {
            M11 = 1.0f - 2.0f * (yy + zz),
            M12 = 2.0f * (xy + wz),
            M13 = 2.0f * (xz - wy),
            M21 = 2.0f * (xy - wz),
            M22 = 1.0f - 2.0f * (zz + xx),
            M23 = 2.0f * (yz + wx),
            M31 = 2.0f * (xz + wy),
            M32 = 2.0f * (yz - wx),
            M33 = 1.0f - 2.0f * (yy + xx)
        };
    }

    public static Matrix4x4 CreateFromYawPitchRoll(float yaw, float pitch, float roll)
    {
        var q = Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll);
        return CreateFromQuaternion(q);
    }

    public static Matrix4x4 CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
    {
        var zaxis = Vector3.Normalize(cameraPosition - cameraTarget);
        var xaxis = Vector3.Normalize(Vector3.Cross(cameraUpVector, zaxis));
        var yaxis = Vector3.Cross(zaxis, xaxis);

        return Identity with
        {
            M11 = xaxis.X,
            M21 = xaxis.Y,
            M31 = xaxis.Z,
            M12 = yaxis.X,
            M22 = yaxis.Y,
            M32 = yaxis.Z,
            M13 = zaxis.X,
            M23 = zaxis.Y,
            M33 = zaxis.Z,
            M41 = -Vector3.Dot(xaxis, cameraPosition),
            M42 = -Vector3.Dot(yaxis, cameraPosition),
            M43 = -Vector3.Dot(zaxis, cameraPosition)
        };
    }

    public static Matrix4x4 CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
    {
        var zaxis = Vector3.Normalize(-forward);
        var xaxis = Vector3.Normalize(Vector3.Cross(up, zaxis));
        var yaxis = Vector3.Cross(zaxis, xaxis);
        return Identity with
        {
            M11 = xaxis.X,
            M12 = xaxis.Y,
            M13 = xaxis.Z,
            M21 = yaxis.X,
            M22 = yaxis.Y,
            M23 = yaxis.Z,
            M31 = zaxis.X,
            M32 = zaxis.Y,
            M33 = zaxis.Z,
            M41 = position.X,
            M42 = position.Y,
            M43 = position.Z
        };
    }

    public static bool Invert(Matrix4x4 matrix, out Matrix4x4 result)
    {
        var r = System.Numerics.Matrix4x4.Invert(matrix, out var invMatrix);
        result = invMatrix;
        return r;
    }

    public static bool Decompose(Matrix4x4 matrix, out Vector3 scale, out Quaternion rotation, out Vector3 translation)
    {
        var result = System.Numerics.Matrix4x4.Decompose(matrix, out var s, out var r, out var t);
        scale = s;
        rotation = r;
        translation = t;
        return result;
    }

    public static Matrix4x4 Lerp(Matrix4x4 start, Matrix4x4 end, float amount)
    {
        return LerpUnclamped(start, end, System.Math.Clamp(amount, 0.0f, 1.0f));
    }

    public static Matrix4x4 LerpUnclamped(Matrix4x4 start, Matrix4x4 end, float amount)
    {
        return start + (end - start) * amount;
    }

    public static Matrix4x4 SmoothStep(Matrix4x4 start, Matrix4x4 end, float amount)
    {
        amount = System.Math.Clamp(amount, 0.0f, 1.0f);
        var step = amount * amount * (3.0f - 2.0f * amount);
        return LerpUnclamped(start, end, step);
    }

    public static Matrix4x4 Transpose(Matrix4x4 matrix)
    {
        return new Matrix4x4
        {
            M11 = matrix.M11,
            M12 = matrix.M21,
            M13 = matrix.M31,
            M14 = matrix.M41,
            M21 = matrix.M12,
            M22 = matrix.M22,
            M23 = matrix.M32,
            M24 = matrix.M42,
            M31 = matrix.M13,
            M32 = matrix.M23,
            M33 = matrix.M33,
            M34 = matrix.M43,
            M41 = matrix.M14,
            M42 = matrix.M24,
            M43 = matrix.M34,
            M44 = matrix.M44
        };
    }

    public static implicit operator System.Numerics.Matrix4x4(Matrix4x4 matrix) => *(System.Numerics.Matrix4x4*)&matrix;
    public static implicit operator Matrix4x4(System.Numerics.Matrix4x4 matrix) => *(Matrix4x4*)&matrix;

    public static Matrix4x4 operator +(Matrix4x4 a, Matrix4x4 b) => System.Numerics.Matrix4x4.Add(a, b);
    public static Matrix4x4 operator -(Matrix4x4 a, Matrix4x4 b) => System.Numerics.Matrix4x4.Subtract(a, b);
    public static Matrix4x4 operator -(Matrix4x4 a) => System.Numerics.Matrix4x4.Negate(a);
    public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b) => System.Numerics.Matrix4x4.Multiply(a, b);
    public static Matrix4x4 operator *(Matrix4x4 a, float b) => System.Numerics.Matrix4x4.Multiply(a, b);

    public static bool operator ==(Matrix4x4 left, Matrix4x4 right) => left.Equals(right);
    public static bool operator !=(Matrix4x4 left, Matrix4x4 right) => !left.Equals(right);

    public bool Equals(Matrix4x4 other) => ((System.Numerics.Matrix4x4)this).Equals(other);
    public override bool Equals(object? obj) => obj is Matrix4x4 other && Equals(other);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(M11); hashCode.Add(M12); hashCode.Add(M13); hashCode.Add(M14);
        hashCode.Add(M21); hashCode.Add(M22); hashCode.Add(M23); hashCode.Add(M24);
        hashCode.Add(M31); hashCode.Add(M32); hashCode.Add(M33); hashCode.Add(M34);
        hashCode.Add(M41); hashCode.Add(M42); hashCode.Add(M43); hashCode.Add(M44);
        return hashCode.ToHashCode();
    }

    public override string ToString() => ((System.Numerics.Matrix4x4)this).ToString();
}