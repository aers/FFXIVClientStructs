using Microsoft.CodeAnalysis;

namespace InteropGenerator.Diagnostics;

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
    
    public static readonly DiagnosticDescriptor GenerationRequiresPartialMethod = new(
        "CSIG0101",
        "Method generation target is not partial",
        "The method {0} must be marked partial in order to support interop generation",
        "InteropGenerator.Methods",
        DiagnosticSeverity.Error,
        true,
        "A method was marked with a generation attribute but is not partial."
    );

    public static readonly DiagnosticDescriptor MethodParameterMustBeUnmanaged = new(
        "CSIG0102",
        "Method generation target has parameter types that are not unmanaged",
        "The parameter {0} of method {1} is type {2}, which is not an unmanaged type",
        "InteropGenerator.Methods",
        DiagnosticSeverity.Error,
        true,
        "A method marked for generation contains a parameter that is of an invalid type."
    );
    
    public static readonly DiagnosticDescriptor MethodReturnMustBeUnmanaged = new(
        "CSIG0103",
        "Method generation target has a return value that is not unmanaged",
        "The return value of method {0} is type {1}, which is not an unmanaged type",
        "InteropGenerator.Methods",
        DiagnosticSeverity.Error,
        true,
        "A method marked for generation contains a return value that is of an invalid type."
    );
}
