using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public struct StdList<T> : IStdList<T>
    where T : unmanaged {
    public StdList<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>> WithOperationSpecs;

    public int Count => WithOperationSpecs.Count;
    public bool IsReadOnly => WithOperationSpecs.IsReadOnly;
    public Pointer<IStdList<T>.Node> First => WithOperationSpecs.First;
    public Pointer<IStdList<T>.Node> Last => WithOperationSpecs.Last;
    public long LongCount => WithOperationSpecs.LongCount;

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeCopy(in T value) =>
        StdList<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>>.CreateNodeCopy(in value);

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeMove(ref T value) =>
        StdList<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>>.CreateNodeMove(ref value);

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeDefault() =>
        StdList<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>>.CreateNodeDefault();

    /// <inheritdoc/>
    public static void DisposeNode(Pointer<IStdList<T>.Node> node) =>
        StdList<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>>.DisposeNode(node);
    
    public void AddAfter(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddAfter(node, newNode);
    public void AddAfterDefault(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.AddAfterDefault(node);
    public void AddAfterCopy(Pointer<IStdList<T>.Node> node, in T value) => WithOperationSpecs.AddAfterCopy(node, in value);
    public void AddAfterMove(Pointer<IStdList<T>.Node> node, ref T value) => WithOperationSpecs.AddAfterMove(node, ref value);
    public void AddBefore(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddBefore(node, newNode);
    public void AddBeforeDefault(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.AddBeforeDefault(node);
    public void AddBeforeCopy(Pointer<IStdList<T>.Node> node, in T value) => WithOperationSpecs.AddBeforeCopy(node, in value);
    public void AddBeforeMove(Pointer<IStdList<T>.Node> node, ref T value) => WithOperationSpecs.AddBeforeMove(node, ref value);
    public void AddFirst(Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddFirst(newNode);
    public void AddFirstDefault() => WithOperationSpecs.AddFirstDefault();
    public void AddFirstCopy(in T value) => WithOperationSpecs.AddFirstCopy(in value);
    public void AddFirstMove(ref T value) => WithOperationSpecs.AddFirstMove(ref value);
    public void AddLast(Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddLast(newNode);
    public void AddLastDefault() => WithOperationSpecs.AddLastDefault();
    public void AddLastCopy(in T value) => WithOperationSpecs.AddLastCopy(in value);
    public void AddLastMove(ref T value) => WithOperationSpecs.AddLastMove(ref value);
    public void Clear() => WithOperationSpecs.Clear();
    public bool Contains(in T value) => WithOperationSpecs.Contains(in value);
    public void Detach(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.Detach(node);
    public void Dispose() => WithOperationSpecs.Dispose();
    public Pointer<IStdList<T>.Node> Find(in T value) => WithOperationSpecs.Find(in value);
    public Pointer<IStdList<T>.Node> FindLast(in T value) => WithOperationSpecs.FindLast(in value);
    public IStdList<T>.Enumerator GetEnumerator() => WithOperationSpecs.GetEnumerator();
    public void Remove(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.Remove(node);
    public bool Remove(in T value) => WithOperationSpecs.Remove(in value);
    public void RemoveFirst() => WithOperationSpecs.RemoveFirst();
    public void RemoveLast() => WithOperationSpecs.RemoveLast();
}
