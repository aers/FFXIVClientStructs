using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class MemberFunctionAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task TargetMethodIsValid_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("??")]
                                public partial int TestFunction(void* param);
                                
                                public partial int TestFunction(void* param) => 0;
                            }
                            """;
        await AnalyzerVerifier<MemberFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

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
        await AnalyzerVerifier<MemberFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
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
        await AnalyzerVerifier<MemberFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
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
        await AnalyzerVerifier<MemberFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
