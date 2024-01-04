namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

// this is the interface that's in the very base of the collision hierarchy
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct Object {
    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);
}

// collision objects are typically organized into intrusive linked lists
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct NodeLink {
    [FieldOffset(0x08)] public Node* Prev;
    [FieldOffset(0x10)] public Node* Next;

    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct Node {
    [FieldOffset(0x00)] public Object Object; // base class
    [FieldOffset(0x08)] public NodeLink NodeLink; // base class
}

// this is a utility to simplify enumerating over linked lists with objects of types derived from Node
public unsafe ref struct NodeEnumerator<Der> where Der : unmanaged {
    private Node* _begin;
    private Node* _next;
    private Node* _current;

    internal NodeEnumerator(Node* head) {
        _begin = _next = head;
        _current = null;
    }

    public bool MoveNext() {
        _current = _next;
        if (_next != null)
            _next = _next->NodeLink.Next;
        return _current != null;
    }

    public void Reset() {
        _next = _begin;
        _current = null;
    }

    public Der* Current => (Der*)_current;

    public NodeEnumerator<Der> GetEnumerator() => this;
}
