using System.Collections;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct StdMap<TKey, TValue, TKeyOperation, TValueOperation>
    : IEnumerable<StdPair<TKey, TValue>>
    where TKey : unmanaged
    where TValue : unmanaged
    where TKeyOperation : IStaticNativeObjectOperation<TKey>
    where TValueOperation : IStaticNativeObjectOperation<TValue> {
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, TKeyOperation, TValueOperation>>* Head;
    public ulong Count;

    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, TKeyOperation, TValueOperation>>* SmallestValue => Head->Left;
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, TKeyOperation, TValueOperation>>* LargestValue => Head->Right;

    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, TKeyOperation, TValueOperation>>.Enumerator GetEnumerator() => new(Head);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    IEnumerator<StdPair<TKey, TValue>> IEnumerable<StdPair<TKey, TValue>>.GetEnumerator() => GetEnumerator();
}

public unsafe struct StdMap<TKey, TValue>
    : IEnumerable<StdPair<TKey, TValue>>
    where TKey : unmanaged
    where TValue : unmanaged {
    public StdMap<TKey, TValue, DefaultStaticNativeObjectOperation<TKey>, DefaultStaticNativeObjectOperation<TValue>> WithOperationSpecs;
    
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, DefaultStaticNativeObjectOperation<TKey>, DefaultStaticNativeObjectOperation<TValue>>>* Head => WithOperationSpecs.Head;
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, DefaultStaticNativeObjectOperation<TKey>, DefaultStaticNativeObjectOperation<TValue>>>* SmallestValue => WithOperationSpecs.SmallestValue;
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, DefaultStaticNativeObjectOperation<TKey>, DefaultStaticNativeObjectOperation<TValue>>>* LargestValue => WithOperationSpecs.LargestValue;
    
    public RedBlackTreeNodeHeader<StdPair<TKey, TValue>, KeyComparingStaticNativeObjectOperation<TKey, TValue, DefaultStaticNativeObjectOperation<TKey>, DefaultStaticNativeObjectOperation<TValue>>>.Enumerator GetEnumerator() => new(WithOperationSpecs.Head);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    IEnumerator<StdPair<TKey, TValue>> IEnumerable<StdPair<TKey, TValue>>.GetEnumerator() => GetEnumerator();
}
