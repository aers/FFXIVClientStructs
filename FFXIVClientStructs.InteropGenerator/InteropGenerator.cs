using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.InteropGenerator;

[Generator]
public sealed partial class InteropGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(s =>
        {
            s.AddSource($"{Attributes.MemberFunctionAttribute.Name}.g.cs",
                Attributes.MemberFunctionAttribute.Source);
            s.AddSource($"{Attributes.VirtualFunctionAttribute.Name}.g.cs",
                Attributes.VirtualFunctionAttribute.Source);
        });
        
        IncrementalValuesProvider<StructDeclarationSyntax> structDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                static (s, _) => Parser.IsSyntaxTargetForGeneration(s),
                static (ctx, _) => Parser.GetSemanticTargetForGeneration(ctx))
            .Where(static s => s is not null)!;

        IncrementalValueProvider<(Compilation, ImmutableArray<StructDeclarationSyntax>)> compilationAndStructs =
            context.CompilationProvider.Combine(structDeclarations.Collect());
        
        context.RegisterSourceOutput(compilationAndStructs, 
            static (spc, source) 
                => Execute(source.Item1, source.Item2, spc));
    }

    private static void Execute(Compilation compilation, ImmutableArray<StructDeclarationSyntax> structs,
        SourceProductionContext context)
    {
        if (structs.IsDefaultOrEmpty)
            return;

        IEnumerable<StructDeclarationSyntax> distinctStructs = structs.Distinct();

        var p = new Parser(compilation, context.ReportDiagnostic, context.CancellationToken);

        IReadOnlyList<TargetStruct> targets = p.GetTargetStructs(distinctStructs);

        var renderer = new Renderer();
        
        foreach (TargetStruct t in targets)
        {
            var source = renderer.Render(t, context.CancellationToken);
            context.AddSource($"{t.Namespace}{t.Name}.FunctionGenerator.g.cs", source);
        }
    }
}