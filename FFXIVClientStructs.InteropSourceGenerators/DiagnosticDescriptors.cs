using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropSourceGenerators;

internal static class DiagnosticDescriptors {
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
}
