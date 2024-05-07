using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class MethodAnalyzerTests {
    [Fact]
    public async Task TargetMethodIsNotPartial() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public int {|CSIG0101:TestFunction|}() { return 0; }
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidParameters() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public partial void TestFunction(int validParam, List<string> {|CSIG0102:invalidParam|});
                                
                                public partial void TestFunction(int validParam, List<string> {|CSIG0102:invalidParam|}) { }
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidReturn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public partial string {|CSIG0103:TestFunction|}();
                                
                                public partial string {|CSIG0103:TestFunction|}() { return ""; }
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
