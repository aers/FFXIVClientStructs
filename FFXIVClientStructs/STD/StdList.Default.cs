using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public struct StdList<T>
    : IStdList<T>
        , IStaticNativeObjectOperation<StdList<T>>
    where T : unmanaged {
    public StdList<T, IStaticMemorySpace.Default> WithOps;

    public static bool HasDefault => true;
    public static bool IsDisposable => true;
    public static bool IsCopiable => StdOps<T>.IsCopiable;
    public static bool IsMovable => true;
    public static int Compare(in StdList<T> left, in StdList<T> right) => StdOps<StdList<T>>.Compare(left, right);
    public static bool ContentEquals(in StdList<T> left, in StdList<T> right) => StdOps<StdList<T>>.ContentEquals(left, right);
    public static void ConstructDefaultInPlace(out StdList<T> item) => StdOps<StdList<T>>.ConstructDefaultInPlace(out item);
    public static void StaticDispose(ref StdList<T> item) => StdOps<StdList<T>>.StaticDispose(ref item);
    public static void ConstructCopyInPlace(in StdList<T> source, out StdList<T> target) => StdOps<StdList<T>>.ConstructCopyInPlace(source, out target);
    public static void ConstructMoveInPlace(ref StdList<T> source, out StdList<T> target) => StdOps<StdList<T>>.ConstructMoveInPlace(ref source, out target);
    public static void Swap(ref StdList<T> item1, ref StdList<T> item2) => StdOps<StdList<T>>.Swap(ref item1, ref item2);

    public int Count => WithOps.Count;
    public bool IsReadOnly => WithOps.IsReadOnly;
    public Pointer<IStdList<T>.Node> First => WithOps.First;
    public Pointer<IStdList<T>.Node> Last => WithOps.Last;
    public long LongCount => WithOps.LongCount;

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeCopy(in T value) =>
        StdList<T, IStaticMemorySpace.Default>.CreateNodeCopy(in value);

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeMove(ref T value) =>
        StdList<T, IStaticMemorySpace.Default>.CreateNodeMove(ref value);

    /// <inheritdoc/>
    public static Pointer<IStdList<T>.Node> CreateNodeDefault() =>
        StdList<T, IStaticMemorySpace.Default>.CreateNodeDefault();

    /// <inheritdoc/>
    public static void DisposeNode(Pointer<IStdList<T>.Node> node, bool disposeValue) =>
        StdList<T, IStaticMemorySpace.Default>.DisposeNode(node, disposeValue);

    public Pointer<IStdList<T>.Node> AddAfter(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => WithOps.AddAfter(node, newNode);
    public Pointer<IStdList<T>.Node> AddAfterDefault(Pointer<IStdList<T>.Node> node) => WithOps.AddAfterDefault(node);
    public Pointer<IStdList<T>.Node> AddAfterCopy(Pointer<IStdList<T>.Node> node, in T value) => WithOps.AddAfterCopy(node, in value);
    public Pointer<IStdList<T>.Node> AddAfterMove(Pointer<IStdList<T>.Node> node, ref T value) => WithOps.AddAfterMove(node, ref value);
    public Pointer<IStdList<T>.Node> AddBefore(Pointer<IStdList<T>.Node> node, Pointer<IStdList<T>.Node> newNode) => WithOps.AddBefore(node, newNode);
    public Pointer<IStdList<T>.Node> AddBeforeDefault(Pointer<IStdList<T>.Node> node) => WithOps.AddBeforeDefault(node);
    public Pointer<IStdList<T>.Node> AddBeforeCopy(Pointer<IStdList<T>.Node> node, in T value) => WithOps.AddBeforeCopy(node, in value);
    public Pointer<IStdList<T>.Node> AddBeforeMove(Pointer<IStdList<T>.Node> node, ref T value) => WithOps.AddBeforeMove(node, ref value);
    public Pointer<IStdList<T>.Node> AddFirst(Pointer<IStdList<T>.Node> newNode) => WithOps.AddFirst(newNode);
    public Pointer<IStdList<T>.Node> AddFirstDefault() => WithOps.AddFirstDefault();
    public Pointer<IStdList<T>.Node> AddFirstCopy(in T value) => WithOps.AddFirstCopy(in value);
    public Pointer<IStdList<T>.Node> AddFirstMove(ref T value) => WithOps.AddFirstMove(ref value);
    public Pointer<IStdList<T>.Node> AddLast(Pointer<IStdList<T>.Node> newNode) => WithOps.AddLast(newNode);
    public Pointer<IStdList<T>.Node> AddLastDefault() => WithOps.AddLastDefault();
    public Pointer<IStdList<T>.Node> AddLastCopy(in T value) => WithOps.AddLastCopy(in value);
    public Pointer<IStdList<T>.Node> AddLastMove(ref T value) => WithOps.AddLastMove(ref value);
    public void Clear() => WithOps.Clear();
    public readonly bool Contains(in T value) => WithOps.Contains(in value);
    public void Detach(Pointer<IStdList<T>.Node> node) => WithOps.Detach(node);
    public void Dispose() => WithOps.Dispose();
    public readonly Pointer<IStdList<T>.Node> Find(in T value) => WithOps.Find(in value);
    public readonly Pointer<IStdList<T>.Node> FindLast(in T value) => WithOps.FindLast(in value);
    public readonly IStdList<T>.Enumerator GetEnumerator() => WithOps.GetEnumerator();
    public void Remove(Pointer<IStdList<T>.Node> node) => WithOps.Remove(node);
    public bool Remove(in T value) => WithOps.Remove(in value);
    public void RemoveFirst() => WithOps.RemoveFirst();
    public void RemoveLast() => WithOps.RemoveLast();
}
