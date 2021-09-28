using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.Generators.FunctionGenerator
{
        internal class FunctionSyntaxContextReceiver : ISyntaxContextReceiver
        {
            public List<Struct> Structs { get; } = new();

            public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
            {
                if (context.Node is not StructDeclarationSyntax sds) return;
                var methods = sds.ChildNodes().OfType<MethodDeclarationSyntax>().Where(m =>
                {
                    var sm = (IMethodSymbol) context.SemanticModel.GetDeclaredSymbol(m);
                    return sm != null && sm.GetAttributes()
                        .Any(a => a.AttributeClass?.Name is "MemberFunctionAttribute" or "VirtualFunctionAttribute");
                }).ToList();

                if (methods.Count <= 0) return;

                if (context.SemanticModel.GetDeclaredSymbol(sds) is not INamedTypeSymbol structType) return;
                var structObj = new Struct
                {
                    Name = structType.Name,
                    Namespace = structType.ContainingNamespace.ToDisplayString(),
                    MemberFunctions = new List<Function>(),
                    VirtualFunctions = new List<Function>(),
                    HasCtor = false
                };

                foreach (var m in methods)
                {
                    if (context.SemanticModel.GetDeclaredSymbol(m) is not IMethodSymbol ms) continue;
                    var format = new SymbolDisplayFormat(
                        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
                        miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes);
                    var functionObj = new Function
                    {
                        Name = ms.Name,
                        ReturnType = ms.ReturnType.ToDisplayString(format),
                        HasBoolReturn = ms.ReturnType.ToDisplayString() == "bool",
                        HasReturn = ms.ReturnType.ToDisplayString() != "void",
                        HasParams = ms.Parameters.Any(),
                        ParamList = string.Join(",",
                            ms.Parameters.Select(p => $"{p.Type.ToDisplayString(format)} {p.Name}")),
                        ParamTypeList = string.Join(",", ms.Parameters.Select(p => p.Type.ToDisplayString(format))),
                        ParamNameList = string.Join(",", ms.Parameters.Select(p => p.Name))
                    };
                    if (ms.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "MemberFunctionAttribute") is
                        { } memberFuncAttr)
                    {
                        functionObj.Signature = (string)memberFuncAttr.ConstructorArguments[0].Value;
                        functionObj.IsStatic = memberFuncAttr.NamedArguments.Any() &&
                                               (bool)(memberFuncAttr.NamedArguments[0].Value.Value ?? false);
                        structObj.MemberFunctions.Add(functionObj);
                        if (ms.Name == "Ctor")
                            structObj.HasCtor = true;
                    }

                    if (ms.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "VirtualFunctionAttribute") is
                        { } virtualFuncAttr)
                    {
                        functionObj.VirtualOffset = (int)(virtualFuncAttr.ConstructorArguments[0].Value ?? 0);
                        structObj.VirtualFunctions.Add(functionObj);
                    }
                }

                Structs.Add(structObj);

            }
        }
}