using System.Numerics;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision.Math;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

public enum ColliderType : int {
    Streamed = 1,
    Mesh = 2,
    Box = 3,
    Cylinder = 4,
    Sphere = 5,
    Plane = 6,
    PlaneTwoSided = 7,
}

// base class for individual objects in the collision scene
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct Collider {
    [FieldOffset(0x00)] public Node Node; // base class, traverse these links to iterate over global scene's collider list
    [FieldOffset(0x20)] public QuadtreeNode QuadtreeNode; // also a base class, traverse these links to iterate over quadtree node's collider list
    //[FieldOffset(0x40)] public uint u40;
    [FieldOffset(0x44)] public uint NumRefs; // remove from scene actually decrements the refcount, collider is removed later in update; sometimes (e.g. while async load is in progress) there could be extra refs
    [FieldOffset(0x48)] public Scene* Scene;
    //0x50: int
    //0x54: padding?
    //0x58: long
    //0x60: long
    [FieldOffset(0x68)] public ulong LayerMask;
    [FieldOffset(0x70)] public ulong ObjectMaterialValue;
    [FieldOffset(0x78)] public ulong ObjectMaterialMask;
    [FieldOffset(0x80)] public float LastTranslationDeltaY;
    [FieldOffset(0x84)] public byte VisibilityFlags; // 0x1 - active for raycasts/containing checks (if not set, collider is ignored during raycasts), 0x2 - active for some global visit function?, rest uninitialized
    //[FieldOffset(0x88)] public UpdateListeners UpdateListeners; // size 0x18 - a typical linked list of callback objects

    /// <summary>
    /// No-op for all derived classes except Mesh.
    /// </summary>
    [VirtualFunction(1)]
    public partial void Load(byte* path);

    /// <summary>
    /// No-op for all derived classes except Mesh. Called by Scene's update when WantUnload returns true before deleting the object.
    /// </summary>
    [VirtualFunction(2)]
    public partial void Unload();

    /// <summary>
    /// Checked every update. Base implementation just checks NumRefs for zero, but derived classes that do async loads also check that load is not in progress.
    /// </summary>
    [VirtualFunction(3)]
    public partial bool WantUnload();

    [VirtualFunction(4)]
    public partial void GetMaterial(ulong* id, ulong* mask);

    [VirtualFunction(5)]
    public partial ulong GetMaterialId();

    [VirtualFunction(6)]
    public partial ulong GetMaterialMask();

    [VirtualFunction(7)]
    public partial void SetMaterial(ulong id, ulong mask);

    [VirtualFunction(8)]
    public partial void SetTranslation(Vector3* translation);

    [VirtualFunction(9)]
    public partial void GetTranslation(Vector3* translation);

    [VirtualFunction(10)]
    public partial void GetWorldBB(AABB* bounds);

    [VirtualFunction(11)]
    public partial void SetRotation(Vector3* eulerAngles);

    [VirtualFunction(12)]
    public partial void GetRotation(Vector3* eulerAngles);

    [VirtualFunction(13)]
    public partial void SetScale(Vector3* scale);

    [VirtualFunction(14)]
    public partial void GetScale(Vector3* scale);

    [VirtualFunction(15)]
    public partial void GetWorldTransform(Matrix4x4* transform);

    [VirtualFunction(16)]
    public partial void GetInvWorldTransform(Matrix4x4* transform);

    [VirtualFunction(17)]
    public partial ColliderType GetColliderType();

    /// <summary>
    /// Called every frame if WantUnload returns false. If returns true, it is readded to the quadtree - otherwise LastTranslationDeltaY is reset to 0.
    /// </summary>
    /// <returns></returns>
    [VirtualFunction(18)]
    public partial bool Update();

    [VirtualFunction(19)]
    public partial bool LoadInProgress();

    [VirtualFunction(20)]
    public partial bool Raycast(RaycastHit* result, ulong layerMask, RaycastParams* args);

    [VirtualFunction(21)]
    public partial bool IsInsideCheckLayer(ulong layerMask, Vector3* pos);

    [VirtualFunction(22)]
    public partial bool IsInside(Vector3* pos);

    //vf23: Visit
}

/// <summary>
/// Streamed collider does not contribute to the collision scene by itself, however it adds and removes other mesh colliders that are inside streaming sphere.
/// In the file system, the whole streamable scene is located in a single directory; the root file is typically called list.pcb.
/// Individual streamable meshes are called /trXXXX.pcb, where XXXX is MeshId field (with zero padding - formatted as %04d).
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct ColliderStreamed {
    [FieldOffset(0x000)] public Collider Collider; // base class
    //0xA0: base class Common::Component::Excel::ExcelResourceListener, size=8
    [FieldOffset(0x0A8)] public fixed byte PathBase[256]; // root directory of the streamed meshes
    [FieldOffset(0x1A8)] public Resource* Resource;
    [FieldOffset(0x1B0)] public int NumMeshesLoading;
    [FieldOffset(0x1B4)] public bool Loaded;
    [FieldOffset(0x1B8)] public float StreamedMinX;
    [FieldOffset(0x1BC)] public float StreamedMinZ;
    [FieldOffset(0x1C0)] public float StreamedMaxX;
    [FieldOffset(0x1C4)] public float StreamedMaxZ;
    [FieldOffset(0x1C8)] public FileHeader* Header; // raw file data
    [FieldOffset(0x1D0)] public FileEntry* Entries; // raw file data, count == Header->NumMeshes
    [FieldOffset(0x1D8)] public Element* Elements; // count == Header->NumMeshes

    // header is followed by NumMeshes entries
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct FileHeader {
        [FieldOffset(0x00)] public int NumMeshes;
        [FieldOffset(0x04)] public AABB Bounds; // not read by the game
        //0x1C: padding?
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct FileEntry {
        [FieldOffset(0x00)] public int MeshId;
        [FieldOffset(0x04)] public AABB Bounds; // note: y bounds are ignored when reading the file
        //0x1C: padding?
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct Element {
        [FieldOffset(0x00)] public int MeshId;
        [FieldOffset(0x08)] public ColliderMesh* Mesh;
        [FieldOffset(0x10)] public float MinX;
        [FieldOffset(0x14)] public float MinZ;
        [FieldOffset(0x18)] public float MaxX;
        [FieldOffset(0x1C)] public float MaxZ;
    }

    // note: it has a bunch of extra no-op virtual funcs - I suspect these are various raycast flavours that were at some point removed from base class, but had empty overrides left in derived classes
}

/// <summary>
/// Generic mesh collider.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x198)]
public unsafe partial struct ColliderMesh {
    [FieldOffset(0x000)] public Collider Collider; // base class
    //0xA0: base class Common::Component::Excel::ExcelResourceListener, size=8
    [FieldOffset(0x0A8)] public Resource* Resource;
    [FieldOffset(0x0B0)] public byte* MemoryData; // if non-null, the mesh data is built programmatically in memory rather than being loaded from file
    [FieldOffset(0x0B8)] public int TotalPrimitives;
    [FieldOffset(0x0BC)] public bool Dirty; // set when object is moved, on next update matrices will be recalculated
    [FieldOffset(0x0BD)] public bool MeshIsSimple; // if true, Mesh is a MeshSimple rather than MeshPCB - this doesn't seem to be ever used in game
    [FieldOffset(0x0BE)] public bool Loaded;
    [FieldOffset(0x0C0)] public float InvScaleX;
    [FieldOffset(0x0C8)] public Mesh* Mesh;
    [FieldOffset(0x0D0)] public int TotalChildren;
    [FieldOffset(0x0D4)] public Vector3 Translation;
    [FieldOffset(0x0E0)] public Vector3 Rotation;
    [FieldOffset(0x0EC)] public Vector3 Scale;
    [FieldOffset(0x0F8)] public Vector3 TranslationPrev;
    [FieldOffset(0x104)] public Vector3 RotationPrev;
    [FieldOffset(0x110)] public Matrix4x3 World;
    [FieldOffset(0x140)] public Matrix4x3 InvWorld;
    [FieldOffset(0x170)] public Vector4 BoundingSphere;
    [FieldOffset(0x180)] public AABB WorldBoundingBox;
}

/// <summary>
/// Box collider - local center is at origin, half-width is 1 in each dimension - so local bounds are (-1,-1,-1) to (1,1,1).
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public unsafe partial struct ColliderBox {
    [FieldOffset(0x000)] public Collider Collider; // base class
    [FieldOffset(0x0A0)] public Vector3 Translation;
    [FieldOffset(0x0AC)] public Vector3 TranslationPrev;
    [FieldOffset(0x0B8)] public Vector3 Rotation;
    [FieldOffset(0x0C4)] public Vector3 RotationPrev;
    [FieldOffset(0x0D0)] public Vector3 Scale;
    [FieldOffset(0x0DC)] public Matrix4x3 World;
    [FieldOffset(0x10C)] public Matrix4x3 InvWorld;
    [FieldOffset(0x13C)] public bool Dirty;
}

/// <summary>
/// Cylinder collider - local center is at origin, local axis is (0,1,0), half-height and radius are 1 - so local bounds are (-1,-1,-1) to (1,1,1).
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct ColliderCylinder {
    [FieldOffset(0x000)] public Collider Collider; // base class
    [FieldOffset(0x0A0)] public Vector3 Translation;
    [FieldOffset(0x0AC)] public Vector3 TranslationPrev;
    [FieldOffset(0x0B8)] public Vector3 Rotation;
    [FieldOffset(0x0C4)] public Vector3 RotationPrev;
    [FieldOffset(0x0D0)] public Vector3 Scale; // z component is set equal to x component on update
    [FieldOffset(0x0DC)] public float Radius; // same as x scale
    [FieldOffset(0x0E0)] public Matrix4x3 World;
    [FieldOffset(0x110)] public Matrix4x3 InvWorld;
    [FieldOffset(0x140)] public bool Dirty;
}

/// <summary>
/// Sphere collider - local center is at origin, radius is 1 - so local bounds are (-1,-1,-1) to (1,1,1).
/// At least some parts of the code assume that scale is always uniform.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe partial struct ColliderSphere {
    [FieldOffset(0x000)] public Collider Collider; // base class
    [FieldOffset(0x0A0)] public bool Dirty;
    [FieldOffset(0x0A4)] public Vector3 Translation;
    [FieldOffset(0x0B0)] public Vector3 TranslationPrev;
    [FieldOffset(0x0BC)] public Vector3 Rotation;
    [FieldOffset(0x0C8)] public Vector3 RotationPrev;
    [FieldOffset(0x0D4)] public Vector3 Scale; // parts of code assume this is uniform and assume x component is radius
    [FieldOffset(0x0E0)] public Vector3 ScalePrev;
    [FieldOffset(0x0EC)] public Matrix4x3 World;
    [FieldOffset(0x11C)] public Matrix4x3 InvWorld;
}

/// <summary>
/// Plane collider - local center is at origin, local normal is (0,0,1), half-side is 1 - so local bounds are (-1,-1,0) to (1,1,0).
/// There are two flavours of planes - one-sided and two-sided (latter is implemented as a derived class without any new fields).
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public unsafe partial struct ColliderPlane {
    [FieldOffset(0x000)] public Collider Collider; // base class
    [FieldOffset(0x0A0)] public Vector3 Translation;
    [FieldOffset(0x0AC)] public Vector3 TranslationPrev;
    [FieldOffset(0x0B8)] public Vector3 Rotation;
    [FieldOffset(0x0C4)] public Vector3 RotationPrev;
    [FieldOffset(0x0D0)] public Vector3 Scale;
    [FieldOffset(0x0DC)] public Matrix4x3 World;
    [FieldOffset(0x10C)] public Matrix4x3 InvWorld;
    [FieldOffset(0x13C)] public bool Dirty;
    [FieldOffset(0x13D)] public bool TwoSided;
}
