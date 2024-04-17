using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

/// <summary>
/// Each collider is added to the appropriate quad-tree node, which is then used to speed up raycasts.
/// Nodes are laid in a contiguous array, level by level, in Morton order swizzle per level.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct Quadtree {
    [FieldOffset(0x00)] public Object Object; // base class
    [FieldOffset(0x08)] public float MinX;
    [FieldOffset(0x0C)] public float MaxX;
    [FieldOffset(0x10)] public float LeafSizeX;
    [FieldOffset(0x14)] public float MinZ;
    [FieldOffset(0x18)] public float MaxZ;
    [FieldOffset(0x1C)] public float LeafSizeZ;
    [FieldOffset(0x20)] public int NumLevels;
    [FieldOffset(0x28)] public QuadtreeNode* Nodes; // each head node links to a Collider, use QuadtreeNode to traverse further
    [FieldOffset(0x30)] public int NumNodes;
    [FieldOffset(0x38)] public SceneManager* Owner;

    public static int NumNodesAtLevel(int level) => 1 << (2 * level); // 4^N
    public static int StartingNodeForLevel(int level) => (NumNodesAtLevel(level) - 1) / 3; // sum(4^i) for i=[0,N) = (1 - 4^N) / (1 - 4)
    public Span<QuadtreeNode> NodesAtLevel(int level) => new(Nodes + StartingNodeForLevel(level), NumNodesAtLevel(level));

    public static uint CellIndex(uint x, uint z) => SwizzleCoordinate(x) | (SwizzleCoordinate(z) << 1);
    public static (uint x, uint z) CellCoords(uint c) => (UnswizzleCoordinate(c), UnswizzleCoordinate(c >> 1));

    // this assumes that coordinate has high 16 bits zero - this is fine, since game supports max 10 levels, and higher level code always creates quadtree with 7 levels
    private static uint SwizzleCoordinate(uint c) {
        c = (c | (c << 8)) & 0x00FF00FF; // 0..0 c15-c8 0..0 c7-c0
        c = (c | (c << 4)) & 0x0F0F0F0F; // 0000 c15-c12 0000 c11-c8 0000 c7-c4 0000 c3-c0
        c = (c | (c << 2)) & 0x33333333; // 00 c15c14 00 c13c12 ... 00 c3c2 00 c1c0
        c = (c | (c << 1)) & 0x55555555; // 0 c15 0 c14 ... 0 c1 0 c0
        return c;
    }

    private static uint UnswizzleCoordinate(uint c) {
        c &= 0x55555555; // mask out every odd bit, since they belong to other coordinate
        // initial: 0 c15 0 c14 0 c13 .... 0 c1 0 c0
        c = (c & 0x33333333) | ((c & 0xcccccccc) >> 1);
        // now: 0 0 c15 c14 0 0 c13 c12 .... 0 0 c3 c2 0 0 c1 c0
        c = (c & 0x0F0F0F0F) | ((c & 0xF0F0F0F0) >> 2);
        // now: 0 0 0 0 c15 c14 c13 c12 0 0 0 0 c11 c10 c9 c8 .... 0 0 0 0 c3 c2 c1 c0
        c = (c & 0x00FF00FF) | ((c & 0xFF00FF00) >> 4);
        // now: 0 0 0 0 0 0 0 0 c15-c8 0 0 0 0 0 0 0 0 c7-c0
        c = (c & 0x0000FFFF) | ((c & 0xFFFF0000) >> 8);
        return c;
    }
}

// QuadtreeNode is derived from Node, but has no extra members - it's used to have two links (in scene object list and quadtree node object list) in colliders
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct QuadtreeNode {
    [FieldOffset(0)] public Node Node;

    [CExportIgnore]
    public unsafe ref struct Enumerator {
        private QuadtreeNode* _head;
        private Collider* _next;
        private Collider* _current;

        internal Enumerator(QuadtreeNode* head) {
            _head = head;
            _next = (Collider*)head->Node.NodeLink.Next;
            _current = null;
        }

        public bool MoveNext() {
            _current = _next;
            if (_next != null)
                _next = (Collider*)_next->QuadtreeNode.Node.NodeLink.Next;
            return _current != null;
        }

        public void Reset() {
            _next = (Collider*)_head->Node.NodeLink.Next;
            _current = null;
        }

        public Collider* Current => _current;

        public Enumerator GetEnumerator() => this;
    }

    public Enumerator Colliders => new Enumerator((QuadtreeNode*)Unsafe.AsPointer(ref this));
}
