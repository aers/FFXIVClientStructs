using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using InteropGenerator.Extensions;
using InteropGenerator.Helpers;
using InteropGenerator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InteropGenerator.Generator;

public sealed partial class InteropGenerator {

    private static StructInfo ParseStructInfo(INamedTypeSymbol structSymbol, AttributeData generateInteropAttributeData, CancellationToken token) {
        // check if we need to collect extra info for inheritance
        ExtraInheritedStructInfo? extraInheritedStructInfo = null;
        generateInteropAttributeData.TryGetConstructorArgument(0, out bool isInherited);

        // collect info on struct methods
        ParseMethods(structSymbol,
            token,
            isInherited,
            out EquatableArray<MemberFunctionInfo> memberFunctions,
            out EquatableArray<VirtualFunctionInfo> virtualFunctions,
            out EquatableArray<StaticAddressInfo> staticAddresses,
            out EquatableArray<StringOverloadInfo> stringOverloads,
            out EquatableArray<MethodInfo> extraPublicMethods);
        token.ThrowIfCancellationRequested();

        // collect info on struct fields
        ParseFields(structSymbol, token, isInherited, out EquatableArray<FixedSizeArrayInfo> fixedSizeArrays, out EquatableArray<FieldInfo> publicFields);
        token.ThrowIfCancellationRequested();

        // other struct attributes
        SignatureInfo? virtualTableSignatureInfo = null;
        uint? virtualTableFunctionCount = null;
        if (structSymbol.TryGetAttributeWithFullyQualifiedMetadataName(InteropTypeNames.VirtualTableAttribute, out AttributeData? virtualTableAttribute)) {
            if (virtualTableAttribute.TryGetConstructorArgument(0, out string? signature)) {
                if (virtualTableAttribute.ConstructorArguments[1].Kind == TypedConstantKind.Array &&
                    virtualTableAttribute.TryGetMultiValueConstructorArgument(1, out ImmutableArray<ushort>? multipleOffsets)) {
                    virtualTableSignatureInfo = new SignatureInfo(signature, multipleOffsets.Value);
                } else if (virtualTableAttribute.TryGetConstructorArgument(1, out ushort? singleOffset)) {
                    ImmutableArray<ushort> values = [singleOffset.Value];
                    virtualTableSignatureInfo = new SignatureInfo(signature, values);
                }
            }
            if (virtualTableAttribute.TryGetConstructorArgument(2, out uint? functionCount)) {
                virtualTableFunctionCount = functionCount == 0 ? null : functionCount;
            }
        }

        using ImmutableArrayBuilder<InheritanceInfo> inheritanceInfoBuilder = new();
        foreach (AttributeData attributeData in structSymbol.GetAttributes()) {
            if (attributeData.AttributeClass is not { } attributeSymbol) continue;
            if (!attributeSymbol.HasFullyQualifiedMetadataName(InteropTypeNames.InheritsAttribute)) continue;
            if (attributeData.ConstructorArguments.Length != 1 ||
                !attributeData.TryGetConstructorArgument(0, out int? parentOffset))
                continue;
            if (attributeSymbol.TypeArguments.Length != 1) continue;

            InheritanceInfo inheritanceInfo = new(
                attributeSymbol.TypeArguments[0].GetNameWithContainingTypeAndNamespace(),
                parentOffset.Value
            );
            inheritanceInfoBuilder.Add(inheritanceInfo);
        }

        // get containing types; our analyzer validates structs are contained in a proper hierarchy so not needed here
        using ImmutableArrayBuilder<string> hierarchy = new();

        for (INamedTypeSymbol? parent = structSymbol;
             parent is not null;
             parent = parent.ContainingType) {
            hierarchy.Add(parent.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat));
        }

        // get struct size, if available
        int? structSize = null;

        if (structSymbol.TryGetAttributeWithFullyQualifiedMetadataName("System.Runtime.InteropServices.StructLayoutAttribute", out AttributeData? structLayoutAttributeData)) {
            structLayoutAttributeData.TryGetNamedArgument("Size", out structSize);
        }

        // collect extra data for an inherited struct
        if (isInherited) {
            ParseProperties(structSymbol, token, out EquatableArray<PropertyInfo> publicProperties);
            extraInheritedStructInfo = new ExtraInheritedStructInfo(
                publicFields,
                extraPublicMethods,
                publicProperties);
        }

        // collect all info
        return new StructInfo(
            structSymbol.GetNameWithContainingTypeAndNamespace(),
            structSymbol.ContainingNamespace.GetNameWithContainingTypeAndNamespace(),
            hierarchy.ToImmutable(),
            memberFunctions,
            virtualFunctions,
            staticAddresses,
            stringOverloads,
            virtualTableSignatureInfo,
            virtualTableFunctionCount,
            fixedSizeArrays,
            inheritanceInfoBuilder.ToImmutable(),
            structSize,
            extraInheritedStructInfo);
    }

    private static void ParseMethods(INamedTypeSymbol structSymbol, CancellationToken token, bool isInherited,
        out EquatableArray<MemberFunctionInfo> memberFunctions,
        out EquatableArray<VirtualFunctionInfo> virtualFunctions,
        out EquatableArray<StaticAddressInfo> staticAddresses,
        out EquatableArray<StringOverloadInfo> stringOverloads,
        out EquatableArray<MethodInfo> extraPublicMethods) {

        using ImmutableArrayBuilder<MemberFunctionInfo> memberFunctionsBuilder = new();
        using ImmutableArrayBuilder<VirtualFunctionInfo> virtualFunctionBuilder = new();
        using ImmutableArrayBuilder<StaticAddressInfo> staticAddressesBuilder = new();
        using ImmutableArrayBuilder<StringOverloadInfo> stringOverloadsBuilder = new();
        using ImmutableArrayBuilder<MethodInfo> extraPublicMethodsBuilder = new();

        foreach (IMethodSymbol methodSymbol in structSymbol.GetMembers().OfType<IMethodSymbol>()) {
            MethodInfo? methodInfo = null;

            // check for one of the method body generation attributes
            if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(InteropTypeNames.MemberFunctionAttribute, out AttributeData? mfAttribute)) {
                var relativeOffsets = ImmutableArray<ushort>.Empty;

                // get signature 
                if (!mfAttribute.TryGetConstructorArgument(0, out string? signature))
                    continue;

                // if attribute has two arguments, it's either a single byte or an array, if neither, attribute is invalid
                if (mfAttribute.ConstructorArguments.Length == 2) {
                    if (mfAttribute.ConstructorArguments[1].Kind == TypedConstantKind.Array &&
                        mfAttribute.TryGetMultiValueConstructorArgument(1, out ImmutableArray<ushort>? multipleOffsets))
                        relativeOffsets = multipleOffsets.Value;
                    else if (mfAttribute.TryGetConstructorArgument(1, out ushort? singleOffset))
                        relativeOffsets = [singleOffset.Value];
                    else
                        continue;
                }

                if (!TryParseMethod(methodSymbol, isInherited, token, out methodInfo))
                    continue;

                MemberFunctionInfo memberFunctionInfo = new(
                    methodInfo,
                    new SignatureInfo(signature, relativeOffsets));

                memberFunctionsBuilder.Add(memberFunctionInfo);
            } else if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(InteropTypeNames.VirtualFunctionAttribute, out AttributeData? vfAttribute)) {
                if (vfAttribute.ConstructorArguments.Length != 1 ||
                    !vfAttribute.TryGetConstructorArgument(0, out uint? index))
                    continue; // ignore malformed attribute

                if (!TryParseMethod(methodSymbol, isInherited, token, out methodInfo))
                    continue;

                VirtualFunctionInfo virtualFunctionInfo = new(
                    methodInfo,
                    index.Value);

                virtualFunctionBuilder.Add(virtualFunctionInfo);
            } else if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(InteropTypeNames.StaticAddressAttribute, out AttributeData? saAttribute)) {
                if (saAttribute.ConstructorArguments.Length != 3 ||
                    !saAttribute.TryGetConstructorArgument(0, out string? signature) ||
                    !saAttribute.TryGetConstructorArgument(2, out bool? isPointer))
                    continue; // ignore malformed attribute

                ImmutableArray<ushort> relativeOffsets;

                if (saAttribute.ConstructorArguments[1].Kind == TypedConstantKind.Array &&
                    saAttribute.TryGetMultiValueConstructorArgument(1, out ImmutableArray<ushort>? multipleOffsets)) {
                    relativeOffsets = multipleOffsets.Value;
                } else if (saAttribute.TryGetConstructorArgument(1, out ushort? singleOffset)) {
                    relativeOffsets = [singleOffset.Value];
                } else {
                    continue;
                }

                if (!TryParseMethod(methodSymbol, isInherited, token, out methodInfo))
                    continue;

                StaticAddressInfo staticAddressInfo = new(
                    methodInfo,
                    new SignatureInfo(signature, relativeOffsets),
                    isPointer.Value);

                staticAddressesBuilder.Add(staticAddressInfo);
            } else if (isInherited && methodSymbol.DeclaredAccessibility == Accessibility.Public && !methodSymbol.IsStatic) {
                if (!TryParseMethod(methodSymbol, isInherited, token, out methodInfo))
                    continue;

                extraPublicMethodsBuilder.Add(methodInfo);
            }

            // check for string overload, which could be applied to some of the above
            if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(InteropTypeNames.GenerateStringOverloadsAttribute, out _)) {
                // retrieve method info if it wasn't previously retrieved
                if (methodInfo is null) {
                    if (!TryParseMethod(methodSymbol, isInherited, token, out methodInfo))
                        continue;
                }

                using ImmutableArrayBuilder<string> ignoredParametersBuilder = new();

                foreach (IParameterSymbol parameterSymbol in methodSymbol.Parameters) {
                    if (parameterSymbol.TryGetAttributeWithFullyQualifiedMetadataName(InteropTypeNames.StringIgnoreAttribute, out _))
                        ignoredParametersBuilder.Add(parameterSymbol.Name);
                }

                EquatableArray<string>? attributes = isInherited ? methodInfo.InheritableAttributes : ParseInheritedAttributes(methodSymbol, token);

                StringOverloadInfo stringOverloadInfo = new(
                    methodInfo,
                    ignoredParametersBuilder.ToImmutable(),
                    attributes);

                stringOverloadsBuilder.Add(stringOverloadInfo);

            }

            token.ThrowIfCancellationRequested();
        }
        memberFunctions = memberFunctionsBuilder.ToImmutable();
        virtualFunctions = virtualFunctionBuilder.ToImmutable();
        staticAddresses = staticAddressesBuilder.ToImmutable();
        stringOverloads = stringOverloadsBuilder.ToImmutable();
        extraPublicMethods = extraPublicMethodsBuilder.ToImmutable();
    }

    private static bool TryParseMethod(IMethodSymbol methodSymbol, bool isInherited, CancellationToken token, [NotNullWhen(true)] out MethodInfo? methodInfo) {
        if (!methodSymbol.TryGetSyntaxNode(token, out MethodDeclarationSyntax? methodSyntax)) {
            methodInfo = null;
            return false; // unable to get method syntax
        }

        var constraints = string.Empty;

        if (methodSymbol.TypeParameters.Any()) {
            ImmutableArray<SymbolDisplayPart> symbolDisplayParts = methodSymbol.ToDisplayParts(new SymbolDisplayFormat(genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeConstraints));
            constraints = string.Join("", symbolDisplayParts[1..]);
        }

        EquatableArray<string>? inheritableAttributes = isInherited ? ParseInheritedAttributes(methodSymbol, token) : null;

        methodInfo =
            new MethodInfo(
                methodSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                methodSyntax.Modifiers.ToString(),
                methodSymbol.ReturnType.GetFullyQualifiedName(),
                constraints,
                methodSymbol.IsStatic,
                methodSymbol.Parameters.Select(p => ParseParameter(p, isInherited, token)).ToImmutableArray(),
                inheritableAttributes
            );

        return true;
    }

    private static ParameterInfo ParseParameter(IParameterSymbol parameterSymbol, bool isInherited, CancellationToken token) => new(
        parameterSymbol.Name,
        parameterSymbol.Type.GetFullyQualifiedName(),
        parameterSymbol.GetDefaultValueString(),
        parameterSymbol.RefKind,
        isInherited ? ParseInheritedAttributes(parameterSymbol, token) : null);

    private static void ParseFields(INamedTypeSymbol structSymbol, CancellationToken token, bool isInherited,
        out EquatableArray<FixedSizeArrayInfo> fixedSizeArrays, out EquatableArray<FieldInfo> publicFields) {

        using ImmutableArrayBuilder<FixedSizeArrayInfo> fixedSizeArrayBuilder = new();
        using ImmutableArrayBuilder<FieldInfo> publicFieldBuilder = new();

        foreach (IFieldSymbol fieldSymbol in structSymbol.GetMembers().OfType<IFieldSymbol>()) {
            if (fieldSymbol.TryGetAttributeWithFullyQualifiedMetadataName(InteropTypeNames.FixedSizeArrayAttribute, out AttributeData? fixedSizeArrayAttributeData)) {
                if (fieldSymbol.Type is not INamedTypeSymbol fieldTypeSymbol)
                    continue;

                if (!fieldTypeSymbol.IsGenericType || fieldTypeSymbol.TypeArguments.Length != 1) // malformed field
                    continue;

                // "FixedSizeArray###"
                if (fieldTypeSymbol.Name.Length < 14)
                    continue;

                // try and get size
                if (!int.TryParse(fieldTypeSymbol.Name[14..], out int size))
                    continue;

                if (!fixedSizeArrayAttributeData.TryGetConstructorArgument(0, out bool? isString))
                    continue;

                EquatableArray<string> inheritableAttributes = ParseInheritedAttributes(fieldSymbol, token);

                FixedSizeArrayInfo fixedSizeArrayInfo = new(
                    fieldSymbol.Name,
                    fieldTypeSymbol.TypeArguments[0].GetFullyQualifiedName(),
                    size,
                    isString.Value,
                    inheritableAttributes
                );

                fixedSizeArrayBuilder.Add(fixedSizeArrayInfo);
            }
            if (isInherited && fieldSymbol.DeclaredAccessibility == Accessibility.Public) {
                if (!fieldSymbol.TryGetAttributeWithFullyQualifiedMetadataName("System.Runtime.InteropServices.FieldOffsetAttribute", out AttributeData? fieldOffsetAttributeData))
                    continue;

                if (!fieldOffsetAttributeData.TryGetConstructorArgument(0, out int fieldOffset))
                    continue;

                EquatableArray<string> inheritableAttributes = ParseInheritedAttributes(fieldSymbol, token);

                FieldInfo fieldInfo = new(
                    fieldSymbol.Name,
                    fieldSymbol.Type.GetFullyQualifiedName(),
                    fieldOffset,
                    inheritableAttributes);

                publicFieldBuilder.Add(fieldInfo);
            }
            token.ThrowIfCancellationRequested();
        }

        fixedSizeArrays = fixedSizeArrayBuilder.ToImmutable();
        publicFields = publicFieldBuilder.ToImmutable();
    }

    private static void ParseProperties(INamedTypeSymbol structSymbol, CancellationToken token, out EquatableArray<PropertyInfo> publicProperties) {
        using ImmutableArrayBuilder<PropertyInfo> publicPropertiesBuilder = new();

        foreach (IPropertySymbol propertySymbol in structSymbol.GetMembers().OfType<IPropertySymbol>()) {
            if (propertySymbol.DeclaredAccessibility != Accessibility.Public ||
                propertySymbol.IsIndexer) {
                continue;
            }

            EquatableArray<string> inheritableAttributes = ParseInheritedAttributes(propertySymbol, token);

            PropertyInfo propertyInfo = new(
                propertySymbol.Name,
                propertySymbol.Type.GetFullyQualifiedName(),
                propertySymbol.RefKind,
                propertySymbol.GetMethod is not null,
                propertySymbol.SetMethod is not null,
                inheritableAttributes
            );

            publicPropertiesBuilder.Add(propertyInfo);

            token.ThrowIfCancellationRequested();
        }

        publicProperties = publicPropertiesBuilder.ToImmutable();
    }

    private static EquatableArray<string> ParseInheritedAttributes(ISymbol symbol, CancellationToken token) {
        ImmutableArrayBuilder<string> inheritedAttributes = new();

        foreach (AttributeData attributeData in symbol.GetAttributes()) {
            // don't inherit our generator attributes
            if (attributeData.AttributeClass?.GetFullyQualifiedMetadataName() is not { } attributeName ||
                InteropTypeNames.UninheritableAttributes.Contains(attributeName))
                continue;

            // rather than parse and store every argument to the attribute, get the attribute list from the original syntax
            // this can be slow, but there should be relatively few inherited attributes
            // the attribute name is still taken from the symbol so it uses the fully defined type name
            // this will break if an attribute argument has a type name in it and the type name is not in scope
            if (attributeData.ApplicationSyntaxReference is not { } syntaxReference)
                continue;

            SyntaxNode originalAttributeSyntax = syntaxReference.GetSyntax(token);
            AttributeArgumentListSyntax? argumentListSyntax = originalAttributeSyntax.ChildNodes().OfType<AttributeArgumentListSyntax>().FirstOrDefault();

            inheritedAttributes.Add(argumentListSyntax is not null ? $"[global::{attributeName}{argumentListSyntax.ToString()}]" : $"[global::{attributeName}]");
        }
        return inheritedAttributes.ToImmutable();
    }
}
