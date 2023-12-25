namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Marks that <typeparamref name="T"/> is not disposable.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
public class NonDisposableStatic<T> : IDisposableStatic<T> {
    /// <inheritdoc/>
    public static bool IsDisposable => false;

    /// <inheritdoc/>
    public static void Dispose(ref T item) { }
}
