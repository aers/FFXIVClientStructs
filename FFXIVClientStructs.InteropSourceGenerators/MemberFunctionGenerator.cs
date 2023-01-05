using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using FFXIVClientStructs.InteropSourceGenerators.Models;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
internal sealed class MemberFunctionGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo,
            Validation<DiagnosticInfo, MemberFunctionInfo> MemberFunctionInfo)> structAndMemberFunctionInfos =
            context.SyntaxProvider
                .ForAttributeWithMetadataName(
                    "FFXIVClientStructs.Interop.Attributes.MemberFunctionAttribute",
                    static (node, _) => node is MethodDeclarationSyntax
                    {
                        Parent : StructDeclarationSyntax, AttributeLists.Count: > 0
                    },
                    static (context, _) =>
                    {
                        StructDeclarationSyntax structSyntax = (StructDeclarationSyntax)context.TargetNode.Parent!;

                        MethodDeclarationSyntax methodSyntax = (MethodDeclarationSyntax)context.TargetNode;
                        IMethodSymbol methodSymbol = (IMethodSymbol)context.TargetSymbol;

                        return (Struct: StructInfo.GetFromSyntax(structSyntax),
                            Info: MemberFunctionInfo.GetFromRoslyn(methodSyntax, methodSymbol));
                    });

        // group by struct
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo,
            Validation<DiagnosticInfo, Seq<MemberFunctionInfo>> MemberFunctionInfos)> groupedStructInfoWithMemberInfos =
            structAndMemberFunctionInfos.TupleGroupByValidation();

        // make sure caching is working
        IncrementalValuesProvider<Validation<DiagnosticInfo, StructWithMemberFunctionInfos>> structWithMemberInfos =
            groupedStructInfoWithMemberInfos.Select(static (item, _) =>
                (item.StructInfo, item.MemberFunctionInfos).Apply(static (si, mfi) =>
                    new StructWithMemberFunctionInfos(si, mfi))
            );
        
        context.RegisterSourceOutput(structWithMemberInfos, (sourceContext, items) =>
        {
            items.Match(
                Fail: diagnosticInfos =>
                {
                    diagnosticInfos.Iter(dInfo => sourceContext.ReportDiagnostic(dInfo.ToDiagnostic()));
                },
                Succ: _ =>
                { 
                    
                });
        });
    }

    internal sealed record MemberFunctionInfo(MethodInfo MethodInfo, string Signature)
    {
        public static Validation<DiagnosticInfo, MemberFunctionInfo> GetFromRoslyn(
            MethodDeclarationSyntax methodSyntax, IMethodSymbol methodSymbol)
        {
            Validation<DiagnosticInfo, MethodInfo> validMethodInfo =
                MethodInfo.GetFromRoslyn(methodSyntax, methodSymbol);

            return validMethodInfo.Bind<MemberFunctionInfo>(methodInfo =>
                new MemberFunctionInfo(methodInfo, string.Empty));
        }
    }

    internal sealed record StructWithMemberFunctionInfos(StructInfo StructInfo,
        Seq<MemberFunctionInfo> MemberFunctionInfos);
}