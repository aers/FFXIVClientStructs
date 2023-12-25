namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Marks that <typeparamref name="T"/> is disposable, using <see cref="IDisposable.Dispose"/>.
/// </summary>
/// <typeparam name="T">The disposable type.</typeparam>
public class DisposableStatic<T> : IDisposableStatic<T>
    where T : IDisposable {
    /// <inheritdoc/>
    public static bool IsDisposable => true;

    /// <inheritdoc/>
    public static void Dispose(ref T item) => item.Dispose();
}
