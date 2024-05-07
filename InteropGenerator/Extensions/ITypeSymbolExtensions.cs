// sourced from https://github.com/Sergio0694/ComputeSharp/blob/main/src/ComputeSharp.SourceGeneration/Extensions/ITypeSymbolExtensions.cs

using InteropGenerator.Helpers;
using Microsoft.CodeAnalysis;

namespace InteropGenerator.Extensions;

/// <summary>
///     Extension methods for <see cref="ITypeSymbol" /> types.
/// </summary>
internal static class ITypeSymbolExtensions {
    /// <summary>
    ///     Checks whether or not a given type symbol has a specified fully qualified metadata name.
    /// </summary>
    /// <param name="symbol">The input <see cref="ITypeSymbol" /> instance to check.</param>
    /// <param name="name">The full name to check.</param>
    /// <returns>Whether <paramref name="symbol" /> has a full name equals to <paramref name="name" />.</returns>
    public static bool HasFullyQualifiedMetadataName(this ITypeSymbol symbol, string name) {
        using ImmutableArrayBuilder<char> builder = new();

        symbol.AppendFullyQualifiedMetadataName(in builder);

        return builder.WrittenSpan.SequenceEqual(name.AsSpan());
    }

    /// <summary>
    ///     Gets the fully qualified metadata name for a given <see cref="ITypeSymbol" /> instance.
    /// </summary>
    /// <param name="symbol">The input <see cref="ITypeSymbol" /> instance.</param>
    /// <returns>The fully qualified metadata name for <paramref name="symbol" />.</returns>
    public static string GetFullyQualifiedMetadataName(this ITypeSymbol symbol) {
        using ImmutableArrayBuilder<char> builder = new();

        symbol.AppendFullyQualifiedMetadataName(in builder);

        return builder.ToString();
    }

    /// <summary>
    ///     Appends the fully qualified metadata name for a given symbol to a target builder.
    /// </summary>
    /// <param name="symbol">The input <see cref="ITypeSymbol" /> instance.</param>
    /// <param name="builder">The target <see cref="ImmutableArrayBuilder{T}" /> instance.</param>
    public static void AppendFullyQualifiedMetadataName(this ITypeSymbol symbol, ref readonly ImmutableArrayBuilder<char> builder) {
        static void BuildFrom(ISymbol? symbol, ref readonly ImmutableArrayBuilder<char> builder) {
            switch (symbol) {
                // Namespaces that are nested also append a leading '.'
                case INamespaceSymbol { ContainingNamespace.IsGlobalNamespace: false }:
                    BuildFrom(symbol.ContainingNamespace, in builder);
                    builder.Add('.');
                    builder.AddRange(symbol.MetadataName.AsSpan());
                    break;

                // Other namespaces (ie. the one right before global) skip the leading '.'
                case INamespaceSymbol { IsGlobalNamespace: false }:
                    builder.AddRange(symbol.MetadataName.AsSpan());
                    break;

                // Types with no namespace just have their metadata name directly written
                case ITypeSymbol { ContainingSymbol: INamespaceSymbol { IsGlobalNamespace: true } }:
                    builder.AddRange(symbol.MetadataName.AsSpan());
                    break;

                // Types with a containing non-global namespace also append a leading '.'
                case ITypeSymbol { ContainingSymbol: INamespaceSymbol namespaceSymbol }:
                    BuildFrom(namespaceSymbol, in builder);
                    builder.Add('.');
                    builder.AddRange(symbol.MetadataName.AsSpan());
                    break;

                // Nested types append a leading '+'
                case ITypeSymbol { ContainingSymbol: ITypeSymbol typeSymbol }:
                    BuildFrom(typeSymbol, in builder);
                    builder.Add('+');
                    builder.AddRange(symbol.MetadataName.AsSpan());
                    break;
            }
        }

        BuildFrom(symbol, in builder);
    }
}
