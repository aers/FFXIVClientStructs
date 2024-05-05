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
        await AnalyzerVerifier<ContainingStructsMustBePartialAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetStructNestedInNonPartialStruct() {
        const string code = """
                            using FFXIVClientStructs.InteropGenerator.Runtime.Attributes;

                            public struct {|CSIG0002:TestStruct|}
                            {
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<ContainingStructsMustBePartialAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task TargetStructCannotBeContainedInClass() {
        const string code = """
                            using FFXIVClientStructs.InteropGenerator.Runtime.Attributes;

                            public class {|CSIG0003:TestStruct|}
                            {
                                [GenerateInterop]
                                public partial struct InnerStruct
                                {
                                }
                            }
                            """;
        await AnalyzerVerifier<ContainingStructsMustBePartialAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
