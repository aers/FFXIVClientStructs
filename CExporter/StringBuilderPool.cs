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

        var builderPooled = new StringBuilderPooled {
            Builder = new StringBuilder()
        };

        builderPooled.OnDispose = () => _pool.Push(builderPooled);

        return builderPooled;
    }

    public static StringBuilderPooled Get(int capacity) {
        if (_pool.Count > 0) {
            var builder = _pool.Pop();
            builder.Builder.EnsureCapacity(capacity);
            return builder;
        }

        var builderPooled = new StringBuilderPooled {
            Builder = new StringBuilder(capacity)
        };

        builderPooled.OnDispose = () => _pool.Push(builderPooled);

        return builderPooled;
    }
}

public class StringBuilderPooled : IDisposable {
    public StringBuilder Builder = null!;
    public Action OnDispose = null!;
    public void Dispose() {
        Builder.Clear();
        OnDispose();
    }
}
