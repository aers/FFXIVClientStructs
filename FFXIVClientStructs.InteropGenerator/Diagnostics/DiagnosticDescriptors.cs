using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropGenerator.Diagnostics;

class DiagnosticDescriptors {

    public static readonly DiagnosticDescriptor GenerationRequiresPartialStruct = new(
        id: "CSIG0001",
        title: "Struct generation target is not partial",
        messageFormat: "The struct {0} must be marked partial in order to support interop generation",
        category: "InteropGenerator.General",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "A struct was marked with the GenerateInterop attribute but is not partial."
    );
}
