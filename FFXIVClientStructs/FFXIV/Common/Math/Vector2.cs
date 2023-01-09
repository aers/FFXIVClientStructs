namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct Vector2 : IEquatable<Vector2>, IFormattable
{
    [FieldOffset(0x0)] public float X;
    [FieldOffset(0x4)] public float Y;

    public static readonly Vector2 Zero = new(0f);
    public static readonly Vector2 One = new(1f);
    public static readonly Vector2 Up = new(0f, 1f);
    public static readonly Vector2 Down = new(0f, -1f);
    public static readonly Vector2 Left = new(-1f, 0f);
    public static readonly Vector2 Right = new(1f, 0f);
    public static readonly Vector2 PositiveInfinity = new(float.PositiveInfinity);
    public static readonly Vector2 NegativeInfinity = new(float.NegativeInfinity);

    public float Magnitude => MathF.Sqrt(SqrMagnitude);
    public float SqrMagnitude => X * X + Y * Y;
    public Vector2 Normalized => Normalize(this);

    public Vector2(float value) : this(value, value) { }
    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
    {
        return Min(Max(value, min), max);
    }

    public static Vector2 Max(Vector2 value1, Vector2 value2)
    {
        return new Vector2(MathF.Max(value1.X, value2.X), MathF.Max(value1.Y, value2.Y));
    }

    public static Vector2 Min(Vector2 value1, Vector2 value2)
    {
        return new Vector2(MathF.Min(value1.X, value2.X), MathF.Min(value1.Y, value2.Y));
    }

    public static Vector2 Normalize(Vector2 value)
    {
        var mag = value.Magnitude;
        return mag > float.Epsilon ? value / mag : Zero;
    }

    public static float Angle(Vector2 from, Vector2 to)
    {
        const float rad2Deg = 1f / (MathF.PI * 2f / 360f);
        var d = from.Magnitude * to.Magnitude;
        if (d < float.Epsilon) return 0f;
        return MathF.Acos(Dot(from, to) / d) * rad2Deg;
    }

    public static float SignedAngle(Vector2 from, Vector2 to)
    {
        var unsignedAngle = Angle(from, to);
        float sign = MathF.Sign(from.X * to.Y - from.Y * to.X);
        return unsignedAngle * sign;
    }

    public static float Dot(Vector2 lhs, Vector2 rhs)
    {
        return lhs.X * rhs.X + lhs.Y * rhs.Y;
    }

    public static float Distance(Vector2 a, Vector2 b)
    {
        return MathF.Sqrt(SqrDistance(a, b));
    }

    public static float SqrDistance(Vector2 a, Vector2 b)
    {
        var diff = a - b;
        return Dot(diff, diff);
    }

    public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
    {
        return LerpUnclamped(a, b, System.Math.Clamp(t, 0.0f, 1.0f));
    }

    public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    public static Vector2 SmoothStep(Vector2 start, Vector2 end, float amount)
    {
        amount = System.Math.Clamp(amount, 0.0f, 1.0f);
        var step = amount * amount * (3.0f - 2.0f * amount);
        return LerpUnclamped(start, end, step);
    }

    public static Vector2 Reflect(Vector2 vector, Vector2 normal)
    {
        return vector - 2.0f * Dot(vector, normal) * normal;
    }

    public static Vector2 Transform(Vector2 position, Matrix4x4 matrix)
    {
        return new Vector2
        {
            X = position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41,
            Y = position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42
        };
    }

    public static Vector2 Transform(Vector2 value, Quaternion rotation)
    {
        var wz2 = rotation.W * (rotation.Z + rotation.Z);
        var xx2 = rotation.X * (rotation.X + rotation.X);
        var xy2 = rotation.X * (rotation.Y + rotation.Y);
        var yy2 = rotation.Y * (rotation.Y + rotation.Y);
        var zz2 = rotation.Z * (rotation.Z + rotation.Z);
        return new Vector2
        {
            X = value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2),
            Y = value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2)
        };
    }

    public static Vector2 TransformNormal(Vector2 normal, Matrix4x4 matrix)
    {
        return new Vector2
        {
            X = normal.X * matrix.M11 + normal.Y * matrix.M21,
            Y = normal.X * matrix.M12 + normal.Y * matrix.M22
        };
    }

    public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
    {
        var toVector = target - current;
        var sqDist = toVector.SqrMagnitude;

        if (sqDist == 0 || maxDistanceDelta >= 0 && sqDist <= maxDistanceDelta * maxDistanceDelta)
            return target;

        var dist = MathF.Sqrt(sqDist);
        return current + toVector / dist * maxDistanceDelta;
    }

    public static implicit operator System.Numerics.Vector2(Vector2 v) => new(v.X, v.Y);
    public static implicit operator Vector2(System.Numerics.Vector2 v) => new(v.X, v.Y);

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
    public static Vector2 operator -(Vector2 a) => new(-a.X, -a.Y);
    public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.X * b.X, a.Y * b.Y);
    public static Vector2 operator *(Vector2 a, float d) => new(a.X * d, a.Y * d);
    public static Vector2 operator *(float d, Vector2 a) => new(a.X * d, a.Y * d);
    public static Vector2 operator /(Vector2 a, Vector2 b) => new(a.X / b.X, a.Y / b.Y);
    public static Vector2 operator /(Vector2 a, float d) => new(a.X / d, a.Y / d);

    public static bool operator ==(Vector2 left, Vector2 right) => left.Equals(right);
    public static bool operator !=(Vector2 left, Vector2 right) => !left.Equals(right);

    public bool Equals(Vector2 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj) => obj is Vector2 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() => ((System.Numerics.Vector2)this).ToString();
    public string ToString(string? format, IFormatProvider? formatProvider) => ((System.Numerics.Vector2)this).ToString(format, formatProvider);
}
