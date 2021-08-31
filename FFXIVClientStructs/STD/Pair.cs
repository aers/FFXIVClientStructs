using System.Runtime.InteropServices;

namespace FFXIVClientStructs.STD
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public unsafe struct StdPair<T1, T2>
        where T1 : unmanaged
        where T2 : unmanaged
    {
        public T1 Item1;
        public T2 Item2;
    }
}
