using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdMap<TKey, TValue, TMemorySpace>
    : IStdMap<TKey, TValue>
        , IStaticNativeObjectOperation<StdMap<TKey, TValue, TMemorySpace>>
    where TKey : unmanaged
    where TValue : unmanaged
    where TMemorySpace : IStaticMemorySpace {

    public RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>> Tree;

    public static bool HasDefault => true;
    public static bool IsDisposable => true;
    public static bool IsCopyable => StdOps<TKey>.IsCopyable && StdOps<TValue>.IsCopyable;
    public static bool IsMovable => true;

    /// <inheritdoc cref="IStdMap{TKey,TValue}.Count"/>
    public readonly int Count => checked((int)Tree.LongCount);

    /// <inheritdoc/>
    public readonly long LongCount => Tree.LongCount;

    /// <inheritdoc/>
    public readonly IStdMap<TKey, TValue>.KeyCollection Keys => new(Tree.Pointer);

    /// <inheritdoc/>
    public readonly IStdMap<TKey, TValue>.ValueCollection Values => new(Tree.Pointer);

    /// <inheritdoc/>
    public ref TValue this[in TKey key] {
        get {
            var loc = Tree.FindLowerBound(key);
            if (loc.KeyEquals(key))
                return ref loc.Bound->_Myval.Item2;

            if (!StdOps<TKey>.IsCopyable)
                throw new InvalidOperationException("Key is not copiable");
            if (!StdOps<TValue>.HasDefault)
                throw new InvalidOperationException("Value has no default");

            var node = Tree.InsertEmpty<TMemorySpace>(loc);
            StdOps<TKey>.ConstructCopyInPlace(key, out node->_Myval.Item1);
            StdOps<TValue>.ConstructDefaultInPlace(out node->_Myval.Item2);
            return ref node->_Myval.Item2;
        }
    }

    /// <inheritdoc/>
    readonly TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key] {
        get {
            var loc = Tree.FindLowerBound(key);
            if (loc.KeyEquals(key))
                return loc.Bound->_Myval.Item2;
            throw new KeyNotFoundException();
        }
    }

    /// <inheritdoc/>
    TValue IDictionary<TKey, TValue>.this[TKey key] {
        readonly get {
            var loc = Tree.FindLowerBound(key);
            if (loc.KeyEquals(key))
                return loc.Bound->_Myval.Item2;
            throw new KeyNotFoundException();
        }
        set {
            var loc = Tree.FindLowerBound(key);
            if (loc.KeyEquals(key)) {
                StdOps<TValue>.StaticDispose(ref loc.Bound->_Myval.Item2);
                StdOps<TValue>.ConstructCopyInPlace(value, out loc.Bound->_Myval.Item2);
            } else {
                if (!StdOps<TKey>.IsCopyable)
                    throw new InvalidOperationException("Key is not copiable");
                if (!StdOps<TValue>.IsCopyable)
                    throw new InvalidOperationException("Value is not copiable");

                var node = Tree.InsertEmpty<TMemorySpace>(loc);
                StdOps<TKey>.ConstructCopyInPlace(key, out node->_Myval.Item1);
                StdOps<TValue>.ConstructCopyInPlace(value, out node->_Myval.Item2);
            }
        }
    }

    /// <inheritdoc/>
    public bool TryAddValueKCopyVCopy(in TKey key, in TValue value) {
        var loc = Tree.FindLowerBound(key);
        if (loc.KeyEquals(key))
            return false;
        if (!StdOps<TKey>.IsCopyable)
            throw new InvalidOperationException("Key is not copiable");
        if (!StdOps<TValue>.IsCopyable)
            throw new InvalidOperationException("Value is not copiable");

        var node = Tree.InsertEmpty<TMemorySpace>(loc);
        StdOps<TKey>.ConstructCopyInPlace(key, out node->_Myval.Item1);
        StdOps<TValue>.ConstructCopyInPlace(value, out node->_Myval.Item2);
        return true;
    }

    /// <inheritdoc/>
    public bool TryAddValueKCopyVMove(in TKey key, ref TValue value) {
        var loc = Tree.FindLowerBound(key);
        if (loc.KeyEquals(key))
            return false;
        if (!StdOps<TKey>.IsCopyable)
            throw new InvalidOperationException("Key is not copiable");
        if (!StdOps<TValue>.IsMovable)
            throw new InvalidOperationException("Value is not movable");

        var node = Tree.InsertEmpty<TMemorySpace>(loc);
        StdOps<TKey>.ConstructCopyInPlace(key, out node->_Myval.Item1);
        StdOps<TValue>.ConstructMoveInPlace(ref value, out node->_Myval.Item2);
        return true;
    }

    /// <inheritdoc/>
    public bool TryAddValueKMoveVCopy(ref TKey key, in TValue value) {
        var loc = Tree.FindLowerBound(key);
        if (loc.KeyEquals(key))
            return false;
        if (!StdOps<TKey>.IsMovable)
            throw new InvalidOperationException("Key is not movable");
        if (!StdOps<TValue>.IsCopyable)
            throw new InvalidOperationException("Value is not copiable");

        var node = Tree.InsertEmpty<TMemorySpace>(loc);
        StdOps<TKey>.ConstructMoveInPlace(ref key, out node->_Myval.Item1);
        StdOps<TValue>.ConstructCopyInPlace(value, out node->_Myval.Item2);
        return true;
    }

    /// <inheritdoc/>
    public bool TryAddValueKMoveVMove(ref TKey key, ref TValue value) {
        var loc = Tree.FindLowerBound(key);
        if (loc.KeyEquals(key))
            return false;
        if (!StdOps<TKey>.IsMovable)
            throw new InvalidOperationException("Key is not movable");
        if (!StdOps<TValue>.IsMovable)
            throw new InvalidOperationException("Value is not movable");

        var node = Tree.InsertEmpty<TMemorySpace>(loc);
        StdOps<TKey>.ConstructMoveInPlace(ref key, out node->_Myval.Item1);
        StdOps<TValue>.ConstructMoveInPlace(ref value, out node->_Myval.Item2);
        return true;
    }

    /// <inheritdoc/>
    public void Clear() => Tree.EraseHead();

    /// <inheritdoc/>
    public void Dispose() => Tree.EraseHead();

    /// <inheritdoc/>
    public readonly bool ContainsKey(in TKey key) => Tree.FindLowerBound(key).KeyEquals(key);

    /// <inheritdoc/>
    [SuppressMessage("Performance", "CA1841:Prefer Dictionary.Contains methods")]
    public readonly bool ContainsValue(in TValue value) => Values.Contains(value);

    /// <inheritdoc/>
    public bool Remove(in TKey key) {
        var loc = Tree.FindLowerBound(key);
        if (!loc.KeyEquals(key))
            return false;

        Tree.ExtractAndErase(loc.Bound);
        return true;
    }

    /// <inheritdoc/>
    public bool Remove(in TKey key, in TValue value) {
        var loc = Tree.FindLowerBound(key);
        if (!loc.KeyEquals(key) || !StdOps<TValue>.ContentEquals(value, loc.Bound->_Myval.Item2))
            return false;

        Tree.ExtractAndErase(loc.Bound);
        return true;
    }

    /// <inheritdoc/>
    public readonly bool TryGetValue(in TKey key, out TValue value, bool copyCtor) {
        var loc = Tree.FindLowerBound(key);
        var eq = loc.KeyEquals(key);
        if (eq && copyCtor)
            StdOps<TValue>.ConstructCopyInPlace(loc.Bound->_Myval.Item2, out value);
        else if (eq)
            value = loc.Bound->_Myval.Item2;
        else
            value = default;
        return eq;
    }

    /// <inheritdoc/>
    public readonly bool TryGetValuePointer(in TKey key, out TValue* value) {
        var loc = Tree.FindLowerBound(key);
        var eq = loc.KeyEquals(key);
        if (eq)
            value = &loc.Bound->_Myval.Item2;
        else
            value = default;
        return eq;
    }

    /// <inheritdoc/>
    public void Add(KeyValuePair<TKey, TValue> item) {
        if (!TryAddValueKCopyVCopy(item.Key, item.Value))
            throw new ArgumentException("An element with the same key already exists.", nameof(item));
    }

    /// <inheritdoc/>
    public void Add(TKey key, TValue value) {
        if (!TryAddValueKCopyVCopy(key, value))
            throw new ArgumentException("An element with the same key already exists.", nameof(key));
    }

    /// <inheritdoc/>
    public readonly bool Contains(KeyValuePair<TKey, TValue> item) {
        var loc = Tree.FindLowerBound(item.Key);
        return loc.KeyEquals(item.Key) && StdOps<TValue>.ContentEquals(item.Value, loc.Bound->_Myval.Item2);
    }

    /// <inheritdoc/>
    public readonly void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
        if (array.Length - arrayIndex < Tree.LongCount)
            throw new ArgumentException(null, nameof(array));

        var i = (long)arrayIndex;
        foreach (ref readonly var k in this)
            array[i++] = k;
    }

    /// <inheritdoc/>
    public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key, item.Value);

    /// <inheritdoc/>
    public readonly RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator GetEnumerator() => new(Tree.Pointer, true);

    /// <inheritdoc/>
    public readonly RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator Reverse() => new(Tree.Pointer, false);

    public static int Compare(in StdMap<TKey, TValue, TMemorySpace> left, in StdMap<TKey, TValue, TMemorySpace> right) {
        using var e1 = left.GetEnumerator();
        using var e2 = right.GetEnumerator();
        while (true) {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();
            if (!b1 && !b2)
                return 0;
            if (b1 && !b2)
                return 1;
            if (!b1 && b2)
                return -1;
            var c = e1.Current.CompareTo(e2.Current);
            if (c != 0)
                return c;
        }
    }
    public static bool ContentEquals(in StdMap<TKey, TValue, TMemorySpace> left, in StdMap<TKey, TValue, TMemorySpace> right) {
        if (left.LongCount != right.LongCount)
            return false;

        using var e1 = left.GetEnumerator();
        using var e2 = right.GetEnumerator();
        while (true) {
            var b1 = e1.MoveNext();
            var b2 = e2.MoveNext();
            if (!b1 && !b2)
                return true;
            if (b1 != b2)
                return false;
            if (!StdPair<TKey, TValue>.ContentEquals(e1.Current, e2.Current))
                return false;
        }
    }
    public static void ConstructDefaultInPlace(out StdMap<TKey, TValue, TMemorySpace> item) {
        item = default;
        item.Tree.GetOrCreateHead<TMemorySpace>();
    }
    public static void StaticDispose(ref StdMap<TKey, TValue, TMemorySpace> item) => item.Dispose();
    public static void ConstructCopyInPlace(in StdMap<TKey, TValue, TMemorySpace> source, out StdMap<TKey, TValue, TMemorySpace> target) {
        if (!IsCopyable)
            throw new InvalidOperationException("Copying is not supported");
        ConstructDefaultInPlace(out target);
        foreach (ref var x in source)
            target.TryAddValueKCopyVCopy(x.Item1, x.Item2);
    }
    public static void ConstructMoveInPlace(ref StdMap<TKey, TValue, TMemorySpace> source, out StdMap<TKey, TValue, TMemorySpace> target) => (target, source) = (source, default);
    public static void Swap(ref StdMap<TKey, TValue, TMemorySpace> item1, ref StdMap<TKey, TValue, TMemorySpace> item2) => (item1, item2) = (item2, item1);
}
