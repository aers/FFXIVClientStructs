namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Marks that <typeparamref name="T"/> might be a <see cref="IDisposable"/>.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
public class AutoDisposableStatic<T> : IDisposableStatic<T> {
    /// <inheritdoc/>
    public static bool IsDisposable => typeof(T).IsAssignableTo(typeof(IDisposable));

    /// <inheritdoc/>
    public static void Dispose(ref T item) => (item as IDisposable)?.Dispose();
}
