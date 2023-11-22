using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct StdPair<T1, T2> : IEquatable<StdPair<T1, T2>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<StdPair<T1, T2>>, ITuple
    where T1 : unmanaged
    where T2 : unmanaged {
    public T1 Item1;
    public T2 Item2;

    public StdPair(T1 item1, T2 item2) {
        Item1 = item1;
        Item2 = item2;
    }

    public readonly override bool Equals([NotNullWhen(true)] object? obj) =>
        obj is StdPair<T1, T2> tuple && Equals(tuple);

    public readonly bool Equals(StdPair<T1, T2> other) =>
        EqualityComparer<T1>.Default.Equals(Item1, other.Item1) &&
        EqualityComparer<T2>.Default.Equals(Item2, other.Item2);

    readonly bool IStructuralEquatable.Equals(object? other, IEqualityComparer comparer) =>
        other is StdPair<T1, T2> vt &&
        comparer.Equals(Item1, vt.Item1) &&
        comparer.Equals(Item2, vt.Item2);

    readonly int IComparable.CompareTo(object? other) {
        if (other is not null) {
            if (other is StdPair<T1, T2> objTuple) {
                return CompareTo(objTuple);
            }

            throw new ArgumentException($"Argument must be of type {typeof(StdPair<T1, T2>)}");
        }

        return 1;
    }

    public readonly int CompareTo(StdPair<T1, T2> other) {
        var c = Comparer<T1>.Default.Compare(Item1, other.Item1);
        if (c != 0)
            return c;

        return Comparer<T2>.Default.Compare(Item2, other.Item2);
    }

    readonly int IStructuralComparable.CompareTo(object? other, IComparer comparer) {
        if (other is not null) {
            if (other is StdPair<T1, T2> objTuple) {
                var c = comparer.Compare(Item1, objTuple.Item1);
                if (c != 0)
                    return c;

                return comparer.Compare(Item2, objTuple.Item2);
            }

            throw new ArgumentException($"Argument must be of type {typeof(StdPair<T1, T2>)}");
        }

        return 1;
    }

    public readonly override int GetHashCode() =>
        HashCode.Combine(Item1.GetHashCode(), Item2.GetHashCode());

    readonly int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) =>
        HashCode.Combine(comparer.GetHashCode(Item1!), comparer.GetHashCode(Item2!));

    public readonly override string ToString() =>
        $"({Item1}, {Item2})";

    readonly int ITuple.Length => 2;

    readonly object? ITuple.this[int index] =>
        index switch {
            0 => Item1,
            1 => Item2,
            _ => throw new IndexOutOfRangeException(),
        };

    public readonly void Deconstruct(out T1 item1, out T2 item2) {
        item1 = Item1;
        item2 = Item2;
    }

    public static implicit operator (T1, T2)(StdPair<T1, T2> pair) => (pair.Item1, pair.Item2);

    public static bool operator ==(StdPair<T1, T2> left, StdPair<T1, T2> right) {
        return left.Equals(right);
    }

    public static bool operator !=(StdPair<T1, T2> left, StdPair<T1, T2> right) {
        return !(left == right);
    }
}
