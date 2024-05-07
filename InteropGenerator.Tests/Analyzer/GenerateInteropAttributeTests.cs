using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class GenerateInteropAttributeTests {
    [Fact]
    public async Task TargetStructIsNotPartial() {
        const string code = """
                            [GenerateInterop]
                            public struct {|CSIG0001:TestStruct|}
                            {
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeHasValidTargetAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetStructNestedInNonPartialStruct() {
        const string code = """
                            public struct {|CSIG0002:TestStruct|}
                            {
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeHasValidTargetAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetStructCannotBeContainedInClass() {
        const string code = """
                            public class {|CSIG0003:TestStruct|}
                            {
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<GenerateInteropAttributeHasValidTargetAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
