using System.Collections;
using System.Runtime.CompilerServices;

using static FFXIVClientStructs.STD.StdHelpers.StdImplHelpers;

namespace FFXIVClientStructs.STD;

// This part deals with the definition and convenience methods.
/// <summary>
/// A <see cref="ValueTuple{T1,T2}"/>-like view for <see href="https://en.cppreference.com/w/cpp/utility/pair">std::pair</see>.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
[StructLayout(LayoutKind.Sequential, Pack = 8)]
public partial struct StdPair<T1, T2>
    : IDisposable
    where T1 : unmanaged
    where T2 : unmanaged {
    public T1 Item1;
    public T2 Item2;

    public StdPair(in T1 item1, in T2 item2) {
        Item1 = item1;
        Item2 = item2;
    }

    public StdPair(in (T1, T2) items) : this(items.Item1, items.Item2) { }

    public static bool operator ==(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.Equals(r);

    public static bool operator !=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => !l.Equals(r);

    public static bool operator <(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) < 0;

    public static bool operator >(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) > 0;

    public static bool operator <=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) <= 0;

    public static bool operator >=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) >= 0;

    public readonly void Deconstruct(out T1 item1, out T2 item2) {
        item1 = Item1;
        item2 = Item2;
    }

    /// <inheritdoc cref="IDisposable.Dispose"/>
    public void Dispose() {
        (Item1 as IDisposable)?.Dispose();
        (Item2 as IDisposable)?.Dispose();
    }

    /// <inheritdoc cref="object.Equals(object?)"/>
    public readonly override bool Equals(object? obj) => obj is StdPair<T1, T2> pair && Equals(pair);

    /// <inheritdoc cref="object.GetHashCode"/>
    public readonly override int GetHashCode() => HashCode.Combine(Item1, Item2);

    /// <inheritdoc cref="object.ToString"/>
    public override string ToString() => $"({Item1}, {Item2})";
}

// This part deals with implementation of the interfaces <see cref="ValueTuple{T1,T2}"/> implements.
/// <summary>
/// A <see cref="ValueTuple{T1,T2}"/>-like view for <see href="https://en.cppreference.com/w/cpp/utility/pair">std::pair</see>.
/// </summary>
public partial struct StdPair<T1, T2>
    : IEquatable<StdPair<T1, T2>>
        , IStructuralEquatable
        , IStructuralComparable
        , IComparable
        , IComparable<StdPair<T1, T2>>
        , ITuple {

    /// <inheritdoc cref="ITuple.this"/>
    public object this[int index] => index switch {
        0 => Item1,
        1 => Item2,
        _ => throw new IndexOutOfRangeException(),
    };

    /// <inheritdoc cref="ITuple.Length"/>
    public int Length => 2;

    /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
    public readonly bool Equals(StdPair<T1, T2> other) => DefaultEquals(Item1, other.Item1) && DefaultEquals(Item2, other.Item2);

    /// <inheritdoc cref="IStructuralEquatable.Equals(object?,System.Collections.IEqualityComparer)"/>
    public readonly bool Equals(object? other, IEqualityComparer comparer) => other is StdPair<T1, T2> pair && Equals(pair);

    /// <inheritdoc cref="IStructuralEquatable.GetHashCode(System.Collections.IEqualityComparer)"/>
    public readonly int GetHashCode(IEqualityComparer comparer) => HashCode.Combine(Item1, Item2);

    /// <inheritdoc cref="IStructuralComparable.CompareTo"/>
    public readonly int CompareTo(object? other, IComparer comparer) {
        switch (other)
        {
            case null:
                return 1;
            case StdPair<T1, T2> pair:
            {
                var res = comparer.Compare(Item1, pair.Item1);
                return res != 0 ? res : comparer.Compare(Item2, pair.Item2);
            }
            default:
                throw new ArgumentException($"Argument must be of type {typeof(StdPair<T1, T2>)}", nameof(other));
        }
    }

    /// <inheritdoc cref="IComparable.CompareTo"/>
    public readonly int CompareTo(object? obj)
    {
        switch (obj)
        {
            case null:
                return 1;
            case StdPair<T1, T2> pair:
            {
                var res = DefaultCompare(Item1, pair.Item1);
                return res != 0 ? res : DefaultCompare(Item2, pair.Item2);
            }
            default:
                throw new ArgumentException($"Argument must be of type {typeof(StdPair<T1, T2>)}", nameof(obj));
        }
    }

    /// <inheritdoc cref="IComparable{T}.CompareTo"/>
    public readonly int CompareTo(StdPair<T1, T2> other) {
        var res = DefaultCompare(Item1, other.Item1);
        return res != 0 ? res : DefaultCompare(Item2, other.Item2);
    }
}
