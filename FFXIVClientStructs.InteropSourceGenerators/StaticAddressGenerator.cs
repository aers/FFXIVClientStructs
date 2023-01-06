using FFXIVClientStructs.InteropGenerator;
using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using FFXIVClientStructs.InteropSourceGenerators.Models;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static FFXIVClientStructs.InteropSourceGenerators.DiagnosticDescriptors;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
internal sealed class StaticAddressGenerator : IIncrementalGenerator
{
    private const string AttributeName = "FFXIVClientStructs.Interop.Attributes.StaticAddressAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo,
            Validation<DiagnosticInfo, StaticAddressInfo> StaticAddressInfo)> structAndStaticAddressInfos =
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
                            Info: StaticAddressInfo.GetFromRoslyn(methodSyntax, methodSymbol));
                    });
        
        // group by struct
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo,
            Validation<DiagnosticInfo, Seq<StaticAddressInfo>> StaticAddressInfos)> groupedStructInfoWithStaticAddressInfos =
            structAndStaticAddressInfos.TupleGroupByValidation();

        // make sure caching is working
        IncrementalValuesProvider<Validation<DiagnosticInfo, StructWithStaticAddressInfos>> structWithStaticAddressInfos =
            groupedStructInfoWithStaticAddressInfos.Select(static (item, _) =>
                (item.StructInfo, item.StaticAddressInfos).Apply(static (si, sai) =>
                    new StructWithStaticAddressInfos(si, sai))
            );

        context.RegisterSourceOutput(structWithStaticAddressInfos, (sourceContext, item) =>
        {
            item.Match(
                Fail: diagnosticInfos =>
                {
                    diagnosticInfos.Iter(dInfo => sourceContext.ReportDiagnostic(dInfo.ToDiagnostic()));
                },
                Succ: structWithStaticAddressInfo =>
                {
                    sourceContext.AddSource(structWithStaticAddressInfo.GetFileName(), structWithStaticAddressInfo.RenderSource());
                });
        });
    }

    internal sealed record StaticAddressInfo(MethodInfo MethodInfo, SignatureInfo SignatureInfo, int Offset,
        bool IsPointer)
    {
        public static Validation<DiagnosticInfo, StaticAddressInfo> GetFromRoslyn(
            MethodDeclarationSyntax methodSyntax, IMethodSymbol methodSymbol)
        {
            Validation<DiagnosticInfo, MethodInfo> validMethodInfo =
                MethodInfo.GetFromRoslyn(methodSyntax, methodSymbol);

            Option<AttributeData> staticAddressAttribute = methodSymbol.GetFirstAttributeDataByTypeName(AttributeName);
            
            Validation<DiagnosticInfo, SignatureInfo> validSignature =
                staticAddressAttribute
                    .GetValidAttributeArgument<string>("Signature", 0, AttributeName, methodSymbol)
                    .Bind(signatureString => SignatureInfo.GetValidatedSignature(signatureString, methodSymbol));
            Validation<DiagnosticInfo, int> validOffset =
                staticAddressAttribute.GetValidAttributeArgument<int>("Offset", 1, AttributeName, methodSymbol);
            Validation<DiagnosticInfo, bool> validIsPointer =
                staticAddressAttribute.GetValidAttributeArgument<bool>("IsPointer", 2, AttributeName, methodSymbol);

            return (validMethodInfo, validSignature, validOffset, validIsPointer).Apply((methodInfo, signature, offset, isPointer) =>
                new StaticAddressInfo(methodInfo, signature, offset, isPointer));
        }

        public void RenderPointer(IndentedStringBuilder builder)
        {
            string pointerText = IsPointer ? "* p" : " ";
            builder.AppendLine($"public static {MethodInfo.ReturnType}{pointerText}p{MethodInfo.Name} {{ internal set; get; }}");
        }

        public void RenderStaticAddressFunction(IndentedStringBuilder builder, string structName)
        {
            MethodInfo.RenderStart(builder);

            string extraPText = IsPointer ? "p" : "";
            builder.AppendLine($"if (StaticAddressPointers.{extraPText}p{MethodInfo.Name} is null)");
            builder.Indent();
            builder.AppendLine(
                $"throw new InvalidOperationException(\"Pointer for {structName}.{MethodInfo.Name} is null. The resolver was either uninitialized or failed to resolve address with signature {SignatureInfo.Signature}.\");");
            builder.DecrementIndent();

            string pointerReturnText = IsPointer ? "*" : "";
            builder.AppendLine($"return {pointerReturnText}StaticAddressPointers.{extraPText}p{MethodInfo.Name};");
            
            MethodInfo.RenderEnd(builder);
        }
    }

    private sealed record StructWithStaticAddressInfos
        (StructInfo StructInfo, Seq<StaticAddressInfo> StaticAddressInfos)
    {
        public string RenderSource()
        {
            IndentedStringBuilder builder = new();

            StructInfo.RenderStart(builder);
            
            builder.AppendLine("public unsafe static class StaticAddressPointers");
            builder.AppendLine("{");
            builder.Indent();
            StaticAddressInfos.Iter(sai => sai.RenderPointer(builder));
            builder.DecrementIndent();
            builder.AppendLine("}");
            
            foreach (StaticAddressInfo sai in StaticAddressInfos)
            {
                builder.AppendLine();
                sai.RenderStaticAddressFunction(builder, StructInfo.Name);
            }

            StructInfo.RenderEnd(builder);

            return builder.ToString();
        }

        public string GetFileName()
        {
            return $"{StructInfo.Namespace}.{StructInfo.Name}.StaticAddresses.g.cs";
        }
    }
}