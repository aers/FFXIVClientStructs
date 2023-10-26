namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct StdList<T> where T : unmanaged {
    [StructLayout(LayoutKind.Sequential)]
    public struct Node {
        public Node* Next;
        public Node* Previous;
        public T Value;
    }

    public Node* Head;
    public ulong Size;
}
