using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public struct StdList<T>
    : IStdList<T>
        , IStaticNativeObjectOperation<StdList<T>>
    where T : unmanaged {
    public StdList<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>> WithOperationSpecs;

    public static bool HasDefault => true;
    public static bool IsDisposable => true;
    public static bool IsCopiable => DefaultStaticNativeObjectOperation<T>.IsCopiable;
    public static bool IsMovable => true;
    public static int Compare(in StdList<T> left, in StdList<T> right) => DefaultStaticNativeObjectOperation<StdList<T>>.Compare(left, right);
    public static bool ContentEquals(in StdList<T> left, in StdList<T> right) => DefaultStaticNativeObjectOperation<StdList<T>>.ContentEquals(left, right);
    public static void ConstructDefaultInPlace(out StdList<T> item) => DefaultStaticNativeObjectOperation<StdList<T>>.ConstructDefaultInPlace(out item);
    public static void StaticDispose(ref StdList<T> item) => DefaultStaticNativeObjectOperation<StdList<T>>.StaticDispose(ref item);
    public static void ConstructCopyInPlace(in StdList<T> source, out StdList<T> target) => DefaultStaticNativeObjectOperation<StdList<T>>.ConstructCopyInPlace(source, out target);
    public static void ConstructMoveInPlace(ref StdList<T> source, out StdList<T> target) => DefaultStaticNativeObjectOperation<StdList<T>>.ConstructMoveInPlace(ref source, out target);
    public static void Swap(ref StdList<T> item1, ref StdList<T> item2) => DefaultStaticNativeObjectOperation<StdList<T>>.Swap(ref item1, ref item2);

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
    public static void DisposeNode(Pointer<IStdList<T>.Node> node, bool disposeValue) =>
        StdList<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>>.DisposeNode(node, disposeValue);

    public Pointer<IStdList<T>.Node> AddAfter(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddAfter(node, newNode);
    public Pointer<IStdList<T>.Node> AddAfterDefault(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.AddAfterDefault(node);
    public Pointer<IStdList<T>.Node> AddAfterCopy(Pointer<IStdList<T>.Node> node, in T value) => WithOperationSpecs.AddAfterCopy(node, in value);
    public Pointer<IStdList<T>.Node> AddAfterMove(Pointer<IStdList<T>.Node> node, ref T value) => WithOperationSpecs.AddAfterMove(node, ref value);
    public Pointer<IStdList<T>.Node> AddBefore(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddBefore(node, newNode);
    public Pointer<IStdList<T>.Node> AddBeforeDefault(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.AddBeforeDefault(node);
    public Pointer<IStdList<T>.Node> AddBeforeCopy(Pointer<IStdList<T>.Node> node, in T value) => WithOperationSpecs.AddBeforeCopy(node, in value);
    public Pointer<IStdList<T>.Node> AddBeforeMove(Pointer<IStdList<T>.Node> node, ref T value) => WithOperationSpecs.AddBeforeMove(node, ref value);
    public Pointer<IStdList<T>.Node> AddFirst(Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddFirst(newNode);
    public Pointer<IStdList<T>.Node> AddFirstDefault() => WithOperationSpecs.AddFirstDefault();
    public Pointer<IStdList<T>.Node> AddFirstCopy(in T value) => WithOperationSpecs.AddFirstCopy(in value);
    public Pointer<IStdList<T>.Node> AddFirstMove(ref T value) => WithOperationSpecs.AddFirstMove(ref value);
    public Pointer<IStdList<T>.Node> AddLast(Pointer<IStdList<T>.Node> newNode) => WithOperationSpecs.AddLast(newNode);
    public Pointer<IStdList<T>.Node> AddLastDefault() => WithOperationSpecs.AddLastDefault();
    public Pointer<IStdList<T>.Node> AddLastCopy(in T value) => WithOperationSpecs.AddLastCopy(in value);
    public Pointer<IStdList<T>.Node> AddLastMove(ref T value) => WithOperationSpecs.AddLastMove(ref value);
    public void Clear() => WithOperationSpecs.Clear();
    public readonly bool Contains(in T value) => WithOperationSpecs.Contains(in value);
    public void Detach(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.Detach(node);
    public void Dispose() => WithOperationSpecs.Dispose();
    public readonly Pointer<IStdList<T>.Node> Find(in T value) => WithOperationSpecs.Find(in value);
    public readonly Pointer<IStdList<T>.Node> FindLast(in T value) => WithOperationSpecs.FindLast(in value);
    public readonly IStdList<T>.Enumerator GetEnumerator() => WithOperationSpecs.GetEnumerator();
    public void Remove(Pointer<IStdList<T>.Node> node) => WithOperationSpecs.Remove(node);
    public bool Remove(in T value) => WithOperationSpecs.Remove(in value);
    public void RemoveFirst() => WithOperationSpecs.RemoveFirst();
    public void RemoveLast() => WithOperationSpecs.RemoveLast();
}
