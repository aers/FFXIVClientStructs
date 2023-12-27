using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.Helper;

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
    public static bool ContentEquals(in StdPair<TKey, TValue> left, in StdPair<TKey, TValue> right) =>
        TKeyOperation.ContentEquals(left.Item1, right.Item1);

    /// <inheritdoc/>
    public static void ConstructDefaultInPlace(out StdPair<TKey, TValue> item) {
        item = default;
        TKeyOperation.ConstructDefaultInPlace(out item.Item1);
        TValueOperation.ConstructDefaultInPlace(out item.Item2);
    }

    /// <inheritdoc/>
    public static void StaticDispose(ref StdPair<TKey, TValue> item) {
        TKeyOperation.StaticDispose(ref item.Item1);
        TValueOperation.StaticDispose(ref item.Item2);
    }
    /// <inheritdoc/>
    public static void ConstructCopyInPlace(in StdPair<TKey, TValue> source, out StdPair<TKey, TValue> target) {
        target = default;
        TKeyOperation.ConstructCopyInPlace(in source.Item1, out target.Item1);
        TValueOperation.ConstructCopyInPlace(in source.Item2, out target.Item2);
    }

    /// <inheritdoc/>
    public static void ConstructMoveInPlace(ref StdPair<TKey, TValue> source, out StdPair<TKey, TValue> target) {
        target = default;
        TKeyOperation.ConstructMoveInPlace(ref source.Item1, out target.Item1);
        TValueOperation.ConstructMoveInPlace(ref source.Item2, out target.Item2);
    }

    /// <inheritdoc/>
    public static void Swap(ref StdPair<TKey, TValue> item1, ref StdPair<TKey, TValue> item2) {
        TKeyOperation.Swap(ref item1.Item1, ref item2.Item1);
        TValueOperation.Swap(ref item1.Item2, ref item2.Item2);
    }
}
