using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class MethodAnalyzerTests {
    [Fact]
    public async Task TargetMethodMustBePartial_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                {|CSIG0101:[MemberFunction("??")]
                                public int TestFunction() { return 0; }|}
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodMustBePartial_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public partial int TestFunction();
                                
                                public partial int TestFunction() => 0;
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidParameters_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public partial void TestFunction({|CSIG0102:List<string> invalidParam|});
                                
                                public partial void TestFunction({|CSIG0102:List<string> invalidParam|}) { }
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidParameters_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public partial void TestFunction(int validParam);
                                
                                public partial void TestFunction(int validParam) { }
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidReturn_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                {|CSIG0103:[MemberFunction("??")]
                                public partial string TestFunction();|}
                                
                                {|CSIG0103:public partial string TestFunction() { return ""; }|}
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidReturn_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public partial bool TestFunction();
                                
                                public partial bool TestFunction() { return true; }
                            }
                            """;
        await AnalyzerVerifier<MethodIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
