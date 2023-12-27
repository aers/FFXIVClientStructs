using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

public struct StdSet<T> : IStdSet<T>, IEquatable<StdSet<T>>
    where T : unmanaged {
    public StdSet<T, IStaticMemorySpace.Default> WithOps;
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
    public readonly RedBlackTree<T>.Enumerator GetEnumerator() => WithOps.GetEnumerator();
    public readonly RedBlackTree<T>.Enumerator Reverse() => WithOps.Reverse();
    public bool AddCopy(in T value) => WithOps.AddCopy(in value);
    public bool AddMove(ref T value) => WithOps.AddMove(ref value);
    public readonly bool Contains(in T item) => WithOps.Contains(in item);
    public bool Remove(in T item) => WithOps.Remove(in item);
    public readonly ref readonly T Min() => ref WithOps.Min();
    public readonly ref readonly T Max() => ref WithOps.Max();
    public readonly T[] ToArray() => WithOps.ToArray();
    public void Dispose() => WithOps.Dispose();
    public readonly bool Equals(StdSet<T> other) => WithOps.Equals(other.WithOps);
}
