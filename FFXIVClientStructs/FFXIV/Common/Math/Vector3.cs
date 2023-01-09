namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct Vector3 : IEquatable<Vector3>, IFormattable
{
    [FieldOffset(0x0)] public float X;
    [FieldOffset(0x4)] public float Y;
    [FieldOffset(0x8)] public float Z;

    public static readonly Vector3 Zero = new(0.0f);
    public static readonly Vector3 One = new(1.0f);
    public static readonly Vector3 Forward = new(0.0f, 0.0f, 1.0f);
    public static readonly Vector3 Back = new(0.0f, 0.0f, -1.0f);
    public static readonly Vector3 Up = new(0.0f, 1.0f, 0.0f);
    public static readonly Vector3 Down = new(0.0f, -1.0f, 0.0f);
    public static readonly Vector3 Right = new(1.0f, 0.0f, 0.0f);
    public static readonly Vector3 Left = new(-1.0f, 0.0f, 0.0f);
    public static readonly Vector3 PositiveInfinity = new(float.PositiveInfinity);
    public static readonly Vector3 NegativeInfinity = new(float.NegativeInfinity);

    public float Magnitude => MathF.Sqrt(SqrMagnitude);
    public float SqrMagnitude => X * X + Y * Y + Z * Z;
    public Vector3 Normalized => Normalize(this);

    public Vector3(float value) : this(value, value, value) { }
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
    {
        return Min(Max(value, min), max);
    }

    public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
    {
        if (vector.SqrMagnitude > maxLength * maxLength)
            return Normalize(vector) * maxLength;
        return vector;
    }

    public static Vector3 Max(Vector3 lhs, Vector3 rhs)
    {
        return new Vector3(MathF.Max(lhs.X, rhs.X), MathF.Max(lhs.Y, rhs.Y), MathF.Max(lhs.Z, rhs.Z));
    }

    public static Vector3 Min(Vector3 lhs, Vector3 rhs)
    {
        return new Vector3(MathF.Min(lhs.X, rhs.X), MathF.Min(lhs.Y, rhs.Y), MathF.Min(lhs.Z, rhs.Z));
    }

    public static Vector3 Normalize(Vector3 value)
    {
        var mag = value.Magnitude;
        return mag > float.Epsilon ? value / mag : Zero;
    }

    public static float Angle(Vector3 from, Vector3 to)
    {
        var d = from.Magnitude * to.Magnitude;
        return d < float.Epsilon ? 0.0f : MathF.Acos(Dot(from, to) / d);
    }

    public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
    {
        var unsignedAngle = Angle(from, to);
        var cross = Cross(from, to);
        float sign = MathF.Sign(axis.X * cross.X + axis.Y * cross.Y + axis.Z * cross.Z);
        return unsignedAngle * sign;
    }

    public static float Dot(Vector3 left, Vector3 right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
    }

    public static Vector3 Cross(Vector3 left, Vector3 right)
    {
        return new Vector3
        {
            X = left.Y * right.Z - left.Z * right.Y,
            Y = left.Z * right.X - left.X * right.Z,
            Z = left.X * right.Y - left.Y * right.X
        };
    }

    public static float Distance(Vector3 a, Vector3 b)
    {
        return MathF.Sqrt(SqrDistance(a, b));
    }

    public static float SqrDistance(Vector3 a, Vector3 b)
    {
        var diff = a - b;
        return Dot(diff, diff);
    }

    public static Vector3 Lerp(Vector3 start, Vector3 end, float amount)
    {
        return LerpUnclamped(start, end, System.Math.Clamp(amount, 0.0f, 1.0f));
    }

    public static Vector3 LerpUnclamped(Vector3 start, Vector3 end, float amount)
    {
        return start + (end - start) * amount;
    }

    public static Vector3 SmoothStep(Vector3 start, Vector3 end, float amount)
    {
        amount = System.Math.Clamp(amount, 0.0f, 1.0f);
        var step = amount * amount * (3.0f - 2.0f * amount);
        return LerpUnclamped(start, end, step);
    }

    public static Vector3 Reflect(Vector3 vector, Vector3 normal)
    {
        return vector - 2.0f * Dot(vector, normal) * normal;
    }

    public static Vector3 Transform(Vector3 position, Matrix4x4 matrix)
    {
        return new Vector3
        {
            X = position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
            Y = position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
            Z = position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43
        };
    }

    public static Vector3 Transform(Vector3 point, Quaternion rotation)
    {
        var x = rotation.X + rotation.X;
        var y = rotation.Y + rotation.Y;
        var z = rotation.Z + rotation.Z;
        var xx = rotation.X * x;
        var yy = rotation.Y * y;
        var zz = rotation.Z * z;
        var xy = rotation.X * y;
        var xz = rotation.X * z;
        var yz = rotation.Y * z;
        var wx = rotation.W * x;
        var wy = rotation.W * y;
        var wz = rotation.W * z;
        return new Vector3
        {
            X = (1.0f - (yy + zz)) * point.X + (xy - wz) * point.Y + (xz + wy) * point.Z,
            Y = (xy + wz) * point.X + (1.0f - (xx + zz)) * point.Y + (yz - wx) * point.Z,
            Z = (xz - wy) * point.X + (yz + wx) * point.Y + (1.0f - (xx + yy)) * point.Z
        };
    }

    public static Vector3 TransformNormal(Vector3 normal, Matrix4x4 matrix)
    {
        return new Vector3
        {
            X = normal.X * matrix.M11 + normal.Y * matrix.M21 + normal.Z * matrix.M31,
            Y = normal.X * matrix.M12 + normal.Y * matrix.M22 + normal.Z * matrix.M32,
            Z = normal.X * matrix.M13 + normal.Y * matrix.M23 + normal.Z * matrix.M33
        };
    }

    public static Vector3 TransformCoordinate(Vector3 coordinate, Matrix4x4 matrix)
    {
        var x = coordinate.X * matrix.M11 + coordinate.Y * matrix.M21 + coordinate.Z * matrix.M31 + matrix.M41;
        var y = coordinate.X * matrix.M12 + coordinate.Y * matrix.M22 + coordinate.Z * matrix.M32 + matrix.M42;
        var z = coordinate.X * matrix.M13 + coordinate.Y * matrix.M23 + coordinate.Z * matrix.M33 + matrix.M43;
        var w = 1.0f / (coordinate.X * matrix.M14 + coordinate.Y * matrix.M24 + coordinate.Z * matrix.M34 + matrix.M44);
        return new Vector3(x * w, y * w, z * w);
    }

    public static Vector3 Project(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix4x4 projectionMatrix)
    {
        var v = TransformCoordinate(vector, projectionMatrix);
        return new Vector3
        {
            X = (1.0f + v.X) * 0.5f * width + x,
            Y = (1.0f - v.Y) * 0.5f * height + y,
            Z = v.Z * (maxZ - minZ) + minZ
        };
    }

    public static Vector3 Unproject(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix4x4 projectionMatrix)
    {
        var v = new Vector3
        {
            X = (vector.X - x) / width * 2.0f - 1.0f,
            Y = -((vector.Y - y) / height * 2.0f - 1.0f),
            Z = (vector.Z - minZ) / (maxZ - minZ)
        };
        Matrix4x4.Invert(projectionMatrix, out var matrix);
        return TransformCoordinate(v, matrix);
    }

    public static Vector3 ProjectOnNormal(Vector3 vector, Vector3 normal)
    {
        var sqrMag = Dot(normal, normal);
        if (sqrMag < float.Epsilon)
            return Zero;
        var dot = Dot(vector, normal);
        return new Vector3(normal.X * dot / sqrMag, normal.Y * dot / sqrMag, normal.Z * dot / sqrMag);
    }

    public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
    {
        var sqrMag = Dot(planeNormal, planeNormal);
        if (sqrMag < float.Epsilon)
            return vector;
        var dot = Dot(vector, planeNormal);
        return new Vector3(vector.X - planeNormal.X * dot / sqrMag, vector.Y - planeNormal.Y * dot / sqrMag, vector.Z - planeNormal.Z * dot / sqrMag);
    }

    public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
    {
        var toVector = target - current;
        var dist = toVector.Magnitude;
        if (dist <= maxDistanceDelta || dist == 0)
            return target;
        return current + toVector / dist * maxDistanceDelta;
    }

    public static implicit operator System.Numerics.Vector3(Vector3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Vector3(System.Numerics.Vector3 v) => new(v.X, v.Y, v.Z);

    public static Vector3 operator +(Vector3 a, Vector3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vector3 operator -(Vector3 a, Vector3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Vector3 operator -(Vector3 a) => new(-a.X, -a.Y, -a.Z);
    public static Vector3 operator *(Vector3 a, Vector3 b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    public static Vector3 operator *(Vector3 a, float d) => new(a.X * d, a.Y * d, a.Z * d);
    public static Vector3 operator *(float d, Vector3 a) => new(a.X * d, a.Y * d, a.Z * d);
    public static Vector3 operator /(Vector3 a, Vector3 b) => new(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
    public static Vector3 operator /(Vector3 a, float d) => new(a.X / d, a.Y / d, a.Z / d);

    public static bool operator ==(Vector3 left, Vector3 right) => left.Equals(right);
    public static bool operator !=(Vector3 left, Vector3 right) => !left.Equals(right);

    public bool Equals(Vector3 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    public override bool Equals(object? obj) => obj is Vector3 vector && Equals(vector);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    public override string ToString() => ((System.Numerics.Vector3)this).ToString();
    public string ToString(string? format, IFormatProvider? formatProvider) => ((System.Numerics.Vector3)this).ToString(format, formatProvider);
}
