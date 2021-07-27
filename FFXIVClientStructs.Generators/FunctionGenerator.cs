using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Scriban;

namespace FFXIVClientStructs.Generators
{
    [Generator]
    class FunctionGenerator : ISourceGenerator
    {
        private Template _mfCodeTemplate;
        private Template _vfCodeTemplate;

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new FunctionSyntaxContextReceiver());

            _mfCodeTemplate = Template.Parse(Templates.MemberFunctions);
            _vfCodeTemplate = Template.Parse(Templates.VirtualFunctions);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxContextReceiver is FunctionSyntaxContextReceiver receiver)) return;

            foreach (var structObj in receiver.Structs)
            {
                if (structObj.MemberFunctions.Any())
                {
                    var filename = structObj.Namespace + "." + structObj.Name + ".MemberFunctions.generated.cs";
                    var source = _mfCodeTemplate.Render(new { Struct = structObj });
                    context.AddSource(filename, SourceText.From(source, Encoding.UTF8));
                }

                if (structObj.VirtualFunctions.Any())
                {
                    var filename = structObj.Namespace + "." + structObj.Name + ".VirtualFunctions.generated.cs";
                    var source = _vfCodeTemplate.Render(new { Struct = structObj });
                    context.AddSource(filename, SourceText.From(source, Encoding.UTF8));
                }
            }

            var resolverTemplate = Template.Parse(Templates.InitializeMemberFunctions);
            var resolverSource = resolverTemplate.Render(new {Structs = receiver.Structs});
            context.AddSource("Resolver.Generated.cs", resolverSource);
;
        }

        class FunctionSyntaxContextReceiver : ISyntaxContextReceiver
        {
            public List<Struct> Structs { get; } = new();

            public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
            {
                if (context.Node is not StructDeclarationSyntax sds) return;
                var methods = sds.ChildNodes().OfType<MethodDeclarationSyntax>().Where(m =>
                {
                    var sm = (IMethodSymbol) context.SemanticModel.GetDeclaredSymbol(m);
                    return sm != null && sm.GetAttributes()
                        .Any(a => a.AttributeClass?.Name == "MemberFunctionAttribute" || a.AttributeClass?.Name == "VirtualFunctionAttribute");
                }).ToList();

                if (methods.Count > 0)
                {
                    if (context.SemanticModel.GetDeclaredSymbol(sds) is not INamedTypeSymbol structType) return;
                    var structObj = new Struct
                    {
                        Name = structType.Name,
                        Namespace = structType.ContainingNamespace.ToDisplayString(),
                        MemberFunctions = new List<Function>(),
                        VirtualFunctions = new List<Function>()
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
                            HasReturn = ms.ReturnType.ToDisplayString() != "void",
                            HasParams = ms.Parameters.Any(),
                            ParamList = string.Join(",",
                                ms.Parameters.Select(p => $"{p.Type.ToDisplayString(format)} {p.Name}")),
                            ParamTypeList = string.Join(",", ms.Parameters.Select(p => p.Type.ToDisplayString(format))),
                            ParamNameList = string.Join(",", ms.Parameters.Select(p => p.Name))
                        };
                        if (ms.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "MemberFunctionAttribute") is { } memberFuncAttr)
                        {
                            functionObj.Signature = (string)memberFuncAttr.ConstructorArguments[0].Value;
                            functionObj.IsStatic = memberFuncAttr.NamedArguments.Any() ? (bool) memberFuncAttr.NamedArguments[0].Value.Value : false;
                            structObj.MemberFunctions.Add(functionObj);
                        }
                        if (ms.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "VirtualFunctionAttribute") is { } virtualFuncAttr)
                        {
                            functionObj.VirtualOffset = (int)virtualFuncAttr.ConstructorArguments[0].Value;
                            structObj.VirtualFunctions.Add(functionObj);
                        }
                    }

                    Structs.Add(structObj);
                }
            }
        }
    }
}
