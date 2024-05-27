using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::BoneSimulator
// ctor "33 D2 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B C1 89 51 10"
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe struct BoneSimulator {
    /// <summary> Non-exhaustive list of physics groups </summary>
    public enum PhysicsGroup : uint
    {
        Clothing = 2,
        HairA = 3, // Usually the hair's bangs
        HairB = 4, // Typically the back of the hair
        HairC = 5, // The sides of the hair
        HairD = 6, // Extraneous hair bits
        Chest = 7,
        Earrings = 8,
        Ears = 18,
    }

    [FieldOffset(0x10)] public PhysicsGroup Group;
    [FieldOffset(0x18)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton
    [FieldOffset(0x20)] public Vector3 CharacterPosition;
    [FieldOffset(0x30)] public Vector3 Gravity;
    [FieldOffset(0x40)] public Vector3 Wind;
    [FieldOffset(0x54)] public float Spring; // Default is ~60, intense jitter happens above that value. Lesser values remove the spring in the bone.
    [FieldOffset(0xF6)] public bool Start; // Flag that is set to true when the simulator starts, and is quickly reset
    [FieldOffset(0xF7)] public bool Stop; // Same as Start, but when the simulator is requested to stop
    [FieldOffset(0xF8)] public bool Reset; // When set to true, resets the bone simulator

}
