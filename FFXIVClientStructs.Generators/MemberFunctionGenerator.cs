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
    class MemberFunctionGenerator : ISourceGenerator
    {
        private Template _codeTemplate;

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new MemberFunctionSyntaxContextReceiver());

            _codeTemplate = Template.Parse(Templates.MemberFunctions);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxContextReceiver is MemberFunctionSyntaxContextReceiver receiver)) return;

            foreach (var structObj in receiver.Structs)
            {
                var filename = structObj.Namespace + structObj.Name + ".generated.cs";
                var source = _codeTemplate.Render(new {Struct = structObj});
                context.AddSource(filename, SourceText.From(source, Encoding.UTF8));
            }

            var resolverTemplate = Template.Parse(Templates.InitializeMemberFunctions);
            var resolverSource = resolverTemplate.Render(new {Structs = receiver.Structs});
            context.AddSource("Resolver.Generated.cs", resolverSource);
;
        }

        class MemberFunctionSyntaxContextReceiver : ISyntaxContextReceiver
        {
            public List<Struct> Structs { get; } = new();

            public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
            {
                if (context.Node is not StructDeclarationSyntax sds) return;
                var methods = sds.ChildNodes().OfType<MethodDeclarationSyntax>().Where(m =>
                {
                    var sm = (IMethodSymbol) context.SemanticModel.GetDeclaredSymbol(m);
                    return sm != null && sm.GetAttributes()
                        .Any(a => a.AttributeClass?.Name == "MemberFunctionAttribute");
                }).ToList();

                if (methods.Count > 0)
                {
                    if (context.SemanticModel.GetDeclaredSymbol(sds) is not INamedTypeSymbol structType) return;
                    var structObj = new Struct
                    {
                        Name = structType.Name,
                        Namespace = structType.ContainingNamespace.ToDisplayString(),
                        MemberFunctions = new List<Function>()
                    };

                    foreach (var m in methods)
                    {
                        if (context.SemanticModel.GetDeclaredSymbol(m) is not IMethodSymbol ms) continue;
                        var attr = ms.GetAttributes().First(a => a.AttributeClass?.Name == "MemberFunctionAttribute");
                        var sig = (string) attr.ConstructorArguments[0].Value;
                        var format = new SymbolDisplayFormat(
                            typeQualificationStyle: SymbolDisplayTypeQualificationStyle
                                .NameAndContainingTypesAndNamespaces,
                            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes);
                        var functionObj = new Function
                        {
                            Name = ms.Name,
                            ReturnType = ms.ReturnType.ToDisplayString(format),
                            HasReturn = ms.ReturnType.ToDisplayString() != "void", 
                            ParamList = string.Join(",",
                                ms.Parameters.Select(p => $"{p.Type.ToDisplayString(format)} {p.Name}")),
                            ParamTypeList = string.Join(",", ms.Parameters.Select(p => p.Type.ToDisplayString(format))),
                            ParamNameList = string.Join(",", ms.Parameters.Select(p => p.Name)),
                            Signature = sig
                        };
                        structObj.MemberFunctions.Add(functionObj);
                    }

                    Structs.Add(structObj);
                }
            }
        }
    }
}
