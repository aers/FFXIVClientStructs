using FFXIVClientStructs.InteropGenerator.Diagnostics.Analyzers;
using FFXIVClientStructs.InteropGenerator.Tests.Helpers;
using Xunit;

namespace FFXIVClientStructs.InteropGenerator.Tests.Analyzer;

public class GenerateInteropAttribute {
    [Fact]
    public async Task TargetStructIsNotPartial() {
        const string code = """
                            using FFXIVClientStructs.InteropGenerator.Runtime.Attributes;

                            [GenerateInterop]
                            public struct {|CSIG0001:TestStruct|}
                            {
                            }
                            """;
        await AnalyzerVerifier<StructGenerationTargetIsNotPartialAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
