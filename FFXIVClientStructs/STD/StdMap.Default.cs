using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

public struct StdMap<TKey, TValue> : IStdMap<TKey, TValue>
    where TKey : unmanaged
    where TValue : unmanaged {
    public StdMap<TKey, TValue, IStaticMemorySpace.Default> WithOps;

    public static bool HasDefault => StdMap<TKey, TValue, IStaticMemorySpace.Default>.HasDefault;
    public static bool IsDisposable => StdMap<TKey, TValue, IStaticMemorySpace.Default>.IsDisposable;
    public static bool IsCopiable => StdMap<TKey, TValue, IStaticMemorySpace.Default>.IsCopiable;
    public static bool IsMovable => StdMap<TKey, TValue, IStaticMemorySpace.Default>.IsMovable;
    public readonly int Count => WithOps.Count;
    public readonly long LongCount => WithOps.LongCount;
    public readonly IStdMap<TKey, TValue>.KeyCollection Keys => WithOps.Keys;
    public readonly IStdMap<TKey, TValue>.ValueCollection Values => WithOps.Values;
    public ref TValue this[in TKey key] => ref WithOps[in key];
    TValue IDictionary<TKey, TValue>.this[TKey key] {
        readonly get => ((IDictionary<TKey, TValue>)WithOps)[key];
        set => ((IDictionary<TKey, TValue>)WithOps)[key] = value;
    }
    readonly TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key] => ((IDictionary<TKey, TValue>)WithOps)[key];
    public void Add(TKey key, TValue value) => WithOps.Add(key, value);
    public void Add(KeyValuePair<TKey, TValue> item) => WithOps.Add(item);
    public void Clear() => WithOps.Clear();
    public readonly bool Contains(KeyValuePair<TKey, TValue> item) => WithOps.Contains(item);
    public readonly void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => WithOps.CopyTo(array, arrayIndex);
    public bool Remove(KeyValuePair<TKey, TValue> item) => WithOps.Remove(item);
    public bool TryAddValueKCopyVCopy(in TKey key, in TValue value) => WithOps.TryAddValueKCopyVCopy(in key, in value);
    public bool TryAddValueKCopyVMove(in TKey key, ref TValue value) => WithOps.TryAddValueKCopyVMove(in key, ref value);
    public bool TryAddValueKMoveVCopy(ref TKey key, in TValue value) => WithOps.TryAddValueKMoveVCopy(ref key, in value);
    public bool TryAddValueKMoveVMove(ref TKey key, ref TValue value) => WithOps.TryAddValueKMoveVMove(ref key, ref value);
    public readonly bool ContainsKey(in TKey key) => WithOps.ContainsKey(in key);
    public readonly bool ContainsValue(in TValue value) => WithOps.ContainsValue(in value);
    public bool Remove(in TKey key) => WithOps.Remove(in key);
    public bool Remove(in TKey key, in TValue value) => WithOps.Remove(in key, in value);
    public readonly bool TryGetValue(in TKey key, out TValue value, bool copyCtor) => WithOps.TryGetValue(in key, out value, copyCtor);
    public readonly RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator GetEnumerator() => WithOps.GetEnumerator();
    public readonly RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator Reverse() => WithOps.Reverse();
    public void Dispose() => WithOps.Dispose();
    public static int Compare(in StdMap<TKey, TValue> left, in StdMap<TKey, TValue> right) => StdMap<TKey, TValue, IStaticMemorySpace.Default>.Compare(left.WithOps, right.WithOps);
    public static bool ContentEquals(in StdMap<TKey, TValue> left, in StdMap<TKey, TValue> right) => StdMap<TKey, TValue, IStaticMemorySpace.Default>.ContentEquals(left.WithOps, right.WithOps);
    public static void ConstructDefaultInPlace(out StdMap<TKey, TValue> item) {
        item = default;
        StdMap<TKey, TValue, IStaticMemorySpace.Default>.ConstructDefaultInPlace(out item.WithOps);
    }
    public static void StaticDispose(ref StdMap<TKey, TValue> item) => item.Dispose();
    public static void ConstructCopyInPlace(in StdMap<TKey, TValue> source, out StdMap<TKey, TValue> target) {
        target = default;
        StdMap<TKey, TValue, IStaticMemorySpace.Default>.ConstructCopyInPlace(source.WithOps, out target.WithOps);
    }
    public static void ConstructMoveInPlace(ref StdMap<TKey, TValue> source, out StdMap<TKey, TValue> target) => (target, source) = (source, default);
    public static void Swap(ref StdMap<TKey, TValue> item1, ref StdMap<TKey, TValue> item2) => (item1, item2) = (item2, item1);
}
