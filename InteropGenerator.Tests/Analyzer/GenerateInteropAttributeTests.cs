using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class GenerateInteropAttributeTests {
    [Fact]
    public async Task TargetStructIsNotPartial_Warn() {
        const string code = """
                            [GenerateInterop]
                            public struct {|CSIG0001:TestStruct|}
                            {
                            }
                            """;
        await AnalyzerVerifier<StructIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructIsNotPartial_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                            }
                            """;
        await AnalyzerVerifier<StructIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetStructNestedInNonPartialStruct_Warn() {
        const string code = """
                            public struct {|CSIG0002:TestStruct|}
                            {
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<StructIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructNestedInNonPartialStruct_NoWarn() {
        const string code = """
                            public partial struct TestStruct
                            {
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<StructIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetStructCannotBeContainedInClass_Warn() {
        const string code = """
                            public class {|CSIG0003:TestStruct|}
                            {
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<StructIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetStructCannotBeContainedInClass_NoWarn() {
        const string code = """
                            public class TestStruct
                            {
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<StructIsValidForGenerationAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
