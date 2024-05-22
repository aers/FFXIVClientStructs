using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class SignatureIsValidAnalyzer : DiagnosticAnalyzer {

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [SignatureContainsInvalidCharacters, SignatureFormatInvalid];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbols
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.MemberFunctionAttribute) is not { } memberFunctionAttribute ||
                context.Compilation.GetTypeByMetadataName(AttributeNames.StaticAddressAttribute) is not { } staticAddressAttribute ||
                context.Compilation.GetTypeByMetadataName(AttributeNames.VirtualFunctionAttribute) is not { } virtualFunctionAttribute)
                return;

            context.RegisterSymbolAction(context => {
                    if (context.Symbol is not IMethodSymbol methodSymbol)
                        return;

                    // check for signature attributes
                    if (!methodSymbol.TryGetAttributeWithType(memberFunctionAttribute, out AttributeData? attributeData) &&
                        !methodSymbol.TryGetAttributeWithType(staticAddressAttribute, out attributeData))
                        return;

                    if (!attributeData.TryGetConstructorArgument(0, out string? signature))
                        return;

                    ValidateSignatureAndReportDiagnostics(signature, attributeData.GetLocation(), context);
                },
                SymbolKind.Method);

            context.RegisterSymbolAction(context => {
                    if (context.Symbol is not INamedTypeSymbol { TypeKind: TypeKind.Struct } structSymbol)
                        return;

                    // check for signature attribute
                    if (!structSymbol.TryGetAttributeWithType(virtualFunctionAttribute, out AttributeData? attributeData))
                        return;

                    if (!attributeData.TryGetConstructorArgument(0, out string? signature))
                        return;

                    ValidateSignatureAndReportDiagnostics(signature, attributeData.GetLocation(), context);
                },
                SymbolKind.NamedType);
        });
    }

    private static void ValidateSignatureAndReportDiagnostics(string signature, Location? attributeLocation, SymbolAnalysisContext context) {
        if (signature == string.Empty ||
            signature[0] == ' ' ||
            signature[^1] == ' ' ||
            signature.Split(' ').All(subString => subString.Length != 2)) {
            context.ReportDiagnostic(Diagnostic.Create(
                SignatureFormatInvalid,
                attributeLocation,
                signature));
        }

        if (ContainsInvalidCharacters(signature)) {
            context.ReportDiagnostic(Diagnostic.Create(
                SignatureContainsInvalidCharacters,
                attributeLocation,
                signature));
        }
    }

    private static bool ContainsInvalidCharacters(string signature) {
        foreach (char character in signature) {
            if (character != '?' &&
                character != ' ' &&
                character is (< 'A' or > 'F') and (< '0' or > '9'))
                return true;
        }

        return false;
    }
}
