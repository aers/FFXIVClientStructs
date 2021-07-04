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

            var buffer = new StringBuilder();

            foreach (var structObj in receiver.Structs)
            {
                var filename = structObj.Namespace + structObj.Name + ".generated.cs";
                var source = _codeTemplate.Render(new {Struct = structObj});
                context.AddSource(filename, SourceText.From(source, Encoding.UTF8));
            }

        }

        class MemberFunctionSyntaxContextReceiver : ISyntaxContextReceiver
        {
            public List<Struct> Structs { get; } = new();

            public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
            {
                if (context.Node is StructDeclarationSyntax sds)
                {
                    var methods = sds.ChildNodes().OfType<MethodDeclarationSyntax>().Where(m =>
                    {
                        var sm = (IMethodSymbol) context.SemanticModel.GetDeclaredSymbol(m);
                        return sm != null && sm.GetAttributes()
                            .Any(a => a.AttributeClass?.Name == "MemberFunctionAttribute");
                    }).ToList();

                    if (methods.Any())
                    {
                        var structType = (INamedTypeSymbol) context.SemanticModel.GetDeclaredSymbol(sds);
                        if (structType != null)
                        {
                            var structObj = new Struct
                            {
                                Name = structType.Name,
                                Namespace = structType.ContainingNamespace.ToDisplayString(),
                                MemberFunctions = new()
                            };

                            foreach (MethodDeclarationSyntax m in methods)
                            {
                                var ms = (IMethodSymbol) context.SemanticModel.GetDeclaredSymbol(m);
                                if (ms != null)
                                {
                                    var functionObj = new Function
                                    {
                                        Name = ms.Name,
                                        ReturnType = ms.ReturnType.ToDisplayString(),
                                        HasReturn = ms.ReturnType.ToDisplayString() != "void", 
                                        ParamList = string.Join(",",
                                            ms.Parameters.Select(p => $"{p.Type.ToDisplayString()} {p.Name}")),
                                        ParamTypeList = string.Join(",", ms.Parameters.Select(p => p.Type.ToDisplayString())),
                                        ParamNameList = string.Join(",", ms.Parameters.Select(p => p.Name))
                                    };
                                    structObj.MemberFunctions.Add(functionObj);
                                }
                            }

                            Structs.Add(structObj);
                        }
                    }
                }
            }
        }
    }
}
