namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct EffectContainer {
    [FieldOffset(0x10)] public float CurrentFloatHeight;
    [FieldOffset(0x14)] public float TargetFloatHeight;
    [FieldOffset(0x18)] public float FloatHeightChangeSpeed;
    // [FieldOffset(0x1C)] private float UnkSpeed;
    // [FieldOffset(0x20)] private int UnkTime;
    // [FieldOffset(0x24)] private byte UnkRidingPillionFlag;
    // [FieldOffset(0x26)] private short UnkRidingPillionValue;
    // [FieldOffset(0x2C)] private float UnkTime2;
    [FieldOffset(0x30)] public StatusEffect StatusEffects;
    [FieldOffset(0x34)] public int MountTiltSetupState1;
    [FieldOffset(0x38)] public int MountTiltSetupState2;
    [FieldOffset(0x40)] public float GroundTiltAngle;
    [FieldOffset(0x44)] public float GroundTiltSpeed;
    [FieldOffset(0x50)] public float FlightTiltAngle;
    [FieldOffset(0x54)] public float FlightTiltSpeed;
    
    [FieldOffset(0x40), Obsolete("Invalid since 7.1")] public byte TiltParam1Type;
    [FieldOffset(0x44), Obsolete("Invalid since 7.1")] public float TiltParam1Value;
    [FieldOffset(0x48), Obsolete("Invalid since 7.1")] public byte TiltParam2Type;
    [FieldOffset(0x4C), Obsolete("Invalid since 7.1")] public float TiltParam2Value;
    
    /// <summary>
    /// Called when mounting/dismounting and maybe other state changes to set new tilt values 
    /// </summary>
    [MemberFunction("48 89 5C 24 ?? 55 48 83 EC ?? C6 41")]
    public partial void LoadTiltData();

    [Flags]
    public enum StatusEffect : byte {
        IsGPoseWet = 0x01,
    }
}
