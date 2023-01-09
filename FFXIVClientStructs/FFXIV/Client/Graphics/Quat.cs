namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct Quat : IEquatable<Quat> {
    [FieldOffset(0x0)] public float X;
    [FieldOffset(0x4)] public float Y;
    [FieldOffset(0x8)] public float Z;
    [FieldOffset(0xC)] public float W;

    public const float Deg2Rad = MathF.PI * 2.0f / 360.0f;
    public const float Rad2Deg = 1.0f / Deg2Rad;
    
    public static readonly Quat Identity = new(0.0f, 0.0f, 0.0f, 1.0f);
    public bool IsIdentity => Equals(Identity);
    public float Magnitude => MathF.Sqrt(SqrMagnitude);
    public float SqrMagnitude => X * X + Y * Y + Z * Z + W * W;
    public Quat Normalized => Normalize(this);

    public Vec3 EulerAngles {
	    get => ToEulerRad(Normalize(this)) * Rad2Deg;
	    set => this = FromEulerRad(value * Deg2Rad);
    }

    public Quat(float value) : this(value, value, value, value) { }
    public Quat(Vec3 value, float w) : this(value.X, value.Y, value.Z, w) { }
    public Quat(float x, float y, float z, float w) {
	    X = x; Y = y; Z = z; W = w;
    }

    public static Quat CreateFromEuler(Vec3 euler) {
	    return FromEulerRad(euler * Deg2Rad);
    }

    public static Quat CreateFromAxisAngle(Vec3 axis, float angle) {
	    var halfAngle = angle * 0.5f;
	    var s = MathF.Sin(halfAngle);
	    var c = MathF.Cos(halfAngle);
	    return new Quat(axis.X * s, axis.Y * s, axis.Z * s, c);
    }

    public static Quat CreateFromYawPitchRoll(float yaw, float pitch, float roll) {
	    var halfRoll = roll * 0.5f;
	    var sr = MathF.Sin(halfRoll);
	    var cr = MathF.Cos(halfRoll);

	    var halfPitch = pitch * 0.5f;
	    var sp = MathF.Sin(halfPitch);
	    var cp = MathF.Cos(halfPitch);

	    var halfYaw = yaw * 0.5f;
	    var sy = MathF.Sin(halfYaw);
	    var cy = MathF.Cos(halfYaw);

	    return new Quat {
		    X = cy * sp * cr + sy * cp * sr,
		    Y = sy * cp * cr - cy * sp * sr,
		    Z = cy * cp * sr - sy * sp * cr,
		    W = cy * cp * cr + sy * sp * sr
	    };
    }

    public static Quat CreateFromRotationMatrix(Mat4x4 matrix) {
	    var trace = matrix.M11 + matrix.M22 + matrix.M33;

	    Quat q = default;

	    if (trace > 0.0f) {
		    var s = MathF.Sqrt(trace + 1.0f);
		    q.W = s * 0.5f;
		    s = 0.5f / s;
		    q.X = (matrix.M23 - matrix.M32) * s;
		    q.Y = (matrix.M31 - matrix.M13) * s;
		    q.Z = (matrix.M12 - matrix.M21) * s;
		    return q;
	    }

	    if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33) {
		    var s = MathF.Sqrt(1.0f + matrix.M11 - matrix.M22 - matrix.M33);
		    var invS = 0.5f / s;
		    q.X = 0.5f * s;
		    q.Y = (matrix.M12 + matrix.M21) * invS;
		    q.Z = (matrix.M13 + matrix.M31) * invS;
		    q.W = (matrix.M23 - matrix.M32) * invS;
	    } else if (matrix.M22 > matrix.M33) {
		    var s = MathF.Sqrt(1.0f + matrix.M22 - matrix.M11 - matrix.M33);
		    var invS = 0.5f / s;
		    q.X = (matrix.M21 + matrix.M12) * invS;
		    q.Y = 0.5f * s;
		    q.Z = (matrix.M32 + matrix.M23) * invS;
		    q.W = (matrix.M31 - matrix.M13) * invS;
	    } else {
		    var s = MathF.Sqrt(1.0f + matrix.M33 - matrix.M11 - matrix.M22);
		    var invS = 0.5f / s;
		    q.X = (matrix.M31 + matrix.M13) * invS;
		    q.Y = (matrix.M32 + matrix.M23) * invS;
		    q.Z = 0.5f * s;
		    q.W = (matrix.M12 - matrix.M21) * invS;
	    }
	    return q;
    }

    public static Quat Normalize(Quat value) {
	    var length = value.Magnitude;
	    if (length < float.Epsilon)
		    return Identity;
	    return new Quat(value.X / length, value.Y / length, value.Z / length, value.W / length);
    }

    public static float Angle(Quat from, Quat to) {
	    var dot = MathF.Min(MathF.Abs(Dot(from, to)), 1.0f);
	    return dot > 1.0f - float.Epsilon ? 0.0f : MathF.Acos(dot) * 2.0f;
    }

    public static float Dot(Quat a, Quat b) {
	    return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
    }

    public static Quat Conjugate(Quat value) {
	    return new Quat(-value.X, -value.Y, -value.Z, value.W);
    }

    public static Quat Invert(Quat value) {
	    var sqrMag = value.SqrMagnitude;
	    if (sqrMag < float.Epsilon)
            return value;
	    return Conjugate(value) * (1.0f / sqrMag);
    }

    public static Quat Lerp(Quat start, Quat end, float amount) {
	    return LerpUnclamped(start, end, Math.Clamp(amount, 0.0f, 1.0f));
    }

    public static Quat LerpUnclamped(Quat start, Quat end, float amount) {
	    var inverse = 1.0f - amount;
	    if (Dot(start, end) >= 0.0f)
		    return Normalize(start * inverse + end * amount);
	    return Normalize(start * inverse - end * amount);
    }

    public static Quat Slerp(Quat start, Quat end, float amount) {
	    return SlerpUnclamped(start, end, Math.Clamp(amount, 0.0f, 1.0f));
    }

    public static Quat SlerpUnclamped(Quat start, Quat end, float amount) {
	    var dot = Dot(start, end);

	    if (MathF.Abs(dot) > 1.0f - 1e-6f)
		    return Normalize(start * (1.0f - amount) + end * (amount * MathF.Sign(dot)));

	    var acos = MathF.Acos(MathF.Abs(dot));
	    var invSin = 1.0f / MathF.Sin(acos);
		var inverse = MathF.Sin((1.0f - amount) * acos) * invSin;
	    var opposite = MathF.Sin(amount * acos) * invSin * MathF.Sign(dot);
		return Normalize(start * inverse + end * opposite);
    }

    public static Quat Squad(Quat value1, Quat value2, Quat value3, Quat value4, float amount) {
	    return SquadUnclamped(value1, value2, value3, value4, Math.Clamp(amount, 0.0f, 1.0f));
    }

    public static Quat SquadUnclamped(Quat value1, Quat value2, Quat value3, Quat value4, float amount) {
	    var start = SlerpUnclamped(value1, value4, amount);
	    var end = SlerpUnclamped(value2, value3, amount);
	    return SlerpUnclamped(start, end, 2.0f * amount * (1.0f - amount));
    }

    private static Quat FromEulerRad(Vec3 euler) {
	    //return CreateFromYawPitchRoll(euler.Y, euler.X, euler.Z);
	    var halfX = euler.X * 0.5f;
	    var cX = MathF.Cos(halfX);
	    var sX = MathF.Sin(halfX);

	    var halfY = euler.Y * 0.5f;
		var cY = MathF.Cos(halfY);
		var sY = MathF.Sin(halfY);

		var halfZ = euler.Z * 0.5f;
		var cZ = MathF.Cos(halfZ);
		var sZ = MathF.Sin(halfZ);

		var qX = new Quat(sX, 0.0f, 0.0f, cX);
		var qY = new Quat(0.0f, sY, 0.0f, cY);
		var qZ = new Quat(0.0f, 0.0f, sZ, cZ);

		return qZ * qY * qX;
	}

    private static Vec3 ToEulerRad(Quat q) {
	    var unit = Dot(q, q);
	    var test = q.X * q.W - q.Y * q.Z;
	    Vec3 v;

	    if (test > 0.4995f * unit) {
		    v.Y = 2.0f * MathF.Atan2(q.Y, q.X);
		    v.X = MathF.PI / 2.0f;
		    v.Z = 0.0f;
		    MakePositive(ref v);
		    return v;
	    }

	    if (test < -0.4995f * unit) {
		    v.Y = -2.0f * MathF.Atan2(q.Y, q.X);
		    v.X = -MathF.PI / 2.0f;
		    v.Z = 0.0f;
		    MakePositive(ref v);
		    return v;
	    }

	    var tmp = new Quat(q.W, q.Z, q.X, q.Y);
	    v.Y = MathF.Atan2(2.0f * tmp.X * tmp.W + 2.0f * tmp.Y * tmp.Z, 1.0f - 2.0f * (tmp.Z * tmp.Z + tmp.W * tmp.W));
	    v.X = MathF.Asin(2.0f * (tmp.X * tmp.Z - tmp.W * tmp.Y));
	    v.Z = MathF.Atan2(2.0f * tmp.X * tmp.Y + 2.0f * tmp.Z * tmp.W, 1.0f - 2.0f * (tmp.Y * tmp.Y + tmp.Z * tmp.Z));
	    MakePositive(ref v);
	    return v;
    }

    private static void MakePositive(ref Vec3 euler) {
	    const float t = MathF.PI * 2.0f;
	    const float negativeFlip = -0.0001f;
	    const float positiveFlip = t - 0.0001f;

	    if (euler.X < negativeFlip)
		    euler.X += t;
	    else if (euler.X > positiveFlip)
		    euler.X -= t;

	    if (euler.Y < negativeFlip)
		    euler.Y += t;
	    else if (euler.Y > positiveFlip)
		    euler.Y -= t;

	    if (euler.Z < negativeFlip)
		    euler.Z += t;
	    else if (euler.Z > positiveFlip)
		    euler.Z -= t;
    }

    public static implicit operator global::System.Numerics.Quaternion(Quat q) => new(q.X, q.Y, q.Z, q.W);
    public static implicit operator Quat(global::System.Numerics.Quaternion q) => new(q.X, q.Y, q.Z, q.W);
    
    public static Quat operator +(Quat a, Quat b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    public static Quat operator -(Quat a, Quat b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    public static Quat operator -(Quat a) => new(-a.X, -a.Y, -a.Z, -a.W);
    public static Quat operator *(Quat a, float d) => new(a.X * d, a.Y * d, a.Z * d, a.W * d);
    public static Vec3 operator *(Quat rotation, Vec3 point) => Vec3.Transform(point, rotation);
    public static Quat operator *(Quat a, Quat b) {
	    return new Quat {
		    X = a.X * b.W + b.X * a.W + (a.Y * b.Z - a.Z * b.Y),
		    Y = a.Y * b.W + b.Y * a.W + (a.Z * b.X - a.X * b.Z),
		    Z = a.Z * b.W + b.Z * a.W + (a.X * b.Y - a.Y * b.X),
		    W = a.W * b.W - (a.X * b.X + a.Y * b.Y + a.Z * b.Z)
	    };
    }

    public static bool operator ==(Quat left, Quat right) => left.Equals(right);
    public static bool operator !=(Quat left, Quat right) => !left.Equals(right);

    public bool Equals(Quat other) {
	    return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
    }

    public override bool Equals(object? obj) => obj is Quat other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

    public override string ToString() => $"{{X:{X} Y:{Y} Z:{Z} W:{W}}}";
}