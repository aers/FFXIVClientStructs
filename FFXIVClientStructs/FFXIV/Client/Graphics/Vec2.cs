namespace FFXIVClientStructs.FFXIV.Client.Graphics; 

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct Vec2 : IEquatable<Vec2>, IFormattable {
	[FieldOffset(0x0)] public float X;
	[FieldOffset(0x4)] public float Y;

	public static readonly Vec2 Zero = new(0f);
	public static readonly Vec2 One = new(1f);
	public static readonly Vec2 Up = new(0f, 1f);
	public static readonly Vec2 Down =  new(0f, -1f);
	public static readonly Vec2 Left = new(-1f, 0f);
	public static readonly Vec2 Right = new(1f, 0f);
	public static readonly Vec2 PositiveInfinity = new(float.PositiveInfinity);
	public static readonly Vec2 NegativeInfinity = new(float.NegativeInfinity);

	public float Magnitude => MathF.Sqrt(SqrMagnitude);
	public float SqrMagnitude => X * X + Y * Y;
	public Vec2 Normalized => Normalize(this);

	public Vec2(float value) : this(value, value) { }
	public Vec2(float x, float y) {
		X = x;
		Y = y;
	}
	
	public static Vec2 Clamp(Vec2 value, Vec2 min, Vec2 max) {
		return Min(Max(value, min), max);
	}

	public static Vec2 Max(Vec2 value1, Vec2 value2) {
		return new Vec2(MathF.Max(value1.X, value2.X), MathF.Max(value1.Y, value2.Y));
	}

	public static Vec2 Min(Vec2 value1, Vec2 value2) {
		return new Vec2(MathF.Min(value1.X, value2.X), MathF.Min(value1.Y, value2.Y));
	}

	public static Vec2 Normalize(Vec2 value) {
		var mag = value.Magnitude;
		return mag > float.Epsilon ? value / mag : Zero;
	}

	public static float Angle(Vec2 from, Vec2 to) {
		const float rad2Deg = 1f / (MathF.PI * 2f / 360f);
		var d = from.Magnitude * to.Magnitude;
		if (d < float.Epsilon) return 0f;
		return MathF.Acos(Dot(from, to) / d) * rad2Deg;
	}

	public static float SignedAngle(Vec2 from, Vec2 to) {
		var unsignedAngle = Angle(from, to);
		float sign = MathF.Sign(from.X * to.Y - from.Y * to.X);
		return unsignedAngle * sign;
	}

	public static float Dot(Vec2 lhs, Vec2 rhs) {
		return lhs.X * rhs.X + lhs.Y * rhs.Y;
	}

	public static float Distance(Vec2 a, Vec2 b) {
		return MathF.Sqrt(SqrDistance(a, b));
	}

	public static float SqrDistance(Vec2 a, Vec2 b) {
		var diff = a - b;
		return Dot(diff, diff);
	}

	public static Vec2 Lerp(Vec2 a, Vec2 b, float t) {
		return LerpUnclamped(a, b, Math.Clamp(t, 0.0f, 1.0f));
	}
    
	public static Vec2 LerpUnclamped(Vec2 a, Vec2 b, float t) {
		return a + (b - a) * t;
	}

	public static Vec2 SmoothStep(Vec2 start, Vec2 end, float amount) {
		amount = Math.Clamp(amount, 0.0f, 1.0f);
		var step = amount * amount * (3.0f - 2.0f * amount);
		return LerpUnclamped(start, end, step);
	}

	public static Vec2 Reflect(Vec2 vector, Vec2 normal) {
		return vector - 2.0f * Dot(vector, normal) * normal;
	}

	public static Vec2 Transform(Vec2 position, Mat4x4 matrix) {
		return new Vec2 {
			X = position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41,
			Y = position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42
		};
	}

	public static Vec2 Transform(Vec2 value, Quat rotation) {
		var wz2 = rotation.W * (rotation.Z + rotation.Z);
		var xx2 = rotation.X * (rotation.X + rotation.X);
		var xy2 = rotation.X * (rotation.Y + rotation.Y);
		var yy2 = rotation.Y * (rotation.Y + rotation.Y);
		var zz2 = rotation.Z * (rotation.Z + rotation.Z);
		return new Vec2 {
			X = value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2),
			Y = value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2)
		};
	}

	public static Vec2 TransformNormal(Vec2 normal, Mat4x4 matrix) {
		return new Vec2 {
			X = normal.X * matrix.M11 + normal.Y * matrix.M21,
			Y = normal.X * matrix.M12 + normal.Y * matrix.M22
		};
	}

	public static Vec2 MoveTowards(Vec2 current, Vec2 target, float maxDistanceDelta) {
		var toVector = target - current;
		var sqDist = toVector.SqrMagnitude;

		if (sqDist == 0 || (maxDistanceDelta >= 0 && sqDist <= maxDistanceDelta * maxDistanceDelta))
			return target;

		var dist = MathF.Sqrt(sqDist);
		return current + toVector / dist * maxDistanceDelta;
	}

	public static implicit operator global::System.Numerics.Vector2(Vec2 v) => new(v.X, v.Y);
	public static implicit operator Vec2(global::System.Numerics.Vector2 v) => new(v.X, v.Y);

	public static Vec2 operator +(Vec2 a, Vec2 b) => new(a.X + b.X, a.Y + b.Y);
	public static Vec2 operator -(Vec2 a, Vec2 b) => new(a.X - b.X, a.Y - b.Y);
	public static Vec2 operator -(Vec2 a) => new(-a.X, -a.Y);
	public static Vec2 operator *(Vec2 a, Vec2 b) => new(a.X * b.X, a.Y * b.Y);
	public static Vec2 operator *(Vec2 a, float d) => new(a.X * d, a.Y * d);
	public static Vec2 operator *(float d, Vec2 a) => new(a.X * d, a.Y * d);
	public static Vec2 operator /(Vec2 a, Vec2 b) => new(a.X / b.X, a.Y / b.Y);
	public static Vec2 operator /(Vec2 a, float d) => new(a.X / d, a.Y / d);

	public static bool operator ==(Vec2 left, Vec2 right) => left.Equals(right);
	public static bool operator !=(Vec2 left, Vec2 right) => !left.Equals(right);

	public bool Equals(Vec2 other) {
		return X.Equals(other.X) && Y.Equals(other.Y);
	}

	public override bool Equals(object? obj) => obj is Vec2 other && Equals(other);
	public override int GetHashCode() => HashCode.Combine(X, Y);

	public override string ToString() => ((global::System.Numerics.Vector2)this).ToString();
	public string ToString(string? format, IFormatProvider? formatProvider) => ((global::System.Numerics.Vector2)this).ToString(format, formatProvider);
}
