using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FFXIVClientStructs.STD.StdHelpers;

[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
public interface IStaticEncoding {
    public abstract static Encoding Encoding { get; }

    public class System : IStaticEncoding {
        private System() => throw new InvalidOperationException();
        
        public static Encoding Encoding => CodePagesEncodingProvider.Instance.GetEncoding(0) ?? throw new NotSupportedException();
    }

    public class Unicode : IStaticEncoding {
        private Unicode() => throw new InvalidOperationException();

        public static Encoding Encoding => Encoding.Unicode;
    }
}
