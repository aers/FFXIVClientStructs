using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

/// <summary>
/// Entry point for collision related operations.
/// Collision scene supports two ways to filter colliders - layers and material masks.
///
/// Each collider, when constructed, is provided a layer mask. Collider is ignored during raycasts if raycast request layer mask AND collider layer mask == 0.
/// Note that individual collider raycast operations are inconsistent in how they handle zero layer mask in raycast request:
/// - primitive shape (non-mesh) colliders skip layer check in that case (so 0 is equivalent to 'all 1s' mask, meaning no colliders are rejected by layer check)
/// - mesh colliders do a normal check, meaning that all mesh colliders are rejected by a layer check
/// Note that some colliders provide functions to perform raycast without layer check.
///
/// Each collider also has a material value (0x7000 by default on construction). When doing raycasts with material filtering, you supply a mask and a value.
/// For primitive shape (non-mesh) colliders, the filtering is simple:
/// - if material filter value is 0, the collider is considered if (collider-material AND filter-mask) != 0
/// - otherwise, the collider is considered if (collider-material AND filter-mask) == filter-value
/// For mesh colliders, things are slightly more complicated. Collider still contains a material value + a material mask (this mask is ignored by all other collider types).
/// Each individual triangle of the mesh also defines its own material value (primitive material). The effective material of a triangle is calculated as follows:
/// - if object material mask is 0, it's just whatever is stored in primitive
/// - otherwise, it is calculated as (primitive-material AND NOT object-material-mask) OR object-material-value (so masked bits are replaced by per-object value)
/// This effective material is then used as collider-material value in the material filtering logic described above.
///
/// There are three main options that are used to customize raycast algorithm - these are stored as 'raycast algorithm type' bitfield, meaning there are 8 total flavours of raycasts:
/// Default (no bits set): usual ray/shape intersection without material filtering.
/// Bit 0 set: use sphere sweep instead of a ray; when choosing between potential intersection points at comparable (within epsilon) distance, select one that has 'more orthogonal' normal (smaller ray-direction dot normal)
/// Bit 1 set: ignore 'horizontal' collisions (ones where normal.Y is > threshold, i.e. angle to vertical axis is smaller than some threshold)
/// Bit 2 set: perform material filtering
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct BGCollisionModule {
    //[FieldOffset(0x00)] public byte u0; - this is set to an argument passed to Initialize function by Framework setup, and it's always 0; this is passed to some scene object constructors, but ultimately doesn't seem to be used - some debug switch?
    [FieldOffset(0x01)] public bool ShuttingDown;
    [FieldOffset(0x08)] public void* ResourceManager;
    [FieldOffset(0x10)] public SceneManager* SceneManager;
    [FieldOffset(0x18)] public nint UpdateTaskLock; // winapi type: SRWLOCK; exclusive lock is acquired while update is in progress, shared lock is acquired during raycasts
    // 0x20: unknown CRITICAL_SECTION (size 0x28); don't see it ever being locked
    [FieldOffset(0x48)] public Client.System.Framework.Task WaitForUpdateTask;
    [FieldOffset(0x80)] public nint UpdateFinishedEvent; // winapi type: event HANDLE
    [FieldOffset(0x88)] public int LoadInProgressCounter; // reset to 1 if any scene has loads in progress during update, otherwise ticks down to 0
    [FieldOffset(0x8C)] public Vector4 ForcedStreamingSphere; // w is radius; if w<0, the rest of the components are ignored and instead camera position is used as center with radius=120

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 0F B6 D6")] // ex to avoid generated name collision
    public partial bool RaycastEx(RaycastHit* hitInfo, Vector3 origin, Vector3 direction, float maxDistance, int layerMask, int* flags);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 F0 84 C0 74 ?? 40 38 BD")]
    public static partial bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, RaycastHit* hitInfo, int* flags);

    [MemberFunction("48 83 EC 48 48 8B 05 ?? ?? ?? ?? 4D 8B D1")]
    public static partial bool Raycast2(Vector3 origin, Vector3 direction, float maxDistance, RaycastHit* hitInfo, int* flags);

    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance = 1000000f) {
        var flags = stackalloc int[] { 0x4000, 0, 0x4000, 0 };
        var hit = new RaycastHit();
        var result = Raycast(origin, direction, maxDistance, &hit, flags);
        hitInfo = hit;
        return result;
    }

    public static bool Raycast2(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance = 1000000f) {
        var flags = stackalloc int[] { 0x4000, 0, 0x4000, 0 };
        var hit = new RaycastHit();
        var result = Raycast2(origin, direction, maxDistance, &hit, flags);
        hitInfo = hit;
        return result;
    }
}


[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct RaycastHit {
    [FieldOffset(0x00)] public Vector3 Point;

    // the triangle that got hit
    [FieldOffset(0x0C)] public Vector3 V1;
    [FieldOffset(0x18)] public Vector3 V2;
    [FieldOffset(0x24)] public Vector3 V3;

    [FieldOffset(0x30), Obsolete("Use Normal instead.")] public Vector3 Unk30;
    [FieldOffset(0x30)] public Vector3 Normal; // normal to the collider shape at intersection point; not filled for all collider types

    [FieldOffset(0x40), Obsolete("Use Material instead.")] public int Flags; // layers i guess?
    [FieldOffset(0x44), Obsolete("Use Material instead.")] public int Unk44; // part of flags?
    [FieldOffset(0x40)] public ulong Material; // see notes on collider materials

    [FieldOffset(0x48)] public float Distance;
    [FieldOffset(0x50)] public Object* Object; // note: it's actually always a Collider*
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct RaycastMaterialFilter {
    [FieldOffset(0x00)] public ulong Mask;
    [FieldOffset(0x08)] public ulong Value;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct RaycastParams {
    [FieldOffset(0x00)] public int Algorithm; // see comment for BGCollisionModule
    [FieldOffset(0x08)] public Vector4* Origin; // either ray origin (Vector3) or swept sphere (Vector4 with radius in w component)
    [FieldOffset(0x10)] public Vector3* Direction;
    [FieldOffset(0x18)] public float* MaxDistance;
    [FieldOffset(0x20)] public float MaxPlaneNormalY; // used for 'non horizontal' raycast flavours
    [FieldOffset(0x28)] public RaycastMaterialFilter* MaterialFilter; // used for 'material filtering' raycast flavours
    [FieldOffset(0x30)] public ulong ObjectMaterialValue;
    [FieldOffset(0x38)] public ulong ObjectMaterialMask;
}
