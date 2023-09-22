using System.Text;
using System.Xml.Linq;
using FFXIVClientStructs.InteropGenerator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
public class ConditionsGenerator : ISourceGenerator {
    public void Initialize(GeneratorInitializationContext context) {
        // No initialization required for this example
    }

    public void Execute(GeneratorExecutionContext context) {
        var enumSymbol = context.Compilation.GetTypeByMetadataName("FFXIVClientStructs.FFXIV.Client.Game.ConditionFlag");
        if (enumSymbol == null) {
            return;
        }

        var sourceBuilder = new IndentedStringBuilder();

        sourceBuilder.AppendLine("namespace FFXIVClientStructs.FFXIV.Client.Game {");

        using (sourceBuilder.Indent()) {
            sourceBuilder.AppendLine("public unsafe partial struct Conditions {");

            using (sourceBuilder.Indent()) {
                foreach (var member in enumSymbol.GetMembers()) {
                    if (member is not IFieldSymbol fieldSymbol) {
                        continue;
                    }

                    if (fieldSymbol.Name == "None" || !fieldSymbol.HasConstantValue) {
                        continue;
                    }

                    var extractedDocumentation = ExtractDocumentationFromXml(fieldSymbol.GetDocumentationCommentXml());
                    if (!string.IsNullOrEmpty(extractedDocumentation)) {
                        sourceBuilder.AppendLines(extractedDocumentation);
                    }

                    sourceBuilder.AppendLine($"public static bool Is{fieldSymbol.Name} => Instance()->Flags[{fieldSymbol.ConstantValue}];");
                    sourceBuilder.AppendLine();
                }
            }

            sourceBuilder.AppendLine("}");
        }

        sourceBuilder.AppendLine("}");

        context.AddSource("Conditions.Getters.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }

    private string ExtractDocumentationFromXml(string? xmlDocumentation) {
        if (string.IsNullOrEmpty(xmlDocumentation)) {
            return string.Empty;
        }

        var xmlDoc = XDocument.Parse(xmlDocumentation);
        var memberElement = xmlDoc.Descendants("member").FirstOrDefault();
        if (memberElement == null) {
            return string.Empty;
        }

        return string.Join("\n", memberElement.Nodes().Select(node => string.Join("\n", node.ToString().Split('\n').Map(line => "/// " + line.TrimStart()))));
    }
}
