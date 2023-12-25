using System.Collections;
using System.Diagnostics;

namespace FFXIVClientStructs.STD.StdHelpers;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct RedBlackTreeNodeHeader<T, TCompare>
    where T : unmanaged
    where TCompare : IStaticComparer<T> {
    public RedBlackTreeNodeHeader<T, TCompare>* Left;
    public RedBlackTreeNodeHeader<T, TCompare>* Parent;
    public RedBlackTreeNodeHeader<T, TCompare>* Right;
    public byte Color;
    public bool IsNil;
    public byte _18;
    public byte _19;
    public T Data;

    public RedBlackTreeNodeHeader<T, TCompare>* Next() {
        Debug.Assert(!IsNil, "Tried to increment a head node.");
        if (Right->IsNil) {
            fixed (RedBlackTreeNodeHeader<T, TCompare>* thisPtr = &this) {
                var ptr = thisPtr;
                RedBlackTreeNodeHeader<T, TCompare>* node;
                while (!(node = ptr->Parent)->IsNil && ptr == node->Right)
                    ptr = node;

                return node;
            }
        }

        var ret = Right;
        while (!ret->Left->IsNil)
            ret = ret->Left;
        return ret;
    }

    public RedBlackTreeNodeHeader<T, TCompare>* Prev() {
        if (IsNil) return Right;

        if (Left->IsNil) {
            fixed (RedBlackTreeNodeHeader<T, TCompare>* thisPtr = &this) {
                var ptr = thisPtr;
                RedBlackTreeNodeHeader<T, TCompare>* node;
                while (!(node = ptr->Parent)->IsNil && ptr == node->Left)
                    ptr = node;

                return ptr->IsNil ? ptr : node;
            }
        }

        var ret = Left;
        while (!ret->Right->IsNil)
            ret = ret->Right;
        return ret;
    }

    public struct Enumerator : IEnumerable<T>, IEnumerator<T> {
        private readonly RedBlackTreeNodeHeader<T, TCompare>* _head;
        private RedBlackTreeNodeHeader<T, TCompare>* _current;

        internal Enumerator(RedBlackTreeNodeHeader<T, TCompare>* head) => _head = _current = head;

        public ref T Current => ref _current->Data;

        object IEnumerator.Current => Current;

        T IEnumerator<T>.Current => Current;

        public bool MoveNext() {
            if (_current == null || _current == _head->Right)
                return false;
            _current = _current == _head ? _head->Left : _current->Next();
            return _current != null;
        }

        public void Reset() => _current = _head;

        public void Dispose() {
        }

        IEnumerator IEnumerable.GetEnumerator() => new Enumerator(_head);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(_head);
    }
}
