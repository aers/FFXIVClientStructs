namespace FFXIVClientStructs.STD.Helper;

public class DefaultKeyExtractor<T> : IStaticKeyExtractor<T, T> {
    public static ref readonly T ExtractKey(in T value) => ref value;
}