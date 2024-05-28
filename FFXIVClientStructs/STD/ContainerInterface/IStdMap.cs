using System.Collections;
using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD.ContainerInterface;

[SuppressMessage("ReSharper", "PossibleInterfaceMemberAmbiguity")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe interface IStdMap<TKey, TValue>
    : IReadOnlyDictionary<TKey, TValue>, IDictionary<TKey, TValue>, ICollection, IDisposable
    where TKey : unmanaged
    where TValue : unmanaged {

    /// <summary>
    /// Gets the number of items in the map.
    /// </summary>
    new int Count { get; }

    /// <summary>
    /// Gets the number of items in the map, in <see cref="long"/>.
    /// </summary>
    long LongCount { get; }

    /// <summary>
    /// Gets the collection of keys.
    /// </summary>
    new KeyCollection Keys { get; }

    /// <summary>
    /// Gets the collection of values.
    /// </summary>
    new ValueCollection Values { get; }

    #region Collection interfaces

    ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;
    ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;
    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;
    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

    int ICollection.Count => Count;
    int ICollection<KeyValuePair<TKey, TValue>>.Count => Count;
    int IReadOnlyCollection<KeyValuePair<TKey, TValue>>.Count => Count;

    bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;
    bool ICollection.IsSynchronized => false;
    object ICollection.SyncRoot => Array.Empty<byte>();

    #endregion

    /// <summary>
    /// Gets the reference of item corresponding to <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The key.</param>
    ref TValue this[in TKey key] { get; }

    /// <summary>
    /// Adds an item to the dictionary, copying both <paramref name="key"/> and <paramref name="value"/>.
    /// </summary>
    /// <param name="key">The key to copy from.</param>
    /// <param name="value">The value to copy from.</param>
    /// <returns><c>true</c> if added; <c>false</c> if the key already exists.</returns>
    bool TryAddValueKCopyVCopy(in TKey key, in TValue value);

    /// <summary>
    /// Adds an item to the dictionary, copying <paramref name="key"/> and moving <paramref name="value"/>.
    /// </summary>
    /// <param name="key">The key to copy from.</param>
    /// <param name="value">The value to move from.</param>
    /// <returns><c>true</c> if added; <c>false</c> if the key already exists.</returns>
    bool TryAddValueKCopyVMove(in TKey key, ref TValue value);

    /// <summary>
    /// Adds an item to the dictionary, moving <paramref name="key"/> and copying <paramref name="value"/>.
    /// </summary>
    /// <param name="key">The key to move from.</param>
    /// <param name="value">The value to copy from.</param>
    /// <returns><c>true</c> if added; <c>false</c> if the key already exists.</returns>
    bool TryAddValueKMoveVCopy(ref TKey key, in TValue value);

    /// <summary>
    /// Adds an item to the dictionary, moving both <paramref name="key"/> and <paramref name="value"/>.
    /// </summary>
    /// <param name="key">The key to move from.</param>
    /// <param name="value">The value to move from.</param>
    /// <returns><c>true</c> if added; <c>false</c> if the key already exists.</returns>
    bool TryAddValueKMoveVMove(ref TKey key, ref TValue value);

    /// <summary>
    /// Determines if the map contains the key <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><c>true</c> if the map contains a corresponding item.</returns>
    bool ContainsKey(in TKey key);

    /// <summary>
    /// Determines if the map contains the key <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The key.</param>
    /// <returns><c>true</c> if the map contains a corresponding item.</returns>
    bool ContainsValue(in TValue value);

    /// <summary>
    /// Removes the item corresponding to <paramref name="key"/> if it exists.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><c>true</c> if removed; <c>false</c> if the key does not exist.</returns>
    bool Remove(in TKey key);

    /// <summary>
    /// Removes the item corresponding to <paramref name="key"/> and <paramref name="value"/> if it exists.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if removed; <c>false</c> if the key does not exist or the value does not match.</returns>
    bool Remove(in TKey key, in TValue value);

    /// <summary>
    /// Attempts to get a copy of the value corresponding to <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The corresponding value.</param>
    /// <param name="copyCtor">If <c>true</c>, use <see cref="IStaticNativeObjectOperation{T}.ConstructCopyInPlace"/> to make a copy.</param>
    /// <returns><c>true</c> if corresponding entry exists.</returns>
    bool TryGetValue(in TKey key, out TValue value, bool copyCtor);

    /// <summary>
    /// Attempts to get the pointer to the value corresponding to <paramref name="key"/>/
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The corresponding value.</param>
    /// <returns><c>true</c> if corresponding entry exists.</returns>
    public bool TryGetValuePointer(in TKey key, out TValue* value);

    /// <summary>
    /// Returns an <see cref="IEnumerable{T}"/> that iterates over the map in sorted order.
    /// </summary>
    /// <returns>An enumerator that iterates over the map in sorted order.</returns>
    new RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator GetEnumerator();

    /// <summary>
    /// Returns an <see cref="IEnumerable{T}"/> that iterates over the map in reverse order.
    /// </summary>
    /// <returns>An enumerator that iterates over the map in reverse order.</returns>
    RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator Reverse();

    #region Collection interfaces

    void ICollection.CopyTo(Array array, int index) {
        if (array is not KeyValuePair<TKey, TValue>[] typedArray)
            throw new ArgumentException(null, nameof(array));
        CopyTo(typedArray, index);
    }

    bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value) => TryGetValue(key, out value, false);
    bool IDictionary<TKey, TValue>.ContainsKey(TKey key) => ContainsKey(key);
    bool IDictionary<TKey, TValue>.Remove(TKey key) => Remove(key);
    bool IReadOnlyDictionary<TKey, TValue>.ContainsKey(TKey key) => ContainsKey(key);
    bool IReadOnlyDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value) => TryGetValue(key, out value, false);
    IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => new KeyValuePairViewEnumerator(GetEnumerator());
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion

    public readonly struct KeyCollection : ICollection<TKey> {
        private readonly RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>* _tree;

        public KeyCollection(RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>* tree) => _tree = tree;

        public int Count => checked((int)_tree->LongCount);
        bool ICollection<TKey>.IsReadOnly => true;

        public KeyEnumerator GetEnumerator() => new(_tree, false);

        public KeyEnumerator Reverse() => new(_tree, true);

        public bool Contains(in TKey item) => _tree->FindLowerBound(item).KeyEquals(item);

        public void CopyTo(TKey[] array, int arrayIndex) {
            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
            if (array.Length - arrayIndex < _tree->LongCount)
                throw new ArgumentException(null, nameof(array));

            var i = (long)arrayIndex;
            foreach (ref readonly var k in this)
                array[i++] = k;
        }

        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        bool ICollection<TKey>.Contains(TKey item) => Contains(item);
        void ICollection<TKey>.Add(TKey item) => throw new NotSupportedException();
        void ICollection<TKey>.Clear() => throw new NotSupportedException();
        bool ICollection<TKey>.Remove(TKey item) => throw new NotSupportedException();
    }

    public struct KeyEnumerator : IEnumerator<TKey>, IEnumerable<TKey> {
        private RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator _enumerator;

        public KeyEnumerator(RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>* tree, bool ltr) =>
            _enumerator = new RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator(tree, ltr);
        private KeyEnumerator(RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator enumerator) =>
            _enumerator = enumerator;

        public readonly ref readonly TKey Current => ref _enumerator.Current.Item1;
        readonly TKey IEnumerator<TKey>.Current => Current;
        readonly object IEnumerator.Current => Current;

        public bool MoveNext() => _enumerator.MoveNext();
        public bool DeleteAndMoveNext() => _enumerator.DeleteAndMoveNext();
        public void Reset() => _enumerator.Reset();
        public void Dispose() => _enumerator.Dispose();

        public KeyEnumerator GetEnumerator() => new(_enumerator.GetEnumerator());
        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct ValueCollection : ICollection<TValue> {
        private readonly RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>* _tree;

        public ValueCollection(RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>* tree) => _tree = tree;

        public int Count => checked((int)_tree->LongCount);
        bool ICollection<TValue>.IsReadOnly => true;

        public ValueEnumerator GetEnumerator() => new(_tree, false);

        public ValueEnumerator Reverse() => new(_tree, true);

        public bool Contains(in TValue item) {
            foreach (ref var v in this) {
                if (StdOps<TValue>.ContentEquals(v, item))
                    return true;
            }

            return false;
        }

        public void CopyTo(TValue[] array, int arrayIndex) {
            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
            if (array.Length - arrayIndex < _tree->LongCount)
                throw new ArgumentException(null, nameof(array));

            var i = (long)arrayIndex;
            foreach (ref readonly var k in this)
                array[i++] = k;
        }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        bool ICollection<TValue>.Contains(TValue item) => Contains(item);
        void ICollection<TValue>.Add(TValue item) => throw new NotSupportedException();
        void ICollection<TValue>.Clear() => throw new NotSupportedException();
        bool ICollection<TValue>.Remove(TValue item) => throw new NotSupportedException();
    }

    public struct ValueEnumerator : IEnumerator<TValue>, IEnumerable<TValue> {
        private RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator _enumerator;

        public ValueEnumerator(RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>* tree, bool ltr) =>
            _enumerator = new RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator(tree, ltr);
        private ValueEnumerator(RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator enumerator) =>
            _enumerator = enumerator;

        public readonly ref TValue Current => ref _enumerator.Current.Item2;
        readonly TValue IEnumerator<TValue>.Current => Current;
        readonly object IEnumerator.Current => Current;

        public bool MoveNext() => _enumerator.MoveNext();
        public bool DeleteAndMoveNext() => _enumerator.DeleteAndMoveNext();
        public void Reset() => _enumerator.Reset();
        public void Dispose() => _enumerator.Dispose();

        public ValueEnumerator GetEnumerator() => new(_enumerator.GetEnumerator());
        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public struct KeyValuePairViewEnumerator : IEnumerator<KeyValuePair<TKey, TValue>> {
        private RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator _enumerator;

        public KeyValuePairViewEnumerator(RedBlackTree<StdPair<TKey, TValue>, TKey, PairKeyExtractor<TKey, TValue>>.Enumerator enu) =>
            _enumerator = enu;

        public readonly KeyValuePair<TKey, TValue> Current => _enumerator.Current;
        readonly object IEnumerator.Current => Current;

        public bool MoveNext() => _enumerator.MoveNext();
        public bool DeleteAndMoveNext() => _enumerator.DeleteAndMoveNext();
        public void Reset() => _enumerator.Reset();
        public void Dispose() => _enumerator.Dispose();
    }
}
