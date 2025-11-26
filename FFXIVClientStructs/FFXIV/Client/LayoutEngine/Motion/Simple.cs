using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Motion;

[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct Sub1 {
    [MemberFunction("E8 ?? ?? ?? ?? 8B 95 ?? ?? ?? ?? C1 E2 14")]
    public partial void LoadFromFile(byte* data);
}

[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct Sub2 {
    [FieldOffset(0x38)] public float UnkRadians;
    [FieldOffset(0x3C)] public float RotationSpeed;

    [FieldOffset(0x41)] public bool Enabled2;
    [FieldOffset(0x42)] public bool Enabled3;

    [FieldOffset(0x48), CExporterUnion("BgOrSg")] public BgPartsLayoutInstance* InstanceBg;
    [FieldOffset(0x48), CExporterUnion("BgOrSg")] public SharedGroupLayoutInstance* InstanceShared;

    [FieldOffset(0x50)] public void* Vfx1; // VfxLayoutInstance
    [FieldOffset(0x58)] public void* Vfx2; // VfxLayoutInstance
    [FieldOffset(0x60)] public SoundLayoutInstance* Sound1;
    [FieldOffset(0x68)] public SoundLayoutInstance* Sound2;
    [FieldOffset(0x70)] public SoundLayoutInstance* Sound3;

    [FieldOffset(0x80)] public Quaternion RotationBaseMain;
    [FieldOffset(0x90)] public Quaternion RotationBaseVfx1;
    [FieldOffset(0xA0)] public Quaternion RotationBaseVfx2;
    [FieldOffset(0xB0)] public Quaternion RotationMain;
    [FieldOffset(0xC0)] public Quaternion RotationVfx1;
    [FieldOffset(0xD0)] public Quaternion RotationVfx2;

    [MemberFunction("E8 ?? ?? ?? ?? 8B 95 ?? ?? ?? ?? C1 E2 0C")]
    public partial void LoadFromFile(byte* data);
}

[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct Timeline { }

// sets rotation of objects based on ingame time of day
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct TimeOfDay {
    [FieldOffset(0x28)] public ILayoutInstance* Instance1;
    [FieldOffset(0x30)] public ILayoutInstance* Instance2;
    [FieldOffset(0x40)] public Quaternion RotationBase1;
    [FieldOffset(0x50)] public Quaternion RotationBase2;
    [FieldOffset(0x60)] public Quaternion Rotation1;
    [FieldOffset(0x70)] public Quaternion Rotation2;
}

[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe partial struct Sub6 {
    [FieldOffset(0x50)] public Vector3 Translation;
    [FieldOffset(0x60)] public Quaternion Rotation;
    [FieldOffset(0x70)] public Vector3 Scale;
}

[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x168)]
public unsafe partial struct Sub7 {
    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray16<Pointer<ILayoutInstance>> _objects;
    [FieldOffset(0xA8)] public uint NumObjects;

    [FieldOffset(0xBC)] public UnkChild Child1;
    [FieldOffset(0x110)] public UnkChild Child2;

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 9D ?? ?? ?? ?? 48 8B CB")]
    public partial void LoadFromFile(byte* data);

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct UnkChild {
        [FieldOffset(0x00)] public byte Flags1;
        [FieldOffset(0x04)] public int Flags2;
        [FieldOffset(0x08)] public int Flags3;

        [FieldOffset(0x14)] public float UnkTimer;
        [FieldOffset(0x1C)] public float UnkFactorHalf;

        [FieldOffset(0x20)] public float UnkFloat_20;
        [FieldOffset(0x24)] public Quaternion Rotation1;
        [FieldOffset(0x34)] public Quaternion Rotation2;
    }
}
