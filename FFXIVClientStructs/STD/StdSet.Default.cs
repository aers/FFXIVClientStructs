using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

public struct StdSet<T>
    : IStdSet<T>
        , IEquatable<StdSet<T>>
        , IStaticNativeObjectOperation<StdSet<T>>
    where T : unmanaged {
    public StdSet<T, IStaticMemorySpace.Default> WithOps;
    public static bool HasDefault => StdSet<T, IStaticMemorySpace.Default>.HasDefault;
    public static bool IsDisposable => StdSet<T, IStaticMemorySpace.Default>.IsDisposable;
    public static bool IsCopyable => StdSet<T, IStaticMemorySpace.Default>.IsCopyable;
    public static bool IsMovable => StdSet<T, IStaticMemorySpace.Default>.IsMovable;
    public readonly long LongCount => WithOps.LongCount;
    public readonly int Count => WithOps.Count;
    public void ExceptWith(IEnumerable<T> other) => WithOps.ExceptWith(other);
    public void IntersectWith(IEnumerable<T> other) => WithOps.IntersectWith(other);
    public readonly bool IsProperSubsetOf(IEnumerable<T> other) => WithOps.IsProperSubsetOf(other);
    public readonly bool IsProperSupersetOf(IEnumerable<T> other) => WithOps.IsProperSupersetOf(other);
    public readonly bool IsSubsetOf(IEnumerable<T> other) => WithOps.IsSubsetOf(other);
    public readonly bool IsSupersetOf(IEnumerable<T> other) => WithOps.IsSupersetOf(other);
    public readonly bool Overlaps(IEnumerable<T> other) => WithOps.Overlaps(other);
    public readonly bool SetEquals(IEnumerable<T> other) => WithOps.SetEquals(other);
    public void SymmetricExceptWith(IEnumerable<T> other) => WithOps.SymmetricExceptWith(other);
    public void UnionWith(IEnumerable<T> other) => WithOps.UnionWith(other);
    public void Clear() => WithOps.Clear();
    public readonly void CopyTo(T[] array, int arrayIndex) => WithOps.CopyTo(array, arrayIndex);
    public readonly T[] ToArrayReverse() => WithOps.ToArrayReverse();
    public readonly RedBlackTree<T, T, DefaultKeyExtractor<T>>.Enumerator GetEnumerator() => WithOps.GetEnumerator();
    public readonly RedBlackTree<T, T, DefaultKeyExtractor<T>>.Enumerator Reverse() => WithOps.Reverse();
    public bool AddCopy(in T value) => WithOps.AddCopy(in value);
    public bool AddMove(ref T value) => WithOps.AddMove(ref value);
    public readonly bool Contains(in T item) => WithOps.Contains(in item);
    public bool Remove(in T item) => WithOps.Remove(in item);
    public readonly ref readonly T Min() => ref WithOps.Min();
    public readonly ref readonly T Max() => ref WithOps.Max();
    public readonly T[] ToArray() => WithOps.ToArray();
    public void Dispose() => WithOps.Dispose();
    public readonly bool Equals(StdSet<T> other) => WithOps.Equals(other.WithOps);
    public static int Compare(in StdSet<T> left, in StdSet<T> right) => StdSet<T, IStaticMemorySpace.Default>.Compare(left.WithOps, right.WithOps);
    public static bool ContentEquals(in StdSet<T> left, in StdSet<T> right) => StdSet<T, IStaticMemorySpace.Default>.ContentEquals(left.WithOps, right.WithOps);
    public static void ConstructDefaultInPlace(out StdSet<T> item) {
        item = default;
        StdSet<T, IStaticMemorySpace.Default>.ConstructDefaultInPlace(out item.WithOps);
    }
    public static void StaticDispose(ref StdSet<T> item) => item.Dispose();
    public static void ConstructCopyInPlace(in StdSet<T> source, out StdSet<T> target) {
        target = default;
        StdSet<T, IStaticMemorySpace.Default>.ConstructCopyInPlace(source.WithOps, out target.WithOps);
    }
    public static void ConstructMoveInPlace(ref StdSet<T> source, out StdSet<T> target) => (target, source) = (source, default);
    public static void Swap(ref StdSet<T> item1, ref StdSet<T> item2) => (item1, item2) = (item2, item1);
}
