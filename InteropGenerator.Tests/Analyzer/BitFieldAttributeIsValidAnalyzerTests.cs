using InteropGenerator.Diagnostics.Analyzers;
using InteropGenerator.Tests.Helpers;
using Xunit;

namespace InteropGenerator.Tests.Analyzer;

public class BitFieldAttributeIsValidAnalyzerTests {
    [Fact]
    public async Task BitFieldAttributeIsValid_NoWarn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=30)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [BitField<bool>("TestBool1", 0)]
                                [BitField<byte>("TestByte1", 1)]
                                [BitField<byte>("TestByte2", 2, 3)]
                                [BitField<short>("TestShort1", 5, 2)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal byte _testField1;
                            
                                [BitField<bool>("TestBool2", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal ushort _testField2;
                            
                                [BitField<bool>("TestBool3", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal uint _testField3;
                            
                                [BitField<bool>("TestBool4", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal ulong _testField4;
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task BitFieldAttributeStartBitNegative_Warn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=1)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [{|CSIG0401:BitField<short>("TestShort", -1, 1)|}]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal byte _testField1;
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task BitFieldAttributeLengthNegative_Warn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=1)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [{|CSIG0402:BitField<short>("TestShort", 0, -1)|}]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal byte _testField1;
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task BitFieldAttributeLengthZero_Warn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=1)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [{|CSIG0402:BitField<short>("TestShort", 0, 0)|}]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal byte _testField1;
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task BitFieldAttributeExceedsFieldSize_Warn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=1)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [{|CSIG0403:BitField<short>("TestShort", 0, 9)|}]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal byte _testField1;
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task BitFieldAttributeEnumDoesNotExceedFieldSize_NoWarn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=1)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [BitField<TestEnum>("TestEnum1", 2, 2)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal byte _testField1;
                            
                                [Flags]
                                public enum TestEnum {
                                    TestValue1 = 1 << 0,
                                    TestValue2 = 1 << 1,
                                }
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task BitFieldAttributeInvalidBackingFieldType_Warn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=1)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [BitField<bool>("TestBool1", 0)]
                                [BitField<byte>("TestByte1", 1)]
                                [BitField<byte>("TestByte2", 2, 3)]
                                [BitField<short>("TestShort1", 5, 2)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal sbyte {|CSIG0405:_testField1|};

                                [BitField<bool>("TestBool2", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal short {|CSIG0405:_testField2|};

                                [BitField<bool>("TestBool3", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal int {|CSIG0405:_testField3|};

                                [BitField<bool>("TestBool4", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal long {|CSIG0405:_testField4|};

                                [BitField<bool>("TestBool5", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal TestEnum {|CSIG0405:_testField5|};
                            
                                [BitField<TestEnum>("TestEnum1", 0, 2)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal TestEnum {|CSIG0405:_testField6|};

                                [BitField<bool>("TestBool6", 0)]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal DateTime {|CSIG0405:_testField7|};
                            
                                [Flags]
                                public enum TestEnum {
                                    TestValue1 = 1 << 0,
                                    TestValue2 = 1 << 1,
                                }
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }

    [Fact]
    public async Task BitFieldAttributeInvalidBooleanLength_Warn() {
        const string code = """
                            [global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size=1)]
                            [GenerateInterop]
                            public partial struct TestStruct
                            {
                                [{|CSIG0406:BitField<bool>("TestBool1", 0, 2)|}]
                                [global::System.Runtime.InteropServices.FieldOffsetAttribute(0)] internal byte _testField1;
                            }
                            """;
        await AnalyzerVerifier<BitFieldAttributeIsValidAnalyzer>.VerifyAnalyzerAsync(code);
    }
}
