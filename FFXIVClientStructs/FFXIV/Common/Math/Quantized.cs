using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Common.Math;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x02)]
public partial struct QuantizedValue {
    [FieldOffset(0x00)] public ushort Value;

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 CB F3 0F 11 85")]
    public static partial float DequantizePositionValue(ushort value);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 FF 49 8B CE")]
    public static partial float DequantizeAngleValue(ushort value);

    public readonly float DequantizePosition() => DequantizePositionValue(Value);
    public readonly float DequantizeAngle() => DequantizeAngleValue(Value);
}

[StructLayout(LayoutKind.Explicit, Size = 0x06)]
public struct QuantizedVector3 {
    [FieldOffset(0x00)] public QuantizedValue X;
    [FieldOffset(0x02)] public QuantizedValue Y;
    [FieldOffset(0x04)] public QuantizedValue Z;

    public readonly Vector3 Dequantize() {
        return new(
            X.DequantizePosition(),
            Y.DequantizePosition(),
            Z.DequantizePosition());
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x06)]
public struct QuantizedRotation3 {
    [FieldOffset(0x00)] public QuantizedValue Pitch; // X
    [FieldOffset(0x02)] public QuantizedValue Yaw;   // Y
    [FieldOffset(0x04)] public QuantizedValue Roll;  // Z

    public readonly Vector3 Dequantize() {
        return new(
            Pitch.DequantizeAngle(),
            Yaw.DequantizeAngle(),
            Roll.DequantizeAngle());
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x12)]
public unsafe partial struct QuantizedTransform {
    [FieldOffset(0x00)] public QuantizedVector3 Translation;
    [FieldOffset(0x06)] public QuantizedRotation3 Rotation;
    [FieldOffset(0x0C)] public QuantizedVector3 Scale;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 53 ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 48 8B 43")]
    public static partial void Quantize(QuantizedTransform* destination, Transform* source);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 ?? 48 85 C0 74 ?? 48 8B 88 ?? ?? ?? ?? EB ?? 33 C9 4C 8B 46")]
    public static partial void Dequantize(QuantizedTransform* source, Transform* destination);

    [MemberFunction("40 53 48 83 EC ?? 0F B7 41 ?? 0F 57 C0")]
    public static partial void DequantizeRotation(QuantizedTransform* source, Quaternion* destination);

    public readonly Transform Dequantize() {
        Transform transform;
        fixed (QuantizedTransform* pThis = &this)
            Dequantize(pThis, &transform);
        return transform;
    }

    public readonly Quaternion DequantizeRotation() {
        Quaternion quaternion;
        fixed (QuantizedTransform* pThis = &this)
            DequantizeRotation(pThis, &quaternion);
        return quaternion;
    }
}
