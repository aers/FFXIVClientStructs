using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropGenerator.Diagnostics;

internal static class DiagnosticDescriptors {
    public static readonly DiagnosticDescriptor GenerationRequiresPartialStruct = new(
        "CSIG0001",
        "Struct generation target is not partial",
        "The struct {0} must be marked partial in order to support interop generation",
        "InteropGenerator.General",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but is not partial."
    );

    public static readonly DiagnosticDescriptor NestedStructMustBeContainedInPartialStruct = new(
        "CSIG0002",
        "Struct generation target is contained in a struct that is not partial",
        "The containing struct {0} must be marked partial in order to support interop generation of {1}",
        "InteropGenerator.General",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but is contained in a struct that is not marked partial."
    );

    public static readonly DiagnosticDescriptor NestedStructCannotBeContainedInClass = new(
        "CSIG0003",
        "Struct generation target is contained in a class",
        "The struct {0} cannot be contained in class {1}",
        "InteropGenerator.General",
        DiagnosticSeverity.Error,
        true,
        "A struct was marked with the GenerateInterop attribute but is contained in a class."
    );
}
