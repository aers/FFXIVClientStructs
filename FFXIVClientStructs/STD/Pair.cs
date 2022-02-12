namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct StdPair<T1, T2>
    where T1 : unmanaged
    where T2 : unmanaged
{
    public T1 Item1;
    public T2 Item2;
}