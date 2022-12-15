using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropGenerator;

internal static class DiagnosticDescriptors
{
    internal static DiagnosticDescriptor MultipleAttributes { get; } = new(
        "CSFG0001",
        "Multiple attributes",
        "Method {0} has multiple function generation attributes",
        "Function Generator",
        DiagnosticSeverity.Error,
        true
    );

    internal static DiagnosticDescriptor InvalidSignature { get; } = new(
        "CSFG0002",
        "Invalid signature",
        "Signature {0} is invalid - use ?? and make sure each byte is 2 characters",
        "Function Generator",
        DiagnosticSeverity.Error,
        true
    );

    internal static DiagnosticDescriptor StructMustBePartial { get; } = new(
        "CSFG0003",
        "Struct must be partial",
        "Struct {0} must be partial",
        "Function Generator",
        DiagnosticSeverity.Error,
        true
    );

    internal static DiagnosticDescriptor MethodMustBePartial { get; } = new(
        "CSFG0004",
        "Method must be partial",
        "Method {0} must be partial",
        "Function Generator",
        DiagnosticSeverity.Error,
        true
    );

    internal static DiagnosticDescriptor ReturnsUnmanaged { get; } = new(
        "CSFG0005",
        "Method must return unmanaged",
        "Method {0} has invalid return type {1} - must be unmanaged type",
        "Function Generator",
        DiagnosticSeverity.Error,
        true);

    internal static DiagnosticDescriptor ParamUnmanagedOrString { get; } = new(
        "CSFG0006",
        "Method parameters unmanaged or string",
        "Parameter {0} has invalid type {1} - must be either unmanaged type or the string type",
        "Function Generator",
        DiagnosticSeverity.Error,
        true);
}