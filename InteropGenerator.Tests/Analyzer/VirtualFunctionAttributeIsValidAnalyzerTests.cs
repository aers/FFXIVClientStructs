using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class VirtualFunctionAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task TargetMethodIsValid_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [VirtualFunction(2)]
                                public partial int TestFunction();
                                
                                public partial int TestFunction() => 0;
                            }
                            """;
        await AnalyzerVerifier<VirtualFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetMethodMustBePartial_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                {|CSIG0101:[VirtualFunction(2)]
                                public int TestFunction() { return 0; }|}
                            }
                            """;
        await AnalyzerVerifier<VirtualFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetMethodContainsInvalidParameters_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [VirtualFunction(3)]
                                public partial void TestFunction({|CSIG0102:List<string> invalidParam|});
                                
                                public partial void TestFunction({|CSIG0102:List<string> invalidParam|}) { }
                            }
                            """;
        await AnalyzerVerifier<VirtualFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetMethodContainsInvalidReturn_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                {|CSIG0103:[VirtualFunction(1)]
                                public partial string TestFunction();|}
                                
                                {|CSIG0103:public partial string TestFunction() { return ""; }|}
                            }
                            """;
        await AnalyzerVerifier<VirtualFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetMethodCannotBeStatic_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                {|CSIG0107:[VirtualFunction(3)]
                                public static partial bool TestFunction();|}
                                
                                {|CSIG0107:public static partial bool TestFunction() { return true; }|}
                            }
                            """;
        await AnalyzerVerifier<VirtualFunctionAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
