using YamlDotNet.Serialization;

namespace ExcelGenerator.Schema.ExdSchema;

public class YamlField {
    [YamlMember(Alias = "name")] public string? Name { get; set; }
    [YamlMember(Alias = "count")] public int Count { get; set; } = 0;
    [YamlMember(Alias = "type")] public YamlFieldType Type { get; set; } = YamlFieldType.Scalar;
    [YamlMember(Alias = "fields")] public List<YamlField> Fields { get; set; } = [];
    [YamlMember(Alias = "targets")] public List<string> Targets { get; set; } = [];
    [YamlMember(Alias = "comment")] public string Comment { get; set; } = string.Empty;

    public override string ToString() {
        var arraySuffix = Count > 0 ? $"[{Count}]" : string.Empty;
        return $"{Name}{arraySuffix} ({Type})";
    }
}

public enum YamlFieldType {
    Scalar,
    Array,
    Icon,
    ModelId,
    Color,
    Link,
}
