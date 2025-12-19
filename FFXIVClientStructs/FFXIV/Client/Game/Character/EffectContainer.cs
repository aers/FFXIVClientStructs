namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct EffectContainer {
    [FieldOffset(0x10)] public float CurrentFloatHeight;
    [FieldOffset(0x14)] public float TargetFloatHeight;
    [FieldOffset(0x18)] public float FloatHeightChangeSpeed;
    // [FieldOffset(0x1C)] public float UnkSpeed;
    // [FieldOffset(0x20)] public int UnkTime;
    // [FieldOffset(0x24)] public byte UnkRidingPillionFlag;
    // [FieldOffset(0x26)] public short UnkRidingPillionValue;
    // [FieldOffset(0x2C)] public float UnkTime2;
    [FieldOffset(0x30)] public StatusEffect StatusEffects;
    [FieldOffset(0x34)] public int MountTiltSetupState1;
    [FieldOffset(0x38)] public int MountTiltSetupState2;
    // [FieldOffset(0x3C)] public byte Unk3C;
    [FieldOffset(0x40)] public byte TiltParam1Type;
    [FieldOffset(0x44)] public float TiltParam1Value;
    [FieldOffset(0x48)] public byte TiltParam2Type;
    [FieldOffset(0x4C)] public float TiltParam2Value;

    [Flags]
    public enum StatusEffect : byte {
        IsGPoseWet = 0x01,
    }
}
