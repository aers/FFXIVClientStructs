using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "PossibleInterfaceMemberAmbiguity")]
public interface IStdList<T> : IDisposable, IReadOnlyCollection<T>, ICollection<T>
    where T : unmanaged {
    /// <summary>
    /// Gets the first node of the list.
    /// </summary>
    Pointer<Node> First { get; }
    
    /// <summary>
    /// Gets the last node of the list.
    /// </summary>
    Pointer<Node> Last { get; }
    
    long LongCount { get; }

    public abstract static Pointer<IStdList<T>.Node> CreateNodeCopy(in T value);
    public abstract static Pointer<IStdList<T>.Node> CreateNodeMove(ref T value);
    public abstract static Pointer<IStdList<T>.Node> CreateNodeDefault();
    public abstract static void DisposeNode(Pointer<Node> node);

    void AddAfter(Pointer<Node> node, Pointer<Node> newNode);
    void AddAfterDefault(Pointer<Node> node);
    void AddAfterCopy(Pointer<Node> node, in T value);
    void AddAfterMove(Pointer<Node> node, ref T value);
    void AddBefore(Pointer<Node> node, Pointer<Node> newNode);
    void AddBeforeDefault(Pointer<Node> node);
    void AddBeforeCopy(Pointer<Node> node, in T value);
    void AddBeforeMove(Pointer<Node> node, ref T value);
    void AddFirst(Pointer<Node> newNode);
    void AddFirstDefault();
    void AddFirstCopy(in T value);
    void AddFirstMove(ref T value);
    void AddLast(Pointer<Node> newNode);
    void AddLastDefault();
    void AddLastCopy(in T value);
    void AddLastMove(ref T value);
    bool Contains(in T value);
    void Detach(Pointer<Node> node);
    Pointer<Node> Find(in T value);
    Pointer<Node> FindLast(in T value);
    new Enumerator GetEnumerator();
    int GetHashCode();
    void Remove(Pointer<Node> node);
    bool Remove(in T value);
    void RemoveFirst();
    void RemoveLast();

    void ICollection<T>.Add(T item) => AddLastCopy(item);
    bool ICollection<T>.Contains(T item) => Contains(item);
    unsafe void ICollection<T>.CopyTo(T[] array, int arrayIndex) {
        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
        if (array.Length - arrayIndex < LongCount)
            throw new ArgumentException(null, nameof(array));

        var i = (long)arrayIndex;
        for (var node = First.Value; node != Last.Value; node = node->Next)
            array[i] = node->Value;
    }
    bool ICollection<T>.Remove(T item) => Remove(item);
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(Last);
    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(Last);
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Node {
        public Node* Next;
        public Node* Previous;
        // Unused in the head node
        public T Value;
    }

    public unsafe struct Enumerator : IEnumerable<T>, IEnumerator<T> {
        private readonly Node* _head;
        private Node* _current;

        internal Enumerator(Pointer<Node> head) => _head = _current = head;

        public ref T Current => ref _current->Value;

        object IEnumerator.Current => Current;

        T IEnumerator<T>.Current => Current;

        public bool MoveNext() {
            if (_head == null || _current->Next == _head)
                return false;
            _current = _current->Next;
            return true;
        }

        public void Reset() => _current = _head;

        public void Dispose() {
        }

        IEnumerator IEnumerable.GetEnumerator() => new Enumerator(_head);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(_head);
    }
}
