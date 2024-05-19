﻿using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class FixedSizeArrayAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task FixedSizeArrayAttributeIsValid_NoWarn() {
        const string code = """
                            [InlineArray(10)]
                            public struct FixedSizeArray10<T> where T : unmanaged 
                            {
                                private T _element0;
                            }
                            
                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] private FixedSizeArray10<int> _tenIntArray;
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task FixedSizeArrayAttributeNotPrivate_Warn() {
        const string code = """
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
                            [InlineArray(10)]
                            public struct SomeType10<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] private SomeType10<int> {|CSIG0302:_tenIntArray|};
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
    
    [Fact]
    public async Task FixedSizeArrayAttributeFieldTypeMustEndWithSize_Warn() {
        const string code = """
                            [InlineArray(10)]
                            public struct FixedSizeArrayTen<T> where T : unmanaged
                            {
                                private T _element0;
                            }

                            [StructLayout(LayoutKind.Explicit, Size=40)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [FieldOffset(0)] [FixedSizeArray] private FixedSizeArrayTen<int> {|CSIG0302:_tenIntArray|};
                            }
                            """;
        await AnalyzerVerifier<FixedSizeArrayAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}