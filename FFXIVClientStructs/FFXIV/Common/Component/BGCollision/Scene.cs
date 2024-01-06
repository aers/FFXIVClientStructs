using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct SceneManager {
    [FieldOffset(0x08)] public void* ResourceManager;
    //[FieldOffset(0x10)] public int u10; - set to BGCollisionModule.u0 != 0 on init => always 0
    [FieldOffset(0x18)] public SceneWrapper* FirstScene; // this is a linked list that always contains a single scene created on init; there are functions that create or destroy additional scenes, but they are not used
    [FieldOffset(0x20)] public int NumScenes;
    [FieldOffset(0x28)] public Vector4 StreamingSphere; // updated every frame by the module

    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);

    /// <summary>
    /// Iterate over loaded scenes. Currently there's always one scene when module is initialized, but game has some unused functions that create or remove more scenes.
    /// </summary>
    public NodeEnumerator<SceneWrapper> Scenes => new(&FirstScene->Node);
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct SceneWrapper {
    [FieldOffset(0x00)] public Node Node; // base class
    [FieldOffset(0x20)] public SceneManager* Manager;
    [FieldOffset(0x28)] public Scene* Scene;

    [VirtualFunction(1)]
    public partial void Clear();

    [VirtualFunction(2)]
    public partial void SetStreamingSphere(float x, float y, float z, float radius);

    [VirtualFunction(3)]
    public partial bool HasLoadingColliders();

    [VirtualFunction(4)]
    public partial ColliderStreamed* AddColliderStreamed(ulong layerMask, byte* pathBase, bool a3);

    [VirtualFunction(5)]
    public partial ColliderMesh* AddColliderMesh(ulong layerMask, byte* path, bool a3, Vector3* translation, Vector3* rotation, Vector3* scale);

    /// <summary>
    /// Create a mesh collider that uses a copy of hardcoded tesselated cylinder geometry.
    /// </summary>
    [VirtualFunction(6)]
    public partial ColliderMesh* AddColliderMeshCylinder(ulong layerMask, Vector3* translation, Vector3* rotation, Vector3* scale);

    [VirtualFunction(7)]
    public partial ColliderBox* AddColliderBox(ulong layerMask, Vector3* translation, Vector3* rotation, Vector3* scale);

    [VirtualFunction(8)]
    public partial ColliderCylinder* AddColliderCylinder(ulong layerMask, Vector3* translation, Vector3* rotation, Vector3* scale);

    [VirtualFunction(9)]
    public partial ColliderSphere* AddColliderSphere(ulong layerMask, Vector3* translation, Vector3* rotation, Vector3* scale);

    [VirtualFunction(10)]
    public partial ColliderPlane* AddColliderPlane(ulong layerMask, Vector3* translation, Vector3* rotation, Vector3* scale);

    [VirtualFunction(11)]
    public partial ColliderPlane* AddColliderPlaneTwoSided(ulong layerMask, Vector3* translation, Vector3* rotation, Vector3* scale);

    [VirtualFunction(12)]
    public partial void RemoveCollider(Collider* collider);

    [VirtualFunction(13)]
    public partial void UpdateColliders();

    [VirtualFunction(14)]
    public partial bool Raycast(RaycastHit* hitInfo, ulong layerMask, RaycastParams* args);

    [VirtualFunction(15)]
    public partial bool ExecuteForEachIntersecting(void* visitor, ulong layerMask, RaycastMaterialFilter* materialFilter, Vector3* rayOrigin, Vector3* rayDirection, float maxDistance);

    [VirtualFunction(16)]
    public partial bool FindContainingCollidersCheckLayer(ColliderList* result, ulong layerMask, Vector3* pos);

    [VirtualFunction(17)]
    public partial bool FindContainingColliders(ColliderList* result, Vector3* pos);

    //[VirtualFunction(18)]
    //public partial bool Visit1(void* visitor);

    // vf19: no-op

    //[VirtualFunction(20)]
    //public partial bool Visit2(void* visitor, Vector3* pos, uint quadtreeLevel);

    //[VirtualFunction(21)]
    //public partial bool Visit3(void* visitor, Vector3* pos);

    [StructLayout(LayoutKind.Explicit, Size = 0x84)]
    public unsafe partial struct ColliderList {
        [FieldOffset(0x00), FixedSizeArray<Pointer<Collider>>(16)] public fixed byte Colliders[16 * 8];
        [FieldOffset(0x80)] public int Count;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct Scene {
    [FieldOffset(0x00)] public Object Object; // base class
    [FieldOffset(0x08)] public SceneManager* Manager;
    [FieldOffset(0x10)] public Collider* FirstCollider;
    [FieldOffset(0x18)] public int NumColliders;
    [FieldOffset(0x20)] public Vector4 StreamingSphere; // xyz = origin, w = radius
    [FieldOffset(0x30)] public int NumLoading;
    [FieldOffset(0x38)] public Quadtree* Quadtree;

    /// <summary>
    /// Iterate over colliders in the scene.
    /// </summary>
    public NodeEnumerator<Collider> Colliders => new(&FirstCollider->Node);
}
