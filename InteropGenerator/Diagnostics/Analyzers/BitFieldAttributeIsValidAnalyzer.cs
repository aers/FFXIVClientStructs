using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class BitFieldAttributeIsValidAnalyzer : DiagnosticAnalyzer {

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [
        BitFieldIndexIsNegative,
        BitFieldLengthIsNegativeOrZero,
        BitFieldExceedsUnderlyingFieldSize,
        BitFieldPropertyDefinitionMissingGetter,
        BitFieldBackingFieldTypeNotSupported,
        BitFieldBooleanLengthInvalid,
    ];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbol
            if (context.Compilation.GetTypeByMetadataName(InteropTypeNames.BitFieldAttribute) is not { } bitFieldAttribute)
                return;

            context.RegisterSymbolAction(context => {
                if (context.Symbol is not IFieldSymbol fieldSymbol)
                    return;

                if (fieldSymbol.ContainingSymbol is not INamedTypeSymbol structSymbol)
                    return;

                int fieldSize = fieldSymbol.Type.SpecialType switch {
                    SpecialType.System_Byte => 1,
                    SpecialType.System_UInt16 => 2,
                    SpecialType.System_UInt32 => 4,
                    SpecialType.System_UInt64 => 8,
                    _ => 0
                };

                int fieldBits = fieldSize * 8;

                foreach (var attributeData in fieldSymbol.GetAttributes()) {
                    if (attributeData.AttributeClass is not { } attributeSymbol)
                        continue;

                    if (!SymbolEqualityComparer.Default.Equals(attributeSymbol.OriginalDefinition, bitFieldAttribute))
                        continue;

                    if (fieldSize == 0) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            BitFieldBackingFieldTypeNotSupported,
                            fieldSymbol.Locations.FirstOrDefault(),
                            fieldSymbol.Name));
                        return;
                    }

                    if (attributeSymbol.TypeArguments.Length != 1)
                        continue;

                    var bitfieldType = attributeSymbol.TypeArguments[0];

                    if (!attributeData.TryGetConstructorArgument(0, out string? name) ||
                        !attributeData.TryGetConstructorArgument(1, out int index) ||
                        !attributeData.TryGetConstructorArgument(2, out int length))
                        continue;

                    var location = attributeData.ApplicationSyntaxReference?.GetSyntax(context.CancellationToken).GetLocation()
                                   ?? fieldSymbol.Locations.FirstOrDefault();

                    if (index < 0) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            BitFieldIndexIsNegative,
                            location,
                            name,
                            fieldSymbol.Name));
                    }

                    if (length <= 0) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            BitFieldLengthIsNegativeOrZero,
                            location,
                            name,
                            fieldSymbol.Name));
                    }

                    if (bitfieldType.SpecialType == SpecialType.System_Boolean && length != 1) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            BitFieldBooleanLengthInvalid,
                            location,
                            name,
                            fieldSymbol.Name));
                    }

                    if ((long)index + length > fieldBits) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            BitFieldExceedsUnderlyingFieldSize,
                            location,
                            name,
                            fieldSymbol.Name));
                    }

                    foreach (IPropertySymbol propertySymbol in structSymbol.GetMembers().OfType<IPropertySymbol>()) {
                        if (!propertySymbol.IsPartialDefinition || propertySymbol.Name != name)
                            continue;

                        if (propertySymbol.GetMethod == null) {
                            context.ReportDiagnostic(Diagnostic.Create(
                                BitFieldPropertyDefinitionMissingGetter,
                                propertySymbol.Locations.FirstOrDefault(),
                                name,
                                fieldSymbol.Name));
                        }

                        break;
                    }
                }
            },
                SymbolKind.Field);
        });
    }
}
