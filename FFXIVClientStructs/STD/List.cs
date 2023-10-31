namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct StdList<T> where T : unmanaged {
    [StructLayout(LayoutKind.Sequential)]
    public struct Node {
        public Node* Next;
        public Node* Previous;
        // Unused in the head node
        public T Value;
    }

    // First node is Head->Next
    // Last node is Head->Previous
    public Node* Head;

    // Size is the number of nodes in the list (excluding the head node)
    public ulong Size;
}
