using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class SignatureAnalyzerTests {
    [Fact]
    public async Task SignatureIsValid_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("AB CD EF ?? 01 23 45 67 89")]
                                public int TestFunction() { return 0; }
                            }
                            """;

        await AnalyzerVerifier<SignatureIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task SignatureContainsInvalidCharacters_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [{|CSIG0201:MemberFunction("ab cd ef")|}]
                                public int TestFunction() { return 0; }
                            }
                            """;

        await AnalyzerVerifier<SignatureIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task SignatureFormatInvalid_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [{|CSIG0202:MemberFunction("ABCDEF0123456789")|}]
                                public int TestFunction() { return 0; }
                            }
                            """;

        await AnalyzerVerifier<SignatureIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
