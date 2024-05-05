using FFXIVClientStructs.InteropGenerator.Extensions;
using FFXIVClientStructs.InteropGenerator.Helpers;
using FFXIVClientStructs.InteropGenerator.Models;
using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropGenerator.Generator;

public sealed partial class InteropGenerator {

    private static StructInfo ParseStructInfo(INamedTypeSymbol structSymbol, CancellationToken token) {
        using ImmutableArrayBuilder<string> hierarchy = new();

        for (var parent = structSymbol;
             parent is not null;
             parent = parent.ContainingType) {
            hierarchy.Add(parent.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat));
        }

        return new StructInfo(
            structSymbol.GetFullyQualifiedMetadataName(),
            structSymbol.ContainingNamespace.ToDisplayString(
                new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces)),
            hierarchy.ToImmutable());
    }
}
