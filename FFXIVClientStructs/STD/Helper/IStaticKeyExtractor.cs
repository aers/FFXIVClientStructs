using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.Helper;

[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
public interface IStaticKeyExtractor<T, TKey> {
    public abstract static ref readonly TKey ExtractKey(in T value);
}
