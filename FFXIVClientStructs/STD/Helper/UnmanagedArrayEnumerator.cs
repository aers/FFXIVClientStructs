using System.Collections;

namespace FFXIVClientStructs.STD.Helper;

/// <summary>
/// Enumerator for an array of unmanaged objects.
/// </summary>
public unsafe struct UnmanagedArrayEnumerator<T>
    : IEnumerable<T>, IEnumerator<T>
    where T : unmanaged {
    private readonly T* _ownerFirst;
    private readonly T* _ownerLast;
    private T* _current;

    /// <summary>
    /// Initializes a new instance of <see cref="UnmanagedArrayEnumerator{T}"/> struct.
    /// </summary>
    /// <param name="first">The pointer to the first item.</param>
    /// <param name="last">The pointer to past the last item.</param>
    public UnmanagedArrayEnumerator(T* first, T* last) {
        _ownerFirst = first;
        _ownerLast = last;
        _current = first - 1;
    }

    /// <summary>
    /// Gets the reference to the current element.
    /// </summary>
    public readonly ref T Current {
        get {
            if (_current < _ownerFirst || _current >= _ownerLast)
                throw new InvalidOperationException();
            return ref *_current;
        }
    }

    /// <inheritdoc cref="IEnumerator{T}.Current"/>
    T IEnumerator<T>.Current => Current;

    /// <inheritdoc cref="IEnumerator.Current"/>
    object IEnumerator.Current => Current;

    /// <inheritdoc cref="IEnumerator.MoveNext"/>
    public bool MoveNext() {
        if (_current >= _ownerLast - 1)
            return false;
        ++_current;
        return true;
    }

    /// <inheritdoc cref="IEnumerator.Reset"/>
    public void Reset() => _current = _ownerFirst - 1;

    /// <inheritdoc cref="IDisposable.Dispose"/>
    public void Dispose() { }

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    public IEnumerator<T> GetEnumerator() => new UnmanagedArrayEnumerator<T>(_ownerFirst, _ownerLast);

    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
    IEnumerator IEnumerable.GetEnumerator() => new UnmanagedArrayEnumerator<T>(_ownerFirst, _ownerLast);
}
