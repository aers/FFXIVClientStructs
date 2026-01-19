using System.Reflection;
using System.Runtime.InteropServices;
using CExporter.Tests.TestTypes;
using Xunit;

namespace CExporter.Tests;

public class FieldInfoExtensionsTests {
    #region GetFieldOffset Tests (Explicit Layout)

    [Fact]
    public void GetFieldOffset_ExplicitLayout_Field1_Returns0() {
        var field = typeof(ExplicitLayoutStruct).GetField("Field1")!;
        var offset = field.GetFieldOffset();
        Assert.Equal(0, offset);
    }

    [Fact]
    public void GetFieldOffset_ExplicitLayout_Field2_Returns4() {
        var field = typeof(ExplicitLayoutStruct).GetField("Field2")!;
        var offset = field.GetFieldOffset();
        Assert.Equal(4, offset);
    }

    [Fact]
    public void GetFieldOffset_ExplicitLayout_Field3_Returns8() {
        var field = typeof(ExplicitLayoutStruct).GetField("Field3")!;
        var offset = field.GetFieldOffset();
        Assert.Equal(8, offset);
    }

    [Fact]
    public void GetFieldOffset_OverlappingFields_BothReturn0() {
        var intField = typeof(OverlappingFieldsStruct).GetField("IntField")!;
        var floatField = typeof(OverlappingFieldsStruct).GetField("FloatField")!;

        Assert.Equal(0, intField.GetFieldOffset());
        Assert.Equal(0, floatField.GetFieldOffset());
    }

    #endregion

    #region GetFieldOffsetSequential Tests

    [Fact]
    public void GetFieldOffsetSequential_PackedStruct_ByteField_Returns0() {
        var field = typeof(PackedStruct).GetField("ByteField")!;
        var offset = field.GetFieldOffsetSequential();
        Assert.Equal(0, offset);
    }

    [Fact]
    public void GetFieldOffsetSequential_PackedStruct_IntField_Returns1() {
        // With Pack=1, IntField should immediately follow ByteField
        var field = typeof(PackedStruct).GetField("IntField")!;
        var offset = field.GetFieldOffsetSequential();
        Assert.Equal(1, offset);
    }

    [Fact]
    public void GetFieldOffsetSequential_PackedStruct_ShortField_Returns5() {
        // With Pack=1: ByteField(0) + IntField(1-4) = 5
        var field = typeof(PackedStruct).GetField("ShortField")!;
        var offset = field.GetFieldOffsetSequential();
        Assert.Equal(5, offset);
    }

    [Fact]
    public void GetFieldOffsetSequential_MixedTypesStruct_CalculatesCorrectly() {
        // B1(0), B2(1), S1(2, aligned to 2), I1(4, aligned to 4), L1(8, aligned to 8)
        var b1 = typeof(MixedTypesStruct).GetField("B1")!;
        var b2 = typeof(MixedTypesStruct).GetField("B2")!;
        var s1 = typeof(MixedTypesStruct).GetField("S1")!;
        var i1 = typeof(MixedTypesStruct).GetField("I1")!;
        var l1 = typeof(MixedTypesStruct).GetField("L1")!;

        Assert.Equal(0, b1.GetFieldOffsetSequential());
        Assert.Equal(1, b2.GetFieldOffsetSequential());
        Assert.Equal(2, s1.GetFieldOffsetSequential());
        Assert.Equal(4, i1.GetFieldOffsetSequential());
        Assert.Equal(8, l1.GetFieldOffsetSequential());
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void GetFieldOffsetSequential_FirstField_AlwaysReturns0() {
        var fields = new[] {
            typeof(SequentialStruct).GetFields()[0],
            typeof(PackedStruct).GetFields()[0],
            typeof(MixedTypesStruct).GetFields()[0],
        };

        foreach (var field in fields) {
            var offset = field.GetFieldOffsetSequential();
            Assert.Equal(0, offset);
        }
    }

    #endregion
}
