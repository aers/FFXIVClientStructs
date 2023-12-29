using System.Collections;
using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD.ContainerInterface;

[SuppressMessage("ReSharper", "PossibleInterfaceMemberAmbiguity")]
public partial interface IStdRandomElementReadable<T> {
    int ICollection.Count => Count;
    int ICollection<T>.Count => Count;
    int IReadOnlyCollection<T>.Count => Count;

    bool ICollection<T>.IsReadOnly => true;
    bool ICollection.IsSynchronized => false;
    object ICollection.SyncRoot => Array.Empty<byte>();

    bool IList.IsFixedSize => true;
    bool IList.IsReadOnly => true;
    T IReadOnlyList<T>.this[int index] => this[index];
    
    void ICollection.CopyTo(Array array, int index) {
        if (array is not T[] typedArray)
            throw new ArgumentException(null, nameof(array));
        CopyTo(typedArray, index);
    }

    bool ICollection<T>.Contains(T item) => Contains(item);

    int IComparable<IStdRandomElementReadable<T>>.CompareTo(IStdRandomElementReadable<T>? other) {
        if (other is null)
            return 1;

        var myIndex = 0;
        var myCount = LongCount;
        var otherIndex = 0;
        var otherCount = other.LongCount;
        while (myIndex < myCount && otherIndex < otherCount) {
            var cmp = StdOps<T>.Compare(this[myIndex], other[otherIndex]);
            if (cmp != 0)
                return cmp;
            myIndex++;
            otherIndex++;
        }

        return myCount.CompareTo(otherCount);
    }

    bool IList.Contains(object? value) => value is T typedValue && Contains(typedValue);

    int IList.IndexOf(object? value) => value is T typedValue ? IndexOf(typedValue) : -1;

    int IList<T>.IndexOf(T item) => IndexOf(item);
}
