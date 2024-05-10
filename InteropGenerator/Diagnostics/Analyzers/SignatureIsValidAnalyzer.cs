using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class SignatureIsValidAnalyzer : DiagnosticAnalyzer {
    
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [SignatureContainsInvalidCharacters, SignatureFormatInvalid];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbols
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.MemberFunctionAttribute) is not { } memberFunctionAttribute||
                context.Compilation.GetTypeByMetadataName(AttributeNames.StaticAddressAttribute) is not { } staticAddressAttribute)
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
                    
                    if (signature == string.Empty || 
                        signature[0] == ' ' ||
                        signature[^1] == ' ' ||
                        signature.Split(' ').All(subString => subString.Length != 2)) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            SignatureFormatInvalid,
                            attributeData.GetLocation(),
                            signature));
                    }
                        
                    if (ContainsInvalidCharacters(signature)) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            SignatureContainsInvalidCharacters,
                            attributeData.GetLocation(),
                            signature));
                    }
                },
                SymbolKind.Method);
        });
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
