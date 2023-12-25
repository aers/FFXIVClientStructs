using System.Collections;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

public struct StdPair<T1, T2> : IStdPair<T1, T2>
    where T1 : unmanaged
    where T2 : unmanaged {
    public StdPair<T1, T2, DefaultStaticNativeObjectOperation<T1>, DefaultStaticNativeObjectOperation<T2>> WithOperationSpecs;

    public StdPair(in T1 item1, in T2 item2) =>
        WithOperationSpecs = new StdPair<T1, T2, DefaultStaticNativeObjectOperation<T1>, DefaultStaticNativeObjectOperation<T2>>(item1, item2);

    public StdPair(in (T1, T2) items) : this(items.Item1, items.Item2) { }

    public object this[int index] => WithOperationSpecs[index];
    public int Length => WithOperationSpecs.Length;
    public ref T1 Item1 => ref Unsafe.AsRef(in WithOperationSpecs).Item1;
    public ref T2 Item2 => ref Unsafe.AsRef(in WithOperationSpecs).Item2;
    public void Deconstruct(out T1 item1, out T2 item2) => WithOperationSpecs.Deconstruct(out item1, out item2);
    public void Dispose() => WithOperationSpecs.Dispose();
    public bool Equals(IStdPair<T1, T2>? other) => WithOperationSpecs.Equals(other);
    public bool Equals(object? other, IEqualityComparer comparer) => WithOperationSpecs.Equals(other, comparer);
    public int GetHashCode(IEqualityComparer comparer) => WithOperationSpecs.GetHashCode(comparer);
    public int CompareTo(object? other, IComparer comparer) => WithOperationSpecs.CompareTo(other, comparer);
    public int CompareTo(object? obj) => WithOperationSpecs.CompareTo(obj);
    public int CompareTo(IStdPair<T1, T2>? other) => WithOperationSpecs.CompareTo(other);
}
