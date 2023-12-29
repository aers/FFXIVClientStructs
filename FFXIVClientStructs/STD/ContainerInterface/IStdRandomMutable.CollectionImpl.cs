using System.Collections;

namespace FFXIVClientStructs.STD.ContainerInterface;

public partial interface IStdRandomMutable<T> {
    bool IList.IsFixedSize => false;

    void ICollection<T>.Add(T item) => AddCopy(item);

    void ICollection<T>.Clear() => Clear();

    bool ICollection<T>.Remove(T item) => Remove(item);

    int IList.Add(object? value) {
        if (LongCount >= int.MaxValue)
            throw new NotSupportedException();
        AddCopy((T)(value ?? throw new ArgumentNullException(nameof(value))));
        return Count - 1;
    }

    void IList.Clear() => Clear();

    void IList.Insert(int index, object? value) => InsertCopy(index, (T)(value ?? throw new ArgumentNullException(nameof(value))));

    void IList.Remove(object? value) => Remove((T)(value ?? throw new ArgumentNullException(nameof(value))));

    void IList.RemoveAt(int index) => RemoveAt(index);

    void IList<T>.Insert(int index, T item) => InsertCopy(index, item);

    void IList<T>.RemoveAt(int index) => RemoveAt(index);
}
