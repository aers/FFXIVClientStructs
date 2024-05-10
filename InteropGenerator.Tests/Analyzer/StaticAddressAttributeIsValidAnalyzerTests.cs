using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class StaticAddressAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task TargetMethodMustBePartial_Warn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                {|CSIG0101:[StaticAddress("??", 0)]
                                public static TestStruct* TestFunction() { return null; }|}
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodMustBePartial_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [StaticAddress("??", 0)]
                                public static partial TestStruct* TestFunction();
                                
                                public static partial TestStruct* TestFunction() => null;
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsParameters_Warn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                {|CSIG0104:[StaticAddress("??", 0)]
                                public static partial TestStruct* TestFunction(int aParam);|}
                                
                                {|CSIG0104:public static partial TestStruct* TestFunction(int aParam) => null;|}
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsParameters_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [StaticAddress("??", 0)]
                                public static partial TestStruct* TestFunction();
                                
                                public static partial TestStruct* TestFunction() => null;
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidReturn_Warn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                {|CSIG0103:[StaticAddress("??", 0)]
                                public static partial string* TestFunction();|}
                                
                                {|CSIG0103:public static partial string* TestFunction() { return null; }|}
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsInvalidReturn_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [StaticAddress("??", 0)]
                                public static partial void* TestFunction();
                                
                                public static partial void* TestFunction() { return null; }
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodMustBeStatic_Warn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                {|CSIG0105:[StaticAddress("??", 0)]
                                public partial TestStruct* TestFunction();|}
                                
                                {|CSIG0105:public partial TestStruct* TestFunction() => null;|}
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodMustBeStatic_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [StaticAddress("??", 0)]
                                public static partial TestStruct* TestFunction();
                                
                                public static partial TestStruct* TestFunction() => null;
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsNonPointerReturn_Warn() {
        const string code = """
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                {|CSIG0106:[StaticAddress("??", 0)]
                                public static partial TestStruct TestFunction();|}
                                
                                {|CSIG0106:public static partial TestStruct TestFunction() { return new TestStruct(); }|}
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task TargetMethodContainsNonPointerReturn_NoWarn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [StaticAddress("??", 0)]
                                public static partial void* TestFunction();
                                
                                public static partial void* TestFunction() { return null; }
                            }
                            """;
        await AnalyzerVerifier<StaticAddressAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
