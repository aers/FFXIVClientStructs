namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct Vector4 : IEquatable<Vector4>, IFormattable
{
    [FieldOffset(0x0)] public float X;
    [FieldOffset(0x4)] public float Y;
    [FieldOffset(0x8)] public float Z;
    [FieldOffset(0xC)] public float W;

    public static readonly Vector4 Zero = new(0f);
    public static readonly Vector4 One = new(1f);
    public static readonly Vector4 PositiveInfinity = new(float.PositiveInfinity);
    public static readonly Vector4 NegativeInfinity = new(float.NegativeInfinity);

    public float Magnitude => MathF.Sqrt(SqrMagnitude);
    public float SqrMagnitude => X * X + Y * Y + Z * Z + W * W;

    public Vector4(float value) : this(value, value, value, value) { }
    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static Vector4 Normalize(Vector4 value)
    {
        var mag = value.Magnitude;
        return mag > float.Epsilon ? value / mag : Zero;
    }

    public static float Dot(Vector4 left, Vector4 right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
    }

    public static Vector4 Project(Vector4 left, Vector4 right)
    {
        return right * (Dot(left, right) / Dot(right, right));
    }

    public static Vector4 Lerp(Vector4 start, Vector4 end, float amount)
    {
        return LerpUnclamped(start, end, System.Math.Clamp(amount, 0.0f, 1.0f));
    }

    public static Vector4 LerpUnclamped(Vector4 start, Vector4 end, float amount)
    {
        return start + (end - start) * amount;
    }

    public static float Distance(Vector4 a, Vector4 b)
    {
        return MathF.Sqrt(SqrDistance(a, b));
    }

    public static float SqrDistance(Vector4 a, Vector4 b)
    {
        var diff = a - b;
        return Dot(diff, diff);
    }

    public static Vector4 Transform(Vector2 position, Matrix4x4 matrix)
    {
        return new Vector4(
            position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41,
            position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42,
            position.X * matrix.M13 + position.Y * matrix.M23 + matrix.M43,
            position.X * matrix.M14 + position.Y * matrix.M24 + matrix.M44
        );
    }

    public static Vector4 Transform(Vector2 value, Quaternion rotation)
    {
        var x2 = rotation.X + rotation.X;
        var y2 = rotation.Y + rotation.Y;
        var z2 = rotation.Z + rotation.Z;

        var wx2 = rotation.W * x2;
        var wy2 = rotation.W * y2;
        var wz2 = rotation.W * z2;
        var xx2 = rotation.X * x2;
        var xy2 = rotation.X * y2;
        var xz2 = rotation.X * z2;
        var yy2 = rotation.Y * y2;
        var yz2 = rotation.Y * z2;
        var zz2 = rotation.Z * z2;

        return new Vector4(
            value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2),
            value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2),
            value.X * (xz2 - wy2) + value.Y * (yz2 + wx2),
            1.0f
        );
    }

    public static Vector4 Transform(Vector3 position, Matrix4x4 matrix)
    {
        return new Vector4(
            position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
            position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
            position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43,
            position.X * matrix.M14 + position.Y * matrix.M24 + position.Z * matrix.M34 + matrix.M44
        );
    }

    public static Vector4 Transform(Vector3 value, Quaternion rotation)
    {
        var x2 = rotation.X + rotation.X;
        var y2 = rotation.Y + rotation.Y;
        var z2 = rotation.Z + rotation.Z;

        var wx2 = rotation.W * x2;
        var wy2 = rotation.W * y2;
        var wz2 = rotation.W * z2;
        var xx2 = rotation.X * x2;
        var xy2 = rotation.X * y2;
        var xz2 = rotation.X * z2;
        var yy2 = rotation.Y * y2;
        var yz2 = rotation.Y * z2;
        var zz2 = rotation.Z * z2;

        return new Vector4(
            value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
            value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2) + value.Z * (yz2 - wx2),
            value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0f - xx2 - yy2),
            1.0f
        );
    }

    public static Vector4 Transform(Vector4 vector, Matrix4x4 matrix)
    {
        return new Vector4(
            vector.X * matrix.M11 + vector.Y * matrix.M21 + vector.Z * matrix.M31 + vector.W * matrix.M41,
            vector.X * matrix.M12 + vector.Y * matrix.M22 + vector.Z * matrix.M32 + vector.W * matrix.M42,
            vector.X * matrix.M13 + vector.Y * matrix.M23 + vector.Z * matrix.M33 + vector.W * matrix.M43,
            vector.X * matrix.M14 + vector.Y * matrix.M24 + vector.Z * matrix.M34 + vector.W * matrix.M44
        );
    }

    public static Vector4 Transform(Vector4 value, Quaternion rotation)
    {
        var x2 = rotation.X + rotation.X;
        var y2 = rotation.Y + rotation.Y;
        var z2 = rotation.Z + rotation.Z;

        var wx2 = rotation.W * x2;
        var wy2 = rotation.W * y2;
        var wz2 = rotation.W * z2;
        var xx2 = rotation.X * x2;
        var xy2 = rotation.X * y2;
        var xz2 = rotation.X * z2;
        var yy2 = rotation.Y * y2;
        var yz2 = rotation.Y * z2;
        var zz2 = rotation.Z * z2;

        return new Vector4(
            value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
            value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2) + value.Z * (yz2 - wx2),
            value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0f - xx2 - yy2),
            value.W
        );
    }

    public static implicit operator System.Numerics.Vector4(Vector4 v) => new(v.X, v.Y, v.Z, v.W);
    public static implicit operator Vector4(System.Numerics.Vector4 v) => new(v.X, v.Y, v.Z, v.W);

    public static Vector4 operator +(Vector4 a, Vector4 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    public static Vector4 operator -(Vector4 a, Vector4 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    public static Vector4 operator -(Vector4 a) => new(-a.X, -a.Y, -a.Z, -a.W);
    public static Vector4 operator *(Vector4 a, float d) => new(a.X * d, a.Y * d, a.Z * d, a.W * d);
    public static Vector4 operator *(float d, Vector4 a) => new(a.X * d, a.Y * d, a.Z * d, a.W * d);
    public static Vector4 operator /(Vector4 a, float d) => new(a.X / d, a.Y / d, a.Z / d, a.W / d);

    public static bool operator ==(Vector4 left, Vector4 right) => left.Equals(right);
    public static bool operator !=(Vector4 left, Vector4 right) => !left.Equals(right);

    public bool Equals(Vector4 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
    }

    public override bool Equals(object? obj) => obj is Vector4 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

    public override string ToString() => ((System.Numerics.Vector4)this).ToString();
    public string ToString(string? format, IFormatProvider? formatProvider) => ((System.Numerics.Vector4)this).ToString(format, formatProvider);
}
