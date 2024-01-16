using FFXIVClientStructs.InteropGenerator;
using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using FFXIVClientStructs.InteropSourceGenerators.Models;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static FFXIVClientStructs.InteropSourceGenerators.DiagnosticDescriptors;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
internal sealed class FixedStringGenerator : IIncrementalGenerator {
    private const string AttributeName = "FFXIVClientStructs.Interop.Attributes.FixedStringAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo, Validation<DiagnosticInfo, FixedStringInfo> FixedStringInfo)> structAndFixedStringInfos =
            context.SyntaxProvider
                .ForAttributeWithMetadataName(
                    AttributeName,
                    static (node, _) => node is VariableDeclaratorSyntax {
                        Parent: VariableDeclarationSyntax {
                            Parent: FieldDeclarationSyntax {
                                Parent: StructDeclarationSyntax, AttributeLists.Count: > 0
                            }
                        }
                    },
                    static (context, _) => {
                        StructDeclarationSyntax structSyntax = (StructDeclarationSyntax)context.TargetNode.Parent!.Parent!.Parent!;

                        IFieldSymbol fieldSymbol = (IFieldSymbol)context.TargetSymbol;

                        return (Struct: StructInfo.GetFromSyntax(structSyntax),
                            Info: FixedStringInfo.GetFromRoslyn(fieldSymbol));
                    });

        // group by struct
        IncrementalValuesProvider<(Validation<DiagnosticInfo, StructInfo> StructInfo, Validation<DiagnosticInfo, Seq<FixedStringInfo>> FixedStringInfos)> groupedStructInfoWithFixedStringInfos =
            structAndFixedStringInfos.TupleGroupByValidation();

        // make sure caching is working
        IncrementalValuesProvider<Validation<DiagnosticInfo, StructWithFixedStringInfos>> structWithFixedInfos =
            groupedStructInfoWithFixedStringInfos.Select(static (item, _) =>
                (item.StructInfo, item.FixedStringInfos).Apply(static (si, fsi) =>
                    new StructWithFixedStringInfos(si, fsi))
            );

        context.RegisterSourceOutput(structWithFixedInfos, (sourceContext, item) => {
            item.Match(
                Fail: diagnosticInfos => {
                    diagnosticInfos.Iter(dInfo => sourceContext.ReportDiagnostic(dInfo.ToDiagnostic()));
                },
                Succ: structWithFixedInfo => {
                    sourceContext.AddSource(structWithFixedInfo.GetFileName(), structWithFixedInfo.RenderSource());
                });
        });
    }

    internal sealed record FixedStringInfo(string FieldName, int MaxLength, string PropertyName) {
        public static Validation<DiagnosticInfo, FixedStringInfo> GetFromRoslyn(IFieldSymbol fieldSymbol) {
            Validation<DiagnosticInfo, IFieldSymbol> validSymbol =
                (fieldSymbol.IsFixedSizeBuffer
                    ? Success<DiagnosticInfo, IFieldSymbol>(fieldSymbol)
                    : Fail<DiagnosticInfo, IFieldSymbol>(
                        DiagnosticInfo.Create(FixedSizedAttributeOnInvalidField,
                            fieldSymbol)))
                .Bind(symbol => {
                    IPointerTypeSymbol pointerType = (symbol.Type as IPointerTypeSymbol)!; // we know its a pointer
                    ITypeSymbol pointedToType = pointerType.PointedAtType;
                    if (pointedToType.SpecialType != SpecialType.System_Byte)
                        return Fail<DiagnosticInfo, IFieldSymbol>(
                            DiagnosticInfo.Create(FixedSizedAttributeOnInvalidField,
                                fieldSymbol));

                    return Success<DiagnosticInfo, IFieldSymbol>(fieldSymbol);
                });
            Option<AttributeData> attribute = fieldSymbol.GetFirstAttributeDataByTypeName(AttributeName);

            Validation<DiagnosticInfo, string> validPropertyName = attribute.GetValidAttributeArgument<string>("PropertyName", 0, AttributeName, fieldSymbol);

            return (validSymbol, validPropertyName).Apply((symbol, propertyName) =>
                new FixedStringInfo(symbol.Name, symbol.FixedSize, string.IsNullOrEmpty(propertyName) ? $"{symbol.Name}String" : propertyName));
        }

        public void RenderFixedString(IndentedStringBuilder builder) {
            builder.AppendLine($"public string {PropertyName} {{");
            using (builder.Indent()) {
                builder.AppendLine($"get {{ fixed (byte* ptr = {FieldName}) {{ var str = Encoding.UTF8.GetString(ptr, 0x{MaxLength:X}); var nullIdx = str.IndexOf('\\0'); return nullIdx >= 0 ? str[..nullIdx] : str; }} }}");
                builder.AppendLine($"set {{ fixed (byte* ptr = {FieldName}) {{ var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty); var lastBytePos = Math.Min(bytes.Length, 0x{MaxLength:X} - 1); Marshal.Copy(bytes, 0, (nint)ptr, lastBytePos); ptr[lastBytePos] = 0; }} }}");
            }
            builder.AppendLine("}");
        }
    }

    private sealed record StructWithFixedStringInfos(StructInfo StructInfo, Seq<FixedStringInfo> FixedStringInfos) {
        public string RenderSource() {
            IndentedStringBuilder builder = new();

            builder.AppendLine("using System.Text;");

            StructInfo.RenderStart(builder);

            foreach (FixedStringInfo fsi in FixedStringInfos)
                fsi.RenderFixedString(builder);

            StructInfo.RenderEnd(builder);

            return builder.ToString();
        }

        public string GetFileName() {
            return $"{StructInfo.Namespace}.{StructInfo.Name}.FixedStrings.g.cs";
        }
    }
}
