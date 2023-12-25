using System.Collections;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct StdMap<TKey, TValue> : IEnumerable<StdPair<TKey, TValue>>
    where TKey : unmanaged
    where TValue : unmanaged {
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyStaticComparer<TKey, TValue>>* Head;
    public ulong Count;

    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyStaticComparer<TKey, TValue>>* SmallestValue => Head->Left;
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyStaticComparer<TKey, TValue>>* LargestValue => Head->Right;

    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyStaticComparer<TKey, TValue>>.Enumerator GetEnumerator() => new(Head);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    IEnumerator<StdPair<TKey, TValue>> IEnumerable<StdPair<TKey, TValue>>.GetEnumerator() => GetEnumerator();
}
