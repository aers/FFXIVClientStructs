using System.Collections;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

public struct StdPair<T1, T2>
    : IStdPair<T1, T2>
        , IStaticNativeObjectOperation<StdPair<T1, T2>>
    where T1 : unmanaged
    where T2 : unmanaged {
    public StdPair<T1, T2, DefaultStaticNativeObjectOperation<T1>, DefaultStaticNativeObjectOperation<T2>> WithOperationSpecs;

    public StdPair(in T1 item1, in T2 item2) =>
        WithOperationSpecs = new StdPair<T1, T2, DefaultStaticNativeObjectOperation<T1>, DefaultStaticNativeObjectOperation<T2>>(item1, item2);

    public StdPair(in (T1, T2) items) : this(items.Item1, items.Item2) { }

    public static bool HasDefault { get; } = DefaultStaticNativeObjectOperation<T1>.HasDefault && DefaultStaticNativeObjectOperation<T2>.HasDefault;
    public static bool IsDisposable { get; } = DefaultStaticNativeObjectOperation<T1>.IsDisposable || DefaultStaticNativeObjectOperation<T2>.IsDisposable;
    public static bool IsCopiable { get; } = DefaultStaticNativeObjectOperation<T1>.IsCopiable && DefaultStaticNativeObjectOperation<T2>.IsCopiable;
    public static bool IsMovable { get; } = DefaultStaticNativeObjectOperation<T1>.IsMovable && DefaultStaticNativeObjectOperation<T2>.IsMovable;

    public object this[int index] => WithOperationSpecs[index];
    public int Length => WithOperationSpecs.Length;
    public ref T1 Item1 => ref Unsafe.AsRef(in WithOperationSpecs).Item1;
    public ref T2 Item2 => ref Unsafe.AsRef(in WithOperationSpecs).Item2;

    public static bool operator ==(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.Equals(r);

    public static bool operator !=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => !l.Equals(r);

    public static bool operator <(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) < 0;

    public static bool operator >(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) > 0;

    public static bool operator <=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) <= 0;

    public static bool operator >=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) >= 0;

    public static int Compare(in StdPair<T1, T2> left, in StdPair<T1, T2> right) {
        var c = DefaultStaticNativeObjectOperation<T1>.Compare(left.Item1, right.Item1);
        return c == 0 ? DefaultStaticNativeObjectOperation<T2>.Compare(left.Item2, right.Item2) : c;
    }

    public static bool ContentEquals(in StdPair<T1, T2> left, in StdPair<T1, T2> right) =>
        DefaultStaticNativeObjectOperation<T1>.ContentEquals(left.Item1, right.Item1) && DefaultStaticNativeObjectOperation<T2>.ContentEquals(left.Item2, right.Item2);

    public static void ConstructDefaultInPlace(out StdPair<T1, T2> item) {
        item = default;
        DefaultStaticNativeObjectOperation<T1>.ConstructDefaultInPlace(out item.Item1);
        DefaultStaticNativeObjectOperation<T2>.ConstructDefaultInPlace(out item.Item2);
    }

    public static void StaticDispose(ref StdPair<T1, T2> item) {
        DefaultStaticNativeObjectOperation<T1>.StaticDispose(ref item.Item1);
        DefaultStaticNativeObjectOperation<T2>.StaticDispose(ref item.Item2);
    }

    public static void ConstructCopyInPlace(in StdPair<T1, T2> source, out StdPair<T1, T2> target) {
        target = default;
        DefaultStaticNativeObjectOperation<T1>.ConstructCopyInPlace(in source.Item1, out target.Item1);
        DefaultStaticNativeObjectOperation<T2>.ConstructCopyInPlace(in source.Item2, out target.Item2);
    }

    public static void ConstructMoveInPlace(ref StdPair<T1, T2> source, out StdPair<T1, T2> target) {
        target = default;
        DefaultStaticNativeObjectOperation<T1>.ConstructMoveInPlace(ref source.Item1, out target.Item1);
        DefaultStaticNativeObjectOperation<T2>.ConstructMoveInPlace(ref source.Item2, out target.Item2);
    }

    public static void Swap(ref StdPair<T1, T2> item1, ref StdPair<T1, T2> item2) {
        DefaultStaticNativeObjectOperation<T1>.Swap(ref item1.Item1, ref item2.Item1);
        DefaultStaticNativeObjectOperation<T2>.Swap(ref item1.Item2, ref item2.Item2);
    }

    public readonly void Deconstruct(out T1 item1, out T2 item2) => WithOperationSpecs.Deconstruct(out item1, out item2);
    public void Dispose() => WithOperationSpecs.Dispose();
    public readonly override bool Equals(object? obj) => obj is StdPair<T1, T2> pair && Equals(pair);
    public readonly bool Equals(IStdPair<T1, T2>? other) => WithOperationSpecs.Equals(other);
    public readonly bool Equals(object? other, IEqualityComparer comparer) => WithOperationSpecs.Equals(other, comparer);
    public readonly override int GetHashCode() => WithOperationSpecs.GetHashCode();
    public readonly int GetHashCode(IEqualityComparer comparer) => WithOperationSpecs.GetHashCode(comparer);
    public readonly int CompareTo(object? other, IComparer comparer) => WithOperationSpecs.CompareTo(other, comparer);
    public readonly int CompareTo(object? obj) => WithOperationSpecs.CompareTo(obj);
    public readonly int CompareTo(IStdPair<T1, T2>? other) => WithOperationSpecs.CompareTo(other);
}
