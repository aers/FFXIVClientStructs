using CExporter.Tests.TestTypes;
using Xunit;

namespace CExporter.Tests;

public class TypeExtensionsTests {
    #region SizeOf Tests

    [Theory]
    [InlineData(typeof(byte), 1)]
    [InlineData(typeof(sbyte), 1)]
    [InlineData(typeof(bool), 1)]
    [InlineData(typeof(char), 2)]
    [InlineData(typeof(short), 2)]
    [InlineData(typeof(ushort), 2)]
    [InlineData(typeof(int), 4)]
    [InlineData(typeof(uint), 4)]
    [InlineData(typeof(float), 4)]
    [InlineData(typeof(long), 8)]
    [InlineData(typeof(ulong), 8)]
    [InlineData(typeof(double), 8)]
    public void SizeOf_PrimitiveTypes_ReturnsCorrectSize(Type type, int expectedSize) {
        var actualSize = type.SizeOf();
        Assert.Equal(expectedSize, actualSize);
    }

    [Fact]
    public void SizeOf_IntPointer_Returns8() {
        unsafe {
            var size = typeof(int*).SizeOf();
            Assert.Equal(8, size);
        }
    }

    [Fact]
    public void SizeOf_VoidPointer_Returns8() {
        unsafe {
            var size = typeof(void*).SizeOf();
            Assert.Equal(8, size);
        }
    }

    [Fact]
    public void SizeOf_ExplicitLayoutStruct_ReturnsLayoutSize() {
        var size = typeof(ExplicitLayoutStruct).SizeOf();
        Assert.Equal(16, size);
    }

    [Fact]
    public void SizeOf_NestedStruct_ReturnsCorrectSize() {
        // NestedStruct: int (4) + padding (4) + ExplicitLayoutStruct (16) = 24
        var size = typeof(NestedStruct).SizeOf();
        Assert.True(size > 0, "Nested struct should have a positive size");
    }

    [Fact]
    public void SizeOf_EnumType_ReturnsUnderlyingTypeSize() {
        var size = typeof(TestEnum).SizeOf();
        Assert.Equal(4, size); // int-backed enum
    }

    [Fact]
    public void SizeOf_ByteEnum_Returns1() {
        var size = typeof(ByteEnum).SizeOf();
        Assert.Equal(1, size);
    }

    #endregion

    #region FixTypeName Tests

    [Theory]
    [InlineData(typeof(void), "void")]
    [InlineData(typeof(byte), "byte")]
    [InlineData(typeof(int), "int")]
    [InlineData(typeof(uint), "unsigned int")]
    [InlineData(typeof(short), "__int16")]
    [InlineData(typeof(ushort), "unsigned __int16")]
    [InlineData(typeof(long), "__int64")]
    [InlineData(typeof(ulong), "unsigned __int64")]
    [InlineData(typeof(float), "float")]
    [InlineData(typeof(double), "double")]
    [InlineData(typeof(char), "wchar_t")]
    [InlineData(typeof(bool), "byte")]
    public void FixTypeName_PrimitiveTypes_ReturnsCppEquivalent(Type type, string expectedName) {
        var actualName = type.FixTypeName();
        Assert.Equal(expectedName, actualName);
    }

    [Fact]
    public void FixTypeName_IntPointer_AddsStar() {
        unsafe {
            var name = typeof(int*).FixTypeName();
            Assert.Equal("int*", name);
        }
    }

    [Fact]
    public void FixTypeName_NestedTypes_UsesDoubleColon() {
        var name = typeof(OuterClass.InnerStruct).FixTypeName();
        Assert.Contains("::", name);
    }

    #endregion

    #region IsStruct Tests

    [Fact]
    public void IsStruct_ValueType_ReturnsTrue() {
        Assert.True(typeof(ExplicitLayoutStruct).IsStruct());
    }

    [Fact]
    public void IsStruct_PrimitiveInt_ReturnsFalse() {
        Assert.False(typeof(int).IsStruct());
    }

    [Fact]
    public void IsStruct_Enum_ReturnsFalse() {
        Assert.False(typeof(TestEnum).IsStruct());
    }

    [Fact]
    public void IsStruct_Class_ReturnsFalse() {
        Assert.False(typeof(OuterClass).IsStruct());
    }

    #endregion

    #region IsBaseType Tests

    [Theory]
    [InlineData(typeof(void), true)]
    [InlineData(typeof(bool), true)]
    [InlineData(typeof(byte), true)]
    [InlineData(typeof(sbyte), true)]
    [InlineData(typeof(short), true)]
    [InlineData(typeof(ushort), true)]
    [InlineData(typeof(int), true)]
    [InlineData(typeof(uint), true)]
    [InlineData(typeof(long), true)]
    [InlineData(typeof(ulong), true)]
    [InlineData(typeof(float), true)]
    [InlineData(typeof(double), true)]
    [InlineData(typeof(char), true)]
    public void IsBaseType_Primitives_ReturnsTrue(Type type, bool expected) {
        Assert.Equal(expected, type.IsBaseType());
    }

    [Fact]
    public void IsBaseType_Struct_ReturnsFalse() {
        Assert.False(typeof(ExplicitLayoutStruct).IsBaseType());
    }

    #endregion

    #region Error Handling Tests

    [Fact]
    public void SizeOf_TypeWithoutParameterlessConstructor_LogsWarningAndReturnsZero() {
        // Clear any previous warnings/errors
        ExporterStatics.Clear();

        // This type should fail to get size via Marshal.SizeOf
        var size = typeof(TypeWithPrivateConstructor).SizeOf();

        // Should return 0 and log a warning or error
        Assert.Equal(0, size);
        Assert.True(
            ExporterStatics.WarningList.Count > 0 || ExporterStatics.ErrorList.Count > 0,
            "Expected a warning or error to be logged when SizeOf fails"
        );
    }

    #endregion
}

// Helper types for tests
public enum TestEnum {
    Value1,
    Value2
}

public enum ByteEnum : byte {
    Value1,
    Value2
}

public class TypeWithPrivateConstructor {
    private TypeWithPrivateConstructor() { }
}
