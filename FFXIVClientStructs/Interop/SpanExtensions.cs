using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.Interop;

public static class SpanExtensions {
    /// <summary>
    /// Gets a pointer to the span element at index.
    /// </summary>
    public static unsafe T* GetPointer<T>(this Span<T> span, int index) where T : unmanaged {
        return (T*)Unsafe.AsPointer(ref span[index]);
    }

    /// <summary>
    /// Enumerates the elements of a Span{T} as pointers.
    /// </summary>
    public unsafe ref struct SpanPointerEnumerator<T> where T : unmanaged {
        private int _currentIndex;
        private readonly Span<T> _items;

        public SpanPointerEnumerator(Span<T> span) {
            _items = span;
            _currentIndex = -1;
        }
        public bool MoveNext() => ++_currentIndex < _items.Length;
        public readonly T* Current => (T*)Unsafe.AsPointer(ref _items[_currentIndex]);
        public SpanPointerEnumerator<T> GetEnumerator() => new(_items);
    }

    /// <summary>
    /// Gets a pointer enumerator for this span.
    /// This allows enumeration over the span as a pointer type, T*, rather than T.
    /// </summary>
    public static SpanPointerEnumerator<T> PointerEnumerator<T>(this Span<T> span) where T : unmanaged => new(span);

    /// <summary>
    /// Checks if the bit in the byte span is set.
    /// </summary>
    /// <param name="index">The bit index in the span</param>'
    /// <exception cref="IndexOutOfRangeException">Span bit length is shorter than index used.</exception>
    public bool CheckBitInSpan(this Span<byte> span, uint index)
    {
        if (span.Length < (index >> 3))
            return (span[index >> 3] & (1 << (index & 7))) != 0;
        throw new IndexOutOfRangeException();
    }
}
