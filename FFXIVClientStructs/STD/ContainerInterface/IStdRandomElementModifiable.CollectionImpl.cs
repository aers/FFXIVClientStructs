using System.Collections;

namespace FFXIVClientStructs.STD.ContainerInterface;

public partial interface IStdRandomElementModifiable<T> {
    ref readonly T IStdRandomElementReadable<T>.this[long index] => ref this[index];
    ref readonly T IStdRandomElementReadable<T>.this[int index] => ref this[index];
    ref readonly T IStdRandomElementReadable<T>.this[Index index] => ref this[index];

    bool ICollection<T>.IsReadOnly => false;
    bool IList.IsReadOnly => false;

    T IList<T>.this[int index] {
        get => this[index < 0 ? throw new IndexOutOfRangeException() : index];
        set => this[index < 0 ? throw new IndexOutOfRangeException() : index] = value;
    }

    object? IList.this[int index] {
        get => this[index < 0 ? throw new IndexOutOfRangeException() : index];
        set => this[index < 0 ? throw new IndexOutOfRangeException() : index] = value is null ? default : (T)value;
    }
}
