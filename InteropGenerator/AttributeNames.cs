namespace InteropGenerator;

public static class AttributeNames {
    private const string Namespace = "InteropGenerator.Runtime.Attributes";

    public const string GenerateInteropAttribute = Namespace + ".GenerateInteropAttribute";
    public const string MemberFunctionAttribute = Namespace + ".MemberFunctionAttribute";
    public const string VirtualFunctionAttribute = Namespace + ".VirtualFunctionAttribute";
    public const string StaticAddressAttribute = Namespace + ".StaticAddressAttribute";
    public const string VirtualTableAttribute = Namespace + ".VirtualTableAttribute";
    public const string GenerateStringOverloads = Namespace + ".GenerateStringOverloadsAttribute";
    public const string StringIgnore = Namespace + ".StringIgnoreAttribute";
    public const string FixedSizeArrayAttribute = Namespace + ".FixedSizeArrayAttribute";
    public const string InheritsAttribute = Namespace + ".InheritsAttribute`1";
}
