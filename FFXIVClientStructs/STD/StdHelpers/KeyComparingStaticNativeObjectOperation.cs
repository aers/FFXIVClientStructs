using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.StdHelpers;

[SuppressMessage("ReSharper", "StaticMemberInGenericType")]
public class KeyComparingStaticNativeObjectOperation<TKey, TValue, TKeyOperation, TValueOperation>
    : IStaticNativeObjectOperation<StdPair<TKey, TValue>>
    where TKey : unmanaged
    where TValue : unmanaged
    where TKeyOperation : IStaticNativeObjectOperation<TKey>
    where TValueOperation : IStaticNativeObjectOperation<TValue> {
    /// <inheritdoc/>
    public static bool HasDefault { get; } = TKeyOperation.HasDefault && TValueOperation.HasDefault;

    /// <inheritdoc/>
    public static bool IsDisposable { get; } = TKeyOperation.IsDisposable || TValueOperation.IsDisposable;

    /// <inheritdoc/>
    public static bool IsCopiable { get; } = TKeyOperation.IsCopiable && TValueOperation.IsCopiable;

    /// <inheritdoc/>
    public static bool IsMovable { get; } = TKeyOperation.IsMovable && TValueOperation.IsMovable;

    /// <inheritdoc/>
    public static int Compare(in StdPair<TKey, TValue> left, in StdPair<TKey, TValue> right) =>
        TKeyOperation.Compare(left.Item1, right.Item1);

    /// <inheritdoc/>
    public static bool Equals(in StdPair<TKey, TValue> left, in StdPair<TKey, TValue> right) =>
        TKeyOperation.Equals(left.Item1, right.Item1);

    /// <inheritdoc/>
    public static void SetDefault(out StdPair<TKey, TValue> item) {
        item = default;
        TKeyOperation.SetDefault(out item.Item1);
        TValueOperation.SetDefault(out item.Item2);
    }
    
    /// <inheritdoc/>
    public static void Dispose(ref StdPair<TKey, TValue> item) {
        TKeyOperation.Dispose(ref item.Item1);
        TValueOperation.Dispose(ref item.Item2);
    }
    /// <inheritdoc/>
    public static void Copy(in StdPair<TKey, TValue> source, out StdPair<TKey, TValue> target) {
        target = default;
        TKeyOperation.Copy(in source.Item1, out target.Item1);
        TValueOperation.Copy(in source.Item2, out target.Item2);
    }
    
    /// <inheritdoc/>
    public static void Move(ref StdPair<TKey, TValue> source, out StdPair<TKey, TValue> target) {
        target = default;
        TKeyOperation.Move(ref source.Item1, out target.Item1);
        TValueOperation.Move(ref source.Item2, out target.Item2);
    }
    
    /// <inheritdoc/>
    public static void Swap(ref StdPair<TKey, TValue> item1, ref StdPair<TKey, TValue> item2) {
        TKeyOperation.Swap(ref item1.Item1, ref item2.Item1);
        TValueOperation.Swap(ref item1.Item2, ref item2.Item2);
    }
}
