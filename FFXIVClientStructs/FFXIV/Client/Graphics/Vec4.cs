namespace FFXIVClientStructs.FFXIV.Client.Graphics; 

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct Vec4 : IEquatable<Vec4>, IFormattable {
	[FieldOffset(0x0)] public float X;
	[FieldOffset(0x4)] public float Y;
	[FieldOffset(0x8)] public float Z;
	[FieldOffset(0xC)] public float W;
	
	public static readonly Vec4 Zero = new(0f);
	public static readonly Vec4 One = new(1f);
	public static readonly Vec4 PositiveInfinity = new(float.PositiveInfinity);
	public static readonly Vec4 NegativeInfinity = new(float.NegativeInfinity);

	public float Magnitude => MathF.Sqrt(SqrMagnitude);
	public float SqrMagnitude => X * X + Y * Y + Z * Z + W * W;
	
	public Vec4(float value) : this(value, value, value, value){}
	public Vec4(float x, float y, float z, float w) {
		X = x;
		Y = y;
		Z = z;
		W = w;
	}
	
	public static Vec4 Normalize(Vec4 value) {
		var mag = value.Magnitude;
		return mag > float.Epsilon ? value / mag : Zero;
	}

	public static float Dot(Vec4 left, Vec4 right) {
		return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
	}

	public static Vec4 Project(Vec4 left, Vec4 right) {
		return right * (Dot(left, right) / Dot(right, right));
	}

	public static Vec4 Lerp(Vec4 start, Vec4 end, float amount) {
		return LerpUnclamped(start, end, Math.Clamp(amount, 0.0f, 1.0f));
	}

	public static Vec4 LerpUnclamped(Vec4 start, Vec4 end, float amount) {
		return start + (end - start) * amount;
	}

	public static float Distance(Vec4 a, Vec4 b) {
		return MathF.Sqrt(SqrDistance(a, b));
	}

	public static float SqrDistance(Vec4 a, Vec4 b) {
		var diff = a - b;
		return Dot(diff, diff);
	}

	public static Vec4 Transform(Vec2 position, Mat4x4 matrix) {
		return new Vec4(
			position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41,
			position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42,
			position.X * matrix.M13 + position.Y * matrix.M23 + matrix.M43,
			position.X * matrix.M14 + position.Y * matrix.M24 + matrix.M44
		);
	}

	public static Vec4 Transform(Vec2 value, Quat rotation) {
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

		return new Vec4(
			value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2),
			value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2),
			value.X * (xz2 - wy2) + value.Y * (yz2 + wx2),
			1.0f
		);
	}

	public static Vec4 Transform(Vec3 position, Mat4x4 matrix) {
		return new Vec4(
			position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
			position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
			position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43,
			position.X * matrix.M14 + position.Y * matrix.M24 + position.Z * matrix.M34 + matrix.M44
		);
	}

	public static Vec4 Transform(Vec3 value, Quat rotation) {
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

		return new Vec4(
			value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
			value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2) + value.Z * (yz2 - wx2),
			value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0f - xx2 - yy2),
			1.0f
		);
	}

	public static Vec4 Transform(Vec4 vector, Mat4x4 matrix) {
		return new Vec4(
			vector.X * matrix.M11 + vector.Y * matrix.M21 + vector.Z * matrix.M31 + vector.W * matrix.M41,
			vector.X * matrix.M12 + vector.Y * matrix.M22 + vector.Z * matrix.M32 + vector.W * matrix.M42,
			vector.X * matrix.M13 + vector.Y * matrix.M23 + vector.Z * matrix.M33 + vector.W * matrix.M43,
			vector.X * matrix.M14 + vector.Y * matrix.M24 + vector.Z * matrix.M34 + vector.W * matrix.M44
		);
	}

	public static Vec4 Transform(Vec4 value, Quat rotation) {
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

		return new Vec4(
			value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
			value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2) + value.Z * (yz2 - wx2),
			value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0f - xx2 - yy2),
			value.W
		);
	}

	public static implicit operator global::System.Numerics.Vector4(Vec4 v) => new(v.X, v.Y, v.Z, v.W);
	public static implicit operator Vec4(global::System.Numerics.Vector4 v) => new(v.X, v.Y, v.Z, v.W);

	public static Vec4 operator +(Vec4 a, Vec4 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
	public static Vec4 operator -(Vec4 a, Vec4 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
	public static Vec4 operator -(Vec4 a) => new(-a.X, -a.Y, -a.Z, -a.W);
	public static Vec4 operator *(Vec4 a, float d) => new(a.X * d, a.Y * d, a.Z * d, a.W * d);
	public static Vec4 operator *(float d, Vec4 a) => new(a.X * d, a.Y * d, a.Z * d, a.W * d);
	public static Vec4 operator /(Vec4 a, float d) => new(a.X / d, a.Y / d, a.Z / d, a.W / d);

	public static bool operator ==(Vec4 left, Vec4 right) => left.Equals(right);
	public static bool operator !=(Vec4 left, Vec4 right) => !left.Equals(right);

	public bool Equals(Vec4 other) {
		return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
	}

	public override bool Equals(object? obj) => obj is Vec4 other && Equals(other);
	public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

	public override string ToString() => ((global::System.Numerics.Vector4)this).ToString();
	public string ToString(string? format, IFormatProvider? formatProvider) => ((global::System.Numerics.Vector4)this).ToString(format, formatProvider);
}
