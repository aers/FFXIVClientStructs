using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD;

public unsafe struct StdSpan<T>
    where T : unmanaged {
    private readonly T* _begin;
    private readonly nint _count;

    public StdSpan(ref readonly T firstPinnedObject, nint count) {
        _begin = (T*)Unsafe.AsPointer(ref Unsafe.AsRef(in firstPinnedObject));
        _count = count;
    }

    public StdSpan(T* begin, nint count) {
        _begin = begin;
        _count = count;
    }

    public StdSpan(T* begin, T* end) {
        _begin = begin;
        _count = (nint)(end - begin);
        if (_count == 0)
            _begin = null;
        else if (_count < 0)
            throw new ArgumentOutOfRangeException(nameof(end), (nint)end, "begin > end?");
    }
}
