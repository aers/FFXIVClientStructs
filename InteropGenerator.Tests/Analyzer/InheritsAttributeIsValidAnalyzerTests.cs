using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class InheritsAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task InheritsAttributeIsTargetingValidType_NoWarn() {
        const string code = """
                            using System.Runtime.InteropServices;

                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop(isInherited: true)]
                            public partial struct BaseStruct
                            {
                            }

                            [StructLayout(LayoutKind.Explicit, Size=8)]
                            [GenerateInterop]
                            [Inherits<BaseStruct>]
                            public partial struct ChildStruct
                            {
                            }
                            """;
        await AnalyzerVerifier<InheritsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task InheritsAttributeIsTargetingUnmarkedType_Warn() {
        const string code = """
                            using System.Runtime.InteropServices;

                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            public partial struct {|CSIG0007:BaseStruct|}
                            {
                            }

                            [StructLayout(LayoutKind.Explicit, Size=8)]
                            [GenerateInterop]
                            [Inherits<BaseStruct>]
                            public partial struct ChildStruct
                            {
                            }
                            """;
        await AnalyzerVerifier<InheritsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task InheritsAttributeIsTargetingMarkedTypeNoInheritsTrue_Warn() {
        const string code = """
                            using System.Runtime.InteropServices;

                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public partial struct {|CSIG0007:BaseStruct|}
                            {
                            }

                            [StructLayout(LayoutKind.Explicit, Size=8)]
                            [GenerateInterop]
                            [Inherits<BaseStruct>]
                            public partial struct ChildStruct
                            {
                            }
                            """;
        await AnalyzerVerifier<InheritsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
