using FFXIVClientStructs.InteropGenerator;
using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using FFXIVClientStructs.InteropSourceGenerators.Models;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
internal sealed class CStrOverloadsGenerator : IIncrementalGenerator
{
    private const string AttributeName = "FFXIVClientStructs.Interop.Attributes.GenerateCStrOverloadsAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo,
            Validation<DiagnosticInfo, CStrOverloadInfo> CStrOverloadInfos)> structAndMethodInfos =
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
                            Info: CStrOverloadInfo.GetFromRoslyn(methodSyntax, methodSymbol));
                    });

        // group by struct
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo,
            Validation<DiagnosticInfo, Seq<CStrOverloadInfo>> CStrOverloadInfos)> groupedStructInfoWithMethodInfos =
            structAndMethodInfos.TupleGroupByValidation();

        // make sure caching is working
        IncrementalValuesProvider<Validation<DiagnosticInfo, StructWithCStrOverloadInfos>> structWithMethodInfos =
            groupedStructInfoWithMethodInfos.Select(static (item, _) =>
                (item.StructInfo, item.CStrOverloadInfos).Apply(static (si, csoi) =>
                    new StructWithCStrOverloadInfos(si, csoi))
            );

        context.RegisterSourceOutput(structWithMethodInfos, (sourceContext, item) =>
        {
            item.Match(
                Fail: diagnosticInfos =>
                {
                    diagnosticInfos.Iter(dInfo => sourceContext.ReportDiagnostic(dInfo.ToDiagnostic()));
                },
                Succ: structWithMethodInfo =>
                {
                    sourceContext.AddSource(structWithMethodInfo.GetFileName(), structWithMethodInfo.RenderSource());
                });
        });
    }

    internal sealed record CStrOverloadInfo(MethodInfo MethodInfo, Option<string> IgnoreArgument)
    {
        public static Validation<DiagnosticInfo, CStrOverloadInfo> GetFromRoslyn(
            MethodDeclarationSyntax methodSyntax, IMethodSymbol methodSymbol)
        {
            Validation<DiagnosticInfo, MethodInfo> validMethodInfo =
                MethodInfo.GetFromRoslyn(methodSyntax, methodSymbol);

            Option<string> optionIgnoreArgument =
                methodSymbol.GetFirstAttributeDataByTypeName(AttributeName)
                    .GetValidAttributeArgument<string>("IgnoreArgument", 0, AttributeName, methodSymbol)
                    .ToOption();

            return validMethodInfo.Bind<CStrOverloadInfo>(methodInfo =>
                new CStrOverloadInfo(methodInfo, optionIgnoreArgument));
        }

        public void RenderOverloadMethods(IndentedStringBuilder builder)
        {
            Seq<string> overloadParamNames =
                MethodInfo.Parameters.Where(param => param.Type == "byte*" && param.Name != IgnoreArgument)
                    .Map(param => param.Name).ToSeq();

            string paramNames = MethodInfo.GetParameterNamesString();
            foreach (string overloadParamName in overloadParamNames)
                paramNames = paramNames.Replace(overloadParamName, $"{overloadParamName}Ptr");

            string returnString = MethodInfo.ReturnType == "void" ? string.Empty : "return ";

            builder.AppendLine();
            MethodInfo.RenderStartOverload(builder, "byte*", "string", IgnoreArgument);
            foreach (string overloadParamName in overloadParamNames)
            {
                var valName = $"utf8StringLength{overloadParamName}";

                builder.AppendLine(
                    $"int {valName} = global::System.Text.Encoding.UTF8.GetByteCount({overloadParamName});");
                builder.AppendLine(
                    $"Span<byte> {overloadParamName}Bytes = {valName} <= 512 ? stackalloc byte[{valName} + 1] : new byte[{valName} + 1];");
                builder.AppendLine(
                    $"global::System.Text.Encoding.UTF8.GetBytes({overloadParamName}, {overloadParamName}Bytes);");
                builder.AppendLine($"{overloadParamName}Bytes[{valName}] = 0;");
                builder.AppendLine();
            }

            foreach (string overloadParamName in overloadParamNames)
            {
                builder.AppendLine($"fixed (byte* {overloadParamName}Ptr = {overloadParamName}Bytes)");
                builder.AppendLine("{");
                builder.Indent();
            }

            builder.AppendLine($"{returnString}{MethodInfo.Name}({paramNames});");

            foreach (string _ in overloadParamNames)
            {
                builder.DecrementIndent();
                builder.AppendLine("}");
            }

            MethodInfo.RenderEnd(builder);

            builder.AppendLine();
            MethodInfo.RenderStartOverload(builder, "byte*", "ReadOnlySpan<byte>", IgnoreArgument);
            foreach (string overloadParamName in overloadParamNames)
            {
                builder.AppendLine($"fixed (byte* {overloadParamName}Ptr = {overloadParamName})");
                builder.AppendLine("{");
                builder.Indent();
            }

            builder.AppendLine($"{returnString}{MethodInfo.Name}({paramNames});");

            foreach (string _ in overloadParamNames)
            {
                builder.DecrementIndent();
                builder.AppendLine("}");
            }

            MethodInfo.RenderEnd(builder);
        }
    }

    private sealed record StructWithCStrOverloadInfos(StructInfo StructInfo, Seq<CStrOverloadInfo> CStrOverloadInfos)
    {
        public string RenderSource()
        {
            IndentedStringBuilder builder = new();

            StructInfo.RenderStart(builder);

            CStrOverloadInfos.Iter(csoi => csoi.RenderOverloadMethods(builder));

            StructInfo.RenderEnd(builder);

            return builder.ToString();
        }

        public string GetFileName()
        {
            return $"{StructInfo.Namespace}.{StructInfo.Name}.CStrOverloads.g.cs";
        }
    }
}