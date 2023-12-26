using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Marks that <typeparamref name="T"/> might be a <see cref="IDisposable"/>.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
public class DefaultStaticNativeObjectOperation<T> : IStaticNativeObjectOperation<T>
    where T : unmanaged {
    private DefaultStaticNativeObjectOperation() => throw new InvalidOperationException();

    /// <inheritdoc/>
    public static bool HasDefault {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => true;
    }

    /// <inheritdoc/>
    public static bool IsDisposable {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    } = typeof(T).IsAssignableTo(typeof(IDisposable));

    /// <inheritdoc/>
    public static bool IsCopiable {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => true;
    }

    /// <inheritdoc/>
    public static bool IsMovable {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => true;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(in T left, in T right) => Comparer<T>.Default.Compare(left, right);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(in T left, in T right) => EqualityComparer<T>.Default.Equals(left, right);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetDefault(out T item) => item = default;

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Dispose(ref T item) => (item as IDisposable)?.Dispose();

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Copy(in T source, out T target) => target = source;

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Move(ref T source, out T target) => (target, source) = (source, default);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Swap(ref T item1, ref T item2) => (item1, item2) = (item2, item1);
}
