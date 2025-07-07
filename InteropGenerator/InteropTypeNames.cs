namespace InteropGenerator;

public static class InteropTypeNames {
    private const string AttributeNamespace = "InteropGenerator.Runtime.Attributes";

    public const string GenerateInteropAttribute = AttributeNamespace + ".GenerateInteropAttribute";
    public const string MemberFunctionAttribute = AttributeNamespace + ".MemberFunctionAttribute";
    public const string VirtualFunctionAttribute = AttributeNamespace + ".VirtualFunctionAttribute";
    public const string StaticAddressAttribute = AttributeNamespace + ".StaticAddressAttribute";
    public const string VirtualTableAttribute = AttributeNamespace + ".VirtualTableAttribute";
    public const string GenerateStringOverloadsAttribute = AttributeNamespace + ".GenerateStringOverloadsAttribute";
    public const string StringIgnoreAttribute = AttributeNamespace + ".StringIgnoreAttribute";
    public const string FixedSizeArrayAttribute = AttributeNamespace + ".FixedSizeArrayAttribute";
    public const string InheritsAttribute = AttributeNamespace + ".InheritsAttribute`1";

    public const string CStringPointer = "InteropGenerator.Runtime.CStringPointer";

    public static HashSet<string> UninheritableAttributes = [MemberFunctionAttribute, VirtualFunctionAttribute, StaticAddressAttribute, GenerateStringOverloadsAttribute, StringIgnoreAttribute, FixedSizeArrayAttribute, "System.Runtime.InteropServices.FieldOffsetAttribute"];
}
