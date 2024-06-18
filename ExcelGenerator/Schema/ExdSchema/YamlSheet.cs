using System.Text;
using YamlDotNet.Serialization;

namespace ExcelGenerator.Schema.ExdSchema;

public class YamlSheet {
    [YamlMember(Alias = "name")] public string Name { get; set; } = string.Empty;
    [YamlMember(Alias = "fields")] public List<YamlField> Fields { get; set; } = [];

    public override string ToString() {
        var sb = new StringBuilder($"Sheet: {Name}");
        if (Fields.Count > 0) {
            sb.AppendLine();
            sb.AppendLine("Fields: {");
            foreach (var field in Fields)
                sb.AppendLine($" {field}");
            sb.Append("}");
        }
        return sb.ToString();
    }
}
