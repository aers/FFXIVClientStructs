using FFXIVClientStructs.InteropGenerator;
using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using FFXIVClientStructs.InteropSourceGenerators.Models;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
internal sealed class NumberArrayGenerator : IIncrementalGenerator {
    private const string AttributeName = "FFXIVClientStructs.Interop.Attributes.NumberArrayAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        var structAndNumberArrayInfo = context.SyntaxProvider.ForAttributeWithMetadataName(AttributeName, static (node, _) => node is StructDeclarationSyntax { AttributeLists.Count: > 0 }, static (context, _) => {
            var structSyntax = (StructDeclarationSyntax)context.TargetNode;

            return (StructInfo: StructInfo.GetFromSyntax(structSyntax), NumberArrayInfo: NumberArrayInfo.GetFromRoslyn(structSyntax, context.TargetSymbol));
        });

        // make sure caching is working
        var structWithNumberArrayInfos = structAndNumberArrayInfo.Select(static (item, _) => (item.StructInfo, item.NumberArrayInfo).Apply(static (si, nai) => new StructWithNumberArrayInfos(si, nai)));

        context.RegisterSourceOutput(structWithNumberArrayInfos, (sourceContext, item) => { item.Match(Fail: diagnosticInfos => { diagnosticInfos.Iter(dInfo => sourceContext.ReportDiagnostic(dInfo.ToDiagnostic())); }, Succ: structWithNumberArrayInfo => { sourceContext.AddSource(structWithNumberArrayInfo.GetFileName(), structWithNumberArrayInfo.RenderSource()); }); });
    }

    internal sealed record NumberArrayInfo(StructInfo StructInfo, uint Index) {
        public static Validation<DiagnosticInfo, NumberArrayInfo> GetFromRoslyn(StructDeclarationSyntax structSyntax, ISymbol structSymbol) {
            var validStructInfo = StructInfo.GetFromSyntax(structSyntax);
            var numberArrayAttribute = structSymbol.GetFirstAttributeDataByTypeName(AttributeName);
            var validIndex = numberArrayAttribute.GetValidAttributeArgument<uint>("Index", 0, AttributeName, structSymbol);
            return (validStructInfo, validIndex).Apply((structInfo, index) => new NumberArrayInfo(structInfo, index));
        }

        public void RenderBaseProperty(IndentedStringBuilder builder) {
            builder.AppendLine("private static FFXIVClientStructs.FFXIV.Component.GUI.NumberArrayData* Base {");
            using (builder.Indent()) {
                builder.AppendLine(" get {");
                using (builder.Indent()) {
                    builder.AppendLine("var uiModule = FFXIVClientStructs.FFXIV.Client.System.Framework.Framework.Instance()->GetUiModule();");
                    builder.AppendLine("if (uiModule == null) return null;");
                    builder.AppendLine("var raptureAtkModule = uiModule->GetRaptureAtkModule();");
                    builder.AppendLine("if (raptureAtkModule == null) return null;");
                    builder.AppendLine("var arrayDataHolder = &raptureAtkModule->AtkModule.AtkArrayDataHolder;");
                    builder.AppendLine($"var numberArray = arrayDataHolder->NumberArrays[{Index}];");
                    builder.AppendLine("return numberArray;");
                }

                builder.AppendLine("}");
            }

            builder.AppendLine("}");
            builder.AppendLine();
        }

        public void RenderWrappers(IndentedStringBuilder builder) {
            builder.AppendLine($"public static int Size() {{");
            using (builder.Indent()) {
                builder.AppendLine("var baseArray = Base;");
                builder.AppendLine("if (baseArray == null) return -1;");
                builder.AppendLine("return baseArray->AtkArrayData.Size;");
            }
            builder.AppendLine("}");
        }
        
        public void RenderInstanceProperty(IndentedStringBuilder builder) {
            builder.AppendLine($"public static {StructInfo.Name}* Instance() {{");
            using (builder.Indent()) {
                builder.AppendLine("var baseArray = Base;");
                builder.AppendLine("if (baseArray == null) return null;");
                builder.AppendLine($"return ({StructInfo.Name}*) baseArray->IntArray;");
            }

            builder.AppendLine("}");
            builder.AppendLine();
        }
    }

    private sealed record StructWithNumberArrayInfos(StructInfo StructInfo, NumberArrayInfo NumberArrayInfo) {
        public string RenderSource() {
            IndentedStringBuilder builder = new();

            StructInfo.RenderStart(builder);

            NumberArrayInfo.RenderBaseProperty(builder);
            NumberArrayInfo.RenderInstanceProperty(builder);
            NumberArrayInfo.RenderWrappers(builder);

            StructInfo.RenderEnd(builder);

            return builder.ToString();
        }

        public string GetFileName() {
            return $"{StructInfo.Namespace}.{StructInfo.Name}.g.cs";
        }
    }
}
