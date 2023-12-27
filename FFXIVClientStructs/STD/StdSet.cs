using System.Collections;
using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdSet<TKey> : IReadOnlySet<TKey>, ISet<TKey>, IDisposable, IEquatable<StdSet<TKey>>
    where TKey : unmanaged {
    public RedBlackTree<TKey, DefaultStaticNativeObjectOperation<TKey>> Tree;

    public readonly long LongCount => Tree.LongCount;

    public readonly int Count => checked((int)Tree.LongCount);

    public readonly bool IsReadOnly => false;

    public readonly RedBlackTree<TKey, DefaultStaticNativeObjectOperation<TKey>>.Enumerator GetEnumerator() => new(Tree.Pointer, true);

    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    readonly IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();

    public readonly RedBlackTree<TKey, DefaultStaticNativeObjectOperation<TKey>>.Enumerator Reverse() => new(Tree.Pointer, false);

    public bool AddCopy(in TKey item) {
        if (!Tree.TryInsertEmpty<DefaultStaticMemorySpace>(item, out var node))
            return false;

        DefaultStaticNativeObjectOperation<TKey>.ConstructCopyInPlace(item, out node->_Myval);
        return true;
    }

    public bool AddMove(ref TKey item) {
        if (!Tree.TryInsertEmpty<DefaultStaticMemorySpace>(item, out var node))
            return false;

        DefaultStaticNativeObjectOperation<TKey>.ConstructMoveInPlace(ref item, out node->_Myval);
        return true;
    }

    void ICollection<TKey>.Add(TKey item) => AddCopy(item);

    bool ISet<TKey>.Add(TKey item) => AddCopy(item);

    public void Clear() => Tree.EraseHead();

    public readonly bool Contains(in TKey item) {
        var b = Tree.FindLowerBound(item).Bound;
        return b is not null && DefaultStaticNativeObjectOperation<TKey>.ContentEquals(b->_Myval, item);
    }

    readonly bool ICollection<TKey>.Contains(TKey item) => Contains(item);

    readonly bool IReadOnlySet<TKey>.Contains(TKey item) => Contains(item);

    public readonly void CopyTo(TKey[] array, int arrayIndex) {
        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
        if (array.Length - arrayIndex < LongCount)
            throw new ArgumentException(null, nameof(array));

        var i = (long)arrayIndex;
        foreach (ref var p in this)
            array[i++] = p;
    }

    public void Dispose() => Tree.EraseHead();

    public readonly bool Equals(in StdSet<TKey> other) => Tree.Equals(other.Tree);
    readonly bool IEquatable<StdSet<TKey>>.Equals(StdSet<TKey> other) => Tree.Equals(other.Tree);
    public readonly override bool Equals(object? obj) => obj is StdSet<TKey> t && Equals(t);

    public void ExceptWith(IEnumerable<TKey> other) {
        var n = Tree.Min();
        if (n is null)
            return;
        
        if (other is not IReadOnlySet<TKey> otherSet)
            otherSet = other.ToHashSet();
        
        using var enumerator = GetEnumerator();
        for (var state = enumerator.MoveNext(); state;) {
            state = otherSet.Contains(enumerator.Current)
                ? enumerator.DeleteAndMoveNext()
                : enumerator.MoveNext();
        }
    }

    public override int GetHashCode() => Tree.GetHashCode();

    public void IntersectWith(IEnumerable<TKey> other) {
        var n = Tree.Min();
        if (n is null)
            return;
        
        if (other is not IReadOnlySet<TKey> otherSet)
            otherSet = other.ToHashSet();
        
        using var enumerator = GetEnumerator();
        for (var state = enumerator.MoveNext(); state;) {
            state = !otherSet.Contains(enumerator.Current)
                ? enumerator.DeleteAndMoveNext()
                : enumerator.MoveNext();
        }
    }

    public readonly bool IsProperSubsetOf(IEnumerable<TKey> other) {
        CountOverlaps(other, out var notFoundInOther, out var notFoundInSelf);
        return notFoundInOther == 0 && notFoundInSelf > 0;
    }

    public readonly bool IsProperSupersetOf(IEnumerable<TKey> other) {
        CountOverlaps(other, out var notFoundInOther, out var notFoundInSelf);
        return notFoundInOther > 0 && notFoundInSelf == 0;
    }

    public readonly bool IsSubsetOf(IEnumerable<TKey> other) {
        CountOverlaps(other, out var notFoundInOther, out _);
        return notFoundInOther == 0;
    }

    public readonly bool IsSupersetOf(IEnumerable<TKey> other) {
        CountOverlaps(other, out _, out var notFoundInSelf);
        return notFoundInSelf == 0;
    }

    public readonly ref readonly TKey Min() => ref Tree.Min()->_Myval;

    public readonly ref readonly TKey Max() => ref Tree.Min()->_Myval;

    public readonly bool Overlaps(IEnumerable<TKey> other) {
        CountOverlaps(other, out _, out var notFoundInSelf);
        return notFoundInSelf < Tree.LongCount;
    }

    public bool Remove(TKey item) {
        var b = Tree.FindLowerBound(item).Bound;
        if (b is null || !DefaultStaticNativeObjectOperation<TKey>.ContentEquals(b->_Myval, item))
            return false;
        Tree.ExtractAndErase(b);
        return true;
    }

    public readonly bool SetEquals(IEnumerable<TKey> other) {
        CountOverlaps(other, out var notFoundInOther, out var notFoundInSelf);
        return notFoundInOther == 0 && notFoundInSelf == 0;
    }

    public void SymmetricExceptWith(IEnumerable<TKey> other) {
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

    public TKey[] ToArray() {
        var res = new TKey[LongCount];
        var i = 0L;
        foreach (ref var v in this)
            res[i++] = v;
        return res;
    }

    public TKey[] ToArrayReverse() {
        var res = new TKey[LongCount];
        var i = 0L;
        foreach (ref var v in Reverse())
            res[i++] = v;
        return res;
    }

    public void UnionWith(IEnumerable<TKey> other) {
        foreach (var o in other)
            AddCopy(o);
    }

    private readonly void CountOverlaps(IEnumerable<TKey> other, out long notFoundInOther, out long notFoundInSelf) {
        if (other is not IReadOnlySet<TKey>)
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
