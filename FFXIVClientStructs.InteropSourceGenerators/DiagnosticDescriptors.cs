using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropSourceGenerators;

internal static class DiagnosticDescriptors
{
    public static DiagnosticDescriptor StructMustBePartial { get; } = new(
        "CSIG0001",
        "Struct must be partial",
        "Struct {0} must be partial to allow generation",
        "General",
        DiagnosticSeverity.Error,
        true
    );

    public static DiagnosticDescriptor NestedStructMustBeContainedInStructs { get; } = new(
        "CSIG0002",
        "Nested struct must be inside a struct",
        "Nested struct {0} must be nested inside a struct",
        "General",
        DiagnosticSeverity.Error,
        true
    );

    public static DiagnosticDescriptor AttributeArgumentInvalid { get; } = new(
        "CSIG0003",
        "Attribute argument is invalid",
        "Attribute argument {0} for attribute type {1} is malformed or invalid",
        "General",
        DiagnosticSeverity.Error,
        true
    );

    public static DiagnosticDescriptor InvalidSignature { get; } = new(
        "CSIG0004",
        "Invalid signature",
        "Signature {0} is invalid. Signature must have 2 characters per byte, including wildcards.",
        "General",
        DiagnosticSeverity.Error,
        true
    );
    
    public static DiagnosticDescriptor AttributeGenericTypeArgumentInvalid { get; } = new(
        "CSIG0005",
        "Attribute generic type argument invalid",
        "Generic type argument for attribute type {0} is invalid",
        "General",
        DiagnosticSeverity.Error,
        true
    );
    
    public static DiagnosticDescriptor FixedSizedAttributeOnInvalidField { get; } = new(
        "CSIG0006",
        "Fixed sized attribute used on invalid field",
        "The fixed sized array attribute can only be used on fixed buffer fields of type byte",
        "General",
        DiagnosticSeverity.Error,
        true
    );

    public static DiagnosticDescriptor MethodMustBePartial { get; } = new(
        "CSIG0100",
        "Method must be partial",
        "Method {0} must be partial to allow generation",
        "Function Generator",
        DiagnosticSeverity.Error,
        true
    );

    public static DiagnosticDescriptor MethodUsesForbiddenType { get; } = new(
        "CSIG0101",
        "Method uses forbidden type",
        "Method {0} uses type {1} which is forbidden in function generators",
        "Function Generator",
        DiagnosticSeverity.Error,
        true
    );
}