using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FFXIVClientStructs.STD.Helper;

[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
public interface IStaticEncoding {
    public abstract static Encoding Encoding { get; }

    public abstract class System : IStaticEncoding {
        public static Encoding Encoding => CodePagesEncodingProvider.Instance.GetEncoding(0) ?? throw new NotSupportedException();
    }

    public abstract class Unicode : IStaticEncoding {
        public static Encoding Encoding => Encoding.Unicode;
    }
}
