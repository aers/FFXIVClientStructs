namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
// Client::Graphics::Kernel::CVector
//   std::vector

// this class inherits std::vector but adds a virtual function, so its just std::vector with a vtbl
[StructLayout(LayoutKind.Sequential)]
public unsafe struct CVector<T> where T : unmanaged
{
    public void* VTable;
    public StdVector<T> Vector;
}