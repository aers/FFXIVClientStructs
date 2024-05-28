using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="ValueTuple{T1,T2}"/>-like view for <see href="https://en.cppreference.com/w/cpp/utility/pair">std::pair</see>.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
[StructLayout(LayoutKind.Sequential, Pack = 8)]
[SuppressMessage("ReSharper", "StaticMemberInGenericType")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public struct StdPair<T1, T2>
    : IDisposable
        , IEquatable<StdPair<T1, T2>>
        , IStructuralEquatable
        , IStructuralComparable
        , IComparable
        , IComparable<StdPair<T1, T2>>
        , ITuple
        , IStaticNativeObjectOperation<StdPair<T1, T2>>
    where T1 : unmanaged
    where T2 : unmanaged {
    public T1 Item1;
    public T2 Item2;

    public StdPair(in T1 item1, in T2 item2) {
        Item1 = item1;
        Item2 = item2;
    }

    public StdPair(in (T1, T2) items) : this(items.Item1, items.Item2) { }

    public static bool HasDefault { get; } = StdOps<T1>.HasDefault && StdOps<T2>.HasDefault;
    public static bool IsDisposable { get; } = StdOps<T1>.IsDisposable || StdOps<T2>.IsDisposable;
    public static bool IsCopiable { get; } = StdOps<T1>.IsCopiable && StdOps<T2>.IsCopiable;
    public static bool IsMovable { get; } = StdOps<T1>.IsMovable && StdOps<T2>.IsMovable;

    /// <inheritdoc cref="ITuple.Length"/>
    public int Length => 2;

    /// <inheritdoc cref="ITuple.this"/>
    public object this[int index] => index switch {
        0 => Item1,
        1 => Item2,
        _ => throw new IndexOutOfRangeException(),
    };

    public static bool operator ==(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.Equals(r);

    public static bool operator !=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => !l.Equals(r);

    public static bool operator <(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) < 0;

    public static bool operator >(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) > 0;

    public static bool operator <=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) <= 0;

    public static bool operator >=(in StdPair<T1, T2> l, in StdPair<T1, T2> r) => l.CompareTo(r) >= 0;

    public static implicit operator KeyValuePair<T1, T2>(StdPair<T1, T2> a) => new(a.Item1, a.Item2);
    public static implicit operator StdPair<T1, T2>(KeyValuePair<T1, T2> a) => new(a.Key, a.Value);

    public static int Compare(in StdPair<T1, T2> left, in StdPair<T1, T2> right) {
        var c = StdOps<T1>.Compare(left.Item1, right.Item1);
        return c == 0 ? StdOps<T2>.Compare(left.Item2, right.Item2) : c;
    }

    public static bool ContentEquals(in StdPair<T1, T2> left, in StdPair<T1, T2> right) =>
        StdOps<T1>.ContentEquals(left.Item1, right.Item1) && StdOps<T2>.ContentEquals(left.Item2, right.Item2);

    public static void ConstructDefaultInPlace(out StdPair<T1, T2> item) {
        StdOps<T1>.ConstructDefaultInPlace(out item.Item1);
        StdOps<T2>.ConstructDefaultInPlace(out item.Item2);
    }

    public static void StaticDispose(ref StdPair<T1, T2> item) {
        StdOps<T1>.StaticDispose(ref item.Item1);
        StdOps<T2>.StaticDispose(ref item.Item2);
    }

    public static void ConstructCopyInPlace(in StdPair<T1, T2> source, out StdPair<T1, T2> target) {
        StdOps<T1>.ConstructCopyInPlace(in source.Item1, out target.Item1);
        StdOps<T2>.ConstructCopyInPlace(in source.Item2, out target.Item2);
    }

    public static void ConstructMoveInPlace(ref StdPair<T1, T2> source, out StdPair<T1, T2> target) {
        StdOps<T1>.ConstructMoveInPlace(ref source.Item1, out target.Item1);
        StdOps<T2>.ConstructMoveInPlace(ref source.Item2, out target.Item2);
    }

    public static void Swap(ref StdPair<T1, T2> item1, ref StdPair<T1, T2> item2) {
        StdOps<T1>.Swap(ref item1.Item1, ref item2.Item1);
        StdOps<T2>.Swap(ref item1.Item2, ref item2.Item2);
    }

    public readonly void Deconstruct(out T1 item1, out T2 item2) {
        item1 = Item1;
        item2 = Item2;
    }

    /// <inheritdoc/>
    public void Dispose() {
        (Item1 as IDisposable)?.Dispose();
        (Item2 as IDisposable)?.Dispose();
    }

    /// <inheritdoc/>
    public readonly override bool Equals(object? obj) =>
        obj is StdPair<T1, T2> pair && ContentEquals(this, pair);

    /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
    public readonly bool Equals(in StdPair<T1, T2> other) => ContentEquals(this, other);

    /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
    readonly bool IEquatable<StdPair<T1, T2>>.Equals(StdPair<T1, T2> other) => ContentEquals(this, other);

    /// <inheritdoc/>
    public readonly bool Equals(object? other, IEqualityComparer comparer) =>
        other is StdPair<T1, T2> pair && ContentEquals(this, pair);

    /// <inheritdoc/>
    public readonly override int GetHashCode() => HashCode.Combine(Item1, Item2);

    /// <inheritdoc/>
    public override string ToString() => $"({Item1}, {Item2})";

    /// <inheritdoc/>
    public readonly int GetHashCode(IEqualityComparer comparer) => HashCode.Combine(Item1, Item2);

    /// <inheritdoc/>
    public readonly int CompareTo(object? other, IComparer comparer) {
        switch (other) {
            case null:
                return 1;
            case StdPair<T1, T2> pair: {
                    var res = comparer.Compare(Item1, pair.Item1);
                    return res != 0 ? res : comparer.Compare(Item2, pair.Item2);
                }
            default:
                throw new ArgumentException($"Argument must be of type {typeof(StdPair<T1, T2>)}", nameof(other));
        }
    }

    /// <inheritdoc/>
    public readonly int CompareTo(object? obj) => obj switch {
        null => 1,
        StdPair<T1, T2> pair => Compare(this, pair),
        _ => throw new ArgumentException($"Argument must be of type {typeof(StdPair<T1, T2>)}", nameof(obj))
    };

    /// <inheritdoc cref="IComparable{T}.CompareTo"/>
    public readonly int CompareTo(in StdPair<T1, T2> other) {
        var res = StdOps<T1>.Compare(Item1, other.Item1);
        return res != 0 ? res : StdOps<T2>.Compare(Item2, other.Item2);
    }

    /// <inheritdoc cref="IComparable{T}.CompareTo"/>
    public readonly int CompareTo(StdPair<T1, T2> other) => Compare(this, other);
}
