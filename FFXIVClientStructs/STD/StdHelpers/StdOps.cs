using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Marks that <typeparamref name="T"/> might be a <see cref="IDisposable"/>.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
[SuppressMessage("ReSharper", "StaticMemberInGenericType")]
public class StdOps<T> : IStaticNativeObjectOperation<T>
    where T : unmanaged {
    private static readonly ConstructDefaultInPlaceDelegate? InnerConstructDefaultInPlace;
    private static readonly ConstructCopyInPlaceDelegate? InnerConstructCopyInPlace;
    private static readonly ConstructMoveInPlaceDelegate? InnerConstructMoveInPlace;
    private static readonly StaticDisposeDelegate? InnerStaticDispose;
    private static readonly SwapDelegate? InnerSwap;

    private StdOps() => throw new InvalidOperationException();

    static StdOps() {
        if (typeof(T).IsAssignableTo(typeof(IStaticNativeObjectOperation<T>))) {
            HasDefault = (bool)typeof(T).GetProperty(nameof(HasDefault))!.GetValue(null)!;
            IsCopiable = (bool)typeof(T).GetProperty(nameof(IsCopiable))!.GetValue(null)!;
            IsMovable = (bool)typeof(T).GetProperty(nameof(IsMovable))!.GetValue(null)!;
            IsDisposable = (bool)typeof(T).GetProperty(nameof(IsDisposable))!.GetValue(null)!;
            InnerConstructDefaultInPlace = (ConstructDefaultInPlaceDelegate)Delegate.CreateDelegate(typeof(ConstructDefaultInPlaceDelegate), typeof(T), nameof(ConstructDefaultInPlace));
            InnerConstructCopyInPlace = (ConstructCopyInPlaceDelegate)Delegate.CreateDelegate(typeof(ConstructCopyInPlaceDelegate), typeof(T), nameof(ConstructCopyInPlace));
            InnerConstructMoveInPlace = (ConstructMoveInPlaceDelegate)Delegate.CreateDelegate(typeof(ConstructMoveInPlaceDelegate), typeof(T), nameof(ConstructMoveInPlace));
            InnerStaticDispose = (StaticDisposeDelegate)Delegate.CreateDelegate(typeof(StaticDisposeDelegate), typeof(T), nameof(StaticDispose));
            InnerSwap = (SwapDelegate)Delegate.CreateDelegate(typeof(SwapDelegate), typeof(T), nameof(Swap));
        } else {
            HasDefault = IsCopiable = IsMovable = true;
            IsDisposable = typeof(T).IsAssignableTo(typeof(IDisposable));
        }
    }

    private delegate void ConstructDefaultInPlaceDelegate(out T item);

    private delegate void StaticDisposeDelegate(ref T item);

    private delegate void ConstructCopyInPlaceDelegate(in T source, out T target);

    private delegate void ConstructMoveInPlaceDelegate(ref T source, out T target);

    private delegate void SwapDelegate(ref T item1, ref T item2);

    /// <inheritdoc/>
    public static bool HasDefault { get; }

    /// <inheritdoc/>
    public static bool IsDisposable { get; }

    /// <inheritdoc/>
    public static bool IsCopiable { get; }

    /// <inheritdoc/>
    public static bool IsMovable { get; }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(in T left, in T right) => Comparer<T>.Default.Compare(left, right);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContentEquals(in T left, in T right) => EqualityComparer<T>.Default.Equals(left, right);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ConstructDefaultInPlace(out T item) {
        if (!HasDefault)
            throw new InvalidOperationException();
        if (InnerConstructDefaultInPlace is not null)
            InnerConstructDefaultInPlace(out item);
        else
            item = default;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ConstructCopyInPlace(in T source, out T target) {
        if (!IsCopiable)
            throw new InvalidOperationException();
        if (InnerConstructCopyInPlace is not null)
            InnerConstructCopyInPlace(in source, out target);
        else
            target = source;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ConstructMoveInPlace(ref T source, out T target) {
        if (!IsMovable)
            throw new InvalidOperationException();
        if (InnerConstructMoveInPlace is not null)
            InnerConstructMoveInPlace(ref source, out target);
        else
            (target, source) = (source, default);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StaticDispose(ref T item) {
        if (InnerStaticDispose is not null)
            InnerStaticDispose(ref item);
        else
            (item as IDisposable)?.Dispose();
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Swap(ref T item1, ref T item2) {
        if (!IsMovable)
            throw new InvalidOperationException();
        if (InnerSwap is not null)
            InnerSwap(ref item1, ref item2);
        else
            (item1, item2) = (item2, item1);
    }
}
