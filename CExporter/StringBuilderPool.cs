using System;
using System.Collections.Generic;
using System.Text;

namespace CExporter;

public static class StringBuilderPool {
    private static readonly Stack<StringBuilderPooled> _pool = new();

    public static StringBuilderPooled Get() {
        if (_pool.Count > 0) {
            return _pool.Pop();
        }

        StringBuilderPooled? builderPooled = null;
        builderPooled = new StringBuilderPooled(
            new StringBuilder(),
            () => _pool.Push(builderPooled!)
        );

        return builderPooled;
    }

    public static StringBuilderPooled Get(int capacity) {
        if (_pool.Count > 0) {
            var pooled = _pool.Pop();
            pooled.Builder.EnsureCapacity(capacity);
            return pooled;
        }

        StringBuilderPooled? builderPooled = null;
        builderPooled = new StringBuilderPooled(
            new StringBuilder(capacity),
            () => _pool.Push(builderPooled!)
        );

        return builderPooled;
    }
}

public class StringBuilderPooled : IDisposable {
    public StringBuilder Builder { get; }
    public Action OnDispose { get; }

    public StringBuilderPooled(StringBuilder builder, Action onDispose) {
        Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        OnDispose = onDispose ?? throw new ArgumentNullException(nameof(onDispose));
    }

    public void Dispose() {
        Builder.Clear();
        OnDispose();
    }
}
