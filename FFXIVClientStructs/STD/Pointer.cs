using System.Runtime.InteropServices;

namespace FFXIVClientStructs.STD
{
    // workaround for C# not supporting pointer types as generic arguments
    [StructLayout(LayoutKind.Sequential, Size=0x8)]
    public readonly unsafe struct Pointer<T> where T : unmanaged
    {
        private readonly T* _value;

        public T* Value => _value;

        Pointer(T* p)
        {
            _value = p;
        }

        public static implicit operator T*(Pointer<T> p) => p._value;
        public static implicit operator Pointer<T>(T* p) => new(p);
    }
}