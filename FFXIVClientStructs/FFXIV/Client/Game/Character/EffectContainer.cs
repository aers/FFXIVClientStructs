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
    [FieldOffset(0x31)] private byte UnkTilt1;
    [FieldOffset(0x32)] private byte Unktilt2;
    [FieldOffset(0x33)] private byte Unktilt3;
    [FieldOffset(0x34)] public int MountTiltSetupState1;
    [FieldOffset(0x38)] public int MountTiltSetupState2;

    [FieldOffset(0x3C)] public TiltOrigin MountGroundTiltOrigin;
    [FieldOffset(0x3D)] private byte MountGroundUnk1;
    [FieldOffset(0x3E)] private byte MountGroundUnk2;
    [FieldOffset(0x40)] public float MountGroundTiltAngle;
    [FieldOffset(0x44)] public float MountGroundTiltSpeed;
    [FieldOffset(0x48)] public TiltFlags MountGroundTiltFlags;

    [FieldOffset(0x4C)] public TiltOrigin MountFlightSwimTiltOrigin;
    [FieldOffset(0x4D)] private byte MountFlightSwimUnk1;
    [FieldOffset(0x4E)] private byte MountFlightSwimUnk2;
    [FieldOffset(0x50)] public float MountFlightSwimTiltAngle;
    [FieldOffset(0x54)] public float MountFlightSwimTiltSpeed;
    [FieldOffset(0x58)] public TiltFlags MountFlightSwimTiltFlags;

    //Set 3 and 4 are loaded into the ownerobject. Looking at code may need to have the owner tilt flags set to enabled in mount.
    [FieldOffset(0x5C)] public TiltOrigin RiderGroundTiltOrigin;
    [FieldOffset(0x5D)] private byte RiderGroundUnk1;
    [FieldOffset(0x5E)] private byte RiderGroundUnk2;
    [FieldOffset(0x60)] public float RiderGroundTiltAngle;
    [FieldOffset(0x64)] public float RiderGroundTiltSpeed;
    [FieldOffset(0x68)] public TiltFlags RiderGroundTiltFlags;

    [FieldOffset(0x6C)] public TiltOrigin RiderFlightSwimTiltOrigin;
    [FieldOffset(0x6D)] private byte RiderFlightSwimUnk1;
    [FieldOffset(0x6E)] private byte RiderFlightSwimUnk2;
    [FieldOffset(0x70)] public float RiderFlightSwimTiltAngle;
    [FieldOffset(0x74)] public float RiderFlightSwimTiltSpeed;
    [FieldOffset(0x78)] public TiltFlags RiderFlightSwimReverseTilt;

    [FieldOffset(0x40), Obsolete("Renamed to MountGroundTiltAngle")] public float GroundTiltAngle;
    [FieldOffset(0x44), Obsolete("Renamed to MountGroundTiltSpeed")] public float GroundTiltSpeed;
    [FieldOffset(0x50), Obsolete("Renamed to MountFlightSwimTiltAngle")] public float FlightTiltAngle;
    [FieldOffset(0x54), Obsolete("Renamed to MountFlightSwimTiltSpeed")] public float FlightTiltSpeed;

    [FieldOffset(0x40), Obsolete("Invalid since 7.1", true)] public byte TiltParam1Type;
    [FieldOffset(0x44), Obsolete("Invalid since 7.1", true)] public float TiltParam1Value;
    [FieldOffset(0x48), Obsolete("Invalid since 7.1", true)] public byte TiltParam2Type;
    [FieldOffset(0x4C), Obsolete("Invalid since 7.1", true)] public float TiltParam2Value;

    /// <summary>
    /// Mount tilt setup, and possibly unmounted tilt setup
    /// </summary>
    [MemberFunction("48 89 5C 24 ?? 55 48 83 EC ?? C6 41")]
    public partial void LoadMountTiltData();

    [Obsolete("Renamed to LoadMountTiltData", true)]
    public void LoadTiltData() => LoadMountTiltData();

    /// <summary>
    /// Mounted player tilt setup
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8B 45")]
    public partial void LoadPlayerTiltData();

    [Flags]
    public enum StatusEffect : byte {
        None = 0,
        IsGPoseWet = 1 << 0,
    }

    [Flags]
    public enum TiltFlags : byte {
        None = 0,
        ReverseRotation = 1 << 0,
    }

    //not exactly sure how to explain this, but this controls how the object pivots.
    public enum TiltOrigin : byte {
        Ground = 1,
        Center = 2,
        Waist = 3,
        UpperBody = 4,
    }
}
