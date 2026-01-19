using System.Runtime.InteropServices;

namespace CExporter.Tests.TestTypes;

/// <summary>
/// Test structures with known layouts for verifying size and offset calculations.
/// </summary>

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct ExplicitLayoutStruct {
    [FieldOffset(0)]
    public int Field1;

    [FieldOffset(4)]
    public int Field2;

    [FieldOffset(8)]
    public long Field3;
}

[StructLayout(LayoutKind.Sequential)]
public struct SequentialStruct {
    public byte ByteField;
    public int IntField;
    public short ShortField;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PackedStruct {
    public byte ByteField;
    public int IntField;
    public short ShortField;
}

[StructLayout(LayoutKind.Sequential)]
public struct NestedStruct {
    public int OuterField;
    public ExplicitLayoutStruct InnerStruct;
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct OverlappingFieldsStruct {
    [FieldOffset(0)]
    public int IntField;

    [FieldOffset(0)]
    public float FloatField; // Overlaps with IntField (union-like)
}

[StructLayout(LayoutKind.Sequential)]
public struct PointerStruct {
    public unsafe int* IntPointer;
    public unsafe void* VoidPointer;
}

[StructLayout(LayoutKind.Sequential)]
public struct MixedTypesStruct {
    public byte B1;
    public byte B2;
    public short S1;
    public int I1;
    public long L1;
}

public struct DefaultLayoutStruct {
    public int Field1;
    public int Field2;
}

// Nested type for testing type name conversion
public class OuterClass {
    [StructLayout(LayoutKind.Sequential)]
    public struct InnerStruct {
        public int Value;
    }
}
