using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD.Helper;

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct HashTable<T, TKey, TKeyExtractor, THasher> : IEnumerable<Pointer<HashTable<T, TKey, TKeyExtractor, THasher>.Node>>
    where T : unmanaged
    where TKey : unmanaged
    where TKeyExtractor : IStaticKeyExtractor<T, TKey>
    where THasher : IStaticHasher<TKey> {

    public float MaxLoadFactor;

    // list of elements, must initialize before _Vec
    public Node* Head;
    public ulong Count;

    // "vector" of list iterators for buckets:
    // each bucket is 2 iterators denoting the closed range of elements in the bucket,
    // or both iterators set to _Unchecked_end() if the bucket is empty.
    public Node** Vec;
    public Node** VecLast;
    public Node** VecEnd;

    public ulong Mask; // the key mask
    public ulong MaxIndex; // current maximum key value, must be a power of 2

    [StructLayout(LayoutKind.Sequential)]
    public struct Node {
        // list node
        public Node* Next; // successor node, or first element if head
        public Node* Prev; // predecessor node, or last element if head
        public T Myval; // the stored value, unused if head
    }

    public readonly int BucketCount => checked((int)MaxIndex);

    public readonly bool ContainsKey(TKey key) => FindNode(key) is not null;

    public readonly bool TryGetValue(TKey key, out T value) {
        var node = FindNode(key);
        if (node is null) {
            value = default;
            return false;
        }

        value = node->Myval;
        return true;
    }

    public readonly Node* FindNode(TKey key) {
        if (Head is null || Vec is null || Count == 0)
            return null;

        var bucket = THasher.Hash(in key) & Mask;
        var node = Vec[(bucket << 1) + 1];
        if (node == Head)
            return null;

        var lo = Vec[bucket << 1];
        while (true) {
            // Search backwards for historical reasons
            if (StdOps<TKey>.ContentEquals(TKeyExtractor.ExtractKey(in node->Myval), in key))
                return node;

            if (node == lo)
                return null;

            node = node->Prev;
        }
    }

    public readonly Enumerator GetEnumerator() => new(Head);
    readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(Head);
    readonly IEnumerator<Pointer<Node>> IEnumerable<Pointer<Node>>.GetEnumerator() => new Enumerator(Head);

    public struct Enumerator : IEnumerator<Pointer<Node>> {
        private readonly Node* _head;
        private Node* _node;

        internal Enumerator(Node* head) {
            _head = head;
            _node = null;
        }

        public void Reset() => _node = null;

        object IEnumerator.Current => Current;
        public readonly Pointer<Node> Current => _node;

        public bool MoveNext() {
            if (_head is null)
                return false;
            _node = _node is null ? _head->Next : _node->Next;
            return _node != _head;
        }

        public void Dispose() {
        }
    }
}
