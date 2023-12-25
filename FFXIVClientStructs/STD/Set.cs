using System.Collections;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct StdSet<TKey> : IEnumerable<TKey>
    where TKey : unmanaged {
    public RedBlackTreeNodeHeader<TKey, DefaultStaticNativeObjectOperation<TKey>>* Head;
    public ulong Count;

    public RedBlackTreeNodeHeader<TKey, DefaultStaticNativeObjectOperation<TKey>>* SmallestValue => Head->Left;
    public RedBlackTreeNodeHeader<TKey, DefaultStaticNativeObjectOperation<TKey>>* LargestValue => Head->Right;

    public RedBlackTreeNodeHeader<TKey, DefaultStaticNativeObjectOperation<TKey>>.Enumerator GetEnumerator() => new(Head);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();
}
