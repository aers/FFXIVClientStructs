using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class GenerateInteropAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task TargetStructIsNotPartial_NoWarn() {
        const string code = """
                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructIsNotPartial_Warn() {
        const string code = """
                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public struct {|CSIG0001:TestStruct|}
                            {
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructValidNesting_NoWarn() {
        const string code = """
                            public partial struct TestStruct
                            {
                                [StructLayout(LayoutKind.Explicit, Size=4)]
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetStructNestedInNonPartialStruct_Warn() {
        const string code = """
                            public struct {|CSIG0002:TestStruct|}
                            {
                                [StructLayout(LayoutKind.Explicit, Size=4)]
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
 

    [Fact]
    public async Task TargetStructNestedInClass_Warn() {
        const string code = """
                            public class {|CSIG0003:TestStruct|}
                            {
                                [StructLayout(LayoutKind.Explicit, Size=4)]
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructMustHaveStructLayoutAttribute_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct {|CSIG0004:TestStruct|}
                            {
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructMustHaveExplicitLayout_Warn() {
        const string code = """
                            [{|CSIG0005:StructLayout(LayoutKind.Sequential, Size=4)|}]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructMustHaveExplicitSize_Warn() {
        const string code = """
                            [{|CSIG0006:StructLayout(LayoutKind.Explicit)|}]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
