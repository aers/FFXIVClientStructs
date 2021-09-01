using System;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.STD
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct StdVector<T> where T : unmanaged
    {
        public T* First;
        public T* Last;
        public T* End;

        public ulong Size()
        {
            if (First == null || Last == null)
                return 0;

            return ((ulong) Last - (ulong) First) / (ulong) sizeof(T);
        }

        public ulong Capacity()
        {
            if (End == null || First == null)
                return 0;

            return ((ulong) End - (ulong) First) / (ulong) sizeof(T);
        }

        public T Get(ulong index)
        {
            if (index >= Size())
                throw new IndexOutOfRangeException($"Index out of Range: {index}");

            return First[index];
        }
    }
}