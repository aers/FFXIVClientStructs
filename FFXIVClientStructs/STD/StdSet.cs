using System.Collections;
using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdSet<T, TMemorySpace>
    : IReadOnlySet<T>
        , ISet<T>
        , ICollection
        , IDisposable
    , IEquatable<StdSet<T, TMemorySpace>>
    where T : unmanaged
    where TMemorySpace : IStaticMemorySpace {
    public RedBlackTree<T, TMemorySpace> Tree;

    public readonly long LongCount => Tree.LongCount;

    public readonly int Count => checked((int)Tree.LongCount);

    public readonly bool IsReadOnly => false;

    #region Collection interfaces

    int ICollection.Count => Count;
    int ICollection<T>.Count => Count;
    int IReadOnlyCollection<T>.Count => Count;

    bool ICollection<T>.IsReadOnly => false;
    bool ICollection.IsSynchronized => false;
    object ICollection.SyncRoot => Array.Empty<byte>();

    #endregion

    public readonly RedBlackTree<T, TMemorySpace>.Enumerator GetEnumerator() => new(Tree.Pointer, true);

    public readonly RedBlackTree<T, TMemorySpace>.Enumerator Reverse() => new(Tree.Pointer, false);

    public bool AddCopy(in T item) {
        if (!Tree.TryInsertEmpty(item, out var node))
            return false;

        StdOps<T>.ConstructCopyInPlace(item, out node->_Myval);
        return true;
    }

    public bool AddMove(ref T item) {
        if (!Tree.TryInsertEmpty(item, out var node))
            return false;

        StdOps<T>.ConstructMoveInPlace(ref item, out node->_Myval);
        return true;
    }

    public void Clear() => Tree.EraseHead();

    public readonly bool Contains(in T item) {
        var b = Tree.FindLowerBound(item).Bound;
        return b is not null && StdOps<T>.ContentEquals(b->_Myval, item);
    }

    public readonly void CopyTo(T[] array, int arrayIndex) {
        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
        if (array.Length - arrayIndex < LongCount)
            throw new ArgumentException(null, nameof(array));

        var i = (long)arrayIndex;
        foreach (ref var p in this)
            array[i++] = p;
    }

    public void Dispose() => Tree.EraseHead();

    public readonly bool Equals(in StdSet<T, TMemorySpace> other) => Tree.Equals(other.Tree);
    readonly bool IEquatable<StdSet<T, TMemorySpace>>.Equals(StdSet<T, TMemorySpace> other) => Tree.Equals(other.Tree);
    public readonly override bool Equals(object? obj) => obj is StdSet<T, TMemorySpace> t && Equals(t);

    public void ExceptWith(IEnumerable<T> other) {
        var n = Tree.Min();
        if (n is null)
            return;
        
        if (other is not IReadOnlySet<T> otherSet)
            otherSet = other.ToHashSet();
        
        using var enumerator = GetEnumerator();
        for (var state = enumerator.MoveNext(); state;) {
            state = otherSet.Contains(enumerator.Current)
                ? enumerator.DeleteAndMoveNext()
                : enumerator.MoveNext();
        }
    }

    public override int GetHashCode() => Tree.GetHashCode();

    public void IntersectWith(IEnumerable<T> other) {
        var n = Tree.Min();
        if (n is null)
            return;
        
        if (other is not IReadOnlySet<T> otherSet)
            otherSet = other.ToHashSet();
        
        using var enumerator = GetEnumerator();
        for (var state = enumerator.MoveNext(); state;) {
            state = !otherSet.Contains(enumerator.Current)
                ? enumerator.DeleteAndMoveNext()
                : enumerator.MoveNext();
        }
    }

    public readonly bool IsProperSubsetOf(IEnumerable<T> other) {
        CountOverlaps(other, out var notFoundInOther, out var notFoundInSelf);
        return notFoundInOther == 0 && notFoundInSelf > 0;
    }

    public readonly bool IsProperSupersetOf(IEnumerable<T> other) {
        CountOverlaps(other, out var notFoundInOther, out var notFoundInSelf);
        return notFoundInOther > 0 && notFoundInSelf == 0;
    }

    public readonly bool IsSubsetOf(IEnumerable<T> other) {
        CountOverlaps(other, out var notFoundInOther, out _);
        return notFoundInOther == 0;
    }

    public readonly bool IsSupersetOf(IEnumerable<T> other) {
        CountOverlaps(other, out _, out var notFoundInSelf);
        return notFoundInSelf == 0;
    }

    public readonly ref readonly T Min() => ref Tree.Min()->_Myval;

    public readonly ref readonly T Max() => ref Tree.Min()->_Myval;

    public readonly bool Overlaps(IEnumerable<T> other) {
        CountOverlaps(other, out _, out var notFoundInSelf);
        return notFoundInSelf < Tree.LongCount;
    }

    public bool Remove(T item) {
        var b = Tree.FindLowerBound(item).Bound;
        if (b is null || !StdOps<T>.ContentEquals(b->_Myval, item))
            return false;
        Tree.ExtractAndErase(b);
        return true;
    }

    public readonly bool SetEquals(IEnumerable<T> other) {
        CountOverlaps(other, out var notFoundInOther, out var notFoundInSelf);
        return notFoundInOther == 0 && notFoundInSelf == 0;
    }

    public void SymmetricExceptWith(IEnumerable<T> other) {
        var n = Tree.Min();
        if (n is null)
            return;
        
        var otherSet = other.ToHashSet();
        
        using var enumerator = GetEnumerator();
        for (var state = enumerator.MoveNext(); state;) {
            state = otherSet.Remove(enumerator.Current)
                ? enumerator.DeleteAndMoveNext()
                : enumerator.MoveNext();
        }

        foreach (var o in otherSet)
            AddCopy(o);
    }

    public T[] ToArray() {
        var res = new T[LongCount];
        var i = 0L;
        foreach (ref var v in this)
            res[i++] = v;
        return res;
    }

    public T[] ToArrayReverse() {
        var res = new T[LongCount];
        var i = 0L;
        foreach (ref var v in Reverse())
            res[i++] = v;
        return res;
    }

    public void UnionWith(IEnumerable<T> other) {
        foreach (var o in other)
            AddCopy(o);
    }

    #region Collection interfaces

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    void ICollection.CopyTo(Array array, int index) {
        if (array is not T[] typedArray)
            throw new ArgumentException(null, nameof(array));
        CopyTo(typedArray, index);
    }

    void ICollection<T>.Add(T item) => AddCopy(item);

    void ICollection<T>.Clear() => Clear();

    bool ICollection<T>.Contains(T item) => Contains(item);

    bool ICollection<T>.Remove(T item) => Remove(item);

    bool ISet<T>.Add(T item) => AddCopy(item);

    bool IReadOnlySet<T>.Contains(T item) => Contains(item);

    #endregion

    private readonly void CountOverlaps(IEnumerable<T> other, out long notFoundInOther, out long notFoundInSelf) {
        if (other is not IReadOnlySet<T>)
            other = other.ToHashSet();

        notFoundInOther = Tree.LongCount;
        notFoundInSelf = 0L;
        foreach (var r in other) {
            if (Contains(r))
                notFoundInOther--;
            else
                notFoundInSelf++;
        }
    }
}
