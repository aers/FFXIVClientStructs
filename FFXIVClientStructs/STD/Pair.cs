namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct StdPair<T1, T2>
    where T1 : unmanaged
    where T2 : unmanaged {
    public T1 Item1;
    public T2 Item2;

    public readonly void Deconstruct(out T1 item1, out T2 item2) {
        item1 = Item1;
        item2 = Item2;
    }
}
