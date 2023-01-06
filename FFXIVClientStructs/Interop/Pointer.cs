namespace FFXIVClientStructs.Interop;

// workaround for C# not supporting pointer types as generic arguments
[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public readonly unsafe struct Pointer<T> where T : unmanaged
{
    public T* Value { get; }

    private Pointer(T* p)
    {
        Value = p;
    }

    public static implicit operator T*(Pointer<T> p)
    {
        return p.Value;
    }

    public static implicit operator Pointer<T>(T* p)
    {
        return new(p);
    }
}