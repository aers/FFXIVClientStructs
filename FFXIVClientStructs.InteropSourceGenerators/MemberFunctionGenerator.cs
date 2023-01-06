using FFXIVClientStructs.InteropGenerator;
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

        context.RegisterSourceOutput(structWithMemberInfos, (sourceContext, item) =>
        {
            item.Match(
                Fail: diagnosticInfos =>
                {
                    diagnosticInfos.Iter(dInfo => sourceContext.ReportDiagnostic(dInfo.ToDiagnostic()));
                },
                Succ: structWithMemberInfo =>
                {
                    sourceContext.AddSource(structWithMemberInfo.GetFileName(), structWithMemberInfo.RenderSource());
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

        public void RenderFunctionPointer(IndentedStringBuilder builder, StructInfo structInfo)
        {
            builder.AppendLine(
                $"public static delegate* unmanaged[Stdcall] <{structInfo.GetThisPtrTypeString()}{MethodInfo.GetParameterTypeString()}{MethodInfo.ReturnType}> {MethodInfo.Name} {{ internal set; get; }}");
        }

        public void RenderMemberFunction(IndentedStringBuilder builder, string structName)
        {
            MethodInfo.RenderStart(builder);

            builder.AppendLine($"if (MemberFunctionPointers.{MethodInfo.Name} is null)");
            builder.Indent();
            builder.AppendLine(
                $"throw new InvalidOperationException(\"Function pointer for {structName}.{MethodInfo.Name} is null. The resolver was either uninitialized or failed to resolve address with signature {SignatureInfo.Signature}.\");");
            builder.DecrementIndent();
            builder.AppendLine();
            if (MethodInfo.IsStatic)
            {
                builder.AppendLine(
                    $"{MethodInfo.GetReturnString()}MemberFunctionPointers.{MethodInfo.Name}({MethodInfo.GetParameterNamesString()});");
            }
            else
            {
                builder.AppendLine($"fixed({structName}* thisPtr = &this)");
                builder.AppendLine("{");
                builder.Indent();
                string paramNames = MethodInfo.GetParameterNamesString();
                if (MethodInfo.Parameters.Any())
                    paramNames = ", " + paramNames;
                builder.AppendLine(
                    $"{MethodInfo.GetReturnString()}MemberFunctionPointers.{MethodInfo.Name}(thisPtr{paramNames});");
                builder.DecrementIndent();
                builder.AppendLine("}");
            }

            MethodInfo.RenderEnd(builder);
        }
    }

    private sealed record StructWithMemberFunctionInfos(StructInfo StructInfo,
        Seq<MemberFunctionInfo> MemberFunctionInfos)
    {
        public string RenderSource()
        {
            IndentedStringBuilder builder = new();

            StructInfo.RenderStart(builder);

            builder.AppendLine("public unsafe static class MemberFunctionPointers");
            builder.AppendLine("{");
            builder.Indent();
            MemberFunctionInfos.Iter(mfi => mfi.RenderFunctionPointer(builder, StructInfo));
            builder.DecrementIndent();
            builder.AppendLine("}");

            foreach (MemberFunctionInfo mfi in MemberFunctionInfos)
            {
                builder.AppendLine();
                mfi.RenderMemberFunction(builder, StructInfo.Name);
            }

            StructInfo.RenderEnd(builder);

            return builder.ToString();
        }

        public string GetFileName()
        {
            return $"{StructInfo.Namespace}.{StructInfo.Name}.MemberFunctions.g.cs";
        }
    }
}