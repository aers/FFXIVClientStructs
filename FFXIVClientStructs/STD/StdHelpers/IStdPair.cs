using System.Collections;
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD.StdHelpers;

public interface IStdPair<T1, T2>
    : IDisposable, IEquatable<IStdPair<T1, T2>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<IStdPair<T1, T2>>, ITuple
    where T1 : unmanaged
    where T2 : unmanaged {
    public ref T1 Item1 { get; }
    public ref T2 Item2 { get; }
    void Deconstruct(out T1 item1, out T2 item2);
}
