using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class FixedSizeArrayAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task FixedSizeArrayAttributeIsValid_NoWarn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;
                            
                            [InlineArray(10)]
                            public struct FixedSizeArray10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] internal FixedSizeArray10<int> _tenIntArray;
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task FixedSizeArrayAttributeNotInternal_Warn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;
                            
                            [InlineArray(10)]
                            public struct FixedSizeArray10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] public FixedSizeArray10<int> {|CSIG0301:_tenIntArray|};
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task FixedSizeArrayAttributeFieldTypeMustStartWithFixedSizeArray_Warn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;
                            
                            [InlineArray(10)]
                            public struct SomeType10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] internal SomeType10<int> {|CSIG0302:_tenIntArray|};
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task FixedSizeArrayAttributeFieldTypeMustEndWithSize_Warn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;
                            
                            [InlineArray(10)]
                            public struct FixedSizeArrayTen<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] internal FixedSizeArrayTen<int> {|CSIG0302:_tenIntArray|};
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task FixedSizeArrayAttributeImproperFieldName_Warn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;
                            
                            [InlineArray(10)]
                            public struct FixedSizeArray10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] internal FixedSizeArray10<int> {|CSIG0303:TenIntArray|};
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task FixedSizeArrayAttributeByteStringIsValid_NoWarn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;

                            [InlineArray(10)]
                            public struct FixedSizeArray10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray(isString: true)] internal FixedSizeArray10<byte> _tenIntArray;
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task FixedSizeArrayAttributeCharStringIsValid_NoWarn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;

                            [InlineArray(10)]
                            public struct FixedSizeArray10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray(isString: true)] internal FixedSizeArray10<char> _tenIntArray;
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task FixedSizeArrayAttributeStringTypeIsInvalid_Warn() {
        const string code = """
                            using System.Runtime.CompilerServices;
                            using System.Runtime.InteropServices;

                            [InlineArray(10)]
                            public struct FixedSizeArray10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray(isString: true)] internal FixedSizeArray10<int> {|CSIG0304:_tenIntArray|};
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
