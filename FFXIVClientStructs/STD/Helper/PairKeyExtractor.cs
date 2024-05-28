namespace FFXIVClientStructs.STD.Helper;

public class PairKeyExtractor<TKey, TValue> : IStaticKeyExtractor<StdPair<TKey, TValue>, TKey>
    where TKey : unmanaged
    where TValue : unmanaged {
    public static ref readonly TKey ExtractKey(in StdPair<TKey, TValue> value) => ref value.Item1;
}
