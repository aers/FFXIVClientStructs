using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using InteropGenerator.Extensions;
using InteropGenerator.Helpers;
using InteropGenerator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InteropGenerator.Generator;

public sealed partial class InteropGenerator {

    private static StructInfo ParseStructInfo(INamedTypeSymbol structSymbol, CancellationToken token) {
        // check if we need to collect extra info for inheritance
        var isInherited = false;
        ExtraInheritedStructInfo? inheritedStructInfo = null;
        if (structSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.GenerateInteropAttribute, out AttributeData? generateInteropAttributeData)) {
            generateInteropAttributeData.TryGetConstructorArgument(0, out isInherited);
        }

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
        if (structSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.VirtualTableAttribute, out AttributeData? virtualTableAttribute)) {
            if (virtualTableAttribute.TryGetConstructorArgument(0, out string? signature)) {
                if (virtualTableAttribute.ConstructorArguments[1].Kind == TypedConstantKind.Array &&
                    virtualTableAttribute.TryGetMultiValueConstructorArgument(1, out ImmutableArray<byte>? multipleOffsets)) {
                    virtualTableSignatureInfo = new SignatureInfo(signature, multipleOffsets.Value);
                }
                else if (virtualTableAttribute.TryGetConstructorArgument(1, out byte? singleOffset)) {
                    ImmutableArray<byte> values = [singleOffset.Value];
                    virtualTableSignatureInfo = new SignatureInfo(signature, values);
                }
            }
        }

        using ImmutableArrayBuilder<InheritanceInfo> inheritanceInfoBuilder = new();
        foreach (AttributeData attributeData in structSymbol.GetAttributes()) {
            if (attributeData.AttributeClass is not { } attributeSymbol) continue;
            if (!attributeSymbol.HasFullyQualifiedMetadataName(AttributeNames.InheritsAttribute)) continue;
            if (attributeData.ConstructorArguments.Length != 1 ||
                !attributeData.TryGetConstructorArgument(0, out int? parentOffset))
                continue;
            if (attributeSymbol.TypeArguments.Length != 1) continue;

            InheritanceInfo inheritanceInfo = new(
                attributeSymbol.TypeArguments[0].GetFullyQualifiedMetadataName(),
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

        // collect extra data for an inherited struct
        if (isInherited &&
            structSymbol.TryGetAttributeWithFullyQualifiedMetadataName("System.Runtime.InteropServices.StructLayoutAttribute", out AttributeData? structLayoutAttributeData) &&
            structLayoutAttributeData.TryGetNamedArgument("Size", out int? size) &&
            size.HasValue) {
            inheritedStructInfo = new ExtraInheritedStructInfo(
                size.Value,
                publicFields,
                extraPublicMethods);
        }

        // collect all info
        return new StructInfo(
            structSymbol.GetFullyQualifiedMetadataName(),
            structSymbol.ContainingNamespace.ToDisplayString(
                new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces)),
            hierarchy.ToImmutable(),
            memberFunctions,
            virtualFunctions,
            staticAddresses,
            stringOverloads,
            virtualTableSignatureInfo,
            fixedSizeArrays,
            inheritanceInfoBuilder.ToImmutable(),
            inheritedStructInfo);
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
            if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.MemberFunctionAttribute, out AttributeData? mfAttribute)) {
                ImmutableArray<byte> relativeOffsets = ImmutableArray<byte>.Empty;

                // get signature 
                if (!mfAttribute.TryGetConstructorArgument(0, out string? signature))
                    continue;
                
                // if attribute has two arguments, it's either a single byte or an array, if neither, attribute is invalid
                if (mfAttribute.ConstructorArguments.Length == 2) {
                    if (mfAttribute.ConstructorArguments[1].Kind == TypedConstantKind.Array &&
                        mfAttribute.TryGetMultiValueConstructorArgument(1, out ImmutableArray<byte>? multipleOffsets))
                        relativeOffsets = multipleOffsets.Value;
                    else if (mfAttribute.TryGetConstructorArgument(1, out byte? singleOffset))
                        relativeOffsets = [singleOffset.Value];
                    else
                        continue;
                }

                if (!TryParseMethod(methodSymbol, token, out methodInfo))
                    continue;

                MemberFunctionInfo memberFunctionInfo = new(
                    methodInfo,
                    new SignatureInfo(signature, relativeOffsets));

                memberFunctionsBuilder.Add(memberFunctionInfo);
            } else if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.VirtualFunctionAttribute, out AttributeData? vfAttribute)) {
                if (vfAttribute.ConstructorArguments.Length != 1 ||
                    !vfAttribute.TryGetConstructorArgument(0, out uint? index))
                    continue; // ignore malformed attribute

                if (!TryParseMethod(methodSymbol, token, out methodInfo))
                    continue;

                VirtualFunctionInfo virtualFunctionInfo = new(
                    methodInfo,
                    index.Value);

                virtualFunctionBuilder.Add(virtualFunctionInfo);
            } else if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.StaticAddressAttribute, out AttributeData? saAttribute)) {
                if (saAttribute.ConstructorArguments.Length != 3 ||
                    !saAttribute.TryGetConstructorArgument(0, out string? signature) ||
                    !saAttribute.TryGetConstructorArgument(2, out bool? isPointer))
                    continue; // ignore malformed attribute

                ImmutableArray<byte> relativeOffsets;
                
                if (saAttribute.ConstructorArguments[1].Kind == TypedConstantKind.Array &&
                    saAttribute.TryGetMultiValueConstructorArgument(1, out ImmutableArray<byte>? multipleOffsets))
                {
                    relativeOffsets = multipleOffsets.Value;
                }
                else if (saAttribute.TryGetConstructorArgument(1, out byte? singleOffset)) {
                    relativeOffsets = [singleOffset.Value];
                } else {
                    continue;
                }

                if (!TryParseMethod(methodSymbol, token, out methodInfo))
                    continue;

                StaticAddressInfo staticAddressInfo = new(
                    methodInfo,
                    new SignatureInfo(signature, relativeOffsets),
                    isPointer.Value);

                staticAddressesBuilder.Add(staticAddressInfo);
            } else if (isInherited && methodSymbol.DeclaredAccessibility == Accessibility.Public && !methodSymbol.IsStatic) {
                if (!TryParseMethod(methodSymbol, token, out methodInfo))
                    continue;
                
                extraPublicMethodsBuilder.Add(methodInfo);
            }

            // check for string overload, which could be applied to some of the above
            if (methodSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.GenerateStringOverloads, out _)) {
                // retrieve method info if it wasn't previously retrieved
                if (methodInfo is null) {
                    if (!TryParseMethod(methodSymbol, token, out methodInfo))
                        continue;
                }

                using ImmutableArrayBuilder<string> ignoredParametersBuilder = new();

                foreach (IParameterSymbol parameterSymbol in methodSymbol.Parameters) {
                    if (parameterSymbol.Type.TypeKind == TypeKind.Pointer &&
                        parameterSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.StringIgnore, out _))
                        ignoredParametersBuilder.Add(parameterSymbol.Name);
                }

                StringOverloadInfo stringOverloadInfo = new(
                    methodInfo,
                    ignoredParametersBuilder.ToImmutable());

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

    private static bool TryParseMethod(IMethodSymbol methodSymbol, CancellationToken token, [NotNullWhen(true)] out MethodInfo? methodInfo) {
        if (!methodSymbol.TryGetSyntaxNode(token, out MethodDeclarationSyntax? methodSyntax)) {
            methodInfo = null;
            return false; // unable to get method syntax
        }

        methodInfo =
            new MethodInfo(
                methodSymbol.Name,
                methodSyntax.Modifiers.ToString(),
                methodSymbol.ReturnType.GetFullyQualifiedName(),
                methodSymbol.IsStatic,
                methodSymbol.Parameters.Select(ParseParameter).ToImmutableArray()
            );

        return true;
    }

    private static ParameterInfo ParseParameter(IParameterSymbol parameterSymbol) => new(
        parameterSymbol.Name,
        parameterSymbol.Type.GetFullyQualifiedName(),
        parameterSymbol.GetDefaultValueString(),
        parameterSymbol.RefKind);

    private static void ParseFields(INamedTypeSymbol structSymbol, CancellationToken token, bool isInherited,
        out EquatableArray<FixedSizeArrayInfo> fixedSizeArrays, out EquatableArray<FieldInfo> publicFields) {

        using ImmutableArrayBuilder<FixedSizeArrayInfo> fixedSizeArrayBuilder = new();
        using ImmutableArrayBuilder<FieldInfo> publicFieldBuilder = new();

        foreach (IFieldSymbol fieldSymbol in structSymbol.GetMembers().OfType<IFieldSymbol>()) {
            if (fieldSymbol.Type is not INamedTypeSymbol fieldTypeSymbol)
                continue;
            if (fieldSymbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeNames.FixedSizeArrayAttribute, out AttributeData? fixedSizeArrayAttributeData)) {
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

                FixedSizeArrayInfo fixedSizeArrayInfo = new(
                    fieldSymbol.Name,
                    fieldTypeSymbol.TypeArguments[0].GetFullyQualifiedName(),
                    size,
                    isString.Value
                );

                fixedSizeArrayBuilder.Add(fixedSizeArrayInfo);
            }
            if (isInherited && fieldSymbol.DeclaredAccessibility == Accessibility.Public) {
                if (!fieldSymbol.TryGetAttributeWithFullyQualifiedMetadataName("System.Runtime.InteropServices.FieldOffsetAttribute", out AttributeData? fieldOffsetAttributeData))
                    continue;

                if (!fieldOffsetAttributeData.TryGetConstructorArgument(0, out int fieldOffset))
                    continue;

                FieldInfo fieldInfo = new(
                    fieldSymbol.Name,
                    fieldSymbol.Type.GetFullyQualifiedName(),
                    fieldOffset);

                publicFieldBuilder.Add(fieldInfo);
            }
            token.ThrowIfCancellationRequested();
        }

        fixedSizeArrays = fixedSizeArrayBuilder.ToImmutable();
        publicFields = publicFieldBuilder.ToImmutable();
    }
}
