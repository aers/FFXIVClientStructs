using System.Collections.Immutable;
using InteropGenerator.Extensions;
using InteropGenerator.Helpers;
using InteropGenerator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InteropGenerator.Generator;

public sealed partial class InteropGenerator {

    private static StructInfo ParseStructInfo(INamedTypeSymbol structSymbol, CancellationToken token) {
        // collection info on struct methods
        ParseMethods(structSymbol, token, out EquatableArray<MemberFunctionInfo> memberFunctions);
        token.ThrowIfCancellationRequested();
        
        // get containing types; our analyzer validates structs are contained in a proper hierachy so not needed here
        using ImmutableArrayBuilder<string> hierarchy = new();

        for (INamedTypeSymbol? parent = structSymbol;
             parent is not null;
             parent = parent.ContainingType) {
            hierarchy.Add(parent.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat));
        }
           
        // collect all info
        return new StructInfo(
            structSymbol.GetFullyQualifiedMetadataName(),
            structSymbol.ContainingNamespace.ToDisplayString(
                new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces)),
            hierarchy.ToImmutable(),
            memberFunctions);
    }

    private static void ParseMethods(INamedTypeSymbol structSymbol, CancellationToken token, out EquatableArray<MemberFunctionInfo> memberFunctions) {
        using ImmutableArrayBuilder<MemberFunctionInfo> memberFunctionsBuilder = new();

        foreach (IMethodSymbol methodSymbol in structSymbol.GetMembers().OfType<IMethodSymbol>()) {
            if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.MemberFunctionAttribute, out AttributeData? mfAttribute)) {
                if (!mfAttribute.TryGetConstructorArgument(0, out string? signature))
                    continue; // ignore malformed attribute

                if (!methodSymbol.TryGetSyntaxNode(token, out MethodDeclarationSyntax? methodSyntax))
                    continue; // unable to get method syntax
                
                MemberFunctionInfo mfi = new MemberFunctionInfo(
                    new MethodInfo(
                        methodSymbol.Name,
                        methodSyntax.Modifiers.ToString(),
                        methodSymbol.ReturnType.GetFullyQualifiedName(),
                        methodSymbol.IsStatic,
                        methodSymbol.Parameters.Select(ParseParameter).ToImmutableArray()
                        ),
                    signature);

                memberFunctionsBuilder.Add(mfi);
            }
        }
        memberFunctions = memberFunctionsBuilder.ToImmutable();
    }

    private static ParameterInfo ParseParameter(IParameterSymbol parameterSymbol) {
        return new ParameterInfo(
            parameterSymbol.Name,
            parameterSymbol.Type.GetFullyQualifiedName(),
            parameterSymbol.GetDefaultValueString());
    }
}
