namespace FFXIVClientStructs.STD.StdHelpers;

public class DefaultStaticComparer<T> : IStaticComparer<T> {
    public static int Compare(in T left, in T right) => StdImplHelpers.DefaultCompare(left, right);
}

public class KeyStaticComparer<TKey, TValue> : IStaticComparer<StdPair<TKey, TValue>>
    where TKey : unmanaged
    where TValue : unmanaged {

    public static int Compare(in StdPair<TKey, TValue> left, in StdPair<TKey, TValue> right) =>
        StdImplHelpers.DefaultCompare(left.Item1, right.Item1);
}
