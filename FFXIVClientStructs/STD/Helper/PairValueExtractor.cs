namespace FFXIVClientStructs.STD.Helper;

public class PairValueExtractor<TKey, TValue> : IStaticKeyExtractor<StdPair<TKey, TValue>, TValue>
    where TKey : unmanaged
    where TValue : unmanaged {
    public static ref readonly TValue ExtractKey(in StdPair<TKey, TValue> value) => ref value.Item2;
}
