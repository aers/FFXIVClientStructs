using System.Collections;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct StdUnorderedMap<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    where TKey : unmanaged
    where TValue : unmanaged {

    public HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>> WithOps;

    public readonly ulong Count => WithOps.Count;

    public readonly bool ContainsKey(TKey key) => WithOps.ContainsKey(key);

    public readonly bool TryGetValue(TKey key, out TValue value) {
        var node = WithOps.FindNode(key);
        if (node is null) {
            value = default;
            return false;
        }

        value = node->Myval.Item2;
        return true;
    }

    // STL-compliant behavior is to create a new entry but not implemented
    // make this public whenever mutation is implemented
    private ref TValue this[TKey key] {
        get {
            var node = WithOps.FindNode(key);
            if (node is null)
                throw new KeyNotFoundException();
            return ref node->Myval.Item2;
        }
    }

    TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key] => this[key];

    public KeyEnumerator Keys => new(WithOps.GetEnumerator());
    public ValueEnumerator Values => new(WithOps.GetEnumerator());

    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;
    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

    public bool Contains(KeyValuePair<TKey, TValue> item) => throw new NotImplementedException();
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => throw new NotImplementedException();

    public readonly HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Node* FindNode(TKey key) => WithOps.FindNode(key);
    public readonly HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Enumerator GetEnumerator() => WithOps.GetEnumerator();

    IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    int IReadOnlyCollection<KeyValuePair<TKey, TValue>>.Count => throw new NotImplementedException();

    public struct KeyEnumerator(HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Enumerator enumerator) : IEnumerable<TKey>, IEnumerator<TKey> {
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
        private HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Enumerator activeEnumerator = enumerator;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

        public ref readonly TKey Current => ref activeEnumerator.Current.Value->Myval.Item1;

        public KeyEnumerator GetEnumerator() => new(enumerator);
        public bool MoveNext() => activeEnumerator.MoveNext();
        public void Reset() => activeEnumerator.Reset();
        public void Dispose() { }

        object IEnumerator.Current => Current;
        TKey IEnumerator<TKey>.Current => Current;
        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public struct ValueEnumerator(HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Enumerator enumerator) : IEnumerable<TValue>, IEnumerator<TValue> {
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
        private HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Enumerator activeEnumerator = enumerator;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

        public ref TValue Current => ref activeEnumerator.Current.Value->Myval.Item2;

        public ValueEnumerator GetEnumerator() => new(enumerator);
        public bool MoveNext() => activeEnumerator.MoveNext();
        public void Reset() => activeEnumerator.Reset();
        public void Dispose() { }

        object IEnumerator.Current => Current;
        TValue IEnumerator<TValue>.Current => Current;
        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public struct Enumerator(HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Enumerator enumerator)
        : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerator<KeyValuePair<TKey, TValue>> {
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
        private HashTable<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>, DefaultHasher<TKey>>.Enumerator activeEnumerator = enumerator;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

        public ref StdPair<TKey, TValue> Current => ref activeEnumerator.Current.Value->Myval;

        public Enumerator GetEnumerator() => new(enumerator);
        public bool MoveNext() => activeEnumerator.MoveNext();
        public void Reset() => activeEnumerator.Reset();
        public void Dispose() { }

        object IEnumerator.Current => new KeyValuePair<TKey, TValue>(Current.Item1, Current.Item2);
        KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => new(Current.Item1, Current.Item2);
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
