namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Static instructions for how to dispose a type.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
public interface IDisposableStatic<T> {
    /// <summary>
    /// Whether the type is disposable.
    /// </summary>
    public abstract static bool IsDisposable { get; }

    /// <summary>
    /// Dispose the given item.
    /// </summary>
    /// <param name="item">The item to dispose.</param>
    public abstract static void Dispose(ref T item);
}
