namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public unsafe struct StdLinkedList<T> where T : unmanaged {
    [StructLayout(LayoutKind.Sequential)]
    public struct Node {
        public T Value;
        public Node* Next;
        public Node* Previous;
    }

    public Node* End;
    public Node* Start;
    public uint Count;

    public Enumerator GetEnumerator() => new(this);

    public struct Enumerator(StdLinkedList<T> list) {
        private Node* _current = list.Start;

        public ref T Current => ref _current->Value;

        public bool MoveNext() {
            if (_current != null) {
                _current = _current->Next;
                return _current != null;
            }

            return false;
        }

        public void Reset() => _current = list.Start;
    }
}
