using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class FixedSizeArrayAttributeIsValidAnalyzer : DiagnosticAnalyzer {

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [
        FixedSizeArrayFieldMustBeInternal,
        FixedSizeArrayFieldMustHaveProperlyNamedType,
        FixedSizeArrayFieldMustHaveProperNaming,
        FixedSizeArrayStringFieldMustBeByteOrChar,
        FixedSizeArrayBitArrayFieldMustBeByte,
        FixedSizeArrayBitArrayFieldBitCountMustMatchSize,
        FixedSizeArrayFieldCannotBeStringAndBitArray,
    ];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbol
            if (context.Compilation.GetTypeByMetadataName(InteropTypeNames.FixedSizeArrayAttribute) is not { } fixedSizeArrayAttribute)
                return;

            context.RegisterSymbolAction(context => {
                if (context.Symbol is not IFieldSymbol fieldSymbol)
                    return;

                if (!fieldSymbol.TryGetAttributeWithType(fixedSizeArrayAttribute, out AttributeData? fixedSizeArrayAttributeData))
                    return;

                if (fieldSymbol.Type is not INamedTypeSymbol { TypeArguments.IsEmpty: false } fieldType)
                    return;

                if (!fixedSizeArrayAttributeData.TryGetConstructorArgument(0, out bool isString) ||
                    !fixedSizeArrayAttributeData.TryGetConstructorArgument(1, out bool isBitArray) ||
                    !fixedSizeArrayAttributeData.TryGetConstructorArgument(2, out int bitCount))
                    return;

                int size = 0;

                if (!fieldSymbol.Type.Name.StartsWith("FixedSizeArray") ||
                    !int.TryParse(fieldSymbol.Type.Name[14..], out size)) {
                    context.ReportDiagnostic(Diagnostic.Create(
                        FixedSizeArrayFieldMustHaveProperlyNamedType,
                        fieldSymbol.Locations.FirstOrDefault(),
                        fieldSymbol.Name,
                        fieldSymbol.Type.ToDisplayString(new SymbolDisplayFormat(genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters))));
                }

                if (isString && !(fieldType.TypeArguments[0].SpecialType == SpecialType.System_Byte || fieldType.TypeArguments[0].SpecialType == SpecialType.System_Char)) {
                    context.ReportDiagnostic(Diagnostic.Create(
                        FixedSizeArrayStringFieldMustBeByteOrChar,
                        fieldSymbol.Locations.FirstOrDefault(),
                        fieldSymbol.Name));
                }

                if (isBitArray) {
                    if (isString) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            FixedSizeArrayFieldCannotBeStringAndBitArray,
                            fieldSymbol.Locations.FirstOrDefault(),
                            fieldSymbol.Name));
                    }
                    if (fieldType.TypeArguments[0].SpecialType != SpecialType.System_Byte) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            FixedSizeArrayBitArrayFieldMustBeByte,
                            fieldSymbol.Locations.FirstOrDefault(),
                            fieldSymbol.Name));
                    }
                    if ((bitCount + 7) / 8 != size) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            FixedSizeArrayBitArrayFieldBitCountMustMatchSize,
                            fieldSymbol.Locations.FirstOrDefault(),
                            fieldSymbol.Name));
                    }
                }

                if (fieldSymbol.DeclaredAccessibility != Accessibility.Internal) {
                    context.ReportDiagnostic(Diagnostic.Create(
                        FixedSizeArrayFieldMustBeInternal,
                        fieldSymbol.Locations.FirstOrDefault(),
                        fieldSymbol.Name));
                }

                if (!fieldSymbol.Name.StartsWith("_")) {
                    context.ReportDiagnostic(Diagnostic.Create(
                        FixedSizeArrayFieldMustHaveProperNaming,
                        fieldSymbol.Locations.FirstOrDefault(),
                        fieldSymbol.Name));
                }
            },
                SymbolKind.Field);
        });
    }
}
