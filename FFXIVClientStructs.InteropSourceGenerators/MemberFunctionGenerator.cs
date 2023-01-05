using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using FFXIVClientStructs.InteropSourceGenerators.Models;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static FFXIVClientStructs.InteropSourceGenerators.DiagnosticDescriptors;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
internal sealed class MemberFunctionGenerator : IIncrementalGenerator
{
    private const string AttributeName = "FFXIVClientStructs.Interop.Attributes.MemberFunctionAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo,
            Validation<DiagnosticInfo, MemberFunctionInfo> MemberFunctionInfo)> structAndMemberFunctionInfos =
            context.SyntaxProvider
                .ForAttributeWithMetadataName(
                    AttributeName,
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
                Succ: structWithMemberInfo =>
                {
                    Seq<string> a = structWithMemberInfo.MemberFunctionInfos.Map(mfi =>
                        $"// {mfi.MethodInfo.Name} - {mfi.SignatureInfo.Signature}");
                    sourceContext.AddSource($"{structWithMemberInfo.StructInfo.Name}.MemberFunctions.g.cs",
                        string.Join("\n", a));
                });
        });
    }

    internal sealed record MemberFunctionInfo(MethodInfo MethodInfo, SignatureInfo SignatureInfo)
    {
        public static Validation<DiagnosticInfo, MemberFunctionInfo> GetFromRoslyn(
            MethodDeclarationSyntax methodSyntax, IMethodSymbol methodSymbol)
        {
            Validation<DiagnosticInfo, MethodInfo> validMethodInfo =
                MethodInfo.GetFromRoslyn(methodSyntax, methodSymbol);

            Validation<DiagnosticInfo, SignatureInfo> validSignature =
                methodSymbol.GetFirstAttributeDataByTypeName(AttributeName)
                    .Bind(attributeData => attributeData.GetAttributeArgument<string>("Signature", 0))
                    .ToValidation(DiagnosticInfo.Create(AttributeArgumentInvalid, methodSymbol, AttributeName,
                        "Signature"))
                    .Bind(signatureString => SignatureInfo.GetValidatedSignature(signatureString, methodSymbol));

            return (validMethodInfo, validSignature).Apply((methodInfo, signature) =>
                new MemberFunctionInfo(methodInfo, signature));
        }
    }

    private sealed record StructWithMemberFunctionInfos(StructInfo StructInfo,
        Seq<MemberFunctionInfo> MemberFunctionInfos);
}