using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::BoneSimulator
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public unsafe struct BoneSimulator {
    [FieldOffset(0x10)] public PhysicsGroup Group;
    [FieldOffset(0x18)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton
    [FieldOffset(0x20)] public Vector3 CharacterPosition;
    [FieldOffset(0x30)] public Vector3 Gravity;
    [FieldOffset(0x40)] public Vector3 Wind;
    // The following two values are derived from the PhysicsGroup sheet if applicable to the object.
    // They are hardcoded to roughly 1/60 (0.016666668) and 60 (59.999996) in cases where the sheet isn't used.
    [FieldOffset(0x50)] public float SimulationTime;
    [FieldOffset(0x54)] public float SimulationTimeInv; // 1/SimulationTime
    [Obsolete("Use SimulationTimeInv instead")]
    [FieldOffset(0x54)] public float Spring; // Default is ~60, intense jitter happens above that value. Lesser values remove the spring in the bone.
    [FieldOffset(0xF6)] public bool IsStarted; // Flag that is set to true when the simulator starts, and is quickly reset
    [FieldOffset(0xF7)] public bool IsStopped; // Same as Start, but when the simulator is requested to stop
    [FieldOffset(0xF8)] public bool IsReset; // When set to true, resets the bone simulator

    [FieldOffset(0x444)] public bool IsSimulating;
    [FieldOffset(0x445)] public bool IsTimeIntegrating; // Whether the simulator is integrating (time stepping) on this frame
    [FieldOffset(0x446)] public bool IsCollidable;

    /// <summary> Non-exhaustive list of physics groups </summary>
    public enum PhysicsGroup : uint {
        Clothing = 2,
        HairA = 3, // Usually the hair's bangs
        HairB = 4, // Typically the back of the hair
        HairC = 5, // The sides of the hair
        HairD = 6, // Extraneous hair bits
        Chest = 7,
        Earrings = 8,
        Ears = 18,
    }
}
