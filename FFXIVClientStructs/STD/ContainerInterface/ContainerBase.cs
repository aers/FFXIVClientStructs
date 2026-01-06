
namespace FFXIVClientStructs.STD;

/// <remarks>
/// Based on MSVC 14.50.35717 definition
/// </remarks>
[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public unsafe struct ContainerBase12<T> where T : unmanaged {
    public ContainerProxy<T>* MyProxy;
}

/// <remarks>
/// Based on MSVC 14.50.35717 definition
/// </remarks>
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct ContainerProxy<T> where T : unmanaged {
    public StdDeque<T>* MyCont; // In reality should be ContainerBase12<T>* but in IDA it looks nicer for it to be the full type
    public IteratorBase12<T>* MyFirstIter;
}

/// <remarks>
/// Based on MSVC 14.50.35717 definition
/// </remarks>
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct IteratorBase12<T> where T : unmanaged {
    public ContainerProxy<T>* MyProxy;
    public IteratorBase12<T>* MyNextIter;
}
