using ExcelGenerator.Schema.ExdSchema;
using Lumina.Data.Structs.Excel;
using YamlDotNet.Serialization;

namespace ExcelGenerator.Schema;

public class Deserializer {
    private readonly IDeserializer _yamlDeserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().WithCaseInsensitivePropertyMatching().Build();

    public Dictionary<string, List<ExcelColumnDefinition>> DeserializeColumns(string filePath) {
        if (filePath.EndsWith(".yml", StringComparison.OrdinalIgnoreCase))
            return DeserializeColumnYml(File.ReadAllText(filePath));
        throw new ArgumentException($"Unsupported file: {filePath}", nameof(filePath));
    }

    private Dictionary<string, List<ExcelColumnDefinition>> DeserializeColumnYml(string yamlString) {
        var data = _yamlDeserializer.Deserialize<Dictionary<string, List<ExcelColumnDefinition>>>(yamlString);
        var subKeys = data.Keys.Where(k => k.Contains('@')).ToList();
        foreach (var subKey in subKeys) {
            var key = subKey.Split('@').First().Trim();
            data.Add(key, data[subKey]);
            data.Remove(subKey);
        }
        return data;
    }

    public Sheet DeserializeSheet(string filePath) {
        if (filePath.EndsWith(".yml", StringComparison.OrdinalIgnoreCase))
            return DeserializeSheetYml(File.ReadAllText(filePath));
        throw new ArgumentException($"Unsupported file: {filePath}", nameof(filePath));
    }

    private Sheet DeserializeSheetYml(string yamlString) {
        var input = _yamlDeserializer.Deserialize<YamlSheet>(yamlString);
        var sheet = new Sheet(input.Name);
        foreach (var field in input.Fields) {
            sheet.Fields.Add(ParseField(field));
        }
        return sheet;
    }

    private static Field ParseField(YamlField field) {
        if (field is { Type: not YamlFieldType.Array, Count: 0 }) {
            var scalar = new ScalarField(field.Name);
            scalar.Remarks.AddRange(field.Targets);
            scalar.Comment = field.Comment;
            return scalar;
        }

        if (field is { Type: YamlFieldType.Array, Fields.Count: 0 } or { Type: YamlFieldType.Array, Fields: [{ Type: not YamlFieldType.Array }] }) {
            var array = new ArrayField(field.Name, field.Count);
            if (field.Targets.Count > 0)
                array.Remarks.AddRange(field.Targets);
            if (field.Fields.FirstOrDefault() is { Targets.Count: > 0 } yf)
                array.Remarks.AddRange(yf.Targets);
            array.Comment = field.Comment;
            return array;
        }

        if (field is { Type: YamlFieldType.Array, Fields.Count: >= 1 }) {
            var str = new StructField(field.Name, field.Count, []);
            str.Fields.AddRange(field.Fields.Select(ParseField));
            str.Comment = field.Comment;
            return str;
        }

        throw new ArgumentException($"Unsupported Field: {field}", nameof(field));
    }
}
