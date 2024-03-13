using System.Numerics;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision.Math;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct IMesh {
    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);

    // vf1: clone
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct Mesh {
    [FieldOffset(0x00)] public Object Object; // base class
    [FieldOffset(0x08)] public IMesh IMesh; // base class
    [FieldOffset(0x10)] public ColliderMesh* OwnerCollider;

    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);

    //[VirtualFunction(1)]
    //public partial nint vf1(ColliderMesh* collider, Matrix4x4* worldTransform, void* visitor);

    [VirtualFunction(2)]
    public partial Vector3* GetBoundsMin();

    [VirtualFunction(3)]
    public partial Vector3* GetBoundsMax();

    /// <summary>
    /// Perform raycast on the mesh. Note that paramsLocal contain ray/sphere origin/radius/direction in local space!
    /// World transform is used for 'non-horizontal' check, if requested.
    /// </summary>
    [VirtualFunction(4)]
    public partial bool Intersect(Matrix4x4* worldTransform, RaycastHit* result, RaycastParams* paramsLocal);

    [VirtualFunction(5)]
    public partial ushort GetNumPrimitives();

    [VirtualFunction(6)]
    public partial uint GetNumVertices();

    /// <summary>
    /// Get world-space positions for all vertices (raw and compressed) in correct order (as referenced by indices).
    /// In game, outVerticesWorld typically would be allocated on stack to fit 256 vertices.
    /// </summary>
    [VirtualFunction(7)]
    public partial void GatherVertices(Matrix4x4* worldTransform, Vector3* outVerticesWorld);

    [VirtualFunction(8)]
    public partial Primitive* GetPrimitives();

    [VirtualFunction(9)]
    public partial void GetAABB(AABB* result);

    //[VirtualFunction(10)]
    //public partial void Visit(nint visitor);

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public unsafe struct Primitive {
        [FieldOffset(0x0)] public byte V1; // index of 3 vertices
        [FieldOffset(0x1)] public byte V2;
        [FieldOffset(0x2)] public byte V3;
        [FieldOffset(0x4)] public ulong Material; // per-triangle material masks, used for optional collision filtering
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct MeshPCB {
    [FieldOffset(0x00)] public Mesh Mesh; // base class
    [FieldOffset(0x18)] public FileNode* RootNode;

    // pcb file header; it is always followed by the root node
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe partial struct FileHeader {
        // first dword is always 0? never read by the game
        [FieldOffset(0x04)] public int Version; // 0 is 'legacy', 1/4 are 'normal', rest unsupported
        [FieldOffset(0x08)] public int TotalChildNodes;
        [FieldOffset(0x0C)] public int TotalPrimitives;
    }

    // pcb is a binary tree; each node can contain some geometry and point to two sub-nodes
    // single node can contain max 256 vertices due to index size in primitives
    [StructLayout(LayoutKind.Explicit, Size = 0x30)] // variable length structure: followed by raw verts then compressed verts then prims
    public unsafe partial struct FileNode {
        [FieldOffset(0x00)] public ulong Header; // ???
        [FieldOffset(0x08)] public int Child1Offset; // byte offset from the beginning of this node
        [FieldOffset(0x0C)] public int Child2Offset; // byte offset from the beginning of this node
        [FieldOffset(0x10)] public AABB LocalBounds;
        [FieldOffset(0x28)] public ushort NumVertsCompressed; // ushort[3] per vert
        [FieldOffset(0x2A)] public ushort NumPrims; // Primitive per triangle
        [FieldOffset(0x2C)] public ushort NumVertsRaw; // vector3 per vert
        //0x2E: padding?
        // this is followed by float[3 * NumVertsRaw] - uncompressed vertices (x/y/z, can't use Vector3 due to padding)
        // this is followed by ushort[3 * NumVertsCompressed] - compressed vertices (x/y/z, 0 is LocalBounds.Min, 65535 is LocalBounds.Max)
        // this is followed by Primitive[NumPrims] - triangles

        public float* RawVerticesPtr => (float*)((FileNode*)Unsafe.AsPointer(ref this) + 1);
        public ushort* CompressedVerticesPtr => (ushort*)(RawVerticesPtr + 3 * NumVertsRaw);
        public Mesh.Primitive* PrimitivesPtr => (Mesh.Primitive*)(CompressedVerticesPtr + 3 * NumVertsCompressed);
        public FileNode* Child1 => Child1Offset != 0 ? (FileNode*)((byte*)Unsafe.AsPointer(ref this) + Child1Offset) : null;
        public FileNode* Child2 => Child2Offset != 0 ? (FileNode*)((byte*)Unsafe.AsPointer(ref this) + Child2Offset) : null;

        public Span<float> RawVertices => new(RawVerticesPtr, 3 * NumVertsRaw);
        public Span<ushort> CompressedVertices => new(CompressedVerticesPtr, 3 * NumVertsCompressed);
        public Span<Mesh.Primitive> Primitives => new(PrimitivesPtr, NumPrims);

        public Vector3 CompressedVertexScale => (LocalBounds.Max - LocalBounds.Min) / 65535.0f;
        public Vector3 Vertex(int index) {
            if (index < NumVertsRaw) {
                var data = RawVerticesPtr + 3 * index;
                return new(data[0], data[1], data[2]);
            } else if (index < NumVertsRaw + NumVertsCompressed) {
                var data = CompressedVerticesPtr + 3 * (index - NumVertsRaw);
                return LocalBounds.Min + CompressedVertexScale * new Vector3(data[0], data[1], data[2]);
            } else {
                throw new ArgumentOutOfRangeException("Vertex index out of range");
            }
        }
    }
}
