using Microsoft.CodeAnalysis;

namespace InteropGenerator.Diagnostics;

internal static class DiagnosticDescriptors {
    public static readonly DiagnosticDescriptor GenerationRequiresPartialStruct = new(
        "CSIG0001",
        "Struct generation target is not partial",
        "The struct {0} must be marked partial in order to support interop generation",
        "InteropGenerator.Struct",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but is not partial."
    );

    public static readonly DiagnosticDescriptor NestedStructMustBeContainedInPartialStruct = new(
        "CSIG0002",
        "Struct generation target is contained in a struct that is not partial",
        "The containing struct {0} must be marked partial in order to support interop generation of {1}",
        "InteropGenerator.Struct",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but is contained in a struct that is not marked partial."
    );

    public static readonly DiagnosticDescriptor NestedStructCannotBeContainedInClass = new(
        "CSIG0003",
        "Struct generation target is contained in a class",
        "The struct {0} cannot be contained in class {1}",
        "InteropGenerator.Struct",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but is contained in a class."
    );

    public static readonly DiagnosticDescriptor GenerationTargetMustUseStructLayoutAttribute = new(
        "CSIG0004",
        "Struct generation target must use the StructLayout attribute",
        "The struct {0} does not have the StructLayout attribute",
        "InteropGenerator.Struct",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but is not marked with the StructLayout attribute.");

    public static readonly DiagnosticDescriptor GenerationTargetMustUseLayoutKindExplicit = new(
        "CSIG0005",
        "Struct generation target must use LayoutKind.Explicit",
        "The struct {0} has the StructLayout attribute but does not use LayoutKind.Explicit",
        "InteropGenerator.Struct",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but does not use LayoutKind.Explicit.");

    public static readonly DiagnosticDescriptor GenerationTargetMustHaveExplicitSize = new(
        "CSIG0006",
        "Struct generation target must provide an explicit size",
        "The struct {0} has the StructLayout attribute but does not provide an explicit size",
        "InteropGenerator.Struct",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but does not provide an explicit size.");

    public static readonly DiagnosticDescriptor GenerationRequiresPartialMethod = new(
        "CSIG0101",
        "Method generation target is not partial",
        "The method {0} must be marked partial in order to support interop generation",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method was marked with a generation attribute but is not partial."
    );

    public static readonly DiagnosticDescriptor MethodParameterMustBeUnmanaged = new(
        "CSIG0102",
        "Method generation target has parameter types that are not unmanaged",
        "The parameter {0} of method {1} is type {2}, which is not an unmanaged type",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for generation contains a parameter that is of an invalid type."
    );

    public static readonly DiagnosticDescriptor MethodReturnMustBeUnmanaged = new(
        "CSIG0103",
        "Method generation target has a return value that is not unmanaged",
        "The return value of method {0} is type {1}, which is not an unmanaged type",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for generation contains a return value that is of an invalid type."
    );

    public static readonly DiagnosticDescriptor StaticAddressMethodMustNotHaveParameters = new(
        "CSIG0104",
        "Static address method generation target is not allowed to have parameters",
        "Method {0} has parameters, which is not allowed for a static address method stub",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for static address generation is not allowed to have parameters."
    );

    public static readonly DiagnosticDescriptor StaticAddressMethodMustBeStatic = new(
        "CSIG0105",
        "Static address method generation target must be static",
        "Method {0} must be static",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for static address generation must be static."
    );

    public static readonly DiagnosticDescriptor StaticAddressMethodReturnMustBePointer = new(
        "CSIG0106",
        "Static address method generation target has a return value that is not a pointer",
        "The return value of method {0} is type {1}, which is not a pointer type",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for static address generation contains a return value that is of an invalid type."
    );

    public static readonly DiagnosticDescriptor VirtualFunctionMethodMustNotBeStatic = new(
        "CSIG0107",
        "Virtual function method generation target must be not static",
        "Method {0} must be not static",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for virtual function generation must not be static."
    );

    public static readonly DiagnosticDescriptor GenerateStringOverloadsMethodMustHaveValidParameter = new(
        "CSIG0108",
        "GenerateStringOverloads method generation target must have a valid byte* parameter to overload",
        "Method {0} must contain a valid string overload parameter (byte*)",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for string overload generation contains no valid target parameters."
    );

    public static readonly DiagnosticDescriptor StringIgnoreMustTargetValidParameter = new(
        "CSIG0109",
        "The StringIgnore attribute is used on an invalid parameter",
        "StringIgnore is used on parameter {0} of type {1}, which is not a valid byte* parameter",
        "InteropGenerator.Method",
        DiagnosticSeverity.Error,
        true,
        "A method marked for string overload generation has a StringIgnore attribute on an invalid target parameter."
    );

    public static readonly DiagnosticDescriptor SignatureContainsInvalidCharacters = new(
        "CSIG0201",
        "Signature contains invalid characters",
        "Signature {0} contains invalid characters (valid characters are A-F, 0-9, ?, and spaces)",
        "InteropGenerator.Signature",
        DiagnosticSeverity.Error,
        true,
        "A signature contains invalid characters (valid characters are A-F, 0-9, ?, and spaces)."
    );

    public static readonly DiagnosticDescriptor SignatureFormatInvalid = new(
        "CSIG0202",
        "Signature format is invalid",
        "Signature {0} format is invalid (valid format is 2-character bytes seperated by spaces with ? as the wildcard character with no leading or trailing spaces)",
        "InteropGenerator.Signature",
        DiagnosticSeverity.Error,
        true,
        "A signature format is invalid (valid format is 2-character bytes seperated by spaces with ? as the wildcard character with no leading or trailign spaces)."
    );

    public static readonly DiagnosticDescriptor FixedSizeArrayFieldMustBeInternal = new(
        "CSIG0301",
        "Fixed size array backing field must be internal",
        "The field {0} marked as a fixed size array must be internal",
        "InteropGenerator.Field",
        DiagnosticSeverity.Error,
        true,
        "A field marked with the FixedSizeArray attribute is not marked internal.");

    public static readonly DiagnosticDescriptor FixedSizeArrayFieldMustHaveProperlyNamedType = new(
        "CSIG0302",
        "Fixed size array backing field must have a valid type",
        "The field {0} marked as a fixed size array has type name {1} but the type name must be FixedSizeArray#<T>, where # is the size of the array and T is the type",
        "InteropGenerator.Field",
        DiagnosticSeverity.Error,
        true,
        "A field marked with the FixedSizeArray attribute has an invalid type format. The type format should be FixedSizeArray#<T>, where # is the size of the array and T is the type.");
    
    public static readonly DiagnosticDescriptor FixedSizeArrayFieldMustHaveProperNaming = new(
        "CSIG0303",
        "Fixed size array backing field must have proper naming",
        "The field {0} marked as a fixed size array must have a name starting with a _",
        "InteropGenerator.Field",
        DiagnosticSeverity.Error,
        true,
        "A field marked with the FixedSizeArray attribute does not use the proper naming scheme.");
}
