using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

public enum ColliderType { None, Box, Sphere, Cylinder, Plane, Mesh, PlaneTwoSided }

/// <summary>
/// Base class for various collision-only instances.
/// </summary>
[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct TriggerBoxLayoutInstance {
    [FieldOffset(0x30)] public Collider* Collider;
    [FieldOffset(0x40)] public Transform Transform;
    //[FieldOffset(0x70)] public ushort u70;
    [FieldOffset(0x74)] public uint FlagsType; // low 4 bits = type, rest uninitialized
    [FieldOffset(0x78)] public byte FlagsActive; // 0x1 = active by default, rest uninitialized

    public ColliderType Type => (ColliderType)(FlagsType & 0xF);
    public bool ActiveByDefault => (FlagsActive & 1) != 0;

    [VirtualFunction(78)]
    public partial ulong GetLayerMask();
}

[GenerateInterop]
[Inherits<TriggerBoxLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct CollisionBoxLayoutInstance {
    [FieldOffset(0x80)] public uint MaterialIdLow;
    [FieldOffset(0x84)] public uint MaterialMaskLow;
    [FieldOffset(0x88)] public uint MaterialIdHigh;
    [FieldOffset(0x8C)] public uint MaterialMaskHigh;
    [FieldOffset(0x90)] public uint PcbPathCrc;
    [FieldOffset(0x94)] public bool LayerMaskIs43h;
    [FieldOffset(0x98)] public void* CollisionUpdateListener;
}
