using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class GenerateStringOverloadsAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task GenerateStringOverloadsAttributeIsValid_NoWarn() {
        const string code = """
                            using System.Runtime.InteropServices;
                            
                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [GenerateStringOverloads]
                                public void TestFunction(byte* stringArg) { return; }
                            }
                            """;
        await AnalyzerVerifier<GenerateStringOverloadsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task GenerateStringOverloadsAttributeWithIgnoreIsValid_NoWarn() {
        const string code = """
                            using System.Runtime.InteropServices;
                            
                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [GenerateStringOverloads]
                                public void TestFunction(byte* stringArg, [StringIgnore] byte* notStringArg) { return; }
                            }
                            """;
        await AnalyzerVerifier<GenerateStringOverloadsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task GenerateStringOverloadsAttributeNoArgument_Warn() {
        const string code = """
                            using System.Runtime.InteropServices;
                            
                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [GenerateStringOverloads]
                                public void {|CSIG0108:TestFunction|}(int arg) { return; }
                            }
                            """;
        await AnalyzerVerifier<GenerateStringOverloadsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task GenerateStringOverloadsAttributeNoArgumentBecauseIgnore_Warn() {
        const string code = """
                            using System.Runtime.InteropServices;
                            
                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [GenerateStringOverloads]
                                public void {|CSIG0108:TestFunction|}([StringIgnore] byte* ignoredStringArg) { return; }
                            }
                            """;
        await AnalyzerVerifier<GenerateStringOverloadsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task GenerateStringOverloadsAttributeStringIgnoreOnInvalidParameter_Warn() {
        const string code = """
                            using System.Runtime.InteropServices;
                            
                            [StructLayout(LayoutKind.Explicit, Size=4)]
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [GenerateStringOverloads]
                                public void TestFunction(byte* stringArg, [StringIgnore] int {|CSIG0109:anArg|}) { return; }
                            }
                            """;
        await AnalyzerVerifier<GenerateStringOverloadsAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
