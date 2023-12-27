using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdList<T, TMemorySpace>
    : IStdList<T>
        , IStaticNativeObjectOperation<StdList<T, TMemorySpace>>
    where T : unmanaged
    where TMemorySpace : IStaticMemorySpace {

    // First node is Head->Next
    // Last node is Head->Previous
    public IStdList<T>.Node* Head;

    // Size is the number of nodes in the list (excluding the head node)
    public ulong Size;

    public static bool HasDefault => true;
    public static bool IsDisposable => true;
    public static bool IsCopiable => StdOps<T>.IsCopiable;
    public static bool IsMovable => true;

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> First => Last.Value->Next;

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> Last {
        get {
            if (Head is null) {
                Head = CreateNodeDefault();
                Head->Next = Head->Previous = Head;
            }

            return Head;
        }
    }

    /// <inheritdoc cref="ICollection{T}.Count"/>
    public readonly int Count => checked((int)Size);

    /// <inheritdoc/>
    public readonly long LongCount => (long)Size;

    /// <inheritdoc/>
    readonly int ICollection<T>.Count => Count;

    /// <inheritdoc/>
    public readonly bool IsReadOnly => false;

    /// <inheritdoc/>
    readonly int IReadOnlyCollection<T>.Count => Count;

    /// <inheritdoc/>
    public static int Compare(in StdList<T, TMemorySpace> left, in StdList<T, TMemorySpace> right) {
        var leftEnd = left.Head;
        var rightEnd = right.Head;
        if (leftEnd is null && rightEnd is null)
            return 0;
        if (leftEnd is null)
            return -1;
        if (rightEnd is null)
            return 1;

        var leftNode = leftEnd->Next;
        var rightNode = rightEnd->Next;
        for (; leftNode != leftEnd && rightNode != rightEnd; leftNode = leftNode->Next, rightNode = rightNode->Next) {
            var c = StdOps<T>.Compare(leftNode->Value, rightNode->Value);
            if (c != 0)
                return c;
        }

        if (leftNode != leftEnd)
            return 1;
        if (rightNode != rightEnd)
            return -1;
        return 0;
    }

    /// <inheritdoc/>
    public static bool ContentEquals(in StdList<T, TMemorySpace> left, in StdList<T, TMemorySpace> right) {
        if (left.Count != right.Count)
            return false;
        if (left.Count == 0 || right.Count == 0)
            return false;
        Debug.Assert(left.Head is not null && right.Head is not null, "Count and Head are not consistent");

        var leftEnd = left.Head;
        var rightEnd = right.Head;
        var leftNode = leftEnd->Next;
        var rightNode = rightEnd->Next;
        for (; leftNode != leftEnd && rightNode != rightEnd; leftNode = leftNode->Next, rightNode = rightNode->Next) {
            if (!StdOps<T>.ContentEquals(leftNode->Value, rightNode->Value))
                return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public static void ConstructDefaultInPlace(out StdList<T, TMemorySpace> item) => item = default;

    /// <inheritdoc/>
    public static void ConstructCopyInPlace(in StdList<T, TMemorySpace> source, out StdList<T, TMemorySpace> target) {
        if (!StdOps<T>.IsCopiable)
            throw new InvalidOperationException("Copying is not supported");
        target = default;
        foreach (ref var v in source)
            target.AddLastCopy(v);
    }

    /// <inheritdoc/>
    public static void ConstructMoveInPlace(ref StdList<T, TMemorySpace> source, out StdList<T, TMemorySpace> target) => (target, source) = (source, default);

    /// <inheritdoc/>
    public static void StaticDispose(ref StdList<T, TMemorySpace> item) => item.Dispose();

    /// <inheritdoc/>
    public static void Swap(ref StdList<T, TMemorySpace> item1, ref StdList<T, TMemorySpace> item2) => (item1, item2) = (item2, item1);

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeCopy(in T value) {
        if (!StdOps<T>.IsCopiable)
            throw new InvalidOperationException("Copying is not supported");
        var alloc = (IStdList<T>.Node*)TMemorySpace.Allocate((nuint)sizeof(IStdList<T>.Node), 0x10);
        if (alloc is null)
            throw new OutOfMemoryException();
        alloc->Next = alloc->Previous = null;
        StdOps<T>.ConstructCopyInPlace(in value, out alloc->Value);
        return alloc;
    }

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeMove(ref T value) {
        if (!StdOps<T>.IsMovable)
            throw new InvalidOperationException("Moving is not supported");
        var alloc = (IStdList<T>.Node*)TMemorySpace.Allocate((nuint)sizeof(IStdList<T>.Node), 0x10);
        if (alloc is null)
            throw new OutOfMemoryException();
        alloc->Next = alloc->Previous = null;
        StdOps<T>.ConstructMoveInPlace(ref value, out alloc->Value);
        return alloc;
    }

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeDefault() {
        if (!StdOps<T>.IsMovable)
            throw new InvalidOperationException("Moving is not supported");
        var alloc = (IStdList<T>.Node*)TMemorySpace.Allocate((nuint)sizeof(IStdList<T>.Node), 0x10);
        if (alloc is null)
            throw new OutOfMemoryException();
        alloc->Next = alloc->Previous = null;
        StdOps<T>.ConstructDefaultInPlace(out alloc->Value);
        return alloc;
    }

    /// <inheritdoc/>
    public static void DisposeNode(Pointer<IStdList<T>.Node> node, bool disposeValue) {
        if (disposeValue)
            StdOps<T>.StaticDispose(ref node.Value->Value);
        IMemorySpace.Free(node, (ulong)sizeof(IStdList<T>.Node));
    }

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddAfter(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) {
        if (node.Value is null || newNode.Value is null)
            throw new NullReferenceException();
        Detach(newNode);
        newNode.Value->Previous = node.Value;
        newNode.Value->Next = node.Value->Next;
        newNode.Value->Next->Previous = newNode.Value;
        node.Value->Next = newNode.Value;
        Size++;
        return newNode;
    }

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddAfterDefault(Pointer<IStdList<T>.Node> node) => AddAfter(node, CreateNodeDefault());

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddAfterCopy(Pointer<IStdList<T>.Node> node, in T value) => AddAfter(node, CreateNodeCopy(in value));

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddAfterMove(Pointer<IStdList<T>.Node> node, ref T value) => AddAfter(node, CreateNodeMove(ref value));

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddBefore(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => AddAfter(node.Value->Previous, newNode);

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddBeforeDefault(Pointer<IStdList<T>.Node> node) => AddBefore(node, CreateNodeDefault());

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddBeforeCopy(Pointer<IStdList<T>.Node> node, in T value) => AddBefore(node, CreateNodeCopy(in value));

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddBeforeMove(Pointer<IStdList<T>.Node> node, ref T value) => AddBefore(node, CreateNodeMove(ref value));

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddFirst(Pointer<IStdList<T>.Node> newNode) => AddAfter(Last, newNode);

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddFirstDefault() => AddFirst(CreateNodeDefault());

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddFirstCopy(in T value) => AddFirst(CreateNodeCopy(in value));

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddFirstMove(ref T value) => AddFirst(CreateNodeMove(ref value));

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddLast(Pointer<IStdList<T>.Node> newNode) => AddBefore(Last, newNode);

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddLastDefault() => AddLast(CreateNodeDefault());

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddLastCopy(in T value) => AddLast(CreateNodeCopy(in value));

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> AddLastMove(ref T value) => AddLast(CreateNodeMove(ref value));

    /// <inheritdoc/>
    public void Clear() {
        if (Head is null)
            return;

        while (Head != Head->Previous)
            Remove(Head->Previous);
    }

    /// <inheritdoc/>
    public readonly bool Contains(in T value) => Find(value).Value is not null;

    /// <inheritdoc/>
    public void Detach(Pointer<IStdList<T>.Node> node) {
        if (node.Value is null)
            throw new NullReferenceException();
        if (node.Value == Head)
            throw new ArgumentException("Cannot detach head node", nameof(node));
        if (node.Value->Next is null || node.Value->Previous is null)
            return;
        node.Value->Previous->Next = node.Value->Next;
        node.Value->Next->Previous = node.Value->Previous;
        node.Value->Previous = node.Value->Next = null;
    }

    /// <inheritdoc/>
    public void Dispose() {
        Clear();
        if (Head is not null)
            DisposeNode(Head, false);
        Head = null;
    }

    /// <inheritdoc/>
    public readonly Pointer<IStdList<T>.Node> Find(in T value) {
        if (Head is null)
            return default;
        for (var node = Head->Next; node != Head; node = node->Next) {
            if (StdOps<T>.ContentEquals(node->Value, value))
                return node;
        }

        return default;
    }

    /// <inheritdoc/>
    public readonly Pointer<IStdList<T>.Node> FindLast(in T value) {
        if (Head is null)
            return default;
        for (var node = Head->Previous; node != Head; node = node->Previous) {
            if (StdOps<T>.ContentEquals(node->Value, value))
                return node;
        }

        return default;
    }

    /// <inheritdoc/>
    public readonly IStdList<T>.Enumerator GetEnumerator() => new(Head);

    /// <inheritdoc cref="object.GetHashCode"/>
    public readonly override int GetHashCode() => HashCode.Combine((nint)Head, Count);

    /// <inheritdoc/>
    public void Remove(Pointer<IStdList<T>.Node> node) {
        if (node.Value is null)
            throw new NullReferenceException();
        Detach(node);
        DisposeNode(node, true);
        Size--;
    }

    /// <inheritdoc/>
    public bool Remove(in T value) {
        if (Find(value) is not { Value: not null } v)
            return false;
        Remove(v);
        return true;
    }

    /// <inheritdoc/>
    public void RemoveFirst() {
        if (Head is null || Head->Next == Head)
            throw new InvalidOperationException();
        Remove(Head->Next);
    }

    /// <inheritdoc/>
    public void RemoveLast() {
        if (Head is null || Head->Previous == Head)
            throw new InvalidOperationException();
        Remove(Head->Previous);
    }
}
