using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.Generators.FunctionGenerator;

public sealed partial class FunctionGenerator
{
    internal sealed class Parser
    {
        private static DiagnosticDescriptor MultipleAttributes { get; } = new(
            id: "CSFG0001",
            title: "Multiple attributes",
            messageFormat: "Method {0} has multiple function generation attributes",
            category: "Function Generator",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true
        );

        private static DiagnosticDescriptor InvalidSignature { get; } = new(
            id: "CSFG0002",
            title: "Invalid signature",
            messageFormat: "Signature {0} is invalid - use ?? and make sure each byte is 2 characters",
            category: "Function Generator",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true
        );

        private static DiagnosticDescriptor StructMustBePartial { get; } = new(
            id: "CSFG0003",
            title: "Struct must be partial",
            messageFormat: "Struct {0} must be partial",
            category: "Function Generator",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true
        );

        private static DiagnosticDescriptor MethodMustBePartial { get; } = new(
            id: "CSFG0004",
            title: "Method must be partial",
            messageFormat: "Method {0} must be partial",
            category: "Function Generator",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true
        );

        private static DiagnosticDescriptor ReturnsUnmanaged { get; } = new(
            id: "CSFG0005",
            title: "Method must return unmanaged",
            messageFormat: "Method {0} has invalid return type {1} - must be unmanaged type",
            category: "Function Generator",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);
        
        private static DiagnosticDescriptor ParamUnmanagedOrString { get; } = new(
            id: "CSFG0006",
            title: "Method parameters unmanaged or string",
            messageFormat: "Parameter {0} has invalid type {1} - must be either unmanaged type or the string type",
            category: "Function Generator",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        internal static bool IsSyntaxTargetForGeneration(SyntaxNode node)
        {
            return node is MethodDeclarationSyntax { AttributeLists.Count: > 0 };
        }

        internal static StructDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
        {
            var methodDeclarationSyntax = (MethodDeclarationSyntax)context.Node;

            foreach (var attributeListSyntax in methodDeclarationSyntax.AttributeLists)
            foreach (var attributeSyntax in attributeListSyntax.Attributes)
            {
                var attributeSymbol = ModelExtensions.GetSymbolInfo(context.SemanticModel, attributeSyntax).Symbol
                    as IMethodSymbol;
                if (attributeSymbol == null) continue;

                var attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                var fullName = attributeContainingTypeSymbol.ToDisplayString();

                if (fullName == Attributes.MemberFunctionAttribute.FullName ||
                    fullName == Attributes.VirtualFunctionAttribute.FullName)
                    return methodDeclarationSyntax.Parent as StructDeclarationSyntax;
            }

            return null;
        }

        private readonly CancellationToken _cancellationToken;
        private readonly Compilation _compilation;
        private readonly Action<Diagnostic> _reportDiagnostic;

        public Parser(Compilation compilation, Action<Diagnostic> reportDiagnostic, CancellationToken cancellationToken)
        {
            _compilation = compilation;
            _cancellationToken = cancellationToken;
            _reportDiagnostic = reportDiagnostic;
        }

        public IReadOnlyList<TargetStruct> GetTargetStructs(IEnumerable<StructDeclarationSyntax> structs)
        {
            INamedTypeSymbol? memberFunctionAttribute =
                _compilation.GetTypeByMetadataName(Attributes.MemberFunctionAttribute.FullName);

            if (memberFunctionAttribute == null)
                return Array.Empty<TargetStruct>();

            INamedTypeSymbol? virtualFunctionAttribute =
                _compilation.GetTypeByMetadataName(Attributes.VirtualFunctionAttribute.FullName);

            if (virtualFunctionAttribute == null)
                return Array.Empty<TargetStruct>();

            var results = new List<TargetStruct>();

            foreach (var group in structs.GroupBy(x => x.SyntaxTree))
            {
                SemanticModel? sm = null;
                foreach (StructDeclarationSyntax structDec in group)
                {
                    _cancellationToken.ThrowIfCancellationRequested();

                    string structName = structDec.Identifier.ToString();

                    if (!structDec.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
                    {
                        _reportDiagnostic(Diagnostic.Create(StructMustBePartial, structDec.GetLocation(), structName));
                    }

                    TargetStruct? ts = null;
                    string nSpace = string.Empty;

                    foreach (MemberDeclarationSyntax member in structDec.Members)
                    {
                        var method = member as MethodDeclarationSyntax;
                        if (method == null)
                            continue;

                        sm ??= _compilation.GetSemanticModel(structDec.SyntaxTree);
                        var methodSymbol =
                            ModelExtensions.GetDeclaredSymbol(sm, method, _cancellationToken) as IMethodSymbol;
                        if (methodSymbol == null)
                            continue;

                        (string? signature, uint? virtualIndex) = (null, null);

                        bool hasMisconfiguredInput = false;

                        ImmutableArray<AttributeData> validAttributes = methodSymbol.GetAttributes().Where(aData =>
                            SymbolEqualityComparer.Default.Equals(aData.AttributeClass, memberFunctionAttribute)
                            || SymbolEqualityComparer.Default.Equals(aData.AttributeClass, virtualFunctionAttribute)
                        ).ToImmutableArray();

                        if (!validAttributes.Any())
                            continue;

                        if (validAttributes.Count() > 1)
                        {
                            _reportDiagnostic(Diagnostic.Create(MultipleAttributes, method.GetLocation(), methodSymbol.Name));
                            continue;
                        }

                        foreach (AttributeData attributeData in validAttributes)
                        {
                            if (attributeData.AttributeClass?.Equals(memberFunctionAttribute,
                                    SymbolEqualityComparer.Default) ?? true)
                            {
                                // [MemberFunction("??")]
                                // [MemberFunction(signature: "??")]
                                if (attributeData.ConstructorArguments.Any())
                                {
                                    foreach (TypedConstant typedConstant in attributeData.ConstructorArguments)
                                    {
                                        if (typedConstant.Kind == TypedConstantKind.Error)
                                            hasMisconfiguredInput = true;
                                    }

                                    ImmutableArray<TypedConstant> items = attributeData.ConstructorArguments;

                                    signature = items[0].IsNull ? "" : (string)items[0].Value!;
                                }

                                // [MemberFunction(Signature = "??")]
                                if (attributeData.NamedArguments.Any())
                                {
                                    foreach (KeyValuePair<string, TypedConstant> namedArgument in attributeData
                                                 .NamedArguments)
                                    {
                                        TypedConstant typedConstant = namedArgument.Value;
                                        if (typedConstant.Kind == TypedConstantKind.Error)
                                        {
                                            hasMisconfiguredInput = true;
                                        }
                                        else
                                        {
                                            TypedConstant value = namedArgument.Value;
                                            if (namedArgument.Key == "Signature")
                                                signature = value.IsNull ? "" : (string)value.Value!;
                                        }
                                    }
                                }
                            }
                            else if (attributeData.AttributeClass.Equals(virtualFunctionAttribute,
                                         SymbolEqualityComparer.Default))
                            {
                                // [VirtualFunction(0)]
                                // [VirtualFunction(index: 0)]
                                if (attributeData.ConstructorArguments.Any())
                                {
                                    foreach (TypedConstant typedConstant in attributeData.ConstructorArguments)
                                    {
                                        if (typedConstant.Kind == TypedConstantKind.Error)
                                            hasMisconfiguredInput = true;
                                    }

                                    ImmutableArray<TypedConstant> items = attributeData.ConstructorArguments;

                                    virtualIndex = items[0].IsNull ? null : (uint)items[0].Value!;
                                }

                                // [VirtualFunction(Index = 0)]
                                if (attributeData.NamedArguments.Any())
                                {
                                    foreach (KeyValuePair<string, TypedConstant> namedArgument in attributeData
                                                 .NamedArguments)
                                    {
                                        TypedConstant typedConstant = namedArgument.Value;
                                        if (typedConstant.Kind == TypedConstantKind.Error)
                                        {
                                            hasMisconfiguredInput = true;
                                        }
                                        else
                                        {
                                            TypedConstant value = namedArgument.Value;
                                            if (namedArgument.Key == "Index")
                                                virtualIndex = value.IsNull ? null : (uint)value.Value!;
                                        }
                                    }
                                }
                            }
                        }

                        if (hasMisconfiguredInput)
                            break;

                        if (signature is not null)
                        {
                            if (signature.Replace(" ", string.Empty).Length % 2 != 0
                                || signature.Contains(" ? "))
                            {
                                _reportDiagnostic(Diagnostic.Create(InvalidSignature, method.GetLocation(), signature));
                                continue;
                            }
                        }

                        bool keepFunction = true;

                        bool isPartial = false;
                        bool isStatic = false;
                        foreach (SyntaxToken mod in method.Modifiers)
                        {
                            if (mod.IsKind(SyntaxKind.PartialKeyword))
                            {
                                isPartial = true;
                            }
                            else if (mod.IsKind(SyntaxKind.StaticKeyword))
                            {
                                isStatic = true;
                            }
                        }

                        if (!isPartial)
                        {
                            _reportDiagnostic(Diagnostic.Create(MethodMustBePartial, method.GetLocation(), methodSymbol.Name));
                            keepFunction = false;
                        }

                        string returnType = methodSymbol.ReturnType.ToDisplayString(
                            SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(
                                SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier
                                | SymbolDisplayMiscellaneousOptions.UseSpecialTypes).WithGenericsOptions(
                                SymbolDisplayGenericsOptions.IncludeTypeParameters |
                                SymbolDisplayGenericsOptions.IncludeTypeConstraints));
                        
                        if (!methodSymbol.ReturnType.IsUnmanagedType)
                        {
                            _reportDiagnostic(Diagnostic.Create(ReturnsUnmanaged, method.GetLocation(), methodSymbol.Name, returnType));
                            keepFunction = false;
                        }

                        Function func = new Function
                        {
                            Name = methodSymbol.Name,
                            Modifiers = method.Modifiers.ToString(),
                            ReturnType = returnType,
                            Signature = signature,
                            VirtualIndex = virtualIndex,
                            IsStatic = isStatic
                        };

                        foreach (IParameterSymbol paramSymbol in methodSymbol.Parameters)
                        {
                            string paramName = paramSymbol.Name;
                            if (string.IsNullOrWhiteSpace(paramName))
                            {
                                // semantic problem, just bail quietly
                                keepFunction = false;
                                break;
                            }

                            ITypeSymbol paramTypeSymbol = paramSymbol.Type;
                            if (paramTypeSymbol is IErrorTypeSymbol)
                            {
                                // semantic problem, just bail quietly
                                keepFunction = false;
                                break;
                            }
                            
                            string typeName = paramTypeSymbol.ToDisplayString(
                                SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(
                                    SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier |
                                    SymbolDisplayMiscellaneousOptions.UseSpecialTypes).WithGenericsOptions(
                                    SymbolDisplayGenericsOptions.IncludeTypeParameters |
                                    SymbolDisplayGenericsOptions.IncludeTypeConstraints));
                            
                            if (!paramTypeSymbol.IsUnmanagedType &&
                                paramTypeSymbol.SpecialType != SpecialType.System_String)
                            {
                                _reportDiagnostic(Diagnostic.Create(ParamUnmanagedOrString, method.GetLocation(),
                                    paramName, typeName));
                                keepFunction = false;
                                continue;
                            }

                            var param = new Parameter
                            {
                                Name = paramName,
                                Type = typeName
                            };
                            
                            func.Parameters.Add(param);
                        }
                        
                        if (ts == null) 
                        {
                            SyntaxNode? potentialNamespaceParent = structDec.Parent;
                            while (potentialNamespaceParent != null 
                                   && potentialNamespaceParent is not NamespaceDeclarationSyntax
                                   && potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax)
                            {
                                potentialNamespaceParent = potentialNamespaceParent.Parent;
                            }

                            BaseNamespaceDeclarationSyntax? namespaceParent =
                                // ReSharper disable once UsePatternMatching
                                potentialNamespaceParent as BaseNamespaceDeclarationSyntax;
                            if (namespaceParent is not null)
                            {
                                nSpace = namespaceParent.Name.ToString();
                                while (true)
                                {
                                    namespaceParent = namespaceParent.Parent as NamespaceDeclarationSyntax;
                                    if (namespaceParent is null)
                                    {
                                        break;
                                    }

                                    nSpace = $"{namespaceParent.Name}.{nSpace}";
                                }
                            }
                        }

                        if (keepFunction)
                        {
                            ts ??= new TargetStruct
                            {
                                Keyword = structDec.Keyword.ValueText,
                                Namespace = nSpace,
                                Name = structDec.Identifier.ToString() + structDec.TypeParameterList,
                                ParentStruct = null
                            };

                            TargetStruct currentStruct = ts;
                            var parentStruct = (structDec.Parent as TypeDeclarationSyntax);
                            
                            while (parentStruct != null && parentStruct.Kind() == SyntaxKind.StructDeclaration)
                            {
                                currentStruct.ParentStruct = new TargetStruct
                                {
                                    Keyword = parentStruct.Keyword.ValueText,
                                    Namespace = nSpace,
                                    Name = parentStruct.Identifier.ToString() + parentStruct.TypeParameterList,
                                    ParentStruct = null,
                                };

                                currentStruct = currentStruct.ParentStruct;
                                parentStruct = (parentStruct.Parent as TypeDeclarationSyntax);
                            }
                            
                            ts.Functions.Add(func);
                        }
                    }

                    if (ts != null)
                        results.Add(ts);
                }
            }

            return results;
        }
    }

    internal sealed class TargetStruct
    {
        public readonly List<Function> Functions = new();
        public string Keyword = string.Empty;
        public string Namespace = string.Empty;
        public string Name = string.Empty;
        public TargetStruct? ParentStruct;
    }

    internal sealed class Function
    {
        public readonly List<Parameter> Parameters = new();
        public string Name = string.Empty;
        public string Modifiers = string.Empty;
        public string ReturnType = string.Empty;
        public string? Signature;
        public uint? VirtualIndex;
        public bool IsStatic;
    }

    internal sealed class Parameter
    {
        public string Name = string.Empty;
        public string Type = string.Empty;
    }
}