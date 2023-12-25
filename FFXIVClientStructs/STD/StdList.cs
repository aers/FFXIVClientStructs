using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdList<T, TMemorySpace, TOperation> : IStdList<T>
    where T : unmanaged
    where TMemorySpace : IStaticMemorySpace
    where TOperation : IStaticNativeObjectOperation<T> {

    // First node is Head->Next
    // Last node is Head->Previous
    public IStdList<T>.Node* Head;

    // Size is the number of nodes in the list (excluding the head node)
    public ulong Size;

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> First => Last.Value->Next;

    /// <inheritdoc/>
    public Pointer<IStdList<T>.Node> Last {
        get {
            if (Head is null) {
                // TODO: allocate the first node
                throw new NotImplementedException();
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
    public static Pointer<IStdList<T>.Node> CreateNodeCopy(in T value) {
        if (!TOperation.IsCopiable)
            throw new InvalidOperationException("Copying is not supported");
        var alloc = (IStdList<T>.Node*)TMemorySpace.Allocate((nuint)sizeof(IStdList<T>.Node), 0x10);
        if (alloc is null)
            throw new OutOfMemoryException();
        alloc->Next = alloc->Previous = null;
        TOperation.Copy(in value, out alloc->Value);
        return alloc;
    }

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeMove(ref T value) {
        if (!TOperation.IsMovable)
            throw new InvalidOperationException("Moving is not supported");
        var alloc = (IStdList<T>.Node*)TMemorySpace.Allocate((nuint)sizeof(IStdList<T>.Node), 0x10);
        if (alloc is null)
            throw new OutOfMemoryException();
        alloc->Next = alloc->Previous = null;
        TOperation.Move(ref value, out alloc->Value);
        return alloc;
    }

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeDefault() {
        if (!TOperation.IsMovable)
            throw new InvalidOperationException("Moving is not supported");
        var alloc = (IStdList<T>.Node*)TMemorySpace.Allocate((nuint)sizeof(IStdList<T>.Node), 0x10);
        if (alloc is null)
            throw new OutOfMemoryException();
        alloc->Next = alloc->Previous = null;
        TOperation.SetDefault(out alloc->Value);
        return alloc;
    }

    /// <inheritdoc/>
    public static void DisposeNode(Pointer<IStdList<T>.Node> node) => IMemorySpace.Free(node, (ulong)sizeof(IStdList<T>.Node));

    /// <inheritdoc/>
    public void AddAfter(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) {
        if (node.Value is null || newNode.Value is null)
            throw new NullReferenceException();
        Detach(newNode);
        newNode.Value->Previous = node.Value;
        newNode.Value->Next = node.Value->Next;
        newNode.Value->Next->Previous = newNode.Value;
        node.Value->Next = newNode.Value;
        Size++;
    }
    
    /// <inheritdoc/>
    public void AddAfterDefault(Pointer<IStdList<T>.Node> node) => AddAfter(node, CreateNodeDefault());
    
    /// <inheritdoc/>
    public void AddAfterCopy(Pointer<IStdList<T>.Node> node, in T value) => AddAfter(node, CreateNodeCopy(in value));
    
    /// <inheritdoc/>
    public void AddAfterMove(Pointer<IStdList<T>.Node> node, ref T value) => AddAfter(node, CreateNodeMove(ref value));

    /// <inheritdoc/>
    public void AddBefore(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => AddAfter(node.Value->Previous, newNode);
    
    /// <inheritdoc/>
    public void AddBeforeDefault(Pointer<IStdList<T>.Node> node) => AddBefore(node, CreateNodeDefault());
    
    /// <inheritdoc/>
    public void AddBeforeCopy(Pointer<IStdList<T>.Node> node, in T value) => AddBefore(node, CreateNodeCopy(in value));
    
    /// <inheritdoc/>
    public void AddBeforeMove(Pointer<IStdList<T>.Node> node, ref T value) => AddBefore(node, CreateNodeMove(ref value));

    /// <inheritdoc/>
    public void AddFirst(Pointer<IStdList<T>.Node> newNode) => AddAfter(Head, newNode);
    
    /// <inheritdoc/>
    public void AddFirstDefault() => AddFirst(CreateNodeDefault());
    
    /// <inheritdoc/>
    public void AddFirstCopy(in T value) => AddFirst(CreateNodeCopy(in value));
    
    /// <inheritdoc/>
    public void AddFirstMove(ref T value) => AddFirst(CreateNodeMove(ref value));

    /// <inheritdoc/>
    public void AddLast(Pointer<IStdList<T>.Node> newNode) => AddBefore(Head, newNode);
    
    /// <inheritdoc/>
    public void AddLastDefault() => AddLast(CreateNodeDefault());
    
    /// <inheritdoc/>
    public void AddLastCopy(in T value) => AddLast(CreateNodeCopy(in value));
    
    /// <inheritdoc/>
    public void AddLastMove(ref T value) => AddLast(CreateNodeMove(ref value));

    /// <inheritdoc/>
    public void Clear() {
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
            IMemorySpace.Free(Head);
        Head = null;
    }

    /// <inheritdoc/>
    public readonly Pointer<IStdList<T>.Node> Find(in T value) {
        if (Head is null)
            return default;
        for (var node = Head->Next; node != Head; node = node->Next) {
            if (TOperation.Equals(node->Value, value))
                return node;
        }

        return default;
    }

    /// <inheritdoc/>
    public readonly Pointer<IStdList<T>.Node> FindLast(in T value) {
        if (Head is null)
            return default;
        for (var node = Head->Previous; node != Head; node = node->Previous) {
            if (TOperation.Equals(node->Value, value))
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
        DisposeNode(node);
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
